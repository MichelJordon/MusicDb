using Domain.Entities;
using Domain.Dtos;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace Infrastructure.Services;

public class AlbumService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AlbumService(DataContext context,  IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetAllByTrack>>> GetAlbums()
    {
        var joined = (
            from alb in _context.Albums
            join art in _context.Artists on alb.ArtistId equals art.ArtistId
            join tr in _context.Tracks on alb.AlbumId equals tr.AlbumId
            select new GetAllByTrack
            {
                ArtistId = alb.ArtistId,
                ArtistName = art.ArtistName,
                AlbumId = alb.AlbumId,
                Title = alb.Title,
                TrackId = tr.TrackId,
                TrackName = tr.TrackName
            }
            ).ToList();
        return new Response<List<GetAllByTrack>>(joined);
    }
    public async Task<Response<AddAlbumDto>> UpdateAlbum(AddAlbumDto album)
    {
        var find = await _context.Albums.FindAsync(album.AlbumId);
        find.Title = album.Title;
        await _context.SaveChangesAsync();
        return new Response<AddAlbumDto>(album);
    }
    public async Task<Response<string>> DeleteAlbum(int id)
    {
        var find = await _context.Albums.FindAsync(id);
        _context.Albums.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted");
    }
    public async Task<Response<GetAlbumDto>> AddTodo(AddAlbumDto track)
    {
        var newTodo = _mapper.Map<Album>(track);
        _context.Albums.Add(newTodo);
        await _context.SaveChangesAsync();
        return new Response<GetAlbumDto>(_mapper.Map<GetAlbumDto>(newTodo));
    }

}