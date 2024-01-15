using backend.Data;
using backend.Models;
using backend.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.LikeRepository;

public class LikeRepository :  GenericRepository<Liked>, ILikeRepository
{
    public LikeRepository(DatabaseContext dbContext) : base(dbContext) {}
    
    
}