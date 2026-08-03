using Homework21.Models;

namespace Homework21.DTOs;

public class PersonRequestDto
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string JobPosition { get; set; } = string.Empty;
    public double Salary { get; set; }
    public double WorkExperience { get; set; }
    public Address PersonAddress { get; set; } = new();
}