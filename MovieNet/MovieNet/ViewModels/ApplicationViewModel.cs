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
            Label = "Bemete";

            MovieDataModelContainer ctx = new MovieDataModelContainer();
            Movies = ctx.MovieSet.ToList();

            var test = 2;
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

    }
}
