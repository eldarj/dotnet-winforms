//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eDostava_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zalbe
    {
        public int ZalbaID { get; set; }
        public string Razlog { get; set; }
        public string Opis { get; set; }
        public int RestoranID { get; set; }
        public int NarucilacID { get; set; }
    
        public virtual Narucioci Narucioci { get; set; }
        public virtual Restorani Restorani { get; set; }
    }
}