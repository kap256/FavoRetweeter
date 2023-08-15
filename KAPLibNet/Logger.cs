
using System.Diagnostics;
using System.Xml.Linq;

namespace KAPLibNet
{
    public abstract class ILogger
    {
        #region 実装済-------------------------------------------
        Level Lv;

        private enum Level
        {
            INFO=0,
            DEBUG = 1,
            TRACE = 2,
        }

        protected ILogger()
        {
#if DEBUG
            Lv = Level.DEBUG;
#else
            Lv = Level.INFO;
#endif
        }

        private void Log(Level lv, string mes)
        {
            if ((int)lv <= (int)(Lv)) {
                Log(mes);
            }
        }
        private bool IsILogger(Type type)
        {
            while (type != null) {
                if (type == typeof(ILogger)) {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }
        private void Log(Level lv, object mes)
        {
            if ((int)lv > (int)(Lv)) return;

            StackTrace stack= new(false);
            var method_name = "unknown()";
            for (int i = 1; i < stack.FrameCount; i++) {
                var method = stack.GetFrame(i)?.GetMethod();
                if (method == null) break;
                if (IsILogger(method.DeclaringType))  continue;
                method_name = method.Name+"()";
                break;
            }
            Log(method_name);
        }

        public void Info(string mes)
        {
            Log(Level.INFO, mes);
        }
        public void Debug(string mes)
        {
            Log(Level.DEBUG, mes);
        }
        public void Trace(string mes)
        {
            Log(Level.TRACE, mes);
        }
        public void Info(Exception ex)
        {
            Log(Level.INFO, $"Exception - {ex.Message}");
            if (ex.InnerException != null) {
                Info(ex.InnerException);
            }
        }
        public void Debug(Exception ex)
        {
            Log(Level.DEBUG, $"Exception - {ex.Message}{Environment.NewLine}===StackTrace========{Environment.NewLine}{ex.StackTrace}");

            if (ex.InnerException != null) {
                Debug(ex.InnerException);
            }
        }
        public void Ex(Exception ex)
        {
#if DEBUG
            Debug(ex);
#else
            Info(ex);
#endif
        }
        public void Debug(object o)
        {
            Log(Level.DEBUG, o);
        }
        #endregion

        protected abstract void Log(string mes);
    }


    public class Logger : ILogger
    {
        string Path;
        public static string DefaultPath
            = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".log";
        static Dictionary<string, Logger> Loggers = new();

        public static Logger GetInstance()
        {
            return GetInstance(DefaultPath);
        }

        public static Logger GetInstance(string path)
        {
            Logger ret;
            if (Loggers.TryGetValue(path, out ret)) {
                return ret;
            }

            ret = new Logger(path);
            Loggers.Add(path, ret);
            return ret;
        }

        private Logger(string path) {
            Path = path;
        }
        private Logger():this("log.log"){ }

        protected override void Log(string mes)
        {
            System.Diagnostics.Debug.WriteLine(mes);
            try {
                using (var writer = new StreamWriter(Path, true)) {
                    writer.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} - {mes}");
                }
            } catch {
                //もみ消す
            }
        }
    }
}