using EVN.HCMC.WebAPI.DataProvider.Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVN.HCMC.WebAPI.DataProvider.Manager
{
    public class LayerInfoDB
    {
        public List<LayerInfo> GetByApplication(string pUsername, string pMapCollectionItemID)
        {
            using (var service = new WGISService.wsGISSoapClient())
            {
                var result = new List<LayerInfo>();
                var applicationID = Helper.GetApplicationFromMapCollectionItemID(pMapCollectionItemID);
                var branchName = Helper.GetBranchFromMapCollectionItemID(pMapCollectionItemID);
                switch (applicationID)
                {
                    case Application.KTLD:
                        // Kiểm tra quyền truy cập
                        var phanQuyenKTLD = service.CheckPhanQuyen(pUsername, Application.KTLD);
                        if (phanQuyenKTLD != null)
                        {
                            var layerInfos = new List<LayerInfo>();

                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "thamchieunen_h_cacheMS",
                                LayerTitle = "Bản đồ nền",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/" + branchName + "/ThamChieuNen_H_Cache/MapServer"
                            });


                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "luoidienhthMS",
                                LayerTitle = "Bản đồ nền Lưới điện hạ thế",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/" + branchName + "/LuoiDien_HT_H/MapServer"
                            });

                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "ldtthMS",
                                LayerTitle = "Bản đồ nền Lưới điện Trung thế",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/" + branchName + "/LuoiDien_TT_H/MapServer"
                            });

                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "luoidienkthktdttLYR",
                                LayerTitle = "Kiểm tra Dây thông tin",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/" + branchName + "/LuoiDien_KT_H/FeatureServer/3"
                            });

                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "luoidienkthktldttLYR",
                                LayerTitle = "Kiểm tra Lưới điện Trung thế",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/" + branchName + "/LuoiDien_KT_H/FeatureServer/0",
                            });
                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "luoidienkthktldhtLYR",
                                LayerTitle = "Kiểm tra Lưới điện Hạ thế",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/" + branchName + "/LuoiDien_KT_H/FeatureServer/1"
                            });
                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "luoidienkthkttbtLYR",
                                LayerTitle = "Kiểm tra Trạm biến thế",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/" + branchName + "/LuoiDien_KT_H/FeatureServer/2"
                            });

                            // cập nhật quyền
                            layerInfos.ForEach(layerInfo =>
                            {
                                layerInfo.IsCreate = phanQuyenKTLD.Create;
                                layerInfo.IsDelete = phanQuyenKTLD.Delete;
                                layerInfo.IsEdit = phanQuyenKTLD.Update;
                                layerInfo.IsView = phanQuyenKTLD.Read;
                            });

                            // cập nhật vào mảng
                            result.AddRange(layerInfos);
                        }
                        break;
                    case Application.KTBA:
                        // Kiểm tra quyền truy cập
                        var phanQuyenKTBA = service.CheckPhanQuyen(pUsername, Application.KTBA);
                        if (phanQuyenKTBA != null)
                        {
                            var layerInfos = new List<LayerInfo>();

                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "gishcm02_y_web_tcncache_yMS",
                                LayerTitle = "Bản đồ nền",
                                Url = "https://prgdc.hcmpc.com.vn/web/rest/services/GISCAOTHE/DC_GISSYNDC_Y_QLTT_TCNCACHE_Y/MapServer"
                            });

                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "luoidienktyMS",
                                LayerTitle = "Bản đồ nền Lưới điện Cao thế",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/GISCAOTHE/Luoidien_CT_Y/MapServer"
                            });

                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "luoidienktykttbaLYR",
                                LayerTitle = "Kiểm tra Trạm biến áp",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/GISCAOTHE/LuoiDien_KT_Y/FeatureServer/0"
                            });

                            // cập nhật quyền
                            layerInfos.ForEach(layerInfo =>
                            {
                                layerInfo.IsCreate = phanQuyenKTBA.Create;
                                layerInfo.IsDelete = phanQuyenKTBA.Delete;
                                layerInfo.IsEdit = phanQuyenKTBA.Update;
                                layerInfo.IsView = phanQuyenKTBA.Read;
                            });

                            // cập nhật vào mảng
                            result.AddRange(layerInfos);
                        }
                        break;
                    case Application.KTDD:
                        // Kiểm tra quyền truy cập
                        var phanQuyenKTDD = service.CheckPhanQuyen(pUsername, Application.KTDD);
                        if (phanQuyenKTDD != null)
                        {
                            var layerInfos = new List<LayerInfo>();

                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "gishcm02_y_web_tcncache_yMS",
                                LayerTitle = "Bản đồ nền",
                                Url = "https://ktlddc.hcmpc.com.vn/arcgis/rest/services/GISCAOTHE/GISHCM02_Y_WEB_TCNCACHE_Y/MapServer"
                            });
                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "luoidienktyMS",
                                LayerTitle = "Bản đồ nền Lưới điện Cao thế",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/GISCAOTHE/Luoidien_CT_Y/MapServer"
                            });
                            layerInfos.Add(new LayerInfo
                            {
                                LayerID = "luoidienktyktddLYR",
                                LayerTitle = "Kiểm tra đường dây",
                                Url = "https://prgrd.hcmpc.com.vn/arcgis/rest/services/GISCAOTHE/LuoiDien_KT_Y/FeatureServer/1"
                            });



                            // cập nhật quyền
                            layerInfos.ForEach(layerInfo =>
                            {
                                layerInfo.IsCreate = phanQuyenKTDD.Create;
                                layerInfo.IsDelete = phanQuyenKTDD.Delete;
                                layerInfo.IsEdit = phanQuyenKTDD.Update;
                                layerInfo.IsView = phanQuyenKTDD.Read;
                            });

                            // cập nhật vào mảng
                            result.AddRange(layerInfos);
                        }

                        break;
                }
                return result;
            }
        }

    }
}
