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

  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<Post>> Get(string id)
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

  [HttpPut("{id:length(24)}")]
  public async Task<IActionResult> Update(string id, UpdatePostDTO updatedPost)
  {
    var post = await _postsService.GetAsync(id);
    if (post is null)
    {
      return NotFound();
    }
    await _postsService.UpdateAsync(id, updatedPost);

    return NoContent();
  }

}