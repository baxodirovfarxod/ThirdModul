using MovieCRUD.DataAccess.Entity;

namespace MovieCRUD.Repository.Repository;
public interface IMovieRepository
{
    Guid AddMovie(Movie movie);
    Movie GetMovieById(Guid id);
    void UpdateMovie(Movie movie);
    void DeleteMovie(Guid id);
    List<Movie> GetAll();
}