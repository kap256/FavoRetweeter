using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAPLibNet
{
    public interface IEnumlikeObject<E> where E : IEnumlikeObject<E>
    {
        public bool TryParse(string value, out E result)
        {
            foreach (var e in GetValues()) {
                if (e.ToString() == value) {
                    result = e;
                    return true;
                }
            }
            result = default;
            return false;
        }

        E[] GetValues();
    }
}
