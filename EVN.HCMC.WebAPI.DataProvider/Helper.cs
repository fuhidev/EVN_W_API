using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVN.HCMC.WebAPI.DataProvider
{
    public class Helper
    {


        public static string GenerateMapCollectionItemID(string applicationID, string donVi)
        {
            return String.Format("{0}-{1}", applicationID, donVi);
        }

        public static string GetApplicationFromMapCollectionItemID(string mapCollectionItemID)
        {
            var split = mapCollectionItemID.Split('-');
            if (split.Length == 2)
            {
                return split[0];
            }
            else { return null; }
        }

        public static string GetBranchFromMapCollectionItemID(string mapCollectionItemID)
        {
            var split = mapCollectionItemID.Split('-');
            if (split.Length == 2)
            {
                return split[1];
            }
            else { return null; }
        }
    }
}
