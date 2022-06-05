using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebApplicaiton.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private Context _context;

    public TeamsController(Context context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<ActionResult> addTeam([FromBody] Team team)
    {
        try
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Team>>> getTeams([FromQuery] int? ranking, [FromQuery] string? teamName)
    {
        try
        {
            if (ranking != null && teamName==null)
            {
                return Ok(_context.Teams.Where(t=>t.Ranking==ranking).ToList());
            }else if (teamName != null&&ranking ==null)
            {
                return Ok(_context.Teams.Where(t=>t.TeamName.Equals(teamName)).ToList());
            }else if (ranking != null && teamName != null)
            {
                return Ok(_context.Teams.Where(t=>t.Ranking==ranking && t.TeamName.Equals(teamName)).ToList());
            }
            return Ok( await _context.Teams.ToListAsync());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}