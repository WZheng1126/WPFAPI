using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using SearchFiction.Views;
using Service;

namespace SearchFiction
{
    public class MainVM:DependencyObject
    {
        public MainVM()
        {
            ViewRegion = new SearchView();
        }
        #region Content

        public static readonly DependencyProperty ViewRegionProperty = DependencyProperty.Register(
            "ViewRegion", typeof(object), typeof(MainVM), new PropertyMetadata());

        public object ViewRegion
        {
            get { return (object) GetValue(ViewRegionProperty); }
            set { SetValue(ViewRegionProperty, value); }
        }

        #endregion
    }
}
