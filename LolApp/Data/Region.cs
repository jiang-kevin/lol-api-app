using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Data
{
    public class Region
    {
        public Region(string regionDisp, string regionCode)
        {
            RegionDisp = regionDisp;
            RegionCode = regionCode;
        }

        public override string ToString()
        {
            return RegionDisp;
        }

        public string RegionDisp;
        public string RegionCode;
    }
}
