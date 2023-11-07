using Microsoft.AspNetCore.Http.HttpResults;
using ModStoreApi.Models;
using ModStoreApi.Repository;

namespace ModStoreApi.Services;
public class CommentsService
{
  private readonly ICommentRepository _commentRepository;

  public CommentsService(
   ICommentRepository commentRepository
  )
  {
    _commentRepository = commentRepository;
  }

  public async Task<List<Comment>> GetAsync() => await _commentRepository.GetAll();

  public async Task<Comment?> GetAsync(int id) => await _commentRepository.GetById(id);

  public async Task<List<Comment>> GetByPostAsync(int postId) => await _commentRepository.GetByPostId(postId);

  public async Task CreateAsync(Comment newCommentDTO)
  {
    var newComment = new Comment(newCommentDTO);
    await _commentRepository.Insert(newComment);
  }

  public async Task UpdateAsync(UpdateCommentDto updatedComment, Comment comment)
  {
    comment.TextBody = updatedComment.TextBody;
    comment.CreatedAt = DateTime.SpecifyKind(comment.CreatedAt, DateTimeKind.Utc);
    comment.UpdatedAt = DateTime.Now.ToUniversalTime();
    await _commentRepository.Update(comment);
  }
}