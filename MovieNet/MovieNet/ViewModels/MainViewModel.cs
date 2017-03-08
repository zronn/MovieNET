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

            StatusColor = "Black";
            ConnectStatusName = "";
            InscriptionStatusName = "";
            ProfilEditStatusName = "";

            UserIdConnected = 0;
            UserNameConnected = "";

            MovieDataModelContainer ctx = new MovieDataModelContainer();
            Movies = ctx.MovieSet.ToList();

            Signin = new RelayCommand(SigninExecute, SigninCanExecute);
            Signup = new RelayCommand(SignupExecute, SignupCanExecute);

            ToSignin = new RelayCommand(ToSigninExecute, ToSigninCanExecute);
            ToSignup = new RelayCommand(ToSignupExecute, ToSignupCanExecute);

            ToProfil = new RelayCommand(ToProfilExecute, ToProfilCanExecute);
            ToMovie = new RelayCommand(ToMovieExecute, ToMovieCanExecute);

            ProfilEdit = new RelayCommand(ProfilEditExecute, ProfilEditCanExecute);

            ToDisconnect = new RelayCommand(ToDisconnectExecute, ToDisconnectCanExecute);
        }

        private int _switchView;
        private int _subSwitchView;

        private string _statusColor;
        private string _connectStatusName;
        private string _inscriptionStatusName;
        private string _profilEditStatusName;

        private int _userIdConnected;
        private string _userNameConnected;

        private string _loginIn;
        private string _passwordIn;

        private string _loginUp;
        private string _passwordUp;

        private string _loginEdit;
        private string _passwordEdit;
        private string _passwordEditConfirm;

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

        public string StatusColor
        {
            get { return _statusColor; }
            set
            {
                _statusColor = value;
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
        public string InscriptionStatusName
        {
            get { return _inscriptionStatusName; }
            set
            {
                _inscriptionStatusName = value;
                RaisePropertyChanged();
            }
        }
        public string ProfilEditStatusName
        {
            get { return _profilEditStatusName; }
            set
            {
                _profilEditStatusName = value;
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
        public string UserNameConnected
        {
            get { return _userNameConnected; }
            set
            {
                _userNameConnected = value;
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
            get { return _loginUp; }
            set { _loginUp = value; }
        }
        public string PasswordUp
        {
            get { return _passwordUp; }
            set { _passwordUp = value; }
        }

        public string LoginEdit
        {
            get { return _loginEdit; }
            set { _loginEdit = value; }
        }
        public string PasswordEdit
        {
            get { return _passwordEdit; }
            set { _passwordEdit = value; }
        }
        public string PasswordEditConfirm
        {
            get { return _passwordEditConfirm; }
            set { _passwordEditConfirm = value; }
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
        public RelayCommand ToDisconnect { get; }
        public RelayCommand ProfilEdit { get; }

        /*
         * Méthode pour la connexion
         */
        void SigninExecute()
        {
            MovieDataModelContainer ctx = new MovieDataModelContainer();

            var query = ctx.UserSet.Where(u => u.Login.Equals(LoginIn) && u.Password.Equals(PasswordIn)).ToList();

            if (query.Any())
            {
                SwitchView = 2;

                UserIdConnected = query[0].Id;
                UserNameConnected = query[0].Login; // La value n'est pas bindée dans l'édition ?
            }
            else
            {
                ConnectStatusName = "Erreur d'identifiants";
                StatusColor = "Red";
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

                StatusColor = "Green";
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

        void ProfilEditExecute()
        {
            StatusColor = "";
            // Si uniquement le login
            if (String.IsNullOrEmpty(LoginEdit))
            {
                StatusColor = "Red";
                ProfilEditStatusName = "Veuillez ajouter un nom d'utilisateur";
            }
            else if (!String.IsNullOrEmpty(LoginEdit) && !String.IsNullOrEmpty(PasswordEdit) && !String.IsNullOrEmpty(PasswordEditConfirm))
            {
                if (PasswordEdit != PasswordEditConfirm)
                {
                    StatusColor = "Red";
                    ProfilEditStatusName = "Les deux mots de passe ne correspondent pas";
                }
                else
                {
                    // Si le login est différent de l'utilisateur connecté, on le modifie
                    if (LoginEdit != UserNameConnected)
                    {
                        MovieDataModelContainer ctx = new MovieDataModelContainer();

                        var user = ctx.UserSet.Single(x => x.Id == UserIdConnected);
                        user.Login = LoginEdit;
                        user.Password = PasswordEdit;
                        ctx.SaveChanges();

                        UserNameConnected = LoginEdit;
                        StatusColor = "Green";
                        ProfilEditStatusName = "Le nom d'utilisateur et le password ont bien été modifiés!";
                    }
                    // Sinon, on modifie uniquement le mot de passe
                    else
                    {
                        MovieDataModelContainer ctx = new MovieDataModelContainer();

                        var user = ctx.UserSet.Single(x => x.Id == UserIdConnected);
                        user.Password = PasswordEdit;
                        ctx.SaveChanges();

                        StatusColor = "Green";
                        ProfilEditStatusName = "Le password a bien été modifié!";
                    }
                }
                // Modification du nom et du mot de passe, si même pseudo que l'actuel on ne le change pas.
            }
            else if (!String.IsNullOrEmpty(LoginEdit))
            {
                if (LoginEdit == UserNameConnected)
                {
                    StatusColor = "Red";
                    ProfilEditStatusName = "Ce login est déjà le votre actuellement";
                }
                else
                {
                    MovieDataModelContainer ctx = new MovieDataModelContainer();

                    var user = ctx.UserSet.Single(x => x.Id == UserIdConnected);
                    user.Login = LoginEdit;
                    ctx.SaveChanges();

                    UserNameConnected = LoginEdit;
                    StatusColor = "Green";
                    ProfilEditStatusName = "Le nom d'utilisateur a bien été modifié!";
                }
            }
        }
        bool ProfilEditCanExecute()
        {
            return true;
        }

        /*
         * Méthode pour se déconnecter
         */
        void ToDisconnectExecute()
        {
            SwitchView = 0;
            SubSwitchView = 0;
            UserIdConnected = 0;
            StatusColor = "Green";
            ConnectStatusName = "Vous avez correctement été déconnecté!";
        }
        bool ToDisconnectCanExecute()
        {
            return true;
        }
    }
}
