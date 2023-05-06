using System.Windows.Input;
using tSeracherr.WPF.Delegate;
using tSeracherr.WPF.View.UserControls;

namespace tSeracherr.WPF.ViewModel
{
    internal class MainVM : BaseVM
    {
        public MainVM()
        {
            CurrentPage = new HomeUC();
        }

        public ICommand HomeButton
        {
            get
            {
                return Navigation(new HomeUC());
            }
        }
        public ICommand SerachTokenButton
        {
            get
            {
                return Navigation(new SearchUC());
            }
        }
        public ICommand ConvertTokenButton
        {
            get
            {
                return Navigation(new ConvertUC());
            }
        }

        public ICommand OptionsButton
        {
            get
            {
                return Navigation(new OptionsUC());
            }
        }

        private ICommand Navigation(object Window)
        {
            return new DelegateCommand(obj => CurrentPage = Window);
        }
    }
}
