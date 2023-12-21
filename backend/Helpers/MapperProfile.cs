using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
using Profile = AutoMapper.Profile;

namespace backend.Helpers;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        CreateMap<Post, PostDTO>();
        CreateMap<PostDTO, Post>();

        CreateMap<Post, PostIncludesDTO>()
            .ForMember(p => p.User, opt => opt.Ignore())
            .ForMember(p => p.Category, opt => opt.Ignore());
            // .ForMember(p => p.Category, opt => opt.MapFrom(src => src.Category))
            // .ForMember(p => p.User, opt => opt.MapFrom(src => src.User));

        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();

        CreateMap<Comment, CommentDTO>();
        CreateMap<CommentDTO, Comment>();

        CreateMap<Profile, ProfileDTO>();
        CreateMap<ProfileDTO, Profile>();

        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
    }
}