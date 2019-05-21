using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using Service;

namespace SearchFiction.VM
{
    public class SearchVM:DependencyObject
    {
        public SearchVM()
        {
            SendFictionCommand = new DelegateCommand<string>(SendFiction);
        }

        public ICommand SendFictionCommand { get; set; }

        private void SendFiction(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("搜索不能为空！");
                return;
            }
            FictionClientHelper.SearchFiction(name, (item) =>
            {
                var code = item.SelectToken("code") + "";
                if (code != "200")
                {
                    MessageBox.Show(item.SelectToken("msg") + "");
                    FictionList.Clear();
                    return;
                }
                var data = item.SelectToken("data");
                var status = data.SelectToken("status");
                var info = data.SelectToken("info");
                var aladdin = data.SelectToken("aladdin");
                var datas = data.SelectToken("data");
                var list = datas as JArray ?? new JArray();
                list.AddFirst(aladdin);
                FictionList = list;
            });
        }
        #region FictionList(小说列表)

        public static readonly DependencyProperty FictionListProperty = DependencyProperty.Register(
            "FictionList", typeof(JArray), typeof(SearchVM), new PropertyMetadata(new JArray()));

        public JArray FictionList
        {
            get { return (JArray)GetValue(FictionListProperty); }
            set { SetValue(FictionListProperty, value); }
        }
        #endregion

    }
}
