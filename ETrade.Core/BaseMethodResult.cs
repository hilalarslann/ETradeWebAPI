using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public class BaseMethodResult
    {
        public bool IsSucceed { get; set; }
        public string Msg { get; set; }
        public BaseMethodResult()
        {
            IsSucceed = false;
            Msg = null;
        }
    }
}
