/* 1
FileWorker textFile = new TxtFileWorker(128);
textFile.Write();
textFile.Read();
textFile.Delete();
textFile.Edit();

abstract class FileWorker
{
    public int MaxStorage { get; set; }
    public abstract string FileExtension { get; }

    public FileWorker(int maxStorage)
    {
        MaxStorage = maxStorage;
    }

    public virtual void Read() => Console.WriteLine("Reading file...");
    public virtual void Write() => Console.WriteLine("Writing file...");
    public virtual void Edit() => Console.WriteLine("Editing file...");
    public virtual void Delete() => Console.WriteLine("Deleting file...");
}

class TxtFileWorker : FileWorker
{
    public override string FileExtension => "txt";

    public TxtFileWorker(int maxStorage) : base(maxStorage) { }

    public override void Write()
    {
        Console.WriteLine($"I Can write to {FileExtension} file with max storage {MaxStorage}");
    }

    public override void Read()
    {
        Console.WriteLine($"I Can read from {FileExtension} file with max storage {MaxStorage}");
    }

    public override void Delete()
    {
        Console.WriteLine($"I Can delete from {FileExtension} file with max storage {MaxStorage}");
    }

    public override void Edit()
    {
        Console.WriteLine($"I Can edit{FileExtension} file with max storage {MaxStorage}");
    }
}
*/


/* 2
FinanceOperations bank = new Bank();
if (bank.CheckUserHistory())
{
    bank.CalculateLoanPercent(12, 500);
}

FinanceOperations mfo = new MicroFinance();
if (mfo.CheckUserHistory())
{
    mfo.CalculateLoanPercent(6, 300);
}

interface FinanceOperations
{
    void CalculateLoanPercent(int month, double amountPerMonth);
    bool CheckUserHistory();
}

class Bank : FinanceOperations
{
    public bool CheckUserHistory()
    {
        Random rnd = new Random();
        bool hasGoodHistory = rnd.Next(2) == 0;
        
        if (hasGoodHistory)
            Console.WriteLine("Bank approved your credit history!");
        else
            Console.WriteLine("Bank rejected your loan application due to poor history.");
            
        return hasGoodHistory;
    }

    public void CalculateLoanPercent(int month, double amountPerMonth)
    {
        double totalRequestedAmount = month * amountPerMonth;
        double totalInterest = totalRequestedAmount * 0.05; 
        double totalToPay = totalRequestedAmount + totalInterest;

        Console.WriteLine($"Loan approved for {month} months.");
        Console.WriteLine($"Total Principal Amount: {totalRequestedAmount}$");
        Console.WriteLine($"Total Interest Fee (5%): {totalInterest}$");
        Console.WriteLine($"Total Amount to Pay back: {totalToPay}$");
    }
}

class MicroFinance : FinanceOperations
{
    public bool CheckUserHistory()
    {
        Console.WriteLine("MicroFinance automatically approved your loan history!");
        return true; 
    }

    public void CalculateLoanPercent(int month, double amountPerMonth)
    {
        double totalRequestedAmount = month * amountPerMonth;
        double totalInterest = totalRequestedAmount * 0.05; 
        double totalToPay = totalRequestedAmount + totalInterest;

        Console.WriteLine($"MicroFinance Loan Details: Total to return after {month} months is {totalToPay}$ (Includes 5% fee: {totalInterest}$)");
    }
}
*/