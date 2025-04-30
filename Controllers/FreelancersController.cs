using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

[ApiController]
[Route("api/[controller]")]
public class FreelancersController : ControllerBase
{
    private readonly AppDbContext _context;
    public FreelancersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Freelancers.Include(f => f.Skillsets).Include(f => f.Hobbies).Where(f => !f.IsArchived));

    [HttpGet("search")]
    public IActionResult Search(string query)
    {
        var result = _context.Freelancers
            .Where(f => (f.Username.Contains(query) || f.Email.Contains(query)) && !f.IsArchived)
            .ToList();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Freelancer freelancer)
    {
        _context.Freelancers.Add(freelancer);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = freelancer.Id }, freelancer);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Freelancer updated)
    {
        var existing = _context.Freelancers.Include(f => f.Skillsets).Include(f => f.Hobbies).FirstOrDefault(f => f.Id == id);
        if (existing == null) return NotFound();

        existing.Username = updated.Username;
        existing.Email = updated.Email;
        existing.PhoneNumber = updated.PhoneNumber;
        existing.Skillsets = updated.Skillsets;
        existing.Hobbies = updated.Hobbies;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var freelancer = _context.Freelancers.Find(id);
        if (freelancer == null) return NotFound();

        _context.Freelancers.Remove(freelancer);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPost("{id}/archive")]
    public IActionResult Archive(int id)
    {
        var freelancer = _context.Freelancers.Find(id);
        if (freelancer == null) return NotFound();

        freelancer.IsArchived = true;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPost("{id}/unarchive")]
    public IActionResult Unarchive(int id)
    {
        var freelancer = _context.Freelancers.Find(id);
        if (freelancer == null) return NotFound();

        freelancer.IsArchived = false;
        _context.SaveChanges();
        return NoContent();
    }
}
