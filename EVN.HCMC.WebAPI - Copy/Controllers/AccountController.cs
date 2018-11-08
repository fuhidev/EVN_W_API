using EVN.HCMC.WebAPI.DataProvider.Manager;
using EVN.HCMC.WebAPI.DataProvider.Manager.Models;
using EVN.HCMC.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace EVN.HCMC.WebAPI.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : ApiController
    {
        [ResponseType(typeof(IEnumerable<LayerInfo>))]
        [Route("LayerInfo/{mapID}")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage LayerInfo(string mapID)
        {
            try
            {
                var username = User.Identity.Name;
                var context = new LayerInfoDB();

                var result = context.GetByApplication(username, mapID);

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [ResponseType(typeof(IEnumerable<MapCollectionItem>))]
        [Route("MapCollection")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage MapCollection()
        {
            try
            {
                var username = User.Identity.Name;

                var context = new MapCollectionDB();
                var result = context.Get(username);

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}
