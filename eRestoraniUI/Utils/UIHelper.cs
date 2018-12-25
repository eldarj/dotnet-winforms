﻿using System;
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
        #region Static vars
        public static int TELEFON_STANDARDNA_DUZINA = 6;
        public static string TELEFON_REGEX = @"\D+|((00)?387){1,}";

        public static string DECIMAL_REGEX = @"[1-9]?[0-9]?\.\d+";
        #endregion

        #region Calculations
        public static string ExtractDecimalCijena(string str)
        {
            Match m = Regex.Match(str, DECIMAL_REGEX);
            return m.Value;
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
            } catch (ArgumentOutOfRangeException e)
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
            } catch (Exception e)
            {
                // handle exception ? za sad samo vrati prazan string...
                telefon = "";
            }

            return telefon;
        }
        #endregion

        #region Messages
        public static void MessageOnApiError(HttpResponseMessage response)
        {
            MessageBox.Show("Error code: " + response.StatusCode + " Error: " + response.ReasonPhrase,
                "Greška",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
        }

        public static void MessageGeneralGreska()
        {
            MessageBox.Show("Dogodila se greška. Pokušajte ponovo ili kontaktirajte podršku.",
                "Greška",
                MessageBoxButtons.RetryCancel,
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
            } catch (Exception e) {
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
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);

            return (Image)bmpCrop;
        }

        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = (float)size.Width / (float)sourceWidth;
            nPercentH = (float)size.Height / (float)sourceHeight;

            if (nPercentH > nPercentW) nPercent = nPercentH;
            else nPercent = nPercentW;

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
    }
}