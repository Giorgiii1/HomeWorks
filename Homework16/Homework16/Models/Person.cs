namespace Homework16.Models;

public class Person
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JobPosition { get; set; } = string.Empty;
    public double Salary { get; set; }
    public double WorkExperience { get; set; }
    public int AddressId { get; set; }
    public Address PersonAddress { get; set; } = new();
}