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

  public async Task<Post?> GetAsync(string id) =>
      await _postRepository.GetById(int.Parse(id));
  public async Task CreateAsync(Post newPostDTO)
  {
    var newPost = new Post(newPostDTO);
    await _postRepository.Insert(newPost);
  }

  public async Task UpdateAsync(string id, UpdatePostDTO updatedPost)
  {
    var post = await GetAsync(id) ?? throw new ArgumentException($"Нет поста с таким  Id");
    post.Title = updatedPost.Title ?? post.Title;
    post.Description = updatedPost.Description ?? post.Description;
    post.TextBody = updatedPost.TextBody ?? post.TextBody;
    // post.MetaTags = updatedPost.MetaTags ?? post.MetaTags;
    // post.UpdateDate = DateTime.Now.Date;
    await _postRepository.Update(post);
  }

}
