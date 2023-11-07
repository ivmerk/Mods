using IntelliTect.Coalesce.Models;
using Microsoft.EntityFrameworkCore;
using ModStoreApi.Models;

namespace ModStoreApi.Repository;
public class CommentRepository : ICommentRepository
{

  private readonly ApplicationDbContext _context;

  public CommentRepository(ApplicationDbContext context)
  {
    _context = context;
  }
  public async Task Insert(Comment comment)
  {
    _context.Comments.Add(comment);
    await _context.SaveChangesAsync();
  }

  public async Task Delete(int id)
  {
    var comment = await _context.Comments.FindAsync(id);
    if (comment != null)
    {
      _context.Comments.Remove(comment);
      await _context.SaveChangesAsync();
    }
  }

  public async Task<List<Comment>> GetAll()
  {
    return await _context.Comments.ToListAsync();
  }

  public async Task<Comment?> GetById(int id)
  {
    return await _context.Comments.FindAsync(id);
  }

  public async Task<List<Comment>> GetByPostId(int postId)
  {
    var comments = _context.Comments.Where(comment => comment.PostId == postId);
    return await comments.ToListAsync();
  }

  public async Task Update(Comment comment)
  {
    _context.Entry(comment).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }
}