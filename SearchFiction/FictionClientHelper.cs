using Newtonsoft.Json.Linq;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFiction
{
    public class FictionClientHelper: WebClientHelper
    {
        public static void SearchFiction(string name,Action<JToken> callback)
        {
            var uri = $"https://www.apiopen.top/novelInfoApi?name={name}";
            Get(uri, (str) =>
            {
                callback.Invoke(JToken.Parse(str));
            });
        }
    }
}
