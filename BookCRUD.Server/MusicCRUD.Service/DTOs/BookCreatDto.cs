namespace BookCRUD.Service.DTOs;
public class BookCreatDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public double Rating { get; set; }
    public int NumberOfCopiesSold { get; set; } // nechta nusxada sotilganini soni
    public int PublishedDate { get; set; }
}
