namespace Domain.Entities;

public class Artist
{
    public int ArtistId { get; set; }
    public string ArtistName { get; set; }
    public List<Album> Albums { get; set; }
    
}