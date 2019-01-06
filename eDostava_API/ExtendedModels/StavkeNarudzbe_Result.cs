using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Models
{
    public partial class StavkeNarudzbe_Result
    {
        public int StavkaNarudzbeID { get; set; }
        public int NarudzbaID { get; set; }
        public int HranaID { get; set; }
        public string HranaNaziv { get; set; }
        public double HranaCijena { get; set; }
        public int Kolicina { get; set; }
        public double UkupnaCijena { get; set; }


        public Hrana_Result Hrana { get; set; }

        public static StavkeNarudzbe_Result GetStavkaResultInstance(StavkeNarudzbe obj)
        {
            return new StavkeNarudzbe_Result
            {
                StavkaNarudzbeID = obj.StavkaNarudzbeID,
                HranaID = obj.HranaID,
                HranaNaziv = obj.Hrana.Naziv,
                HranaCijena = obj.Hrana.Cijena,
                UkupnaCijena = obj.Hrana.Cijena * obj.Kolicina,
                NarudzbaID = obj.NarudzbaID,
                Kolicina = obj.Kolicina,
                Hrana = Hrana_Result.GetHranaResultInstance(obj.Hrana)
            };
        }
    }
}