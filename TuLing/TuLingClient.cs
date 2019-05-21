using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Service;

namespace TuLing
{
    public class TuLingClient: WebClientHelper
    {
        public static void SendMsg(string msg,Action<JToken> result)
        {
            var param = new JObject();
            param["key"] = "f50a3f0fa09d42f8b2b3161421a73e05";
            param["info"] = msg;
            Post(param, "http://www.tuling123.com/openapi/api", (str) =>
            {
                var job = JObject.Parse(str);
                result.Invoke(job);
            });
        }
    }

}
