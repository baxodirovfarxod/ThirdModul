using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCRUD.Service.DTOs;
using MovieCRUD.Service.Extension;
using MovieCRUD.Service.Services;

namespace MovieCRUD.Server.Controllers
{
    [Route("api/movieController")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;
        public MovieController()
        {
            movieService = new MovieService();
        }
        [HttpPost("addMovie")]
        public Guid AddMovie(MovieCreatDto movie)
        {
            return movieService.AddMovie(movie);
        }

        [HttpPut("updateMovie")]
        public void UpdateMovie(MovieGetDto movie)
        {
            movieService.UpdateMovie(movie);
        }

        [HttpDelete("deleteMovie")]
        public void DeleteMovie(Guid id)
        {
            movieService.DeleteMovie(id);
        }

        [HttpGet("getAllMovies")]
        public List<MovieGetDto> GetAllMovies()
        {
            return movieService.GetAll();
        }

        [HttpGet("getAllMoviesByDirector")]
        public List<MovieGetDto> GetAllMoviesByDirector(string director)
        {
            return movieService.GetAllMoviesByDirector(director);
        }

        [HttpGet("getTopRatedMovie")]
        public MovieGetDto GetTopRatedMovie()
        {
            return movieService.GetTopRatedMovie();
        }

        [HttpGet("getHighestGrossingMovie")]
        public MovieGetDto GetHighestGrossingMovie()
        {
            return movieService.GetHighestGrossingMovie();
        }

        [HttpGet("searchMoviesByTitle")]
        public List<MovieGetDto> SearchMoviesByTitle(string keyword)
        {
            return movieService.SearchMoviesByTitle(keyword);
        }

        [HttpGet("getMoviesWithinDurationRange")]
        public List<MovieGetDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
        {
            return movieService.GetMoviesWithinDurationRange(minMinutes, maxMinutes);
        }

        [HttpGet("getTotalBoxOfficeEarningsByDirector")]
        public long GetTotalBoxOfficeEarningsByDirector(string director)
        {
            return movieService.GetTotalBoxOfficeEarningsByDirector(director);
        }

        [HttpGet("getMoviesSortedByRating")]
        public List<MovieGetDto> GetMoviesSortedByRating()
        {
            return movieService.GetMoviesSortedByRating();
        }

        [HttpGet("getRecentMovies")]
        public List<MovieGetDto> GetRecentMovies(int years)
        {
            return movieService.GetRecentMovies(years);
        }

        [HttpGet("durationMinutesToHours")]
        public double DurationMinutesToHours(Guid id)
        {
            return movieService.DurationMinutesToHours(id);
        }

        [HttpGet("boxOfficeEarningsSum")]
        public long BoxOfficeEarningsSum()
        {
            return movieService.BoxOfficeEarningsSum();
        }
    }
}
