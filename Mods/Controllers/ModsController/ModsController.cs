using ModStoreApi.Models;
using ModStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ModStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModsController : ControllerBase
{
  private readonly ModsService _modsService;

  public ModsController(ModsService modsService) => _modsService = modsService;

  [HttpGet]
  public async Task<List<Mod>> Get()
  {
    return await _modsService.GetAsync();
  }

  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<Mod>> Get(string id)
  {
    var book = await _modsService.GetAsync(id);

    if (book is null)
    {
      return NotFound();
    }
    return book;
  }

  [HttpPost]
  public async Task<IActionResult> Post(Mod newMod)
  {
    await _modsService.CreateAsync(newMod);
    return CreatedAtAction(nameof(Get), new { id = newMod.Id }, newMod);
  }

  [HttpPut("{id:length(24)}")]
  public async Task<IActionResult> Update(string id, Mod updatedMod)
  {
    var mod = await _modsService.GetAsync(id);
    if (mod is null)
    {
      return NotFound();
    }
    updatedMod.Id = mod.Id;

    await _modsService.UpdateAsync(id, updatedMod);

    return NoContent();
  }

  [HttpDelete("{id:length(24)}")]
  public async Task<IActionResult> Delete(string id)
  {
    var mod = await _modsService.GetAsync(id);
    if (mod is null)
    {
      return NotFound();
    }
    await _modsService.RemoveAsync(id);

    return NoContent();
  }
}