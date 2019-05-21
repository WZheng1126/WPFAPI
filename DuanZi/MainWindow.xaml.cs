using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DuanZi.VM;
using Newtonsoft.Json.Linq;

namespace DuanZi
{
    public class TypeTemplate : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var job = item as JObject;
            var control = container as FrameworkElement;
            var type = job.SelectToken("type") + "";
            if (type == "image")
            {
                return control.FindResource("ImageDataTemplate") as DataTemplate;
            }
            else if (type == "video")
            {
                return control.FindResource("VideoDataTemplate") as DataTemplate;
            }
            else if (type == "text")
            {
                return control.FindResource("TextDataTemplate") as DataTemplate;
            }
            else if (type == "gif")
            {
                return control.FindResource("GifDataTemplate") as DataTemplate;
            }

            return control.FindResource("TextDataTemplate") as DataTemplate;
        }
    }

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();
        }

        private void ScrollViewer_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            bool isAtButtom = false;
            
            double dVer = scrollViewer.VerticalOffset;
            
            double dViewport = scrollViewer.ViewportHeight;
            
            double dExtent = scrollViewer.ExtentHeight;

            if (dVer != 0)
            {
                if (dVer + dViewport == dExtent)
                {
                    isAtButtom = true;
                }
                else
                {
                    isAtButtom = false;
                }
            }
            else
            {
                isAtButtom = false;
            }

            if (scrollViewer.VerticalScrollBarVisibility == ScrollBarVisibility.Disabled
                || scrollViewer.VerticalScrollBarVisibility == ScrollBarVisibility.Hidden)
            {
                isAtButtom = true;
            }

            if (isAtButtom)
            {
                (this.DataContext as MainVM).UpData();
            }
        }
    }
}
