using eRestoraniUI.ResourceMessages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.Utils
{
    class UIHelper
    {
        #region Regex Strings
        public static int TELEFON_STANDARDNA_DUZINA = 6;
        public static string TELEFON_REGEX = @"\D+|((00)?387){1,}";
        public static string DECIMAL_REGEX = @"[1-9]?[0-9]?\.\d+";
        #endregion

        #region Strings
        public static string ListToString<T>(List<T> list, string delimiter, string defaultIfEmpty = "-")
        {
            string temp = "";
            foreach (T item in list)
            {
                temp += list.Last().Equals(item) ? item.ToString() : item.ToString() + ", ";
            }
            return String.IsNullOrEmpty(temp) ? defaultIfEmpty : temp;
        }
        #endregion

        #region Calculations
        public static string ExtractDecimalCijena(string str)
        {
            Match m = Regex.Match(str, DECIMAL_REGEX);
            return m.Value != "" ? m.Value : "0";
        }

        public static string GenerateMaskedDecimal(double value)
        {
            string maskedString = Convert.ToString(value);
            int decPos = maskedString.IndexOf('.');

            try
            {
                if (decPos == -1) // ako je double vrijednost samo cijeli broj, dodaj '.' i nule na decimale
                {
                    maskedString = maskedString + ".00";
                    decPos = maskedString.IndexOf('.');
                }
                if (maskedString.Substring(0, decPos).Length == 1) // ako je cijeli broj samo jedna cifra, dodaj 0 pred isti
                {
                    maskedString = "0" + maskedString;
                    decPos = maskedString.IndexOf('.');
                }
                if (maskedString.Substring(decPos + 1).Length == 1) // ako su decimale zapravo samo jedna decimala/cifra, dodaj 0 na zadnju decimalu
                {
                    maskedString += "0";
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                maskedString = "00.00";
            }

            return maskedString;
        }

        internal static string ExtractPoneNumber(string telefon)
        {
            try
            {
                telefon = Regex.Replace(telefon, TELEFON_REGEX, "");
                if (telefon[0] != '0' && telefon.Length != TELEFON_STANDARDNA_DUZINA)
                {
                    return "0" + telefon;
                }
            }
            catch (Exception e)
            {
                // handle exception ? za sad samo vrati prazan string...
                telefon = "";
            }

            return telefon;
        }
        #endregion

        #region Messages
        public static void MessageOnApiError(string msg)
        {
            if (!String.IsNullOrEmpty(ApiMessages.ResourceManager.GetString(msg)))
                msg = ApiMessages.ResourceManager.GetString(msg);
            else
                msg = Messages.greska_msg_pokusaj_ponovo;

            MessageBox.Show(msg, ResourceMessages.Messages.greska_msg_title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void MessageGeneralGreska()
        {
            MessageBox.Show("Dogodila se greška. Pokušajte ponovo ili kontaktirajte podršku.",
                "Greška",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        #endregion

        #region Accounts
        public static string GenerateSalt()
        {
            byte[] arr = new byte[16];

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(arr);

            return Convert.ToBase64String(arr);
        }

        public static string GenerateHash(string lozinka, string salt)
        {
            byte[] byteLozinka;
            byte[] byteSalt;
            byte[] forHashing;
            try
            {
                byteLozinka = Encoding.Unicode.GetBytes(lozinka);
                byteSalt = Convert.FromBase64String(salt);
                forHashing = new byte[byteLozinka.Length + byteSalt.Length];
            }
            catch (Exception e)
            {
                // check the callstack here
                // exception ćemo uhvatiti ako ne možemo dohvatiti bytove ili base64 od lozinke ili salta (ako nisu dobrog formata ili dužine)
                // također, vrati bilo koji string kao hash, jer je svakako nije validan
                return "hashinvalid";
            }

            //strcpy i strcat
            System.Buffer.BlockCopy(byteLozinka, 0, forHashing, 0, byteLozinka.Length);
            System.Buffer.BlockCopy(byteSalt, 0, forHashing, byteLozinka.Length, byteSalt.Length);

            HashAlgorithm alg = HashAlgorithm.Create("SHA1");
            return Convert.ToBase64String(alg.ComputeHash(forHashing));
        }
        #endregion

        #region Slike
        public static Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            try
            {
                Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                return (Image)bmpCrop;
            }
            catch (Exception e)
            {
                // croparea outside image
                return null;
            }
        }

        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = (float)size.Width / (float)sourceWidth; // 0.1
            nPercentH = (float)size.Height / (float)sourceHeight; //0.5

            if (nPercentH > nPercentW) nPercent = nPercentW;
            else nPercent = nPercentH;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);

            g.Dispose();
            return (Image)b;
        }
        #endregion

        #region SpinnerLoader
        public static void LoaderImgStackDisplay(ref PictureBox imgLoader, ref Stack<bool> loaderImgStack)
        {
            if (loaderImgStack.Count < 1)
            {
                imgLoader.Visible = true;
            }
            loaderImgStack.Push(true);
        } // za hendlanje više 'izvora' aktiviranja spinnera

        public static void LoaderImgStackHide(ref PictureBox imgLoader, ref Stack<bool> loaderImgStack)
        {
            if (loaderImgStack.Count <= 1)
            {
                imgLoader.Visible = false;
            }
            loaderImgStack.Pop();
        } // za hendlanje više 'izvora' aktiviranja spinnera
        #endregion

        #region Generic UI element bindings
        // Za setup bind-a i comboboxa
        public static async Task<List<T>> GenericBindCmb<T>(PictureBox spinner, Stack<bool> spinnerTracker, string requestRoute,
            ComboBox cmb, string valueMemberName, string displayMember, Dictionary<string, int> qparams = null)
        {
            WebApiHelper servis = new WebApiHelper();
            List<T> data = new List<T>();

            UIHelper.LoaderImgStackDisplay(ref spinner, ref spinnerTracker);
            HttpResponseMessage response = qparams != null ? 
                await servis.GetResponse(qparams, requestRoute) :
                await servis.GetResponse(requestRoute);

            if (response.IsSuccessStatusCode)
            {
                data = new List<T>(response.Content.ReadAsAsync<List<T>>().Result);
                cmb.DataSource = data;
                cmb.ValueMember = valueMemberName;
                cmb.DisplayMember = displayMember;

                //enable controls
                cmb.Enabled = true;
            }
            UIHelper.LoaderImgStackHide(ref spinner, ref spinnerTracker);
            return data;
        }

        // Za setup bind-a i listboxa
        public static BindingListHelper<T> GenericBindListBox<T>(ListBox listBox, string valueMemberName, string displayMember, List<T> items)
        {
            BindingListHelper<T> data = new BindingListHelper<T>(items);

            listBox.DataSource = data.Source;
            listBox.ValueMember = valueMemberName;
            listBox.DisplayMember = displayMember;

            //enable controls
            listBox.Enabled = true;

            return data;
        }

        // Za setup bind-a i listboxa
        public static async Task<BindingListHelper<T>> GenericBindListBox<T>(PictureBox spinner, Stack<bool> spinnerTracker, string requestRoute,
            ListBox listBox, string valueMemberName, string displayMember)
        {
            WebApiHelper servis = new WebApiHelper();
            BindingListHelper<T> data = new BindingListHelper<T>();

            try
            {
                UIHelper.LoaderImgStackDisplay(ref spinner, ref spinnerTracker);
                HttpResponseMessage response = await servis.GetResponse(requestRoute);
                if (response.IsSuccessStatusCode)
                {
                    data = new BindingListHelper<T>(response.Content.ReadAsAsync<List<T>>().Result);
                    listBox.DataSource = data.Source;
                    listBox.ValueMember = valueMemberName;
                    listBox.DisplayMember = displayMember;

                    //enable controls
                    listBox.Enabled = true;
                }
                UIHelper.LoaderImgStackHide(ref spinner, ref spinnerTracker);
            }
            catch (Exception e)
            {
                // podataka nema, pa nećemo ni popuniti listbox
            }
            return data;
        }

        #endregion
    }
}
