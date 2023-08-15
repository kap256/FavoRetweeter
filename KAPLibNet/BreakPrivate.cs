using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.BindingFlags;

namespace KAPLibNet
{
    public  class BreakPrivate<T> where T:notnull
    {
        T Target;
        Type TargetType;
        public BreakPrivate(T t)
        {
            Target = t;
            TargetType = typeof(T);
        }

        public List<string> EnumFields(Logger log=null)
        {
            var ret = new List<string>();
            var fields = TargetType.GetFields(NonPublic | Instance);
            foreach (var f in fields) {
                log?.Info($"{f.FieldType.Name} {TargetType.Name}::{f.Name}");
                ret.Add(f.Name);
            }
            return ret;
        }
        public List<string> EnumMethods(Logger log = null)
        {
            var ret = new List<string>();
            var methods = TargetType.GetMethods(NonPublic | Instance);
            foreach (var m in methods) {
                log?.Info($"{m.ReturnType.Name} {TargetType.Name}::{m.Name}()");
                ret.Add(m.Name);
            }
            return ret;
        }
        public object FieldGet(string name)
        {
            var field = TargetType.GetField(name,  NonPublic | Instance);
            return field?.GetValue(Target);
        }

        public object MethodInvoke(string name, object[] parameters)
        {
            var method =  TargetType.GetMethod(name, InvokeMethod | NonPublic | Instance);

            if (method == null) {
                throw new NotImplementedException(name);
            }

            return method.Invoke(Target, parameters);
        }
    }
}
