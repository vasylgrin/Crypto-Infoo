using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace tSeracherr.WPF.ViewModel
{
    public class BaseVM : INotifyPropertyChanged
    {
        private static object _currentPage;
        public object CurrentPage { get => _currentPage; set { _currentPage = value; OnPropertyChanged(); } }


        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


    }
}
