public class ReportHeader
{
    public string GetHtmlHeader() => "<header> My Header </header>";
    public string GetPdfHeader() => "Header : I’m using Facade Pattern";
}

public class ReportBody
{
    public string GetHtmlBody() => "<body>\nVideo provides a powerful way to help you prove your point. When you click" +
                                   "\nOnline Video, you can paste in the embed code for the video you want to add." +
                                   "\n</body>";
    
    public string GetPdfBody() => "Body :\nVideo provides a powerful way to help you prove your point. When you click" +
                                  "\nOnline Video, you can paste in the embed code for the video you want to add." +
                                  "\nYou can also type a keyword to search online for the video that best fits your" +
                                  "\ndocument. To make your document look professionally produced, Word provides";
}

public class ReportFooter
{
    public string GetHtmlFooter() => "<footer> My Footer </footer>";
    public string GetPdfFooter() => "Footer: Page 1";
}

public class ReportGeneratorFacade
{
    private readonly ReportHeader _header = new();
    private readonly ReportBody _body = new();
    private readonly ReportFooter _footer = new();

    public void GenerateHtml()
    {
        Console.WriteLine(_header.GetHtmlHeader());
        Console.WriteLine(_body.GetHtmlBody());
        Console.WriteLine(_footer.GetHtmlFooter());
    }

    public void GeneratePdf()
    {
        Console.WriteLine(_header.GetPdfHeader());
        Console.WriteLine(_body.GetPdfBody());
        Console.WriteLine(_footer.GetPdfFooter());
    }
}