using MovieCRUD.Service.DTOs;

namespace MovieCRUD.Service.Services;
public interface IMovieService
{
    Guid AddMovie(MovieCreatDto movie);
    MovieGetDto GetMovieById(Guid id);
    void UpdateMovie(MovieGetDto movie);
    void DeleteMovie(Guid id);
    List<MovieGetDto> GetAll();
    List<MovieGetDto> GetAllMoviesByDirector(string director);
    MovieGetDto GetTopRatedMovie();
    MovieGetDto GetHighestGrossingMovie();
    List<MovieGetDto> SearchMoviesByTitle(string keyword);
    List<MovieGetDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);
    long GetTotalBoxOfficeEarningsByDirector(string director);
    List<MovieGetDto> GetMoviesSortedByRating();
    List<MovieGetDto> GetRecentMovies(int years);

}