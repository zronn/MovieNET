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
            SwitchView = 0;
            SubSwitchView = 0;

            ConnectStatusName = "";
            ConnectStatusColor = "Black";

            UserConnected = "";

            InscriptionStatusName = "";

            MovieDataModelContainer ctx = new MovieDataModelContainer();
            Movies = ctx.MovieSet.ToList();

            Signin = new RelayCommand(SigninExecute, SigninCanExecute);
            Signup = new RelayCommand(SignupExecute, SignupCanExecute);

            ToSignin = new RelayCommand(ToSigninExecute, ToSigninCanExecute);
            ToSignup = new RelayCommand(ToSignupExecute, ToSignupCanExecute);

            ToProfil = new RelayCommand(ToProfilExecute, ToProfilCanExecute);
            ToMovie = new RelayCommand(ToMovieExecute, ToMovieCanExecute);
        }

        private int _switchView;
        private int _subSwitchView;
        private string _connectStatusName;
        private string _connectStatusColor;
        private string _inscriptionStatusName;

        private string _userConnected;

        private string _loginIn;
        private string _passwordIn;

        private string _loginUp;
        private string _passwordUp;

        private List<Movie> _movies;

        public int SwitchView
        {
            get { return _switchView; }
            set
            {
                _switchView = value;
                RaisePropertyChanged();
            }
        }
        public int SubSwitchView
        {
            get { return _subSwitchView; }
            set
            {
                _subSwitchView = value;
                RaisePropertyChanged();
            }
        }
        public string ConnectStatusName
        {
            get { return _connectStatusName; }
            set
            {
                _connectStatusName = value;
                RaisePropertyChanged();
            }
        }
        public string ConnectStatusColor
        {
            get { return _connectStatusColor; }
            set
            {
                _connectStatusColor = value;
                RaisePropertyChanged();
            }
        }
        public string InscriptionStatusName
        {
            get { return _inscriptionStatusName; }
            set
            {
                _inscriptionStatusName = value;
                RaisePropertyChanged();
            }
        }
        public string UserConnected
        {
            get { return _userConnected; }
            set
            {
                _userConnected = value;
                RaisePropertyChanged();
            }
        }
        public string LoginIn
        {
            get { return _loginIn; }
            set { _loginIn = value; }
        }
        public string PasswordIn
        {
            get { return _passwordIn; }
            set { _passwordIn = value; }
        }
        public string LoginUp
        {
            get { return _loginIn; }
            set { _loginIn = value; }
        }
        public string PasswordUp
        {
            get { return _passwordUp; }
            set { _passwordUp = value; }
        }
        public List<Movie> Movies
        {
            get { return _movies; }
            set { _movies = value; }
        }

        public RelayCommand Signin { get; }
        public RelayCommand Signup { get; }
        public RelayCommand ToSignin { get; }
        public RelayCommand ToSignup { get; }
        public RelayCommand ToProfil { get; }
        public RelayCommand ToMovie { get; }

        /*
         * Méthode pour la connexion
         */
        void SigninExecute()
        {
            MovieDataModelContainer ctx = new MovieDataModelContainer();

            var query = ctx.UserSet.Where(u => u.Login.Equals(LoginIn) && u.Password.Equals(PasswordIn));

            if (query.Any())
            {
                ConnectStatusName = "Connexion réussie !";
                ConnectStatusColor = "Green";

                SwitchView = 2;
                
                //ApplicationWindow applicationWindow = new ApplicationWindow();
                //applicationWindow.Show();
                
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
        
        /*
         * Méthode pour aller vers la vue de connexion
         */
        void ToSigninExecute()
        {
            SwitchView = 0;
        }
        bool ToSigninCanExecute()
        {
            return true;
        }

        /*
         * Méthode pour la connexion
         */
        void SignupExecute()
        {
            MovieDataModelContainer ctx = new MovieDataModelContainer();

            var query = ctx.UserSet.Where(u => u.Login.Equals(LoginUp));

            if (query.Any())
            {
                // Le nom d'utilisateur choisi existe déjà, l'inscription n'est pas prise en compte
                InscriptionStatusName = "Ce nom d'utilisateur existe déjà!";
            }
            else
            {
                // Ajout du nouvel utilisateur
                User user = new User();

                user.Login = LoginUp;
                user.Password = PasswordUp;

                ctx.UserSet.Add(user);

                ctx.SaveChanges();

                ConnectStatusColor = "Green";
                ConnectStatusName = LoginUp + ", votre inscription a bien été prise en compte!";

                // TODO Vider les valeur du champs sinon elles sont populate!

                SwitchView = 0;
            }
        }
        bool SignupCanExecute()
        {
            return true;
        }

        /*
         * Méthode pour aller vers la vue d'inscription
         */
        void ToSignupExecute()
        {
            SwitchView = 1;
        }
        bool ToSignupCanExecute()
        {
            return true;
        }

        /*
         * Méthode pour aller vers la sous-vue de profil
         */
        void ToProfilExecute()
        {
            SubSwitchView = 2;
        }
        bool ToProfilCanExecute()
        {
            return true;
        }
        
        /*
         * Méthode pour aller vers la sous-vue des films
         */
        void ToMovieExecute()
        {
            SubSwitchView = 1;
        }
        bool ToMovieCanExecute()
        {
            return true;
        }
    }
}
