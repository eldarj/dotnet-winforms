using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace eDostava_API.Models
{
    public partial class Hrana_Result
    {
        #region SlikaHandlers
        public Image GetSlikaImage()
        {
            try
            {
                MemoryStream ms = new MemoryStream(this.Slika);
                return Image.FromStream(ms);
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
        }
        public void SetSlikaImage(Image img)
        {
            if (img == null)
            {
                this.Slika = null;
                return;
            }
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            this.Slika = ms.ToArray();
        }

        public Image GetSlikaThumbImage()
        {
            try
            {
                MemoryStream ms = new MemoryStream(this.SlikaThumb);
                return Image.FromStream(ms);
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
        }
        public void SetSlikaThumbImage(Image img)
        {
            if (img == null)
            {
                this.SlikaThumb = null;
                return;
            }
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            this.SlikaThumb = ms.ToArray();
        }
        #endregion

        public static Hrana_Result GetHranaResultInstance(Hrana obj)
        {
            return new Hrana_Result
            {
                HranaID = obj.HranaID,
                Sifra = obj.Sifra,
                Naziv = obj.Naziv,
                Cijena = obj.Cijena,
                Opis = obj.Opis,
                Slika = obj.Slika,
                SlikaThumb = obj.SlikaThumb,
                TipKuhinjeID = obj.TipKuhinjeID,
                TipKuhinjeNaziv = obj.TipoviKuhinje?.Naziv,
                RestoranID = obj.RestoranID,
                RestoranNaziv = obj.Restorani?.Naziv
            };
        }
    }
}