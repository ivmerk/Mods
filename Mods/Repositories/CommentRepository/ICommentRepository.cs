using ModStoreApi.Models;

namespace ModStoreApi.Repository;
public interface ICommentRepository : IRepository<Comment>
{
  Task<List<Comment>> GetByPostId(int postId);
}