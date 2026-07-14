using System.Text;
using CodeInspector.Models;
using CodeInspector.Report.Models;

namespace CodeInspector.Report.Html;

public static class HtmlTemplate
{
    public static string Header(ReportModel report)
    {
        return $@"
<html>

<head>

<title>CodeInspector Report</title>

<style>

body
{{
font-family:Segoe UI;
background:#f5f5f5;
margin:40px;
}}

table
{{
border-collapse:collapse;
width:100%;
}}

th
{{
background:#333;
color:white;
padding:10px;
}}

td
{{
padding:8px;
border-bottom:1px solid #ddd;
}}

.High{{color:#d35400;font-weight:bold;}}

.Critical{{color:red;font-weight:bold;}}

.Medium{{color:#2980b9;font-weight:bold;}}

.Low{{color:green;font-weight:bold;}}

</style>

</head>

<body>

<h1>CodeInspector</h1>

<h2>Project : {report.ProjectName}</h2>

<h3>Scan Date : {report.ScanDate}</h3>

<h3>Total Files : {report.TotalFiles}</h3>

<h3>Total Issues : {report.TotalIssues}</h3>

<br/>

<table>

<tr>

<th>Rule</th>

<th>Severity</th>

<th>File</th>

<th>Class</th>

<th>Method</th>

<th>Message</th>

<th>Recommendation</th>

</tr>";
    }

    public static string Issue(Issue issue)
    {
        return $@"
<tr>

<td>{issue.RuleId}</td>

<td class='{issue.Severity}'>{issue.Severity}</td>

<td>{issue.FileName}</td>

<td>{issue.ClassName}</td>

<td>{issue.MethodName}</td>

<td>{issue.Message}</td>

<td>{issue.Recommendation}</td>

</tr>";
    }

    public static string Footer()
    {
        return @"
</table>

</body>

</html>";
    }
}