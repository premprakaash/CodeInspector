namespace CodeInspector.Data.Entities;

public class Report
{
    public Guid Id { get; set; }

    public Guid ScanId { get; set; }

    public string HtmlPath { get; set; } = "";

    public string PdfPath { get; set; } = "";

    public DateTime GeneratedOn { get; set; }
        = DateTime.UtcNow;

    public Scan Scan { get; set; } = null!;
}