/* 1
Console.Write("Enter a: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter b: ");
int b = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter n: ");
int n = Convert.ToInt32(Console.ReadLine());

static int CountPowers(int a, int b, int n)
{
    int count = 0;
    for (int i = 1; i < b; i++)
    {
        if (Math.Pow(i, n) >= a && Math.Pow(i, n) <= b)
        {
            count++;
        }
        else if (Math.Pow(i, n) > b)
        {
            break;
        }
    }
    return count;
}

Console.WriteLine(CountPowers(a, b, n));
*/

/* 2
Console.Write("Enter characters: ");
string input = Console.ReadLine();

static int CountPairs(string input)
{
    var inputGroups = input.GroupBy(input => input);
    int totalPairs = 0;
    foreach (var group in inputGroups)
    {
        totalPairs = totalPairs + (group.Count() / 2);
    }

    return totalPairs;
}

Console.WriteLine($"output: {CountPairs(input)}");
*/

/* 3
Console.Write("Enter a: ");
string str1 = Convert.ToString(Console.ReadLine());
Console.Write("Enter b: ");
string str2 = Convert.ToString(Console.ReadLine());

static string LongestCommonSuffix(string str1, string str2)
{
    string suffix = "";
    
    int i = str1.Length - 1; 
    int j = str2.Length - 1;

    while (i >= 0 && j >= 0 && str1[i] == str2[j])
    {
        suffix = str1[i] + suffix;
        i--;
        j--;
    }

    return suffix;
}

Console.WriteLine(LongestCommonSuffix(str1, str2));
*/

/* 4
List<int> myNumbers = new List<int> { 5, 5 };
List<string> myStrings = new List<string> { "test", "random", "programming", "word" };
List<bool> myBools = new List<bool> { true, false, true, false, true, false, false };

ProcessList(myStrings);
ProcessList(myBools);
ProcessList(myNumbers);

static void ProcessList<T>(List<T> list)
{
    if (list is List<string> StringList)
    {
        foreach (var item in StringList)
        {
            Console.WriteLine(item.ToUpper());
        }
    }

    if (list is List<int> Int32List)
    {
        int sum = Int32List.Sum();
        Console.WriteLine($"Sum is {sum}");
    }

    if (list is List<bool> boolList)
    {
        Console.WriteLine($"First Element is {boolList[0]}");
        Console.WriteLine($"Middle Element is {boolList[boolList.Count / 2]}");
        Console.WriteLine($"Last Element is {boolList[boolList.Count - 1]}");
    }
}
*/

/* 5
Console.Write("Enter a number: ");
int n = Convert.ToInt32(Console.ReadLine());

static void PrintDigits(int n)
{
    if (n < 10)
    {
        Console.Write(n);
        return;
    }
    PrintDigits(n / 10);
    Console.Write($" - {n % 10}");
}

PrintDigits(n);
Console.WriteLine();
*/
 
/* 6
Console.Write("Enter numbers: ");
string input = Console.ReadLine();

int[] nums = input.Split(',').Select(int.Parse).ToArray();

bool hasDuplicate = ContainsDuplicate(nums);
Console.WriteLine("Result: " + hasDuplicate);

static bool ContainsDuplicate(int[] nums)
{
    return nums.Length > nums.Distinct().Count();
}
*/