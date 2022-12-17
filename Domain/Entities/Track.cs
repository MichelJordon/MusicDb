namespace Domain.Entities;

public class Track
{
    public int TrackId { get; set; }
    public string TrackName { get; set; }
    public int AlbumId { get; set; }
    public Album Album { get; set; }
}