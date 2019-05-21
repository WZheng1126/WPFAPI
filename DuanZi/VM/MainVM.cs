using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace DuanZi.VM
{
    public class MainVM:DependencyObject
    {
        public MainVM()
        {
            UpData();
        }

        public void UpData()
        {
            DuanZiClientHelper.GetData(DuanZiClientHelper.TypeEnum.All, 0, (item) =>
            {
                MainData["AllList"] = item.SelectToken("data");
            });
            DuanZiClientHelper.GetData(DuanZiClientHelper.TypeEnum.Text, 0, (item) =>
            {
                MainData["TextList"] = item.SelectToken("data");
            });
            DuanZiClientHelper.GetData(DuanZiClientHelper.TypeEnum.Image, 0, (item) =>
            {
                MainData["ImageList"] = item.SelectToken("data");
            });
            DuanZiClientHelper.GetData(DuanZiClientHelper.TypeEnum.Video, 0, (item) =>
            {
                MainData["VideoList"] = item.SelectToken("data");
            });
        }
        #region MainData

        public static readonly DependencyProperty MainDataProperty = DependencyProperty.Register(
            "MainData", typeof(JObject), typeof(MainVM), new PropertyMetadata(new JObject()));

        public JObject MainData
        {
            get { return (JObject) GetValue(MainDataProperty); }
            set { SetValue(MainDataProperty, value); }
        }

        #endregion
    }
}
