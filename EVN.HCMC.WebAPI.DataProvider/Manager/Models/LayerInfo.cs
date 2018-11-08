using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVN.HCMC.WebAPI.DataProvider.Manager.Models
{
    public class LayerInfo
    {
        public string LayerID { get; set; }
        public string LayerTitle { get; set; }
        public Boolean IsView { get; set; }
        public Boolean IsCreate { get; set; }
        public Boolean IsDelete { get; set; }
        public Boolean IsEdit { get; set; }
        public string Url { get; set; }
    }

    public static class Application
    {
        public const string
            KTLD = "KTLD_Mb",
            KTDD = "KTDD_Mb",
            KTBA = "KTBA_Mb";
    }
}
