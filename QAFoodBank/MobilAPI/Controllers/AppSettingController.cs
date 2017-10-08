using QAFoodBank.MobileAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QAFoodBank.MobileAPI.Controllers
{
    public class AppSettingController : ApiController
    {
        private QAFB_DBEntities db = new QAFB_DBEntities();

        public IEnumerable<AppSettng> Get()
        {
            return db.AppSettngs.ToList();
        }
    }
}
