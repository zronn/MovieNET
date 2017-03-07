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
    public class ApplicationViewModel : ViewModelBase
    {
        public ApplicationViewModel()
        {
            ToFilm = new RelayCommand(ToFilmExecute, ToFilmCanExecute);
            ToProfil = new RelayCommand(ToProfilExecute, ToProfilCanExecute);
            
            SwitchView = 0;
            Label = "Bemete";

            MovieDataModelContainer ctx = new MovieDataModelContainer();
            Movies = ctx.MovieSet.ToList();
   
        }

        private int _switchView;

        public int SwitchView
        {
            get { return _switchView; }
            set {
                _switchView = value;
                RaisePropertyChanged();
            }
        }


        private List<Movie> _movies;

        public List<Movie> Movies
        {
            get { return _movies; }
            set { _movies = value; }
        }


        private string _label;

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        public RelayCommand ToFilm { get; }
        public RelayCommand ToProfil { get; }


        void ToFilmExecute()
        {
            SwitchView = 0;
        }

        void ToProfilExecute()
        {
            SwitchView = 1;
        }

        bool ToFilmCanExecute()
        {
            return true;
        }

        bool ToProfilCanExecute()
        {
            return true;
        }
    }
}
