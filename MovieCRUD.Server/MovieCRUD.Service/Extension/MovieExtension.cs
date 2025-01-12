using MovieCRUD.Service.Services;

namespace MovieCRUD.Service.Extension;
public static class MovieExtension
{
    public static double DurationMinutesToHours(this IMovieService movieService, Guid id)
    {
        return movieService.GetMovieById(id).DurationMinutes / 60d;
    }
    public static long BoxOfficeEarningsSum(this IMovieService movieService)
    {
        return movieService.GetAll().Sum(mov => mov.BoxOfficeEarnings);
    }
}
