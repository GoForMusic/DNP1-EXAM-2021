using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebApplicaiton.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private Context _context;

    public PlayerController(Context context)
    {
        _context = context;
    }
    
    [HttpPost]
    [Route("{TeamName}")]
    public async Task<ActionResult> addPlayer([FromBody] Player player, [FromRoute] string TeamName)
    {
        try
        {
            
            await _context.Players.AddAsync(player);

            Team local = await _context.Teams.FirstAsync(t => t.TeamName.Equals(TeamName));
            local.Players.Add(player);
            _context.Teams.Update(local);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message + e.StackTrace);
        }
    }
    
    [HttpDelete]
    [Route("{name}")]
    public async Task<ActionResult> deletePlayer([FromRoute] string name)
    {
        try
        {
            Player? existing = await _context.Players.FirstAsync(t=>t.Name.Equals(name));
            if (existing is null)
            {
                throw new Exception($"Could not find player with name {name}. Nothing was deleted");
            }
            _context.Players.Remove(existing);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}