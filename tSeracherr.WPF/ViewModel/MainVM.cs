using System.Windows.Input;
using tSeracherr.WPF.Delegate;
using tSeracherr.WPF.Services;
using tSeracherr.WPF.View.UserControls;

namespace tSeracherr.WPF.ViewModel
{
    internal class MainVM : BaseVM
    {
        private static object _currentPage;
        private int _borderOpacity;

        public object CurrentPage { get => _currentPage; set { _currentPage = value; OnPropertyChanged(); } }
        public int BorderOpacity
        {
            get { return _borderOpacity; }
            set { _borderOpacity = value; OnPropertyChanged(); }
        }


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
