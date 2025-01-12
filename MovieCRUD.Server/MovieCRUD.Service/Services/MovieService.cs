using MovieCRUD.DataAccess.Entity;
using MovieCRUD.Repository.Repository;
using MovieCRUD.Service.DTOs;

namespace MovieCRUD.Service.Services;
public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    public MovieService()
    {
        _movieRepository = new MovieRepository();
    }
    public Guid AddMovie(MovieCreatDto movie)
    {
        var _movie = ConvertToEntity(movie);
        return _movieRepository.AddMovie(_movie);
    }
    public MovieGetDto GetMovieById(Guid id)
    {
        var movie = _movieRepository.GetMovieById(id);
        return ConvertToDto(movie);
    }
    public void UpdateMovie(MovieGetDto movie)
    {
        _movieRepository.UpdateMovie(ConvertToEntity(movie));
    }
    public void DeleteMovie(Guid id)
    {
        _movieRepository.DeleteMovie(id);
    }
    public List<MovieGetDto> GetAll()
    {
        var movieList = _movieRepository.GetAll();
        return movieList.Select(mov => ConvertToDto(mov)).ToList();
    }
    public List<MovieGetDto> GetAllMoviesByDirector(string director)
    {
        var movieList = GetAll();
        return movieList.Where(mov => mov.Director.ToLower() == director.ToLower()).ToList();
    }
    public MovieGetDto GetTopRatedMovie()
    {
        var movieList = GetAll();
        var maxRate = movieList.Max(movie => movie.Rating);
        var movie = movieList.FirstOrDefault(mov => mov.Rating == maxRate);
        if (movie is null)
        {
            throw new Exception("Storage is Empty !");
        }

        return movie;
    }
    public List<MovieGetDto> GetMoviesReleasedAfterYear(int year)
    {
        var movieList = GetAll();
        return movieList.Where(mov => mov.ReleaseDate > year).ToList();
    }
    public MovieGetDto GetHighestGrossingMovie()
    {
        var movies = GetAll();
        var higgestGrosingMovie = movies.Max(mov => mov.BoxOfficeEarnings);
        var movie = movies.FirstOrDefault(mov => mov.BoxOfficeEarnings == higgestGrosingMovie);
        if(movie is null)
        {
            throw new Exception("Storage is empty!");
        }

        return movie;
    }
    public List<MovieGetDto> SearchMoviesByTitle(string keyword)
    {
        var movies = GetAll();
        return movies.Where(mov => mov.Title.ToLower().Contains(keyword.ToLower())).ToList();
    }
    public List<MovieGetDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        var movies = GetAll();
        return movies.Where(mov => mov.DurationMinutes > minMinutes && mov.DurationMinutes < maxMinutes).ToList();
    }
    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        var movies = GetAllMoviesByDirector(director);
        return movies.Sum(mov => mov.BoxOfficeEarnings);
    }
    public List<MovieGetDto> GetMoviesSortedByRating()
    {
        var movies = GetAll();
        return movies.OrderByDescending(mov => mov.Rating).ToList();
    }
    public List<MovieGetDto> GetRecentMovies(int years)
    {
        var movies = GetAll();
        return movies.Where(mov => mov.ReleaseDate == years).ToList();
    }
    private Movie ConvertToEntity(MovieCreatDto movie)
    {
        return new Movie
        { 
            Id = Guid.NewGuid(),
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate,
        };
    }
    private Movie ConvertToEntity(MovieGetDto movie)
    {
        return new Movie
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate
        };
    }
    private MovieGetDto ConvertToDto(Movie movie)
    {
        return new MovieGetDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate
        };
    }
}
