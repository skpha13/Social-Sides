using backend.Models;
using backend.Repositories.GenericRepository;

namespace backend.Repositories.CommentRepository;

public interface ICommentRepository: IGenericRepository<Comment>
{
    
}