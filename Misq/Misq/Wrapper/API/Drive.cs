using Misq.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misq.Wrapper
{
    public class Drive
    {
        Me Me;
        public readonly Files Files;

        internal Drive(Me me)
        {
            Me = me;
            Files = new(me);
        }
    }
}
