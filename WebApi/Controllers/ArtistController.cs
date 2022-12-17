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
public class ArtistController
{
    private readonly ArtistService _artistService;
    
    public ArtistController(ArtistService artistService)
    {
        _artistService = artistService;
    }
    [HttpGet("Ppp")]
    public async Task<Response<List<GetArtistDto>>> Gett()
    {
        return  await _artistService.GetArtist();
    }
    [HttpGet]
    public async Task<Response<List<GetAllByTrack>>> Get()
    {
        return  await _artistService.GetTodos();
    }
    [HttpPost("Insert")]
    public async Task<Response<GetArtistDto>> AddTodo(AddArtistDto track)
    {
        return await _artistService.AddTodo(track);
    }
    [HttpPut("UpdateArtist")]
    public async Task<Response<AddArtistDto>> UpdateArtist(AddArtistDto artist)
    {
        return await _artistService.UpdateArtist(artist);
    }

    [HttpDelete("DeleteArtist")]
    public async Task<Response<string>> DeleteArtist(int id)
    {
        return await _artistService.DeleteArtist(id);
    }
}