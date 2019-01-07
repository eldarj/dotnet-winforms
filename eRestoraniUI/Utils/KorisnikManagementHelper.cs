using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.Utils
{
    class KorisnikManagementHelper // helper za Korisnikmanagement page
    {
        public class KorisnikListModel
        {
            public BindingList<Korisnici_Result> BindingList { get; set; }
            public BindingSource BindingSource { get; set; }
            public int UlogaId { get; set; }
            public string UlogaNaziv { get; set; }

            public KorisnikListModel(int ulogaId, string ulogaNaziv)
            {
                this.UlogaId = ulogaId;
                this.UlogaNaziv = ulogaNaziv;
                BindingSource = new BindingSource();
            }

            public int ListCount { get { return this.BindingList.Count; } }
        }
    }
}
