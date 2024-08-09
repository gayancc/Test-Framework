using System.Text;

namespace FlurTestFramework.Infrastructure.Helpers;

public static class HtmlHelper
{
    public static string ToTable(this TestContext.TestAdapter adapter)
    {
        var parameters = adapter.Method?.GetParameters();
        var parameterValues = adapter.Arguments;
        if (parameters == null) return string.Empty;
        var htmlTable = new StringBuilder();


        htmlTable.Append("<table style='width:100%; border-collapse: collapse;'>")
            .Append("<thead>")
            .Append("<tr style='border-bottom: 1px solid black;'>")
            .Append("<th style='text-align: left; padding: 5px;'>Parameter Name</th>")
            .Append("<th style='text-align: left; padding: 5px;'>Value</th>")
            .Append("</tr>")
            .Append("</thead>")
            .Append("<tbody>");

        for (int i = 0; i < parameters.Length; i++)
        {
            string parameterName = parameters[i].ParameterInfo.Name;
            string parameterValue = parameterValues[i]?.ToString() ?? "null";

            htmlTable.Append("<tr>")
                .Append($"<td style='padding: 5px;'>{parameterName}</td>")
                .Append($"<td style='padding: 5px;'>{parameterValue}</td>")
                .Append("</tr>");
        }

        htmlTable.Append("</tbody></table>");
        return htmlTable.ToString();
    }
}