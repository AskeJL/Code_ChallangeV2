
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherDocument
{
    public class PDFHelper
    {
        private static readonly SemaphoreSlim _browserInitLock = new SemaphoreSlim(1, 1);
        private static readonly SemaphoreSlim _pdfSemaphore = new SemaphoreSlim(3);
        private static IBrowser? _browser;

        public static async Task ConvertReportsToPdfAsync(List<Report> reports, string[] icaoCodes)
        {
            await _pdfSemaphore.WaitAsync(); // acquire slot
            try
            {
                if (reports == null || reports.Count == 0)
                    throw new ArgumentException("No reports to render");

                string html = BuildHtml(reports, icaoCodes);
                var browser = await GetBrowserAsync();
                using var page = await browser.NewPageAsync();

                await page.SetContentAsync(html, new NavigationOptions
                {
                    WaitUntil = new[] { WaitUntilNavigation.Networkidle0 }
                });

                string pdfFilePath = $"..\\..\\..\\..\\Generated\\MetarReport_{string.Join("_", icaoCodes)}.pdf";

                await page.PdfAsync(pdfFilePath, new PdfOptions
                {
                    Format = PaperFormat.A4,
                    PrintBackground = true,
                    MarginOptions = new MarginOptions
                    {
                        Top = "20mm",
                        Right = "15mm",
                        Bottom = "20mm",
                        Left = "15mm"
                    }
                });

                Console.WriteLine("PDF generated and saved to " + pdfFilePath);
            }
            finally
            {
                _pdfSemaphore.Release(); // release slot
            }
        }


        internal static string BuildHtml(List<Report> reports, string[] icaoCodes)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<html><head><meta charset='UTF-8'>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Arial; font-size: 11pt; }");
            sb.AppendLine(".title { font-size: 18pt; font-weight: bold; margin-bottom: 15px; }");
            sb.AppendLine(".report { margin-bottom: 40px; break-after: page;}");
            sb.AppendLine(".section { margin-bottom: 20px;}");
            sb.AppendLine(".section-title { font-size: 13pt; font-weight: bold; margin-top: 10px; }");
            sb.AppendLine(".row { margin: 3px 0; }");
            sb.AppendLine("</style></head><body>");

            sb.AppendLine($"<div class='title'>Vejrrapport (Weather Report) - {string.Join(", ", icaoCodes)}</div>");
            var i = 0;
            foreach (var report in reports)
            {
                sb.AppendLine("<div class='report'>"); // wrapper for each report

                var ident = report?.conditions?.ident ?? report?.forecast?.ident ?? "Unknown";
                sb.AppendLine($"<div class='section'><h2>Station: {WebUtility.HtmlEncode(ident)}</h2>");

                var conditions = new List<Conditions>();
                if (report.conditions != null) conditions.Add(report.conditions);
                if (report.forecast?.conditions != null) conditions.AddRange(report.forecast.conditions);

                foreach (var (condition, index) in conditions.Select((c, i) => (c, i)))
                {
                    var heading = (index == 0 && report.conditions != null) ? "Metar condition" : "Taf condition";
                    sb.AppendLine($"<div class='section'><h3>{heading}</h3>");

                    sb.AppendLine(Row("Sigtbarhed (Visibility)", condition?.visibility?.distanceSm != null ? $"{condition.visibility.distanceSm} miles" : "Data unavailable"));
                    sb.AppendLine(Row("Temperatur (Temperature)", condition?.tempC?.ToString() + " °C" ?? "Data unavailable"));
                    sb.AppendLine(Row("Tryk (Pressure)", condition?.pressureHg?.ToString() + " inHg" ?? "Data unavailable"));
                    sb.AppendLine(Row("Vind Hastighed (Wind Speed)", condition?.wind?.speedKts?.ToString() + " kts" ?? "Data unavailable"));
                    sb.AppendLine(Row("Vind Retning (Wind Direction)", condition?.wind?.direction?.ToString() + "°" ?? "Data unavailable"));
                    sb.AppendLine(Row("Sidst opdateret", condition?.dateIssued?.ToString("dd-MM-yyyy HH:mm:ss") ?? "Data unavailable"));

                    sb.AppendLine("</div>"); // end section
                }

                sb.AppendLine("</div>"); // end report
                if (i < reports.Count - 1)
                {
                    sb.AppendLine("<div style='page-break-before: always;'></div>");
                }
                i++;
            }

            sb.AppendLine("</body></html>");
            return sb.ToString();
        }

        private static string Row(string key, string value) =>
            $"<div class='row'><b>{WebUtility.HtmlEncode(key)}:</b> {WebUtility.HtmlEncode(value)}</div>";

        public static async Task<IBrowser> GetBrowserAsync()
        {
            if (_browser != null) return _browser;

            await _browserInitLock.WaitAsync(); // only one thread enters

            try
            {
                if (_browser != null) return _browser; // check again inside lock

                // Safe download path
                var browserFetcher = new BrowserFetcher(new BrowserFetcherOptions());

                // Only one download at a time
                await browserFetcher.DownloadAsync();

                _browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true,
                    Args = new[] { "--no-sandbox", "--disable-setuid-sandbox" }
                });

                return _browser;
            }
            finally
            {
                _browserInitLock.Release();
            }
        }
    }
}
