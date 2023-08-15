using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static KAPLibNet.IConfig;

namespace KAPLibNet
{
    public interface IConfig
    {
        protected Configuration config { get; }

        public interface IConfValue<T> : IDisposable
        {
            public void Init(IConfig conf, string key);
            public void Set(T value);
            public T Get();
        }
        public class ConfStr : IConfValue<string>
        {
            protected IConfig Conf;
            protected string Key;
            protected string Default;
            public ConfStr() { }
            public ConfStr(IConfig conf, string key, string def)
            {
                Init(conf, key, def);
            }
            public void Init(IConfig conf, string key)
            {
                Init(conf, key, "");
            }
            public virtual void Init(IConfig conf, string key, string def)
            {
                Conf = conf;
                Key = key;
                Default = def;
            }

            public static implicit operator string(ConfStr c)
                => c.Conf.GetConfig(c.Key, c.Default);
            public void Set(string value)
                => Conf.SetConfig(Key, value);
            public string Get()
                => (string)this;
            public string GetDefault()
                => Default;

            public virtual void Dispose() { }

        }
        public class ConfInt : ConfStr, IConfValue<int>
        {
            public int Min;
            public int Max;
            public ConfInt() { }
            public ConfInt(IConfig conf, string key, int def, int min = 0, int max = int.MaxValue)
            {
                Init(conf, key, def.ToString(), min, max);
            }
            public override void Init(IConfig conf, string key, string def)
            {
                Init(conf, key, def, 0, int.MaxValue);
            }
            public void Init(IConfig conf, string key, string def, int min, int max)
            {
                base.Init(conf, key, def);
                Min = min;
                Max = max;
            }

            public static implicit operator int(ConfInt c)
            {
                int value = int.Parse(c.Conf.GetConfig(c.Key, c.Default));

                if (value < c.Min) value = c.Min;
                if (value > c.Max) value = c.Max;

                return value;
            }
            public void Set(int value)
                => Conf.SetConfig(Key, value.ToString());
            public new int Get()
                => (int)this;
        }
        public class ConfBool : ConfStr, IConfValue<bool>
        {
            const string TRUE = "1";
            const string FALSE = "0";
            public ConfBool() { }
            public ConfBool(IConfig conf, string key, bool def)
                : base(conf, key, GetStr(def))
            {
            }

            public static implicit operator bool(ConfBool c)
                => !(c.Conf.GetConfig(c.Key, c.Default).Equals(FALSE));
            public void Set(bool value)
                => Conf.SetConfig(Key, GetStr(value));
            public new bool Get()
                => (bool)this;
            private static string GetStr(bool b)
                => (b ? TRUE : FALSE);
        }
        public class ConfEnum<E> : ConfStr, IConfValue<E> where E : struct, Enum
        {
            E EnumDefault;
            public ConfEnum() { }
            public ConfEnum(IConfig conf, string key, E def)
                : base(conf, key, def.ToString())
            {
                EnumDefault = def;
            }

            public static implicit operator E(ConfEnum<E> c)
            {
                string value = c.Conf.GetConfig(c.Key, c.Default);
                E ret;
                if (!Enum.TryParse<E>(value, out ret)) {
                    return c.EnumDefault;
                }
                return ret;
            }
            public void Set(E value)
                => Conf.SetConfig(Key, value.ToString());
            public new E Get()
                => (E)this;
        }

        public class ConfPoint : IConfValue<Point>
        {
            ConfInt X;
            ConfInt Y;

            public ConfPoint() { }
            public ConfPoint(IConfig conf, string key, int x, int y)
            {
                Init(conf, key, x, y);
            }
            public void Init(IConfig conf, string key)
            {
                Init(conf, key, 0, 0);
            }
            public void Init(IConfig conf, string key, int x, int y)
            {
                X = new(conf, $"{key}_X", x);
                Y = new(conf, $"{key}_Y", y);
            }

            public static implicit operator Point(ConfPoint c)
            {
                return new(c.X, c.Y);
            }
            public static implicit operator Size(ConfPoint c)
            {
                return new(c.X, c.Y);
            }
            public void Set(Point value)
            {
                X.Set(value.X);
                Y.Set(value.Y);
            }
            public void Set(Size value)
            {
                X.Set(value.Width);
                Y.Set(value.Height);
            }

            public Point Get()
                => (Point)this;

            public void Dispose()
            {
                X.Dispose();
                Y.Dispose();
            }

        }
        public class ConfDictionary : ConfStr
        {
            static readonly string Separator = "🎰";
            static readonly string SeparatorSub = "🎯";
            protected Dictionary<string, string> Dic;

            public ConfDictionary() { }
            public ConfDictionary(IConfig conf, string key)
            {
                this.Init(conf, key, "");
            }

            public override void Init(IConfig conf, string key, string def)
            {
                base.Init(conf, key, def);
                Dic = new();
                var strs = ((string)this).Split(Separator);
                try {
                    for (int i = 0; i < strs.Length; i += 2) {
                        var k = strs[i];
                        var v = strs[i + 1];
                        Dic.Add(k, v);
                    }
                } catch {
                    //偶数でない時は仕方ないな。
                }
            }

            public void FlushDictionary()
            {
                var builder = new StringBuilder();
                foreach (var pair in Dic) {
                    if (builder.Length > 0) {
                        builder.Append(Separator);
                    }
                    builder.Append(pair.Key.Replace(Separator, SeparatorSub));
                    builder.Append(Separator);
                    builder.Append(pair.Value.Replace(Separator, SeparatorSub));
                }
                Set(builder.ToString());
            }

            public static implicit operator Dictionary<string, string>(ConfDictionary c)
            {
                return c.Dic;
            }
            public string this[string key] {
                get { return Dic[key]; }
                set { Dic[key] = value; }
            }

            public override void Dispose()
            {
                FlushDictionary();
            }
        }
        public class ConfClass<T> : ConfDictionary, IConfValue<T> where T : class, new()
        {
            public ConfClass() { }
            public ConfClass(IConfig conf, string key)
                : base(conf, key)
            {
            }

            public static implicit operator T(ConfClass<T> c)
            {
                var ret = new T();
                var fields = typeof(T).GetFields();
                foreach (var f in fields) {
                    string strval=null;
                    try {
                        if (c.Dic.TryGetValue(f.Name, out strval)) {
                            object val;
                            if (f.FieldType == typeof(string)) {
                                val = strval;
                            } else {
                                val = Activator.CreateInstance(f.FieldType, strval);
                            }
                            f.SetValue(ret, val);
                        }
                    } catch (Exception ex) {
                        throw new Exception(
                            $"デシリアライズに失敗しました。\n{f.Name} <- \"{strval}\"",
                            ex);
                    }
                }
                return ret;
            }
            public void Set(T obj)
            {
                Dic.Clear();
                var fields = typeof(T).GetFields();
                foreach (var f in fields) {
                    var value = f.GetValue(obj);
                    if (value != null) {
                        Dic.Add(f.Name, value.ToString());
                    }
                }
                FlushDictionary();
            }

            T IConfValue<T>.Get()
                => (T)this;
        }
        public class ConfList<C, T> : IList<T>, IDisposable where C : IConfValue<T>, new()
        {
            List<T> List;
            IConfig Config;
            string Key;
            int OldSize;

            private string GetKey(int i)
            {
                return $"{Key}_{i}";
            }
            public ConfList(IConfig conf, string key)
            {
                List = new();
                Config = conf;
                Key = key;

                int i = 0;
                while (true) {
                    if (Config.GetConfig(GetKey(i), null) == null) {
                        break;
                    }
                    var c = new C();
                    c.Init(Config, $"{Key}_{i}");
                    var value = c.Get();
                    List.Add(value);
                    i++;
                }
                OldSize = List.Count;
            }
            public void FlushList()
            {
                for (int i = 0; i < List.Count; i++) {
                    var value = List[i];
                    var c = new C();
                    c.Init(Config, $"{Key}_{i}");
                    c.Set(value);
                }
                for (int i = List.Count; i < OldSize; i++) {
                    Config.RemoveConfig($"{Key}_{i}");
                }
                OldSize = List.Count;
            }
            public void Dispose()
            {
                FlushList();
            }

            public T this[int index] {
                get => ((IList<T>)List)[index];
                set => ((IList<T>)List)[index] = value;
            }

            public int Count => ((ICollection<T>)List).Count;
            public bool IsReadOnly => ((ICollection<T>)List).IsReadOnly;
            public void Add(T item) => ((ICollection<T>)List).Add(item);
            public void Clear() => ((ICollection<T>)List).Clear();
            public bool Contains(T item) => ((ICollection<T>)List).Contains(item);
            public void CopyTo(T[] array, int arrayIndex) => ((ICollection<T>)List).CopyTo(array, arrayIndex);
            public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)List).GetEnumerator();
            public int IndexOf(T item) => ((IList<T>)List).IndexOf(item);
            public void Insert(int index, T item) => ((IList<T>)List).Insert(index, item);
            public bool Remove(T item) => ((ICollection<T>)List).Remove(item);
            public void RemoveAt(int index) => ((IList<T>)List).RemoveAt(index);
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)List).GetEnumerator();
        }


        protected string GetConfig(string key, string def_value)
        {
            var conf = config.AppSettings.Settings[key];
            if (conf == null) {
                if (!String.IsNullOrEmpty(def_value)) {
                    SetConfig(key, def_value);
                }
                return def_value;
            } else {
                return conf.Value;
            }
        }

        protected void SetConfig(string key, string value)
        {
            var current = config.AppSettings.Settings[key];
            if (current != null) {
                current.Value = value;
            } else {
                config.AppSettings.Settings.Add(key, value);
            }
            config.Save();
        }
        protected void RemoveConfig(string key)
        {
            config.AppSettings.Settings.Remove(key);
            //指定したキーを持つ要素が含まれていない場合、 NameValueCollection は変更されません。 
            config.Save();
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////
    public abstract class ConfigBase : IConfig
    {
        private Configuration _config;
        Configuration IConfig.config => _config;


        public ConfigBase()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        public ConfigBase(string path)
        {
            var exeFileMap = new ExeConfigurationFileMap { ExeConfigFilename = path };
            _config = ConfigurationManager.OpenMappedExeConfiguration(
                exeFileMap, ConfigurationUserLevel.None);

        }
    }
}
