using PdfSharp.Snippets;
using System;
using System.Collections.Generic;
using WeatherDocument;


namespace WeatherDocumentTests
{
    public class HtmlBuilderTests
    {
        [Test]
        public void BuildHtml_IncludesReportTitleAndStation()
        {
            // Arrange
            var reports = new List<Report>
        {
            ReportTestData.CreateSampleReport()
        };
            string[] icaoCodes = { "EKCH" };

            // Act
            string html = PDFHelper.BuildHtml(reports, icaoCodes);

            // Assert
            Assert.IsTrue(html.Contains("Vejrrapport"));
            Assert.IsTrue(html.Contains("EKCH"));
            Assert.IsTrue(html.Contains("<div class='row'><b>Temperatur (Temperature):</b> 12"));
            Assert.IsTrue(html.Contains("<div class='row'><b>Tryk (Pressure):</b> 29,92 inHg</div>"));
            Assert.IsTrue(html.Contains("<div class='row'><b>Vind Hastighed (Wind Speed):</b> 8 kts</div>"));
        }

        [Test]
        public void BuildHtml_MultipleReports_AddsPageBreak()
        {
            // Arrange
            var sampleReports = ReportTestData.CreateSampleReports(5); // 5 reports
            var html = PDFHelper.BuildHtml(sampleReports, new[] { "ICAO001", "ICAO002" });

            Assert.IsTrue(html.Contains("ICAO001"));
            Assert.IsTrue(html.Contains("ICAO002"));
            Assert.IsTrue(html.Contains("ICAO004"));
        }
    }
}