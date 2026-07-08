using System.Xml.Linq;
using System.Text.Json;

/* 1
string file1Path = @"C:\Users\ggong\OneDrive\Desktop\HomeWorks\Homework11\Homework11\test_file.txt";
if (!File.Exists(file1Path))
{
    File.Create(file1Path).Close();
}

Console.Write("Enter number of lines: ");
int n1 = Convert.ToInt32(Console.ReadLine());

string[] lines = new string[n1];
for (int i = 0; i < n1; i++)
{
    lines[i] = Console.ReadLine();
}
File.WriteAllLines(file1Path, lines);

string[] allLinesInFile = File.ReadAllLines(file1Path);
string lastLine = allLinesInFile.Last();
Console.WriteLine($"Output: {lastLine}");
*/

/* 2
string file2Path = @"C:\Users\ggong\OneDrive\Desktop\HomeWorks\Homework11\Homework11\multiplication_table.txt";
Console.Write("Enter N: ");
int n2 = Convert.ToInt32(Console.ReadLine());

string result2 = "";
for (int i = 1; i <= 9; i++)
{
    for (int j = 1; j <= n2; j++)
    {
        result2 += $"{j} * {i} = {j * i}";
        if (j < n2)
        {
            result2 += " | ";
        }
    }
    result2 += Environment.NewLine;
}

Console.WriteLine(Environment.NewLine + "Output:");
Console.Write(result2);
File.WriteAllText(file2Path, result2);
*/

/* 3
string file3Path = @"C:\Users\ggong\OneDrive\Desktop\HomeWorks\Homework11\Homework11\output.xml";

Console.Write("Enter string: ");
string inputString = Console.ReadLine(); 

Console.Write("Enter N: ");
int n3 = Convert.ToInt32(Console.ReadLine()); 

int partLength = (int)Math.Ceiling((double)inputString.Length / n3);

XElement root = new XElement("Root");
for (int i = 0; i < n3; i++)
{
    int startIndex = i * partLength;
    int length = Math.Min(partLength, inputString.Length - startIndex);
    string subString = inputString.Substring(startIndex, length);

    XElement node = new XElement(subString, $"string {i + 1}");
    root.Add(node);
}

XDocument xmlDoc = new XDocument(root);
xmlDoc.Save(file3Path);

Console.WriteLine("\nOutput (XML File Content):");
Console.WriteLine(xmlDoc.ToString());
*/

/* 4
string json4Path = @"C:\Users\ggong\OneDrive\Desktop\HomeWorks\Homework11\Homework11\birthday_data.json";

string jsonString4 = File.ReadAllText(json4Path);

using JsonDocument doc4 = JsonDocument.Parse(jsonString4);
JsonElement root4 = doc4.RootElement;

string currentStr = root4.GetProperty("currentDate").GetString();
string birthdayStr = root4.GetProperty("birthday").GetString();

DateTime currentDate = DateTime.Parse(currentStr);
DateTime birthdayDate = DateTime.Parse(birthdayStr);

TimeSpan difference = birthdayDate - currentDate;
int daysLeft = difference.Days;

Console.WriteLine($"Output: {daysLeft}");
*/

/*
string input5Path = @"C:\Users\ggong\OneDrive\Desktop\HomeWorks\Homework11\Homework11\input.json";
string output5Path = @"C:\Users\ggong\OneDrive\Desktop\HomeWorks\Homework11\Homework11\output.json";

string jsonString5 = File.ReadAllText(input5Path);

using JsonDocument doc5 = JsonDocument.Parse(jsonString5);
JsonElement root5 = doc5.RootElement;

string word = root5.GetProperty("word").GetString();
int key = Convert.ToInt32(root5.GetProperty("key").GetString());

string cipherResult = "";
foreach (char c in word)
{
    if (char.IsUpper(c))
    {
        int alphabetIndex = c - 'A';
        int newIndex = (alphabetIndex + key) % 26;
        char cipherChar = (char)('A' + newIndex);
        cipherResult += cipherChar;
    }
    else
    {
        cipherResult += c;
    }
}

var outputObj = new { Cipher = cipherResult };
string outputJson = JsonSerializer.Serialize(outputObj, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText(output5Path, outputJson);

Console.WriteLine("Output JSON Content:");
Console.WriteLine(outputJson);
*/