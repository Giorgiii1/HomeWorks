using Homework.Validators;
using Homework21.DTOs;
using Homework21.Models;


namespace Homework21.Tests.Validators;

public class PersonValidatorTests
{
    private readonly PersonValidator _validator = new();

    private PersonRequestDto GetValidDto() => new()
    {
        CreateDate = DateTime.Now.AddDays(-1),
        Firstname = "გიორგი",
        Lastname = "გონგლაძე",
        JobPosition = "დეველოპერი",
        Salary = 5000,
        WorkExperience = 3,
        PersonAddress = new Address
        {
            Country = "საქართველო",
            City = "თბილისი",
            HomeNumber = "12"
        }
    };

    [Fact]
    public void Validate_ValidDto_ShouldNotHaveErrors()
    {
        var dto = GetValidDto();
        var result = _validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_FutureCreateDate_ShouldHaveValidationError()
    {
        var dto = GetValidDto();
        dto.CreateDate = DateTime.Now.AddDays(2); 

        var result = _validator.Validate(dto);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(dto.CreateDate));
    }

    [Fact]
    public void Validate_SalaryExceedsLimit_ShouldHaveValidationError()
    {
        var dto = GetValidDto();
        dto.Salary = 15000; 

        var result = _validator.Validate(dto);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(dto.Salary));
    }

    [Fact]
    public void Validate_EmptyAddressCity_ShouldHaveValidationError()
    {
        var dto = GetValidDto();
        dto.PersonAddress.City = ""; 

        var result = _validator.Validate(dto);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "PersonAddress.City");
    }
}