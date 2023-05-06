using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using tSeracherr.WPF.Delegate;

namespace tSeracherr.WPF.Services
{
    internal static class OptionsService
    {
        public const string LIGHT_THEME_URL = "Themes\\LightMode.xaml";
        public const string DARK_THEME_URL = "Themes\\DarkMode.xaml";        
        
        public const string UKR_LANG_CODE = "uk-UA";
        public const string ENG_LANG_CODE = "en-US";

        public static void ChangeLanguage(string langCode)
        {
            Properties.Settings.Default.LanguageCode = langCode;
            Properties.Settings.Default.Save();

            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            Application.Current.Shutdown();
        }

        public static void ChangeTheme(string inputUri)
        {
            Properties.Settings.Default.ThemeCode = inputUri;
            Properties.Settings.Default.Save();

            Application.Current.Resources.MergedDictionaries.RemoveAt(0);

            var uri = new Uri(inputUri, UriKind.Relative);
            var resDict = new ResourceDictionary() { Source = uri };

            Application.Current.Resources.MergedDictionaries.Add(resDict);
        }
    }
}
