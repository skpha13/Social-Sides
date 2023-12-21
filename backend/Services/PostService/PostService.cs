using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
using backend.Repositories.PostRepository;

namespace backend.Services.PostService;

public class PostService : IPostService
{
    private IPostRepository _postRepository;
    private IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
    public async Task<List<PostDTO>> GetAllPosts()
    {
        var postList = await _postRepository.GetAllAsync();
        var postDTOs = postList.Select(p => new PostDTO()
        {
            Id = p.Id,
            Title = p.Title,
            Text = p.Text
        }).ToList();
        return postDTOs;
    }
}