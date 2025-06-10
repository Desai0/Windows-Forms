using _07___Graphics;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace FavoriteMoviesApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _newMovieTitle;

        public ObservableCollection<Movie> AllMovies { get; set; }
        public ObservableCollection<Movie> FavoriteMovies { get; set; }

        public string NewMovieTitle
        {
            get => _newMovieTitle;
            set
            {
                if (_newMovieTitle == value) return;
                _newMovieTitle = value;
                OnPropertyChanged(nameof(NewMovieTitle));
            }
        }

        public ICommand AddMovieCommand { get; }
        public ICommand AddToFavoritesCommand { get; }
        public ICommand RemoveFromFavoritesCommand { get; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            AllMovies = new ObservableCollection<Movie>();
            FavoriteMovies = new ObservableCollection<Movie>();

            AddMovieCommand = new RelayCommand(x => AddMovie(), x => !string.IsNullOrWhiteSpace(NewMovieTitle));

            AddToFavoritesCommand = new RelayCommand(param => AddToFavorites(param as Movie), param => param is Movie movie && !FavoriteMovies.Contains(movie));

            RemoveFromFavoritesCommand = new RelayCommand(param => RemoveFromFavorites(param as Movie));
        }

        private void AddMovie()
        {
            AllMovies.Add(new Movie { Title = NewMovieTitle });
            NewMovieTitle = string.Empty;
        }

        private void AddToFavorites(Movie movie)
        {
            if (movie != null && !FavoriteMovies.Any(m => m.Title == movie.Title))
            {
                FavoriteMovies.Add(movie);
            }
        }

        private void RemoveFromFavorites(Movie movie)
        {
            if (movie != null)
            {
                FavoriteMovies.Remove(movie);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);
    }
}