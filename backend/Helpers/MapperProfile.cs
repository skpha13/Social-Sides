﻿using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.RelationsDTOs;
using Profile = AutoMapper.Profile;

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
        CreateMap<UserDTO, User>();
        
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
                        Username = src.User.Username,
                        FirstName = src.User.FirstName,
                        LastName = src.User.LastName,
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