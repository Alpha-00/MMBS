using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LAMB
{
    class Miscellaneous
    {

    }
    public static class StringExtension
    {
        public static string Substring(this string str, string key)
        {
            return str.Contains(key)?str.Substring(str.IndexOf(key)):str;
        }
        public static string Substring2End(this string str, string key)
        {
            return str.Contains(key) ? str.Substring(str.IndexOf(key)+key.Length) : str;
        }
        public static string RemoveFrom(this string str, string key)
        {
            return str.Contains(key) ? str.Remove(str.IndexOf(key)) : str;
        }
    }
}
