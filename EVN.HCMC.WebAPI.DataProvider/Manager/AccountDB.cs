using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVN.HCMC.WebAPI.DataProvider.Manager
{
    public class AccountDB
    {
        public Boolean IsValid(string pUsername,string pPassword)
        {
            using (var service = new WGISService.wsGISSoapClient())
            {
                return service.CheckUserOutlook(pUsername, pPassword);
            }
        }
    }
}
