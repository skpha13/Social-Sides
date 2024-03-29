﻿using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.DTOs.PostDTOs;
using backend.Repositories.PostRepository;

namespace backend.Services.PostService;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
    public async Task<List<PostDTO>> GetAllPosts()
    {
        var postList =  await _postRepository.GetAllAsync();
        return _mapper.Map<List<PostDTO>>(postList);
    }

    public async Task<bool> DeletePostById(Guid id)
    {
        _postRepository.DeleteById(id);
        return await _postRepository.SaveAsync();
    }

    public List<PostIncludesDTO> GetPostsWithIncludes(string? include, Guid userId)
    {
        var posts = _postRepository.GetAllPostsWithIncludes(include);
        var mappedPosts = _mapper.Map<List<PostIncludesDTO>>(posts);
        foreach (var post in mappedPosts)
        {
            post.isLikedByUser = _postRepository.IsLikedBy(userId, post.Id);
        }
        return mappedPosts;
    }

    public async Task CreatePost(CreatePostUserDTO payload)
    {
        await _postRepository.CreateAsync(_mapper.Map<Post>(payload));
        await _postRepository.SaveAsync();
    }

    public async Task UpdatePost(UpdatePostDTO updatePostDto)
    {
        var existingPost = await _postRepository.FindByIdAsync(updatePostDto.Id);
        if (existingPost == null)
        {
            throw new Exception("Post not found");
        }
        
        if (updatePostDto.Text.Any()) existingPost.Text = updatePostDto.Text;

        _postRepository.Update(_mapper.Map<Post>(existingPost));
        await _postRepository.SaveAsync();
    }
}