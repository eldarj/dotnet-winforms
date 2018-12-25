﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class eRestoraniEntities : DbContext
    {
        public eRestoraniEntities()
            : base("name=eRestoraniEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administratori> Administratori { get; set; }
        public virtual DbSet<Blokovi> Blokovi { get; set; }
        public virtual DbSet<Gradovi> Gradovi { get; set; }
        public virtual DbSet<Hrana> Hrana { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<LoginStats> LoginStats { get; set; }
        public virtual DbSet<Narucioci> Narucioci { get; set; }
        public virtual DbSet<NarudzbaStatusi> NarudzbaStatusi { get; set; }
        public virtual DbSet<Narudzbe> Narudzbe { get; set; }
        public virtual DbSet<Recenzije> Recenzije { get; set; }
        public virtual DbSet<Restorani> Restorani { get; set; }
        public virtual DbSet<RestoranStatusi> RestoranStatusi { get; set; }
        public virtual DbSet<StavkeNarudzbe> StavkeNarudzbe { get; set; }
        public virtual DbSet<TipoviKuhinje> TipoviKuhinje { get; set; }
        public virtual DbSet<Vlasnici> Vlasnici { get; set; }
        public virtual DbSet<Zalbe> Zalbe { get; set; }
        public virtual DbSet<Zaposlenici> Zaposlenici { get; set; }
    
        public virtual ObjectResult<Blokovi_Result> esp_Blokovi_SelectAll(Nullable<int> gradId)
        {
            var gradIdParameter = gradId.HasValue ?
                new ObjectParameter("gradId", gradId) :
                new ObjectParameter("gradId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Blokovi_Result>("esp_Blokovi_SelectAll", gradIdParameter);
        }
    
        public virtual ObjectResult<Gradovi_Result> esp_Gradovi_SelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Gradovi_Result>("esp_Gradovi_SelectAll");
        }
    
        public virtual ObjectResult<Hrana_Result> esp_Hrana_Pretraga(Nullable<int> restoranId, string param)
        {
            var restoranIdParameter = restoranId.HasValue ?
                new ObjectParameter("restoranId", restoranId) :
                new ObjectParameter("restoranId", typeof(int));
    
            var paramParameter = param != null ?
                new ObjectParameter("param", param) :
                new ObjectParameter("param", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Hrana_Result>("esp_Hrana_Pretraga", restoranIdParameter, paramParameter);
        }
    
        public virtual ObjectResult<Hrana_Result> esp_Hrana_SelectByRestoran(Nullable<int> restoranId)
        {
            var restoranIdParameter = restoranId.HasValue ?
                new ObjectParameter("restoranId", restoranId) :
                new ObjectParameter("restoranId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Hrana_Result>("esp_Hrana_SelectByRestoran", restoranIdParameter);
        }
    
        public virtual ObjectResult<TipoviKuhinje_Result> esp_TipoviKuhinje_SelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TipoviKuhinje_Result>("esp_TipoviKuhinje_SelectAll");
        }
    
        public virtual ObjectResult<Restorani_Result> esp_Restorani_SelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Restorani_Result>("esp_Restorani_SelectAll");
        }
    
        public virtual ObjectResult<NarudzbaStatusi_Result> esp_NarudzbeStatusi_SelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NarudzbaStatusi_Result>("esp_NarudzbeStatusi_SelectAll");
        }
    
        public virtual ObjectResult<Recenzije_Result> esp_Recenzije_SelectByRestoranOrNarucilac(Nullable<int> filterRestoranID, Nullable<int> filterNarucilacID)
        {
            var filterRestoranIDParameter = filterRestoranID.HasValue ?
                new ObjectParameter("filterRestoranID", filterRestoranID) :
                new ObjectParameter("filterRestoranID", typeof(int));
    
            var filterNarucilacIDParameter = filterNarucilacID.HasValue ?
                new ObjectParameter("filterNarucilacID", filterNarucilacID) :
                new ObjectParameter("filterNarucilacID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Recenzije_Result>("esp_Recenzije_SelectByRestoranOrNarucilac", filterRestoranIDParameter, filterNarucilacIDParameter);
        }
    
        public virtual ObjectResult<RestoranStatusi_Result> esp_RestoranStatusi_SelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RestoranStatusi_Result>("esp_RestoranStatusi_SelectAll");
        }
    
        public virtual ObjectResult<Restorani_Result> esp_Restorani_FilterBlokGradVlasnikStatus(Nullable<int> blokId, Nullable<int> gradId, Nullable<int> vlasnikId, Nullable<int> statusId)
        {
            var blokIdParameter = blokId.HasValue ?
                new ObjectParameter("blokId", blokId) :
                new ObjectParameter("blokId", typeof(int));
    
            var gradIdParameter = gradId.HasValue ?
                new ObjectParameter("gradId", gradId) :
                new ObjectParameter("gradId", typeof(int));
    
            var vlasnikIdParameter = vlasnikId.HasValue ?
                new ObjectParameter("vlasnikId", vlasnikId) :
                new ObjectParameter("vlasnikId", typeof(int));
    
            var statusIdParameter = statusId.HasValue ?
                new ObjectParameter("statusId", statusId) :
                new ObjectParameter("statusId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Restorani_Result>("esp_Restorani_FilterBlokGradVlasnikStatus", blokIdParameter, gradIdParameter, vlasnikIdParameter, statusIdParameter);
        }
    
        public virtual ObjectResult<Restorani_Result> esp_Restorani_FilterString(string filterString)
        {
            var filterStringParameter = filterString != null ?
                new ObjectParameter("filterString", filterString) :
                new ObjectParameter("filterString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Restorani_Result>("esp_Restorani_FilterString", filterStringParameter);
        }
    
        public virtual ObjectResult<Zalbe_Result> esp_Zalbe_SelectByRestoranOrNarucilac(Nullable<int> filterRestoranID, Nullable<int> filterNarucilacID)
        {
            var filterRestoranIDParameter = filterRestoranID.HasValue ?
                new ObjectParameter("filterRestoranID", filterRestoranID) :
                new ObjectParameter("filterRestoranID", typeof(int));
    
            var filterNarucilacIDParameter = filterNarucilacID.HasValue ?
                new ObjectParameter("filterNarucilacID", filterNarucilacID) :
                new ObjectParameter("filterNarucilacID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Zalbe_Result>("esp_Zalbe_SelectByRestoranOrNarucilac", filterRestoranIDParameter, filterNarucilacIDParameter);
        }
    
        public virtual ObjectResult<Zaposlenici_Result> esp_Zaposlenici_SelectByRestoran(Nullable<int> filterRestoranID)
        {
            var filterRestoranIDParameter = filterRestoranID.HasValue ?
                new ObjectParameter("filterRestoranID", filterRestoranID) :
                new ObjectParameter("filterRestoranID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Zaposlenici_Result>("esp_Zaposlenici_SelectByRestoran", filterRestoranIDParameter);
        }
    }
}
