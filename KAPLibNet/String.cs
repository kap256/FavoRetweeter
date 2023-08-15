using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KAPLibNet.IConfig;

namespace KAPLibNet
{
    public struct StrInt
    {
        int Value;
        public StrInt() => Value = 0;
        public StrInt(int i) => Value = i;
        public StrInt(string str) => Value = int.Parse(str);
        public override string ToString() => $"{Value}";

        public static implicit operator int(StrInt s) => s.Value;
        public static implicit operator StrInt(int i) => new StrInt(i);
        public static implicit operator StrInt(string s) => new StrInt(s);
    }
    public struct StrBool
    {
        const string TRUE = "true";
        const string FALSE = "false";

        bool Value;

        public StrBool() => Value = false;
        public StrBool(bool i) => Value = i;
        public StrBool(string str) => Value = (str == TRUE ? true : false);
        public override string ToString() => (Value?TRUE:FALSE);

        public static implicit operator bool(StrBool s) => s.Value;
        public static implicit operator StrBool(bool i) => new StrBool(i);
        public static implicit operator StrBool(string s) => new StrBool(s);
    }
}
