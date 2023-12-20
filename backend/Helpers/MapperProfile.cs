using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
using Profile = AutoMapper.Profile;

namespace backend.Helpers;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        CreateMap<Post, PostDTO>()
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryId, opt => opt.Ignore());
        CreateMap<PostDTO, Post>();

        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();

        CreateMap<Comment, CommentDTO>();
        CreateMap<CommentDTO, Comment>();

        CreateMap<Profile, PostDTO>().ForMember(dest => dest.User, opt => opt.Ignore());
        CreateMap<PostDTO, Profile>();

        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Profile, opt => opt.Ignore());
        CreateMap<UserDTO, User>();
    }
}