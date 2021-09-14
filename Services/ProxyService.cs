using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WARP_Buff.Base;

namespace WARP_Buff.Services
{
    public class ProxyService : IProxyService
    {
        public string GenerateUniqCode(int length)
        {    
            string uniqCode = "";
            while (uniqCode.Length < length)
            {
                uniqCode += Entities.AlphabetLetter[new Random().Next(0, Entities.AlphabetLetter.Length - 1)].ToString();
            }
            return uniqCode;
        }

        public Proxy GetAvailableProxy()
        {
            try
            {
                var proxyList = new List<string>();
                var response = (HttpWebResponse)((HttpWebRequest)WebRequest.Create(Entities.ProxyUrl)).GetResponse();
                var conditionToMatch = new Regex(Entities.RegexFormular).Matches(new StreamReader(response.GetResponseStream()).ReadToEnd());
                foreach (object obj in conditionToMatch)
                {
                    var objectValue = (Match)RuntimeHelpers.GetObjectValue(obj);
                    proxyList.Add(objectValue.Value);
                }
                return new Proxy { ListProxy = proxyList, NumberOfProxy = proxyList.Count };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                return new Proxy { ListProxy = null, NumberOfProxy = 0 };
            }
        }

        public HttpWebRequest OpenProxy(string proxyAddress)
        {
            try
            {
                string host = proxyAddress.Split(':')[0];
                string port = proxyAddress.Split(':')[1];
                var proxy = new WebProxy(host, Convert.ToInt32(port));
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Entities.ProxyExecuteUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip");
                httpWebRequest.ContentType = "application/json; charset=UTF-8";
                httpWebRequest.Host = Entities.Host;
                httpWebRequest.KeepAlive = true;
                httpWebRequest.UserAgent = "okhttp/3.12.1";
                httpWebRequest.Proxy = proxy;
                return httpWebRequest;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                return null;
            }
        }
    }
}
