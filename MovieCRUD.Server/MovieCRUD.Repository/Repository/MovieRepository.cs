using MovieCRUD.DataAccess.Entity;
using System.Text.Json;

namespace MovieCRUD.Repository.Repository;
public class MovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies;
    private readonly string _path;
    public MovieRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Movie.json");
        if (File.Exists(_path) is false)
        {
            File.WriteAllText(_path, "[]");
        }
        _movies = ReadMovies();
    }
    public Guid AddMovie(Movie movie)
    {
        _movies.Add(movie);
        SaveData();
        return movie.Id;
    }
    public Movie GetMovieById(Guid id)
    {
        var movie = _movies.FirstOrDefault(mov => mov.Id == id);
        if (movie is null)
        {
            throw new Exception($"Bunday {id} lik movie yo'q");
        }

        return movie;
    }
    public void UpdateMovie(Movie movie)
    {
        var movieFromDB = GetMovieById(movie.Id);
        var index = _movies.IndexOf(movie);
        _movies[index] = movie;
        SaveData();
    }
    public void DeleteMovie(Guid id)
    {
        _movies.Remove(GetMovieById(id));
        SaveData();
    }
    public List<Movie> GetAll()
    {
        return _movies;
    }
    private void SaveData()
    {
        var movieJson = JsonSerializer.Serialize(_movies);
        File.WriteAllText(_path, movieJson);
    }
    private List<Movie> ReadMovies()
    {
        var movieJson = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<List<Movie>>(movieJson);
    }
}
