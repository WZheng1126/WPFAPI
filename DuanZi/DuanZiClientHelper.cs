using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using Service;

namespace DuanZi
{
    public class DuanZiClientHelper:WebClientHelper
    {
        public enum TypeEnum
        {
            All=1,Text=2,Image=3,Gif=4,Video=5
        }
        public static void GetData(TypeEnum type,int page,Action<JToken> callback)
        {
            var uri = $"https://www.apiopen.top/satinGodApi?type={(int)type}&page={page}";
            Get(uri, (str) =>
            {
                var job = JToken.Parse(str);
                var code = job.SelectToken("code");
                if (code + "" == "200")
                {
                    callback.Invoke(job);
                    return;
                }
                MessageBox.Show(job.SelectToken("msg")+"");
            });
        }
    }
}
