using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Models
{
    public partial class Gradovi_Result
    {
        public static Gradovi_Result GetGradoviResultInstance (Gradovi g)
        {
            return new Gradovi_Result
            {
                Naziv = g.Naziv,
                GradID = g.GradID,
                PostanskiBroj = g.PostanskiBroj
            };
        }
    }
}