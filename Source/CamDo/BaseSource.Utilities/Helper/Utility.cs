using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace BaseSource.Utilities.Helper
{
    public class Utility
    {
        public static string GetTextFromHtml(string html, int? length)
        {
            var descriptions = Regex.Replace(html, "<(.|\n)*?>", "").Trim();
            descriptions = Regex.Replace(descriptions, "&nbsp;|\n", " ");

            if (length.HasValue && length > 0)
            {
                if (descriptions.Length > length)
                {
                    descriptions = descriptions.Substring(0, length.Value);
                    if (descriptions.LastIndexOf(" ") != -1)
                    {
                        descriptions = descriptions.Substring(0, descriptions.LastIndexOf(" ")) + "...";
                    }
                }
            }

            return descriptions;
        }

        public static string FormatNumber(decimal? price)
        {
            string value = string.Empty;
            if (price.HasValue)
            {
                CultureInfo cul = CultureInfo.GetCultureInfo("en-US");
                value = price.Value.ToString("#,###.####", cul.NumberFormat);
            }
            return value == string.Empty ? "0" : value;
        }

        public static string ConvertToUnSignString(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string GenerateRandomOTP()
        {
            Random rdm = new Random();
            return rdm.Next(0, 9999).ToString("D4");
        }
        public static string RandomString(int size)
        {
            string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random _rng = new Random();
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}
