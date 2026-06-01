// Task 1

Console.Write("Please enter your number: ");
var number = Convert.ToInt32(Console.ReadLine());

if (number % 5 == 0)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}


// Task 2

Console.Write("Enter your first number: ");
var num1 = Convert.ToDouble(Console.ReadLine());
Console.Write("Enter your second number: ");
var num2 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
Console.WriteLine($"{num1} * {num2} = {num1 * num2}");

double bigNumber;
double smallNumber;

if (num1 > num2)
{
    bigNumber = num1;
    smallNumber = num2;
}
else
{
    bigNumber = num2;
    smallNumber = num1;
}

Console.WriteLine($"{bigNumber} - {smallNumber} = {bigNumber - smallNumber}");

if (smallNumber == 0)
{
    Console.WriteLine("Not Allowed To Divide By Zero");
}
else
{
    Console.WriteLine($"{bigNumber} / {smallNumber} = {bigNumber / smallNumber}");
}


// Task 3

Console.Write("Enter first number: ");
var x = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter second number: ");
var y = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Input -- X = {x}, Y = {y}");

int temp = x;
x = y;
y = temp;

Console.WriteLine($"Output -- X = {x}, Y = {y}");


// Task 4

Console.Write("Enter a number for multiplication table: ");
int num = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"\nMultiplication table for {num}:");

for (int i = 1; i <= 9; i++)
{
    Console.WriteLine($"{num} * {i} = {num * i}");
}


// Task 5

Console.Write("Enter number: ");
var numb = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i < numb; i++)
{
    if (i % 2 == 0)
        Console.WriteLine(i * i);
}