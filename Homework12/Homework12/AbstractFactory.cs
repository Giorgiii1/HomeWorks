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


public interface IChair
{
    void SitOn();
}

public interface ISofa
{
    void LieOn();
}

public interface ICoffeeTable
{
    void PutCoffee();
}


public class VictorianChair : IChair
{
    public void SitOn() => Console.WriteLine("Victorian Chair SitOn");
}

public class VictorianSofa : ISofa
{
    public void LieOn() => Console.WriteLine("Victorian Sofa SitOn");
}

public class VictorianCoffeeTable : ICoffeeTable
{
    public void PutCoffee() => Console.WriteLine("Victorian Coffee PutCoffee");
}

public class ModernChair : IChair
{
    public void SitOn() => Console.WriteLine("Modern Chair SitOn");
}

public class ModernSofa : ISofa
{
    public void LieOn() => Console.WriteLine("Modern Sofa SitOn");
}

public class ModernCoffeeTable : ICoffeeTable
{
    public void PutCoffee() => Console.WriteLine("Modern Coffee PutCoffee");
}

public interface IFurnitureFactory
{
    IChair CreateChair();
    ISofa CreateSofa();
    ICoffeeTable CreateCoffeeTable();
}

public class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new VictorianChair();
    public ISofa CreateSofa() => new VictorianSofa();
    public ICoffeeTable CreateCoffeeTable() => new VictorianCoffeeTable();
}

public class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new ModernChair();
    public ISofa CreateSofa() => new ModernSofa();
    public ICoffeeTable CreateCoffeeTable() => new ModernCoffeeTable();
}