using System;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using tSeracherr.WPF.Delegate;
using tSeracherr.WPF.Services;

namespace tSeracherr.WPF.ViewModel
{
    class OptionsVM : BaseVM
    {
        public ICommand Light
        {
            get
            {
                return new DelegateCommand(obj => OptionsService.ChangeTheme(OptionsService.LIGHT_THEME_URL));
            }
        }

        public ICommand Dark
        {
            get
            {
                return new DelegateCommand(obj => OptionsService.ChangeTheme(OptionsService.DARK_THEME_URL));
            }
        }

        public ICommand EngLang
        {
            get
            {
                return new DelegateCommand(obj => OptionsService.ChangeLanguage(OptionsService.ENG_LANG_CODE));
            }
        }

        public ICommand UkrLang
        {
            get
            {
                return new DelegateCommand(obj => OptionsService.ChangeLanguage(OptionsService.UKR_LANG_CODE));
            }
        }
    }
}
