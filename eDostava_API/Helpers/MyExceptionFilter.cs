using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace eDostava_API.Helpers
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    ReasonPhrase = "Uplata obavezna",
                    Content = new StringContent("Potrebno izvršiti uplatu!")
                };
            }
            else if(actionExecutedContext.Exception is InvalidOperationException)
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    ReasonPhrase = "Traženi resurs ne postoji",
                    Content = new StringContent("Traženi resurs ne postoji u bazi i nije mogao biti pronađen.")
                };
            }
            else
            {
                base.OnException(actionExecutedContext);
            }
        }
    }
}