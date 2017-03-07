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
            List<Movie> movies = new List<Movie>();
            Label = "Bemete";

            MovieDataModelContainer ctx = new MovieDataModelContainer();

            Movie movie = new Movie();

            movies = ctx.MovieSet.ToList();
        }

        private string _label;

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

    }
}
