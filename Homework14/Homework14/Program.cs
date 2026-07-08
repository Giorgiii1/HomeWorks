//1
IFurnitureFactory factory = new VictorianFurnitureFactory();

IChair chair = factory.CreateChair();
ISofa sofa = factory.CreateSofa();
ICoffeeTable table = factory.CreateCoffeeTable();

chair.SitOn();
sofa.LieOn();
table.PutCoffee();


factory = new ModernFurnitureFactory();

chair = factory.CreateChair();
sofa = factory.CreateSofa();
table =  factory.CreateCoffeeTable();

chair.SitOn();
sofa.LieOn();
table.PutCoffee();


//2
IActor actorProxy = new StuntmanProxy();

actorProxy.PerfomScene("Talking", isDangerous: false);
actorProxy.PerfomScene("Driving car", isDangerous: true);

//3
ReportGeneratorFacade facade = new ReportGeneratorFacade();
Console.WriteLine("HTML");
facade.GenerateHtml();
Console.WriteLine("PDF");
facade.GeneratePdf();

//4
FileProcessorContext processor = new();

string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");

processor.ProcessFile(Path.Combine(folderPath, "data.json"));
processor.ProcessFile(Path.Combine(folderPath, "archive.zip"));
processor.ProcessFile(Path.Combine(folderPath, "notes.txt"));
