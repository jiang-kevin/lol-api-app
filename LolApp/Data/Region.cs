using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Data
{
    /// <summary>
    /// Class representing a region for the Riot Games API
    /// </summary>
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

        /// <summary>
        /// Representation of region for human readability
        /// </summary>
        public string RegionDisp;

        /// <summary>
        /// Representation of region for use in API
        /// </summary>
        public string RegionCode;
    }
}
