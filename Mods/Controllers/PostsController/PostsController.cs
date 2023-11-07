using ModStoreApi.Models;
using ModStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ModStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
  private readonly PostsService _postsService;
  public PostsController(PostsService postsService) => _postsService = postsService;

  [HttpGet]
  public async Task<List<Post>> Get()
  {
    return await _postsService.GetAsync();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Post>> Get(int id)
  {
    var post = await _postsService.GetAsync(id);

    if (post is null)
    {
      return NotFound();
    }
    return post;
  }

  [HttpPost]
  public async Task<IActionResult> Post(Post newPostDTO)
  {
    await _postsService.CreateAsync(newPostDTO);
    return CreatedAtAction(nameof(Get), new { id = newPostDTO.Id }, newPostDTO);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, UpdatePostDTO updatedPost)
  {
    var oldPost = await _postsService.GetAsync(id);

    if (oldPost is null)
    {
      return NotFound();
    }
    await _postsService.UpdateAsync(oldPost, updatedPost);

    return NoContent();
  }

}