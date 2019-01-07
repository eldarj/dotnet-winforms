using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace eDostava_API.Helpers
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception is NullReferenceException)
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
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.ServiceUnavailable,
                    ReasonPhrase = "Ne možemo obraditi zahtjev",
                    Content = new StringContent("Trenutno ne možemo obraditi vaš zahtjev, molimo kontaktirajte podršku.")
                };
            }

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    ReasonPhrase = "Podaci nisu validni",
                    Content = new StringContent("Dogodila se greška, podaci nisu validni! Ako ste unijeli validne podatke, molimo provjerite još jedanput, te kontaktirajte podršku.")
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
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.ServiceUnavailable,
                    ReasonPhrase = "Ne možemo obraditi zahtjev",
                    Content = new StringContent("Trenutno ne možemo obraditi vaš zahtjev, molimo kontaktirajte podršku.")
                };
            }
        }
    }
}