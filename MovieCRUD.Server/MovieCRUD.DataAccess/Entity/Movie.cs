namespace MovieCRUD.DataAccess.Entity;
public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; } // rejissyorining ismi
    public int DurationMinutes { get; set; } // Davomiyligi (minutlarda)
    public double Rating { get; set; } // Baholanish (IMDB yoki shunga o'xshash)
    public long BoxOfficeEarnings { get; set; } // Yig'gan summasi (dollarda)
    public int ReleaseDate { get; set; }
}
