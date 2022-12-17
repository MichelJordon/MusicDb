using Domain.Entities;
using Domain.Dtos;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace Infrastructure.Services;

public class TrackService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TrackService(DataContext context,  IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
    public async Task<Response<GetTrackDto>> AddTodo(AddTrackDto track)
    {
        var newTodo = _mapper.Map<Domain.Entities.Track>(track);
        _context.Tracks.Add(newTodo);
        await _context.SaveChangesAsync();
        return new Response<GetTrackDto>(_mapper.Map<GetTrackDto>(newTodo));
    }
    public async Task<Response<AddTrackDto>> UpdateTrack(AddTrackDto track)
    {
        var find = await _context.Tracks.FindAsync(track.TrackId);
        find.TrackName = track.TrackName;

        await _context.SaveChangesAsync();
        return new Response<AddTrackDto>(track);
    }

    public async Task<Response<string>> DeleteTrack(int id)
    {
        var find = await _context.Tracks.FindAsync(id);
        _context.Tracks.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted");
    }

}