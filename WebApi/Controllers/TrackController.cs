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
public class TrackController
{
    private readonly TrackService _trackService;

    public TrackController(TrackService trackService)
    {
        _trackService = trackService;
    }
    [HttpGet]
    public async Task<Response<List<GetAllByTrack>>> Get()
    {
        return  await _trackService.GetTodos();
    }
    [HttpPost("Insert")]
    public async Task<Response<GetTrackDto>> AddTodo(AddTrackDto track)
    {
        return await _trackService.AddTodo(track);
    }
    [HttpPut("UpdateTrack")]
    public async Task<Response<AddTrackDto>> UpdateTrack(AddTrackDto track)
    {
        return await _trackService.UpdateTrack(track);
    }

    [HttpDelete("DeleteTrack")]
    public async Task<Response<string>> DeleteTrack(int id)
    {
        return await _trackService.DeleteTrack(id);
    }
}