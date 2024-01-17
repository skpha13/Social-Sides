using backend.Models;
using backend.Models.DTOs;
using backend.Models.DTOs.CommentDTOs;
using backend.Models.DTOs.PostDTOs;
using backend.Models.DTOs.UserFollowsCategoryDTOs;
using backend.Models.RelationsDTOs;
using Microsoft.AspNetCore.Identity;
using Profile = AutoMapper.Profile;

namespace backend.Helpers;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        var hasher = new PasswordHasher<User>();
        CreateMap<Post, PostDTO>();
        CreateMap<PostDTO, Post>();
        
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();
        
        CreateMap<Profile, ProfileDTO>();
        CreateMap<ProfileDTO, Profile>();

        CreateMap<Category, CategoryIdDTO>();
        CreateMap<CategoryIdDTO, Category>();

        CreateMap<UserFollowsCategoryDTO, UserFollowsCategory>();
        
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>()
            .ForMember(u => u.Id, 
                opt => opt.MapFrom(src => new Guid()));

        CreateMap<CreateCommentDTO, Comment>()
            .ForMember(c => c.LastModified, opt =>
                opt.MapFrom(src => DateTime.Now))
            .ForMember(c => c.DateCreated, opt =>
                opt.MapFrom(src => DateTime.Now));

        CreateMap<UserCreateDTO, User>()
            .ForMember(u => u.Id, opt => 
                    opt.MapFrom(src => new Guid()))
            .ForMember(u => u.PasswordHash, opt => 
                opt.MapFrom(src => hasher.HashPassword(null, src.Password)))
            .ForMember(u => u.LockoutEnabled, opt =>
                opt.MapFrom(src => false))
            .ForMember(u => u.SecurityStamp, opt =>
                opt.Ignore());
        
        CreateMap<UserUpdateDTO, User>()
            .ForMember(u => u.PasswordHash, opt => 
                opt.MapFrom(src => hasher.HashPassword(null, src.Password)));
        
        CreateMap<SignUpDTO, User>()
            .ForMember(u => u.Id, opt => 
                opt.MapFrom(src => new Guid()))
            .ForMember(u => u.PasswordHash, opt => 
                opt.MapFrom(src => hasher.HashPassword(null, src.Password)))
            .ForMember(u => u.LockoutEnabled, opt =>
                opt.MapFrom(src => false))
            .ForMember(u => u.SecurityStamp, opt =>
                opt.Ignore());
        
        CreateMap<Post, PostIncludesDTO>()
            .ForMember(p => p.Relations,
                opt => opt.MapFrom(src => new PostRelationsDTO()
                {
                    Category = (src.Category != null) ? new CategoryDTO()
                    {
                        Id = src.Category.Id,
                        Title = src.Category.Title,
                        Color = src.Category.Color
                    } : null,
                    User = (src.User != null) ? new UserDTO()
                    {
                        Id = src.User.Id,
                        UserName = src.User.UserName,
                        Email = src.User.Email
                    } : null,
                    Comments = (src.Comments != null) ? src.Comments.Select(c => new CommentDTO()
                    {
                        Text = c.Text,
                        UserId = (c.User != null) ? c.User.Id : null,
                        UserName = (c.User != null) ? c.User.UserName : null,
                        LastModified = c.LastModified
                    }).ToList() : null
                }));
            
        CreateMap<Comment, CommentDTO>();
        CreateMap<CommentDTO, Comment>();

        CreateMap<CreateCategoryDTO, Category>()
            .ForMember(c => c.Id, opt =>
                opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(c => c.LastModified, opt =>
                opt.MapFrom(src => DateTime.Now))
            .ForMember(c => c.DateCreated, opt =>
                opt.MapFrom(src => DateTime.Now));

        CreateMap<UpdateCategoryDTO, Category>()
            .ForMember(ob => ob.LastModified, opt => opt.MapFrom(src => DateTime.Now));

        CreateMap<CreatePostDTO, Post>()
            .ForMember(c => c.LastModified, opt =>
                    opt.MapFrom(src => DateTime.Now))
            .ForMember(c => c.DateCreated, opt =>
                    opt.MapFrom(src => DateTime.Now))
            .ForMember(c => c.TotalLikes, opt => 
                    opt.MapFrom(src => 0));

        CreateMap<UpdatePostDTO, Post>()
            .ForMember(ob => ob.LastModified, opt => opt.MapFrom(src => DateTime.Now));

        CreateMap<CreatePostUserDTO, Post>()
            .ForMember(c => c.LastModified, opt =>
                opt.MapFrom(src => DateTime.Now))
            .ForMember(c => c.DateCreated, opt =>
                opt.MapFrom(src => DateTime.Now));
    }
}