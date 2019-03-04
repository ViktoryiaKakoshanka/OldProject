using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfOrganization.ViewModel
{
    public class AuthorizationWindowViewModel : INotifyPropertyChanged
    {
        private IList<string> _login;

        public IList<string> Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public AuthorizationWindowViewModel()
        {
            Login = new List<string>
            {
                "1",
                "2"
            };
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}