using EVN.HCMC.WebAPI.DataProvider.Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVN.HCMC.WebAPI.DataProvider.Manager
{
    public class MapCollectionDB
    {
        public List<MapCollectionItem> Get(string pUsername)
        {
            using (var service = new WGISService.wsGISSoapClient())
            {
                var result = new List<MapCollectionItem>();

                // kiểm tra lưới điện
                var resKTLD = service.CheckPhanQuyen(pUsername, Application.KTLD);
                if (resKTLD != null)
                {
                    var id = this.GenerateID(Application.KTLD, resKTLD);
                    if (!String.IsNullOrEmpty(id))
                        result.Add(new MapCollectionItem
                        {
                            ID = id,
                            Name = "Bản đồ kiểm tra lưới điện - " + resKTLD.DonVi
                        });
                }

                // kiểm tra trạm biến áp
                var resKTBA = service.CheckPhanQuyen(pUsername, Application.KTBA);
                if (resKTBA != null)
                {
                    var id = this.GenerateID(Application.KTBA, resKTBA);
                    if (!String.IsNullOrEmpty(id))
                        result.Add(new MapCollectionItem
                        {
                            ID = id,
                            Name = "Bản đồ kiểm tra trạm biến áp"
                        });
                }
                // kiểm tra đường dây
                var resKTDD = service.CheckPhanQuyen(pUsername, Application.KTDD);
                if (resKTDD != null)
                {
                    var id = this.GenerateID(Application.KTDD, resKTDD);
                    if (!String.IsNullOrEmpty(id))
                        result.Add(new MapCollectionItem
                        {
                            ID = id,
                            Name = "Bản đồ kiểm tra đường dây" 
                        });
                }

                return result;
            }
        }

        private string GenerateID(string applicationID, WGISService.PhanQuyen phanQuyen)
        {
            return Helper.GenerateMapCollectionItemID(applicationID, phanQuyen.DonVi);
        }
    }
}
