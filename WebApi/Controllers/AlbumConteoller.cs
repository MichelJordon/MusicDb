using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController
{
    private readonly AlbumService _albumService;

    public AlbumController(AlbumService albumService)
    {
        _albumService = albumService;
    }
    [HttpGet]
    public async Task<Response<List<GetAllByTrack>>> Get()
    {
        return  await _albumService.GetAlbums();
    }
    [HttpPost("Insert")]
    public async Task<Response<GetAlbumDto>> AddTodo(AddAlbumDto track)
    {
        return await _albumService.AddTodo(track);
    }
    [HttpPut("UpdateAlbum")]
    public async Task<Response<AddAlbumDto>> UpdateAlbum(AddAlbumDto album)
    {
        return await _albumService.UpdateAlbum(album);
    }

    [HttpDelete("DeleteAlbum")]
    public async Task<Response<string>> DeleteAllbum(int id)
    {
        return await _albumService.DeleteAlbum(id);
    }
}