using CountriesWeb.Models;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var countries = new List<Country>
{
    new() { Id = 1, Name = "United States", Code = "US", Capital = "Washington D.C.", Region = "North America", Population = 331000000 },
    new() { Id = 2, Name = "Canada", Code = "CA", Capital = "Ottawa", Region = "North America", Population = 38000000 },
    new() { Id = 3, Name = "United Kingdom", Code = "GB", Capital = "London", Region = "Europe", Population = 67000000 },
    new() { Id = 4, Name = "Germany", Code = "DE", Capital = "Berlin", Region = "Europe", Population = 83000000 },
    new() { Id = 5, Name = "France", Code = "FR", Capital = "Paris", Region = "Europe", Population = 67000000 },
    new() { Id = 6, Name = "India", Code = "IN", Capital = "New Delhi", Region = "Asia", Population = 1393000000 },
    new() { Id = 7, Name = "Japan", Code = "JP", Capital = "Tokyo", Region = "Asia", Population = 125000000 },
    new() { Id = 8, Name = "Australia", Code = "AU", Capital = "Canberra", Region = "Oceania", Population = 26000000 },
    new() { Id = 9, Name = "Brazil", Code = "BR", Capital = "Brasília", Region = "South America", Population = 215000000 },
    new() { Id = 10, Name = "South Africa", Code = "ZA", Capital = "Pretoria", Region = "Africa", Population = 60000000 }
};

app.MapGet("/", () =>
{
    var html = BuildHtml(countries);
    return Results.Content(html, "text/html", Encoding.UTF8);
});

app.Run();

static string BuildHtml(IEnumerable<Country> countries)
{
    var sb = new StringBuilder();
    sb.AppendLine("<!doctype html>");
    sb.AppendLine("<html lang=\"en\">");
    sb.AppendLine("<head>");
    sb.AppendLine("  <meta charset=\"utf-8\" />");
    sb.AppendLine("  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />");
    sb.AppendLine("  <title>Countries</title>");
    sb.AppendLine("  <style>");
    sb.AppendLine("    body{font-family:Segoe UI,Arial,sans-serif;background:#f6f7fb;margin:0;padding:24px;color:#222}");
    sb.AppendLine("    .container{max-width:900px;margin:0 auto;background:#fff;border-radius:12px;box-shadow:0 8px 24px rgba(0,0,0,.08);padding:24px}");
    sb.AppendLine("    h1{margin:0 0 16px 0;font-size:28px}");
    sb.AppendLine("    table{width:100%;border-collapse:collapse}");
    sb.AppendLine("    th,td{padding:12px;border-bottom:1px solid #eee;text-align:left}");
    sb.AppendLine("    th{background:#f0f2f7;font-weight:600}");
    sb.AppendLine("    tr:hover{background:#fafbff}");
    sb.AppendLine("    .country-name{color:green;font-weight:600;font-size:50px}");
    sb.AppendLine("    .pill{display:inline-block;background:#eef3ff;color:#2a4b8d;border-radius:999px;padding:4px 10px;font-size:12px}");
    sb.AppendLine("  </style>");
    sb.AppendLine("</head>");
    sb.AppendLine("<body>");
    sb.AppendLine("  <div class=\"container\">");
    sb.AppendLine("    <h1>Countries</h1>");
    sb.AppendLine("    <table>");
    sb.AppendLine("      <thead><tr><th>Name</th><th>Code</th><th>Capital</th><th>Region</th><th>Population</th></tr></thead>");
    sb.AppendLine("      <tbody>");

    foreach (var c in countries)
    {
        sb.AppendLine($"<tr><td class=\"country-name\">{WebUtility.HtmlEncode(c.Name)}</td><td><span class=\"pill\">{WebUtility.HtmlEncode(c.Code)}</span></td><td>{WebUtility.HtmlEncode(c.Capital)}</td><td>{WebUtility.HtmlEncode(c.Region)}</td><td>{c.Population:N0}</td></tr>");
    }

    sb.AppendLine("      </tbody>");
    sb.AppendLine("    </table>");
    sb.AppendLine("  </div>");
    sb.AppendLine("</body>");
    sb.AppendLine("</html>");

    return sb.ToString();
}
