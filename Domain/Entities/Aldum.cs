namespace Domain.Entities;

public class Album
{
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
    public List<Track> Tracks { get; set; }
}