/* 1
Employee employee = new Employee();
employee.FirstName = "John";
employee.LastName = "Doe";
employee.Age = 20;
employee.Position = "Developer";
employee.WeeklyHours = new[] { 8, 9, 8, 8, 8, 4, 0 };

Employee tester = new Employee();
tester.FirstName = "Anna";
tester.LastName = "Doe";
tester.Age = 20;
tester.Position = "Tester";
tester.WeeklyHours = new[] { 8, 7, 6, 7, 5, 0, 0 };

Company company = new Company();
company.IsLocal = true;

double johnSalary = employee.CalculateWeeklySalary();
double annaSalary = tester.CalculateWeeklySalary();
double totalCompanySalary = johnSalary + annaSalary;

Console.WriteLine($"{employee.FirstName} Salary: {johnSalary}$");
Console.WriteLine($"{tester.FirstName} Salary: {annaSalary}$");
Console.WriteLine($"Company Salary Sum: {totalCompanySalary}$");

double tax = company.CalculateTax(totalCompanySalary);
Console.WriteLine($"Tax is 18%: {tax}$");


class Employee
{
    public string FirstName;
    public string LastName;
    public int Age;
    public string Position;
    public int[] WeeklyHours;

    public double CalculateWeeklySalary()
    {
        double totalSalary = 0;
        int totalHours = 0;
        int hourlyRate = 0;
        
        if (Position == "Tester") hourlyRate = 20;
        else if (Position == "Developer") hourlyRate = 30;
        else if (Position == "Manager") hourlyRate = 40;
        else hourlyRate = 10;

        for (int i = 0; i < WeeklyHours.Length; i++)
        {
            int hoursWorked = WeeklyHours[i];
            if (hoursWorked == 0) continue;
            
            totalHours += hoursWorked;
            double dailySalary = 0;
            
            if (hoursWorked > 8)
            {
                int overtimeHours = hoursWorked - 8;
                dailySalary = (8 * hourlyRate) + (overtimeHours * (hourlyRate + 5));
            }
            else
            {
                dailySalary = hoursWorked * hourlyRate;
            }

            if (i == 5 || i == 6)
            {
                dailySalary *= 2;
            }
            totalSalary += dailySalary;
        }

        if (totalHours > 50)
        {
            totalSalary = totalSalary + (totalSalary * 0.20);
        }
        
        return totalSalary;
    }
}

class Company
{
    public bool IsLocal;

    public double CalculateTax(double totalSalary)
    {
        if (IsLocal)
        {
            return totalSalary * 0.18;
        }
        else
        {
            return totalSalary * 0.05;
        }
    }
}
*/

/* 2
Student student = new Student();
student.Name = "Giorgi";
student.Age = 20;
student.EnrollmentYear = 2024;

Teacher teacher = new Teacher();
teacher.Name = "David";
teacher.IsCertified = true;

int yearsLeft = student.GetYearsRemaining();
Console.WriteLine($"{student.Name} has {yearsLeft} years left until graduation.");

string randomSubject = student.GetRandomSubject();
Console.WriteLine($"{student.Name} picked the subject: {randomSubject}");

Console.WriteLine($"\n{teacher.Name} is checking the subject:");
teacher.CheckSubject(randomSubject);


class Teacher
{
    public string Name;
    public bool IsCertified;

    public void CheckSubject(string subjectName)
    {
        Random random = new Random();
        if (subjectName == "Math")
        {
            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            Console.WriteLine(num1 + num2);
        }
        else if (subjectName == "Chemistry")
        {
            Console.WriteLine("H20");
        }
        else if (subjectName == "English")
        {
            Console.WriteLine("Hello");
        }
        else
        {
            Console.WriteLine($"Not competent in the subject: {subjectName}");
        }
    }
}

class Student
{
    public string Name;
    public int Age;
    public int EnrollmentYear;

    public string GetRandomSubject()
    {
        string[] subjects = { "Math", "Chemistry", "English", "History" };
        Random rnd = new Random();
        int index = rnd.Next(subjects.Length);
        return  subjects[index];
    }

    public int GetYearsRemaining()
    {
        int currentYear = 2026;
        int yearsStudied = currentYear - EnrollmentYear;
        int yearsLeft = 4 - yearsStudied;
        if (yearsLeft < 0) return 0;
        return yearsLeft;
    }
}
*/


/* 3
Student gio = new GoodStudent("Alex");
Student maria = new LazyStudent("Maria");

ClassRoom classRoom = new ClassRoom(gio, maria);
classRoom.PrintAllStudentActivities();

class Student
{
    public string Name;

    public Student(string name)
    {
        Name = name;
    }
    
    public virtual void Study()
    {
        Console.WriteLine("Student study");
    }
    public virtual void Read()
    {
        Console.WriteLine("Student read");
    }
    public virtual void Write()
    {
        Console.WriteLine("Student write");
    }

    public virtual void Relax()
    {
        Console.WriteLine("Student relax");
    }
}

class GoodStudent : Student
{
    public GoodStudent(string name)
        : base(name)
    {
    }

    public override void Read()
    {
        Console.WriteLine($"{Name} reading");
    }

    public override void Write()
    {
        Console.WriteLine($"{Name} writing");
    }

    public override void Study()
    {
        Console.WriteLine($"{Name} studying");
    }

    public override void Relax()
    {
        Console.WriteLine($"{Name} relaxing");
    }
    
}

class LazyStudent : Student
{
    public LazyStudent(string name)
        : base(name)
    {
    }

    public override void Read()
    {
        Console.WriteLine($"{Name} reading");
    }

    public override void Write()
    {
        Console.WriteLine($"{Name} writing");
    }

    public override void Study()
    {
        Console.WriteLine($"{Name} studying");
    }

    public override void Relax()
    {
        Console.WriteLine($"{Name} relaxing");
    }
    
}

class ClassRoom
{
    public List<Student> Students = new List<Student>();

    public ClassRoom(params Student[] students)
    {
        Students.AddRange(students);
    }

    public void PrintAllStudentActivities()
    {
        foreach (var student in Students)
        {
            Console.WriteLine($"--- Activities of {student.Name} ---");
            student.Study();
            student.Read();
            student.Write();
            student.Relax();
            Console.WriteLine();
        }
    }
}
*/

