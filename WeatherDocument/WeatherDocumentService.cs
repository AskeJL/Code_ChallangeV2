using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("WeatherDocumentTests")]

namespace WeatherDocument
{
    public class WeatherDocumentService
    {
        public static async Task GenerateWeatherDocument(params string[] icaoCodes)
        {
            var reports = await MetarFetchService.FetchMetarDatas(icaoCodes);

            await PDFHelper.ConvertReportsToPdfAsync(reports, icaoCodes);
        }
    }
}
