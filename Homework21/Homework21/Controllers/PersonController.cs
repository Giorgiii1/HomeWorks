using FluentValidation;
using Homework21.Data;
using Homework21.DTOs;
using Homework21.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework21.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PersonController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IValidator<PersonRequestDto> _validator;

    public PersonController(AppDbContext context, IValidator<PersonRequestDto> validator)
    {
        _context = context;
        _validator = validator;
    }

    [HttpPost]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> Create([FromBody] PersonRequestDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        var person = new Person
        {
            CreateDate = DateTime.UtcNow, 
            Firstname = dto.Firstname,
            Lastname = dto.Lastname,
            JobPosition = dto.JobPosition,
            Salary = dto.Salary,
            WorkExperience = dto.WorkExperience,
            PersonAddress = dto.PersonAddress
        };

        _context.Persons.Add(person);
        await _context.SaveChangesAsync();

        var updatedList = await _context.Persons.Include(p => p.PersonAddress).ToListAsync();
        return Ok(updatedList);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<IEnumerable<Person>>> GetAll()
    {
        return Ok(await _context.Persons.Include(p => p.PersonAddress).ToListAsync());
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<Person>> GetById(int id)
    {
        var person = await _context.Persons.Include(p => p.PersonAddress).FirstOrDefaultAsync(p => p.Id == id);
        if (person == null)
            return NotFound(new { Message = $"Person with ID {id} not found." });

        return Ok(person);
    }

    [HttpGet("filter")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<IEnumerable<Person>>> Filter(
        [FromQuery] double? minSalary, 
        [FromQuery] string? city,
        [FromQuery] string? firstname)
    {
        var query = _context.Persons.Include(p => p.PersonAddress).AsQueryable();

        if (minSalary.HasValue)
        {
            query = query.Where(p => p.Salary >= minSalary.Value);
        }

        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query.Where(p => p.PersonAddress.City.ToLower().Contains(city.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(firstname))
        {
            query = query.Where(p => p.Firstname.ToLower().Contains(firstname.ToLower()));
        }

        var result = await query.ToListAsync();
        return Ok(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonRequestDto dto)
    {
        var existingPerson = await _context.Persons.Include(p => p.PersonAddress).FirstOrDefaultAsync(p => p.Id == id);
        if (existingPerson == null)
            return NotFound(new { Message = $"Person with ID {id} not found." });

        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        existingPerson.Firstname = dto.Firstname;
        existingPerson.Lastname = dto.Lastname;
        existingPerson.JobPosition = dto.JobPosition;
        existingPerson.Salary = dto.Salary;
        existingPerson.WorkExperience = dto.WorkExperience;
        existingPerson.PersonAddress = dto.PersonAddress;

        await _context.SaveChangesAsync();

        return Ok(existingPerson);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var person = await _context.Persons.FindAsync(id);
        if (person == null)
            return NotFound(new { Message = $"Person with ID {id} not found." });

        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();

        var updatedList = await _context.Persons.Include(p => p.PersonAddress).ToListAsync();
        return Ok(updatedList);
    }
}