using System.ComponentModel.DataAnnotations;

namespace Homework15.Models;

public class Appointment : IValidatableObject
{
    [Required(ErrorMessage = "Name is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Lastname is required")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Doctor is required")]
    public string Doctor { get; set; }
    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.Date)]
    public string Time {get;set;}

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (TimeSpan.TryParse(Time, out TimeSpan appointmentTime))
        {
            TimeSpan startTime = new TimeSpan(10, 0, 0);
            TimeSpan endTime = new TimeSpan(19, 0, 0);

            if (appointmentTime < startTime || appointmentTime > endTime)
            {
                yield return new ValidationResult("Time must be in the future",
                    new[] {nameof(Time)});
            }
        }
        else
        {
            yield return new ValidationResult("Time must be a number",
                new[] {nameof(Time)});
        }
    }
}
