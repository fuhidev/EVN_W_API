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
                //var resKTLD = service.CheckPhanQuyen(pUsername, Application.KTLD);
                var resKTLD = new WGISService.PhanQuyen
                {
                    Create = true,Delete=true,DonVi="GISGOVAP",Enable=true,Read=true,Update=true
                };
                if (resKTLD != null)
                {
                    result.Add(new MapCollectionItem
                    {
                        ID = this.GenerateID(Application.KTLD, resKTLD),
                        Name = "Bản đồ kiểm tra lưới điện - " + resKTLD.DonVi
                    });
                }

                // kiểm tra trạm biến áp
                //var resKTBA = service.CheckPhanQuyen(pUsername, Application.KTBA);
                var resKTBA = new WGISService.PhanQuyen
                {
                    Create = true,
                    Delete = true,
                    DonVi = "GISGOVAP",
                    Enable = true,
                    Read = true,
                    Update = true
                };
                if (resKTBA != null)
                {
                    result.Add(new MapCollectionItem
                    {
                        ID = this.GenerateID(Application.KTBA, resKTBA),
                        Name = "Bản đồ kiểm tra trạm biến áp - " + resKTBA.DonVi
                    });
                }
                // kiểm tra đường dây
                var resKTDD = service.CheckPhanQuyen(pUsername, Application.KTDD);
                if (resKTDD != null)
                {
                    result.Add(new MapCollectionItem
                    {
                        ID = this.GenerateID(Application.KTDD, resKTDD),
                        Name = "Bản đồ kiểm tra đường dây - " + resKTDD.DonVi
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
