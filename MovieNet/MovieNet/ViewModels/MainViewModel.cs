using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MovieNet.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            SwitchView = 0;
            SubSwitchView = 0;

            StatusColor = "";
            ConnectStatusName = "";
            InscriptionStatusName = "";
            ProfilEditStatusName = "";
            AddMovieStatusName = "";

            UserIdConnected = 0;
            UserNameConnected = "";

            MovieDataModelContainer ctx = new MovieDataModelContainer();
            Movies = ctx.MovieSet.ToList();
            
            Types = ctx.TypeSet.ToList();            

            Signin = new RelayCommand(SigninExecute, SigninCanExecute);
            Signup = new RelayCommand(SignupExecute, SignupCanExecute);

            ProfilEdit = new RelayCommand(ProfilEditExecute, ProfilEditCanExecute);
            MovieSearch = new RelayCommand(MovieSearchExecute, MovieSearchCanExecute);

            ToSignin = new RelayCommand(ToSigninExecute, ToSigninCanExecute);
            ToSignup = new RelayCommand(ToSignupExecute, ToSignupCanExecute);

            ToProfil = new RelayCommand(ToProfilExecute, ToProfilCanExecute);
            ToAddMovie = new RelayCommand(ToAddMovieExecute, ToAddMovieCanExecute);
            ToValidAddMovie = new RelayCommand(ToValidAddMovieExecute, ToValidAddMovieCanExecute);
            ToMovie = new RelayCommand(ToMovieExecute, ToMovieCanExecute);
            ToMovieDetail = new RelayCommand<MovieNet.Movie>((s) => ToMovieDetailExecute(s));
            ToMovieDelete = new RelayCommand<MovieNet.Movie>((s) => ToMovieDeleteExecute(s));
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

        private string _titleAdd;
        private string _descriptionAdd;
        private int _type;

        private string _addMovieStatusName;

        private string _movieTitleSearch;

        private string _movieDetailTitle;
        private string _movieDetailDescription;
        private string _movieDetailUser;
        private string _movieDetailType;
        private string _movieDetailNote;

        private string _deleteStatusName;
        

        private List<Movie> _movies;
        private List<Type> _types;
        private List<Comment> _comments;

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
        public string AddMovieStatusName
        {
            get { return _addMovieStatusName; }
            set
            {
                _addMovieStatusName = value;
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

        public int Type
        {
            get { return _type; }
            set
            {
                _type = value;
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
        public string MovieTitleSearch
        {
            get { return _movieTitleSearch; }
            set
            {
                _movieTitleSearch = value;
                RaisePropertyChanged();
            }
        }

        public string MovieDetailTitle
        {
            get { return _movieDetailTitle; }
            set
            {
                _movieDetailTitle = value;
                RaisePropertyChanged();
            }
        }
        public string MovieDetailDescription
        {
            get { return _movieDetailDescription; }
            set
            {
                _movieDetailDescription = value;
                RaisePropertyChanged();
            }
        }

        public string MovieDetailUser
        {
            get { return _movieDetailUser; }
            set { _movieDetailUser = value; }
        }

        public string MovieDetailType
        {
            get { return _movieDetailType; }
            set { _movieDetailType = value; }
        }

        public string MovieDetailNote
        {
            get { return _movieDetailNote; }
            set { _movieDetailNote = value; }
        }

    
        public string DeleteStatusName
        {
            get { return _deleteStatusName; }
            set
            {
                _deleteStatusName = value; 
                RaisePropertyChanged();
            }
        }


        public List<Movie> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                RaisePropertyChanged();
            }
        }
        public List<Type> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                RaisePropertyChanged();
            }
        }

        public List<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value;  }
        }

        public RelayCommand Signin { get; }
        public RelayCommand Signup { get; }
        public RelayCommand ToSignin { get; }
        public RelayCommand ToSignup { get; }
        public RelayCommand ToProfil { get; }
        public RelayCommand ToAddMovie { get; }
        public RelayCommand ToValidAddMovie { get; }
        public RelayCommand ToMovie { get; }
        public RelayCommand ToDisconnect { get; }
        public RelayCommand ProfilEdit { get; }
        public RelayCommand MovieSearch { get; }
        public RelayCommand<MovieNet.Movie> ToMovieDetail { get; private set; }
        public RelayCommand<MovieNet.Movie> ToMovieDelete { get; private set; }



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
                StatusColor = "Green";

                UserIdConnected = query[0].Id;
                UserNameConnected = LoginIn;

                SwitchView = 2;
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
                if (String.IsNullOrEmpty(LoginUp))
                {
                    InscriptionStatusName = "Veuillez renseigner un nom d'utilisateur";
                }
                else if (String.IsNullOrEmpty(PasswordUp))
                {
                    InscriptionStatusName = "Veuillez renseigner un mot de passe";
                } else
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

            MovieDataModelContainer ctx = new MovieDataModelContainer();
            Movie movie = new Movie();

            movie.Title = TitleAdd;
            movie.Description = DescriptionAdd;
            movie.User = ctx.UserSet.Find(UserIdConnected); ;
            movie.Type = ctx.TypeSet.Find(Type);
            ctx.MovieSet.Add(movie);
            ctx.SaveChanges();

            Movies = ctx.MovieSet.ToList();

            SubSwitchView = 0;

        }
        bool ToValidAddMovieCanExecute()
        {
            if (String.IsNullOrEmpty(TitleAdd))
            {
                AddMovieStatusName = "Veuillez ajouter un titre";
                return false;
            }
            else if (String.IsNullOrEmpty(DescriptionAdd))
            {
                AddMovieStatusName = "Veuillez ajouter une description";
                return false;

            }
            else if (Type == default(int))
            {
                AddMovieStatusName = "Veuillez choisir une catégorie de film";
                return false;
            }
            else
            {
                return true;
            }
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
            SubSwitchView = 0;
        }
        bool ToMovieCanExecute()
        {
            return true;
        }

        /*
         * Méthode pour modifier le profil de l'utilisateur
         */
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

        /*
         * Méthode pour effectuer une recherche sur les films
         */
        void MovieSearchExecute()
        {
            MovieDataModelContainer ctx = new MovieDataModelContainer();

            Movies = ctx.MovieSet.Where(m => m.Title.Contains(MovieTitleSearch)).ToList();
        }
        bool MovieSearchCanExecute()
        {
            return true;
        }

        private void ToMovieDetailExecute(MovieNet.Movie ListMovie)
        {
            SubSwitchView = 3;
            MovieDetailTitle = ListMovie.Title;
            MovieDetailDescription = ListMovie.Description;
            MovieDetailType = ListMovie.Type.Value;
            MovieDetailUser = ListMovie.User.Login;

            int NoteAvg = 0;

            if (ListMovie.Note.Count > 0)
            {
                int NoteCount = ListMovie.Note.Count;

                foreach (MovieNet.Note note in ListMovie.Note)
                {
                    NoteAvg += note.Value;
                }

                NoteAvg = NoteAvg / NoteCount;
            }

            if (NoteAvg == 0)
                MovieDetailNote = "Aucune note pour ce film";
            else
                MovieDetailNote = NoteAvg.ToString();

            MovieDataModelContainer ctx = new MovieDataModelContainer();
            Comments = ctx.CommentSet.Where(c => c.Movie.Id.Equals(ListMovie.Id)).ToList();
        }

        private void ToMovieDeleteExecute(MovieNet.Movie ListMovie)
        {
            MovieDataModelContainer ctx = new MovieDataModelContainer();

            if (ListMovie.User.Id != UserIdConnected)
            {
                DeleteStatusName = "Vous n'avez le droit de supprimer ce film";
            }
            else
            {
                Movie film = ctx.MovieSet.Find(ListMovie.Id);

                ctx.MovieSet.Remove(film);
                ctx.SaveChanges();

                DeleteStatusName = "";

                Movies = ctx.MovieSet.ToList();
                SubSwitchView = 0;
            }
        }
    }
}
