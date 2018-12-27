using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Models
{
    public partial class Restorani_Result
    {
        public override bool Equals(object obj)
        {
            Restorani_Result _obj = obj as Restorani_Result;
            return _obj != null && this.RestoranID == _obj.RestoranID;
        }

        public override string ToString()
        {
            return this.Naziv.ToString();
        }


    }
}