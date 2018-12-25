using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace eDostava_API.Helpers
{
    public class ExceptionHandler
    {
        private HttpResponseException CreateHttpResponseException(string reason, HttpStatusCode code)
        {
            HttpResponseMessage m = new HttpResponseMessage
            {
                StatusCode = code,
                ReasonPhrase = reason,
                Content = new StringContent(reason)
            };

            return new HttpResponseException(m);
        }

        public static string HandleEception(EntityException e)
        {
            SqlException error = e.InnerException as SqlException;

            switch (error.Number)
            {
                case 2627:
                    return GetConstraintExceptionMessage(error);
                default:
                    return error.Message + " (" + error.Number + ")";
            }
        }

        private static string GetConstraintExceptionMessage(SqlException error)
        {
            string newMessage = error.Message;
            int startIndex = newMessage.IndexOf("'");
            int endIndex = newMessage.IndexOf("'", startIndex + 1);

            if (startIndex > 0 && endIndex > 0)
            {
                string constraintName = newMessage.Substring(startIndex + 1, endIndex - startIndex - 1);

                if (constraintName == "UQ_Naziv")
                {
                    newMessage = "restoran_naziv_constraint";
                } else if (constraintName == "UQ_Email")
                {
                    newMessage = "restoran_email_constraint";
                }
            }
            return newMessage;
        }
    }
}