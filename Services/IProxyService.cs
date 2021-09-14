using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WARP_Buff.Base;

namespace WARP_Buff.Services
{
    public interface IProxyService
    {
        Proxy GetAvailableProxy();
        HttpWebRequest OpenProxy(string proxyAddress);
        string GenerateUniqCode(int length);
    }
}
