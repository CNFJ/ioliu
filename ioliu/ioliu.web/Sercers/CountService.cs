using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public class CountService
    {
        private int _count;
        public int GetLatestCounbt()
        {
            return _count++;
        }
    }
}
