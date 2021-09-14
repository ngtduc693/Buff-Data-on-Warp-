using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARP_Buff.Base
{
    public class Entities
    {
        private static string proxyUrl = "https://api.proxyscrape.com?request=getproxies&proxytype=http&timeout=10000&country=all&ssl=all&anonymity=all";
        private static string proxyExecuteUrl = "https://api.cloudflareclient.com/v0a745/reg";
        private static string regexFormular = "[0 - 9]{1,3}.[0-9]{1,3}.[0-9]{ 1,3}.[0-9]{ 1,3}:[0-9]{ 1,5}";
        private static string host = "api.cloudflareclient.com";
        private static string alphabetLetter = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string ProxyUrl 
        { 
            get { return proxyUrl; } 
        }
        public static string RegexFormular
        {
            get { return regexFormular; }
        }
        public static string ProxyExecuteUrl
        {
            get { return proxyExecuteUrl; }
        }
        public static string Host
        {
            get { return host; }
        }
        public static string AlphabetLetter
        {
            get { return alphabetLetter; }
        }
    }
}
