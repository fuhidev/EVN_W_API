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
            var name = ConvertIDToName(donVi);
            if (string.IsNullOrEmpty(name))
                return null;
            return String.Format("{0}-{1}", applicationID,name );
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

        private static String ConvertIDToName(string id)
        {
            string name = "";
            if (id == "J")
            {
                name = "TANTHUAN";
            }
            else if (id == "A")
            {
                name = "SAIGON";
            }
            else if (id == "C")
            {
                name = "PHUTHO";
            }
            else if (id == "D")
            {
                name = "ANPHUDONG";
            }
            else if (id == "E")
            {
                name = "CHOLON";
            }
            else if (id == "G")
            {
                name = "GIADINH";
            }
            else if (id == "H")
            {
                name = "GOVAP";
            }
            else if (id == "K")
            {
                name = "BINHCHANH";
            }
            else if (id == "L")
            {
                name = "BINHPHU";
            }
            else if (id == "N")
            {
                name = "TANPHU";
            }
            else if (id == "P")
            {
                name = "TANBINH";
            }
            else if (id == "R")
            {
                name = "HOCMON";
            }
            else if (id == "S")
            {
                name = "CUCHI";
            }
            else if (id == "T")
            {
                name = "THUDUC";
            }
            else if (id == "V")
            {
                name = "DUYENHAI";
            }
            else if (id == "X")
            {
                name = "THUTHIEM";
            }
            return "GIS" + name;
        }
    }
}
