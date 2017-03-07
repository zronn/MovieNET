using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.Views;

namespace MovieNet.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ConnectStatusName = "";
            ConnectStatusColor = "Black";

            Signin = new RelayCommand(SigninExecute, SigninCanExecute);
        }

        private string _connectStatusName;

        public string ConnectStatusName
        {
            get { return _connectStatusName; }
            set
            {
                _connectStatusName = value;
                RaisePropertyChanged();
            }
        }

        private string _connectStatusColor;

        public string ConnectStatusColor
        {
            get { return _connectStatusColor; }
            set
            {
                _connectStatusColor = value;
                RaisePropertyChanged();
            }
        }

        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public RelayCommand Signin { get; }

        void SigninExecute()
        {
            MovieDataModelContainer ctx = new MovieDataModelContainer();

            var query = ctx.UserSet.Where(u => u.Login.Equals(Login) && u.Password.Equals(Password));

            if (query.Any())
            {
                ConnectStatusName = "Connexion réussie !";
                ConnectStatusColor = "Green";

                ApplicationWindow applicationWindow = new ApplicationWindow();
                applicationWindow.Show();
                
            }
            else
            {
                ConnectStatusName = "Erreur d'identifiants";
                ConnectStatusColor = "Red";
            }
        }

        bool SigninCanExecute()
        {
            return true;
        }
    }
}
