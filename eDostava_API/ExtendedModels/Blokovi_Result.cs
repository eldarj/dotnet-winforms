using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Models
{
    public partial class Blokovi_Result
    {
        public static Blokovi_Result GetBlokoviResultInstance(Blokovi b)
        {
            return new Blokovi_Result
            {
                BlokID = b.BlokID,
                GradID = b.GradID,
                Naziv = b.Naziv,
                NazivGrada = b.Naziv
            };
        }
    }
}