using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.BusinessEntities
{
    public static class Enumerates
    {
        public enum Result
        {
            Success=0,
            Error=-1
        }

        public enum LogType
        {
            Message=1,
            Error=2,
            Warning=3
        }
    }
}
