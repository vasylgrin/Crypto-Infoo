using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Media3D;
using tSeracherr.WPF.Services;

namespace tSeracherr.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var cultureName = WPF.Properties.Settings.Default.LanguageCode;
            var themeCode = WPF.Properties.Settings.Default.ThemeCode;

            if (!string.IsNullOrWhiteSpace(themeCode))
            {
                if(themeCode == OptionsService.LIGHT_THEME_URL)
                {
                    OptionsService.ChangeTheme(themeCode);
                }
                else if(themeCode == OptionsService.DARK_THEME_URL)
                {
                    OptionsService.ChangeTheme(themeCode);
                }
            }

            if (!string.IsNullOrEmpty(cultureName))
            {
                var culture = CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(cultureName);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
                var c = CultureInfo.CreateSpecificCulture(cultureName);

            }
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
    }
}
