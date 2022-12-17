using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Context;

public class DataContext:DbContext
{
    public DataContext( DbContextOptions<DataContext> options ) : base(options)
    {

    }
    public DbSet<Artist> Artists {get; set;}
    public DbSet<Album> Albums {get; set;}
    public DbSet<Track> Tracks{get; set;}
}