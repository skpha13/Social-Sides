using backend.Data;
using backend.Models;
using backend.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.CommentRepository;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(DatabaseContext dbContext) : base(dbContext) {}
    
    
}