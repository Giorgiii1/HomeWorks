/* 1
Console.Write("Input: ");
var radius = Convert.ToInt32(Console.ReadLine());

var bigSquare = Math.Pow(2 * radius, 2);
var smallSquare = Math.Pow(2 * radius, 2) / 2;
var result = bigSquare - smallSquare;

Console.WriteLine($"Output: {result}");
*/

/* 2
string[] jackpot = { "@", "@", "@", "@", "@" };

bool isJackpot = true;

string first = jackpot[0];

for (int i = 1; i < jackpot.Length; i++)
{
    if (jackpot[i] != first)
    {
        isJackpot = false;
        break;
    }
    
}

Console.WriteLine(isJackpot ? "Yes" : "No");
*/

/* 3
Console.Write("Enter wins: ");
var wins = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter losses: ");
var losses = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter draws: ");
var draws = Convert.ToInt32(Console.ReadLine());

int totalPoints = (wins * 3) + (losses * 0) + (draws * 1);

Console.WriteLine($"Total points: {totalPoints}");
*/


/* 4
Console.Write("Enter 7 days hours: ");
int [] hours = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
int totalSalary = 0;

for (int i = 0; i < 6; i++)
{
    if (i < 5)
    {
        if (hours[i] > 8)
        { 
            totalSalary = (8* 10) + (hours[i]- 8) * 15 + totalSalary;
        }
        else
        {
            totalSalary = hours[i] * 10 + totalSalary;
        }
        
    }
    else
    {
        totalSalary = hours[i] * 20 + totalSalary;
    }
}

Console.WriteLine("Total Salary: " + totalSalary);
*/

/* 5
Console.Write("Enter marathon progress: ");
int[] progress = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
int count = 0;

for (int i = 1; i < progress.Length; i++)
{
    if (progress[i] > progress[i - 1])
    {
        count++;
    }
}

Console.WriteLine(count);
*/

/* 6
Console.Write("Enter n:");
var n = Convert.ToInt32(Console.ReadLine());
string[] words = ["Hello", "World","Programming", "communication"];
    
var filteredWords = words.Where(word => word.Length >= n).ToList();

if (filteredWords.Count == 0)
{
    Console.WriteLine("No elements found");
}
else
{
    foreach (var word in filteredWords)
    {
        Console.WriteLine(word);
    }

}
*/

