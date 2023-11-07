using ModStoreApi.Models;
using ModStoreApi.Repository;

namespace ModStoreApi.Services;

public class PostsService
{

  private readonly IPostRepository _postRepository;

  public PostsService(
    IPostRepository postRepository
  )
  {
    _postRepository = postRepository;
  }
  public async Task<List<Post>> GetAsync() => await _postRepository.GetAll();

  public async Task<Post?> GetAsync(int id) =>
      await _postRepository.GetById(id);
  public async Task CreateAsync(Post newPostDTO)
  {
    var newPost = new Post(newPostDTO);
    await _postRepository.Insert(newPost);
  }

  public async Task UpdateAsync(Post post, UpdatePostDTO updatedPost)
  {
    post.Title = updatedPost.Title ?? post.Title;
    post.Description = updatedPost.Description ?? post.Description;
    post.TextBody = updatedPost.TextBody ?? post.TextBody;
    post.MetaTagTitle = updatedPost.MetaTagTitle ?? post.MetaTagTitle;
    post.MetaTagDescription = updatedPost.MetaTagDescription ?? post.MetaTagDescription;
    post.MetaTagKeywords = updatedPost.MetaTagKeywords ?? post.MetaTagKeywords;
    post.CreatedAt = DateTime.SpecifyKind(post.CreatedAt, DateTimeKind.Utc);
    post.UpdatedAt = DateTime.Now.ToUniversalTime();
    await _postRepository.Update(post);
  }

}
