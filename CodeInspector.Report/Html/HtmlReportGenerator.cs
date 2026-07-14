using System.Text;
using CodeInspector.Report.Models;

namespace CodeInspector.Report.Html;

public class HtmlReportGenerator
{
    public void Generate(
        ReportModel report,
        string outputFile)
    {
        var html = new StringBuilder();

        html.Append(HtmlTemplate.Header(report));

        foreach (var issue in report.Issues)
        {
            html.Append(HtmlTemplate.Issue(issue));
        }

        html.Append(HtmlTemplate.Footer());

        File.WriteAllText(outputFile, html.ToString());
    }
}