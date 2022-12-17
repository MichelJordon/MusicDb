using Domain.Entities;
using Domain.Dtos;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace Infrastructure.Services;

public class ArtistService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ArtistService(DataContext context,  IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetArtistDto>>> GetArtist()
    {
       var todos = _mapper.Map<List<GetArtistDto>>(_context.Artists.ToList());
       return new Response<List<GetArtistDto>>(todos);
    }
    public async Task<Response<List<GetAllByTrack>>> GetTodos()
    {
        var track = (from alb in _context.Albums 
            join art in _context.Artists on alb.AlbumId equals art.ArtistId
            join tr in _context.Tracks on alb.AlbumId equals tr.AlbumId
            select new GetAllByTrack{
                TrackId = tr.TrackId,
                TrackName = tr.TrackName,
                ArtistId = alb.ArtistId,
                ArtistName = art.ArtistName,
                AlbumId = alb.AlbumId,
                Title = alb.Title
            }).ToList();
       return new Response<List<GetAllByTrack>>(track);
    }
    public async Task<Response<GetArtistDto>> AddTodo(AddArtistDto track)
    {
        var newTodo = _mapper.Map<Artist>(track);
        _context.Artists.Add(newTodo);
        await _context.SaveChangesAsync();
        return new Response<GetArtistDto>(_mapper.Map<GetArtistDto>(newTodo));
    }
    public async Task<Response<AddArtistDto>> UpdateArtist(AddArtistDto artist)
    {
        var find = await _context.Artists.FindAsync(artist.ArtistId);
        find.ArtistName = artist.ArtistName;

        await _context.SaveChangesAsync();
        return new Response<AddArtistDto>(artist);
    }

    public async Task<Response<string>> DeleteArtist(int id)
    {
        var find = await _context.Artists.FindAsync(id);
        _context.Artists.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted");
    }
}