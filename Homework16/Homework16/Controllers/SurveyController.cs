using FluentValidation;
using Homework16.Data;
using Homework16.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework16.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurveyController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IValidator<Person> _validator;

    public SurveyController(AppDbContext context, IValidator<Person> validator)
    {
        _context = context;
        _validator = validator;
    }

    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Person person)
    {
        var validationResult = await _validator.ValidateAsync(person);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();

        
        var people = await _context.Persons.Include(p => p.PersonAddress).ToListAsync();
        return Ok(people);
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _context.Persons.Include(p => p.PersonAddress).ToListAsync();
        return Ok(people);
    }

    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var person = await _context.Persons
            .Include(p => p.PersonAddress)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (person == null)
        {
            return NotFound(new { Message = $"Record with ID {id} not found." });
        }

        return Ok(person);
    }

    
    [HttpGet("filter")]
    public async Task<IActionResult> GetFiltered([FromQuery] double? minSalary, [FromQuery] string? city)
    {
        var query = _context.Persons.Include(p => p.PersonAddress).AsQueryable();

        if (minSalary.HasValue)
        {
            query = query.Where(p => p.Salary >= minSalary.Value);
        }

        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query.Where(p => p.PersonAddress.City.Contains(city));
        }

        var result = await query.ToListAsync();
        return Ok(result);
    }

    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var person = await _context.Persons.FindAsync(id);

        if (person == null)
        {
            return NotFound(new { Message = $"Record with ID {id} not found." });
        }

        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();

        var people = await _context.Persons.Include(p => p.PersonAddress).ToListAsync();
        return Ok(people);
    }

    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Person updatedPerson)
    {
        var validationResult = await _validator.ValidateAsync(updatedPerson);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        var existingPerson = await _context.Persons
            .Include(p => p.PersonAddress)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (existingPerson == null)
        {
            return NotFound(new { Message = $"Record with ID {id} not found." });
        }

        
        existingPerson.CreateDate = updatedPerson.CreateDate;
        existingPerson.FirstName = updatedPerson.FirstName;
        existingPerson.LastName = updatedPerson.LastName;
        existingPerson.JobPosition = updatedPerson.JobPosition;
        existingPerson.Salary = updatedPerson.Salary;
        existingPerson.WorkExperience = updatedPerson.WorkExperience;

        existingPerson.PersonAddress.Country = updatedPerson.PersonAddress.Country;
        existingPerson.PersonAddress.City = updatedPerson.PersonAddress.City;
        existingPerson.PersonAddress.HomeNumber = updatedPerson.PersonAddress.HomeNumber;

        await _context.SaveChangesAsync();

        var people = await _context.Persons.Include(p => p.PersonAddress).ToListAsync();
        return Ok(people);
    }
}