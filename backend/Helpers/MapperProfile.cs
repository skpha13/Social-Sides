using backend.Models;
using backend.Models.DTOs;
using backend.Models.RelationsDTOs;
using Profile = AutoMapper.Profile;
using BCryptNet = BCrypt.Net.BCrypt;

namespace backend.Helpers;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        CreateMap<Post, PostDTO>();
        CreateMap<PostDTO, Post>();
        
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();
        
        CreateMap<Profile, ProfileDTO>();
        CreateMap<ProfileDTO, Profile>();
        
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>()
            .ForMember(u => u.Id, 
                opt => opt.MapFrom(src => new Guid()));

        CreateMap<UserCreateDTO, User>()
            .ForMember(u => u.Id, opt => 
                    opt.MapFrom(src => new Guid()))
            .ForMember(u => u.PasswordHash, opt => 
                opt.MapFrom(src => BCryptNet.HashPassword(src.Password)))
            .ForMember(u => u.LockoutEnabled, opt =>
                opt.MapFrom(src => false))
            .ForMember(u => u.SecurityStamp, opt =>
                opt.Ignore());
        
        CreateMap<UserUpdateDTO, User>()
            .ForMember(u => u.PasswordHash, opt => 
                opt.MapFrom(src => BCryptNet.HashPassword(src.Password)));
        
        // TODO: see how to make mapping simpler
        CreateMap<Post, PostIncludesDTO>()
            .ForMember(p => p.Relations,
                opt => opt.MapFrom(src => new PostRelationsDTO()
                {
                    Category = (src.Category != null) ? new CategoryDTO()
                    {
                        Title = src.Category.Title
                    } : null,
                    User = (src.User != null) ? new UserDTO()
                    {
                        UserName = src.User.UserName,
                        Email = src.User.Email
                    } : null,
                    // Comments = src.Comments,
                    // Saves = src.Saves
                }));
            // .ForMember(p => p.User, opt => opt.Ignore())
            // .ForMember(p => p.Category, opt => opt.Ignore());
            // .ForMember(p => p.Category, opt => opt.MapFrom(src => src.Category))
            // .ForMember(p => p.User, opt => opt.MapFrom(src => src.User));

        CreateMap<Comment, CommentDTO>();
        CreateMap<CommentDTO, Comment>();
    }
}