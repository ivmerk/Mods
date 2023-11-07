using ModStoreApi.Models;
using ModStoreApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace ModStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{

  private readonly CommentsService _commentsService;
  private readonly PostsService _postsService;
  public CommentsController(CommentsService commentsService, PostsService postsService)
  {
    _commentsService = commentsService;
    _postsService = postsService;
  }

  [HttpGet]
  public async Task<List<Comment>> Get()
  {
    return await _commentsService.GetAsync();
  }


  [HttpGet("{id}")]
  public async Task<ActionResult<Comment>> Get(int id)
  {
    var comment = await _commentsService.GetAsync(id);
    if (comment is null)
    {
      return NotFound();
    }
    return comment;
  }

  [HttpGet("postid/{id}")]
  public async Task<ActionResult<List<Comment>>> GetByPostId(int id)
  {
    var post = await _postsService.GetAsync(id);
    if (post is null)
    {
      return NotFound();
    }
    return await _commentsService.GetByPostAsync(id);

  }
  [HttpPost]
  public async Task<IActionResult> Comment(Comment newCommentDTO)
  {
    await _commentsService.CreateAsync(newCommentDTO);
    return CreatedAtAction(nameof(Get), new { id = newCommentDTO.Id }, newCommentDTO);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, UpdateCommentDto updateCommentDto)
  {
    var oldComment = await _commentsService.GetAsync(id);
    if (oldComment is null)
    {
      return NotFound();
    }
    await _commentsService.UpdateAsync(updateCommentDto, oldComment);

    return NoContent();
  }
}


