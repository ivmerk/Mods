using Microsoft.EntityFrameworkCore;
using ModStoreApi.Models;

namespace ModStoreApi.Repository;
public class PostRepository : IPostRepository
{

  private readonly ApplicationDbContext _context;

  public PostRepository(ApplicationDbContext context)
  {
    _context = context;
  }
  public async Task Insert(Post post)
  {
    _context.Posts.Add(post);
    await _context.SaveChangesAsync();
  }

  public async Task Delete(int id)
  {
    var post = await _context.Posts.FindAsync(id);
    if (post != null)
    {
      _context.Posts.Remove(post);
      await _context.SaveChangesAsync();
    }
  }

  public async Task<List<Post>> GetAll()
  {
    return await _context.Posts.ToListAsync();
  }

  public async Task<Post?> GetById(int id)
  {
    return await _context.Posts.FindAsync(id);
  }

  public async Task Update(Post post)
  {
    _context.Entry(post).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }
}