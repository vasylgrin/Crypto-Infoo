using System.Windows.Input;
using tSeracherr.WPF.Delegate;
using tSeracherr.WPF.View.UserControls;

namespace tSeracherr.WPF.ViewModel
{
    internal class MainVM : BaseVM
    {
        private static object _currentPage;
        public object CurrentPage { get => _currentPage; set { _currentPage = value; OnPropertyChanged(); } }

        public MainVM()
        {
            CurrentPage = new HomeUC();
        }

        public ICommand HomeButton
        {
            get
            {
                return new DelegateCommand(obj => CurrentPage = new HomeUC());
            }
        }
        public ICommand SerachTokenButton
        {
            get
            {
                return new DelegateCommand(obj => CurrentPage = new SearchUC());
            }
        }
        public ICommand ConvertTokenButton
        {
            get
            {
                return new DelegateCommand(obj => CurrentPage = new ConvertUC());
            }
        }

        public ICommand OptionsButton
        {
            get
            {
                return new DelegateCommand(obj => CurrentPage = new OptionsUC());
            }
        }
    }
}
