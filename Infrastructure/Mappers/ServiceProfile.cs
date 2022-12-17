using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastucture.Meppers;
public class ServicesProfile:Profile
{
    public ServicesProfile()
    {
        CreateMap<Track, AddTrackDto>().ReverseMap();
        CreateMap<Track, GetTrackDto>().ReverseMap();
        CreateMap<GetTrackDto, AddTrackDto>().ReverseMap();

        CreateMap<Artist, AddArtistDto>().ReverseMap();
        CreateMap<Artist, GetArtistDto>().ReverseMap();
        CreateMap<GetArtistDto, AddArtistDto>().ReverseMap();

        CreateMap<Album, AddAlbumDto>().ReverseMap();
        CreateMap<Album, GetAlbumDto>().ReverseMap();
        CreateMap<GetAlbumDto, AddAlbumDto>().ReverseMap();
    }
}