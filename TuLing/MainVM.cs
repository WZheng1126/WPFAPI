using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using Service;

namespace TuLing
{
    

    public class MainVM:DependencyObject
    {
        public MainVM()
        {
            SendMsgCommand = new DelegateCommand<string>(SendMsg);
            ClearMsgListCommand = new DelegateCommand(ClearMsg);
        }

        public ICommand SendMsgCommand { get; set; }
        public ICommand ClearMsgListCommand { get; set; }


        private void SendMsg(string msg)
        {
            TuLingClient.SendMsg(msg,(result) =>
            {
                MsgList.Add(CreateMsg("我：", msg));
                MsgList.Add(CreateMsg("图灵机器人：", result.SelectToken("text") + ""));
                Console.WriteLine(result.SelectToken("code"));
            });
        }

        private void ClearMsg()
        {
            MsgList.Clear();
        }

        #region MsgList

        public static readonly DependencyProperty MsgListProperty = DependencyProperty.Register(
            "MsgList", typeof(JArray), typeof(MainVM), new PropertyMetadata(new JArray()));

        public JArray MsgList
        {
            get { return (JArray) GetValue(MsgListProperty); }
            set { SetValue(MsgListProperty, value); }
        }

        #endregion


        private JObject CreateMsg(string person, string msg)
        {
            var job = new JObject();
            job["person"] = person;
            job["msg"] = msg;
            return job;
        }
    }
}
