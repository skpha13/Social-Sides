using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
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

    public bool DeletePostById(Guid id)
    {
        return _postRepository.DeleteById(id);
    }

    public List<PostIncludesDTO> GetPostsWithIncludes(string? include)
    {
        var posts = _postRepository.GetAllPostsWithIncludes(include);
        return _mapper.Map<List<PostIncludesDTO>>(posts);
    }

    public async Task CreatePost(CreatePostDTO createPostDto)
    {
        await _postRepository.CreateAsync(_mapper.Map<Post>(createPostDto));
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
    }
}