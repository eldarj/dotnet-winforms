using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eDostava_API.Helpers.BaseClasses
{
    public class BaseApiController : ApiController
    {
        public eRestoraniEntities db = new eRestoraniEntities();
    }
}
