using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WARP_Buff.Services
{
    public class AccountService : IAccountService
    {
        public void BuffData(string uidUser)
        {
            int numberTotalRequest = 0;
            int numberCurrentRequest = 0;
            var proxyService = new ProxyService();
            var proxy = proxyService.GetAvailableProxy();
            while (proxy.NumberOfProxy > 0)
            {
                if (numberCurrentRequest > proxy.NumberOfProxy)
                    proxy = proxyService.GetAvailableProxy();
                foreach(var item in proxy.ListProxy)
                {
                    var httpRequest = proxyService.OpenProxy(item);
                    if (httpRequest is not null)
                    {
                        var install_id = proxyService.GenerateUniqCode(22);
                        var key = proxyService.GenerateUniqCode(43) + "=";
                        var tos = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fff") + "+07:00";
                        var fcm_token = install_id + ":APA91b" + proxyService.GenerateUniqCode(134);
                        var referer = uidUser;
                        var type = "Android";
                        var locale = "en-GB";
                        var body = new
                        {
                            install_id = install_id,
                            key = key,
                            tos = tos,
                            fcm_token = fcm_token,
                            referrer = referer,
                            warp_enabled = false,
                            type = type,
                            locale = locale
                        };
                        try
                        {
                            var jsonBody = JsonConvert.SerializeObject(body);
                            using (StreamWriter sw = new StreamWriter(httpRequest.GetRequestStream()))
                            {
                                sw.Write(jsonBody);
                            }
                            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                            using (StreamReader sw = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                sw.ReadToEnd();
                            }
                            httpResponse = null;
                            numberTotalRequest++;
                            Console.WriteLine("1 GB just added to your account. Total {0} GB added to your account since you ran this tool", numberTotalRequest);                            
                        }
                        catch (Exception ex)
                        {
                            //Do nothing
                        }
                    }
                }
            }

        }
    }
}
