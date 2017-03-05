using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace MovieNet
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Name = "Veuillez vous connecter";
            MyCommand = new RelayCommand(MyCommandExecute, MyCommandeCanExecute);
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
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


        public RelayCommand MyCommand { get; }

        void MyCommandExecute()
        {

            Name = "Hello click!";
        }

        bool MyCommandeCanExecute()
        {
            return true;
        }
    }
}
