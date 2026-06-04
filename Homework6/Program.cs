/* week6 - 1
string inputWord = Console.ReadLine();

var result = string.Join(Environment.NewLine, inputWord
    .GroupBy(c => c)
    .Select(g => $"{g.Key} {g.Count()}"));

Console.WriteLine(result);
*/


/*week 6 - 2
string[] cities = { "Tbilisi", "London", "Madrid", "Rome" };

string[] input = Console.ReadLine().Split(' ');

var matchedCities = cities .Where(city => city.StartsWith(input[0]) && city.EndsWith(input[1]));

Console.WriteLine(string.Join("\n",matchedCities));
*/



/* 1
Console.WriteLine("Input:");გი

int n = Convert.ToInt32(Console.ReadLine());

int[] mainArray = new int[n];


for (int i = 0; i < n; i++)
{
    mainArray[i] = Convert.ToInt32(Console.ReadLine());
}



int evenCount = 0;
int oddCount = 0;

for (int i = 0; i < mainArray.Length; i++)
{
    if (mainArray[i] % 2 == 0)
    {
        evenCount++;
    }
    else
    {
        oddCount++;
    }
}


int[] even = new int[evenCount];
int[] odd = new int[oddCount];

int evenIndex = 0;
int oddIndex = 0;


for (int i = 0; i < mainArray.Length; i++)
{
    if (mainArray[i] % 2 == 0)
    {
        even[evenIndex] = mainArray[i];
        evenIndex++;
    }
    else
    {
        odd[oddIndex] = mainArray[i];
        oddIndex++;
    }
}


Console.WriteLine("Output");

Console.Write("მასივი#1 :");
for (int i = 0; i < even.Length; i++)
{
    Console.Write(" " + even[i]);
}
Console.WriteLine();

Console.Write("მასივი#2: ");
for (int i = 0; i < odd.Length; i++)
{
    Console.Write(odd[i]);
    if (i < odd.Length - 1)
    {
        Console.Write(" ");
    }
}
Console.WriteLine();

*/

/* 2
Dictionary<string, string> contacts = new Dictionary<string, string>();


contacts.Add("Giorgi", "599111222");
contacts.Add("Anano", "555333444");
contacts.Add("Dato", "577555666");


contacts.Remove("Anano");


if (contacts.ContainsKey("Giorgi"))
{
    contacts["Giorgi"] = "599000000";
}


foreach (var contact in contacts)
{
    Console.WriteLine($"სახელი: {contact.Key}, ნომერი: {contact.Value}");
}
*/

/* 3
Console.Write("Input: ");
int size = Convert.ToInt32(Console.ReadLine());

int[] numbers = new int[size];


for (int i = 0; i < size; i++)
{
    numbers[i] = Convert.ToInt32(Console.ReadLine());
}


var grouped = numbers.GroupBy(x => x).ToList();

foreach (var group in grouped)
{
    
    Console.WriteLine($"{group.Key} appears {group.Count()} times sum {group.Sum()}");
}
*/

/*

int[] scores = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Console.Write("Input (N): ");
int topN = Convert.ToInt32(Console.ReadLine());


var topScores = scores.OrderByDescending(x => x)
    .Take(topN)
    .OrderBy(x => x)
    .ToList();

Console.WriteLine("Output:");
Console.WriteLine(string.Join(" ", topScores));

*/
