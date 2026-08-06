using Homework.Validators;
using Homework21.Controllers;
using Homework21.Data;
using Homework21.DTOs;
using Homework21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Homework21.Tests.Controllers;

public class PersonControllerTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
            .Options;

        return new AppDbContext(options);
    }

    private PersonRequestDto GetValidDto() => new()
    {
        CreateDate = DateTime.Now.AddDays(-1),
        Firstname = "გიორგი",
        Lastname = "გონგლაძე",
        JobPosition = "დიზაინერი",
        Salary = 3000,
        WorkExperience = 2,
        PersonAddress = new Address { Country = "GEO", City = "Tbilisi", HomeNumber = "5" }
    };

    [Fact]
    public async Task Create_ValidPerson_ReturnsOkWithUpdatedList()
    {
        // Arrange
        var context = GetDbContext();
        var validator = new PersonValidator();
        var controller = new PersonController(context, validator);

        // Act
        var result = await controller.Create(GetValidDto());

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var list = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
        Assert.Single(list);
    }

    [Fact]
    public async Task GetAll_ReturnsAllPersons()
    {
        // Arrange
        var context = GetDbContext();
        context.Persons.Add(new Person { Firstname = "გიორგი", Lastname = "გონგაძე", JobPosition = "Dev", PersonAddress = new Address() });
        context.Persons.Add(new Person { Firstname = "ნიკა", Lastname = "ბერიძე", JobPosition = "Dev", PersonAddress = new Address() });
        await context.SaveChangesAsync();

        var controller = new PersonController(context, new PersonValidator());

        // Act
        var result = await controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var list = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
        Assert.Equal(2, list.Count());
    }

    [Fact]
    public async Task GetById_ExistingId_ReturnsPerson()
    {
        // Arrange
        var context = GetDbContext();
        var person = new Person { Firstname = "გიორგი", Lastname = "ა", JobPosition = "Dev", PersonAddress = new Address() };
        context.Persons.Add(person);
        await context.SaveChangesAsync();

        var controller = new PersonController(context, new PersonValidator());

        // Act
        var result = await controller.GetById(person.Id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedPerson = Assert.IsType<Person>(okResult.Value);
        Assert.Equal("გიორგი", returnedPerson.Firstname);
    }

    [Fact]
    public async Task GetById_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        var context = GetDbContext();
        var controller = new PersonController(context, new PersonValidator());

        // Act
        var result = await controller.GetById(999);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public async Task Filter_ByMinSalary_ReturnsFilteredResult()
    {
        // Arrange
        var context = GetDbContext();
        context.Persons.AddRange(
            new Person { Firstname = "ლაშა", Lastname = "Low", JobPosition = "Dev", Salary = 1000, PersonAddress = new Address { City = "Tbilisi" } },
            new Person { Firstname = "ნიკა", Lastname = "High", JobPosition = "Dev", Salary = 8000, PersonAddress = new Address { City = "Tbilisi" } }
        );
        await context.SaveChangesAsync();

        var controller = new PersonController(context, new PersonValidator());

        // Act
        var result = await controller.Filter(minSalary: 5000, city: null, firstname: null);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var list = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
        Assert.Single(list);
        Assert.Equal("ნიკა", list.First().Firstname);
    }

    [Fact]
    public async Task Delete_ExistingId_RemovesPersonAndReturnsUpdatedList()
    {
        // Arrange
        var context = GetDbContext();
        var person = new Person { Firstname = "დათო", Lastname = "ლომიძე", JobPosition = "Dev", PersonAddress = new Address() };
        context.Persons.Add(person);
        await context.SaveChangesAsync();

        var controller = new PersonController(context, new PersonValidator());

        // Act
        var result = await controller.Delete(person.Id);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        Assert.Empty(context.Persons);
    }
}