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

            UserIdConnected = 0;

            InscriptionStatusName = "";

            MovieDataModelContainer ctx = new MovieDataModelContainer();
            Movies = ctx.MovieSet.ToList();

            Signin = new RelayCommand(SigninExecute, SigninCanExecute);
            Signup = new RelayCommand(SignupExecute, SignupCanExecute);

            ToSignin = new RelayCommand(ToSigninExecute, ToSigninCanExecute);
            ToSignup = new RelayCommand(ToSignupExecute, ToSignupCanExecute);

            ToProfil = new RelayCommand(ToProfilExecute, ToProfilCanExecute);
            ToAddMovie = new RelayCommand(ToAddMovieExecute, ToAddMovieCanExecute);

            ToValidAddMovie = new RelayCommand(ToValidAddMovieExecute, ToValidAddMovieCanExecute);

            ToMovie = new RelayCommand(ToMovieExecute, ToMovieCanExecute);
        }

        private int _switchView;
        private int _subSwitchView;
        private string _connectStatusName;
        private string _connectStatusColor;
        private string _inscriptionStatusName;

        private int _userIdConnected;

        private string _loginIn;
        private string _passwordIn;

        private string _loginUp;
        private string _passwordUp;

        private string _titleAdd;
        private string _descriptionAdd;

        private string _addMovieStatusName;

        private List<Movie> _movies;
        private List<Type> _types;

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
        public int UserIdConnected
        {
            get { return _userIdConnected; }
            set
            {
                _userIdConnected = value;
                RaisePropertyChanged();
            }
        }


        

        public string AddMovieStatusName
        {
            get { return _addMovieStatusName; }
            set
            {
                _addMovieStatusName = value;
                RaisePropertyChanged();
            }
        }


        public string TitleAdd
        {
            get { return _titleAdd; }
            set { _titleAdd = value; }
        }

        public string DescriptionAdd
        {
            get { return _descriptionAdd; }
            set { _descriptionAdd = value; }
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

        public List<Type> Types
        {
            get { return _types; }
            set { _types = value; }
        }


        public RelayCommand Signin { get; }
        public RelayCommand Signup { get; }
        public RelayCommand ToSignin { get; }
        public RelayCommand ToSignup { get; }
        public RelayCommand ToProfil { get; }
        public RelayCommand ToAddMovie { get; }
        public RelayCommand ToValidAddMovie { get; }
        public RelayCommand ToMovie { get; }

        /*
         * Méthode pour la connexion
         */
        void SigninExecute()
        {
            MovieDataModelContainer ctx = new MovieDataModelContainer();

            var query = ctx.UserSet.Where(u => u.Login.Equals(LoginIn) && u.Password.Equals(PasswordIn)).ToList();

            if (query.Any())
            {
                ConnectStatusName = "Connexion réussie !";
                ConnectStatusColor = "Green";

                UserIdConnected = query[0].Id;

                SwitchView = 2;
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
         * Méthode pour aller vers la sous-vue formulaire d'ajout de film
         */
        void ToAddMovieExecute()
        {
            SubSwitchView = 1;

            /*MovieDataModelContainer ctx = new MovieDataModelContainer();
            Types = ctx.TypeSet.ToList();*/
        }
        bool ToAddMovieCanExecute()
        {
            return true;
        }

        /*
         * Méthode pour valider le formulaire de film
         */
        void ToValidAddMovieExecute()
        {
            var Valid = true;
            if (String.IsNullOrEmpty(TitleAdd))
            {
                AddMovieStatusName = "Veuillez Ajouter un titre";
                Valid = false;
            }
            if (String.IsNullOrEmpty(DescriptionAdd))
            {
                AddMovieStatusName = "Veuillez Ajouter une description";
                Valid = false;
            }

        }
        bool ToValidAddMovieCanExecute()
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
