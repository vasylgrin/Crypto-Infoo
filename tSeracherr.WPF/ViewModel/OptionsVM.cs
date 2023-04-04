using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using tSeracherr.WPF.Delegate;

namespace tSeracherr.WPF.ViewModel
{
    class OptionsVM : BaseVM
    {
        public ICommand Light
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    App.Current.Resources.MergedDictionaries.RemoveAt(0);

                    var uri = new Uri("Themes\\LightMode.xaml", UriKind.Relative);
                    var resDict = new ResourceDictionary() { Source = uri };
                    App.Current.Resources.MergedDictionaries.Add(resDict);
                });
            }
        }

        public ICommand Dark
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    App.Current.Resources.MergedDictionaries.RemoveAt(0);

                    var uri = new Uri("Themes\\DarkMode.xaml", UriKind.Relative);
                    var resDict = new ResourceDictionary() { Source = uri };
                    App.Current.Resources.MergedDictionaries.Add(resDict);
                });
            }
        }
    }
}
