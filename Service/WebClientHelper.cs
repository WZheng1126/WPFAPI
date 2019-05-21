using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class WebClientHelper
    {
        protected static void Post(JObject param, string uri, Action<string> callback)
        {
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add(HttpRequestHeader.ContentType, "text/json; charset=UTF-8");
            var data = Encoding.UTF8.GetBytes(param + "");
            webClient.UploadDataCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    var result = Encoding.UTF8.GetString(e.Result);
                    callback.Invoke(result);
                }
                else
                {
                    Console.WriteLine(e.Error);
                }
            };
            webClient.UploadDataAsync(new Uri(uri), "POST", data);
        }
        protected static void Get(string uri, Action<string> callback)
        {
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add(HttpRequestHeader.ContentType, "text/json; charset=UTF-8");
            webClient.DownloadDataCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    var result = Encoding.UTF8.GetString(e.Result);
                    callback.Invoke(result);
                }
                else
                {
                    Console.WriteLine(e.Error);
                }
            };
            webClient.DownloadDataAsync(new Uri(uri));
        }
    }
}
