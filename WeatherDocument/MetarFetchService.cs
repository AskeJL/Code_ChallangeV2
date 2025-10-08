using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("WeatherDocumentTests")]

namespace WeatherDocument
{
    public static class MetarFetchService
    {
        private static readonly Uri _baseAddress = new Uri("https://qa.foreflight.com/weather/report/");

        public static async Task<List<Report>> FetchMetarDatas(string[] icaos)
        {
            var reports = new List<Report>();
            var client = new HttpClient
            {
                BaseAddress = _baseAddress,
            };

            client.DefaultRequestHeaders.Add("ff-coding-exercise", "1");
            foreach (var icao in icaos)
            {
                var report = await FetchMetarData(icao, client);
                if (report is not null)
                {
                    reports.Add(report);
                }
            }
            return reports;
        }

        internal static async Task<Report> FetchMetarData(string icao, HttpClient client)
        {
            var retryPolicy = Policy
            .Handle<HttpRequestException>()
            .Or<TaskCanceledException>() // handles timeouts
            .WaitAndRetryAsync(
            retryCount: 3,
            sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
            onRetry: (exception, timeSpan, attempt, context) =>
            {
                Console.WriteLine($"Retry {attempt} for {icao} after {timeSpan.TotalSeconds}s due to {exception.Message}");
            });

            try
            {
                var response = await retryPolicy.ExecuteAsync(() => client.GetAsync(icao));
                var json = await response.Content.ReadAsStringAsync();
                var report = JsonConvert.DeserializeObject<Metar>(json);
                return report.report;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP error fetching METAR for {icao}: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON parse error for {icao}: {jsonEx.Message}");
            }
            catch (TaskCanceledException tcEx)
            {
                Console.WriteLine($"Request timeout for {icao}: {tcEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error for {icao}: {ex.Message}");
            }

            return null;
        }

    }
}
