using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDocument;

namespace WeatherDocumentTests
{

    public static class ReportTestData
    {
        public static Report CreateSampleReport()
        {
            return new Report(
                conditions: new Conditions(
                    text: "Clear skies, light winds",
                    dateIssued: DateTime.UtcNow,
                    lat: 55.615,
                    lon: 12.656,
                    elevationFt: 141,
                    relativeHumidity: 65,
                    flightRules: "VFR",
                    cloudLayers: new List<CloudLayer>
                    {
                    new CloudLayer(coverage: "FEW", type: "Cumulus", altitudeFt: 1200, ceiling: false),
                    new CloudLayer(coverage: "SCT", type: "Stratus", altitudeFt: 2500, ceiling: false)
                    },
                    cloudLayersV2: new List<CloudLayersV2>
                    {
                    new CloudLayersV2(coverage: "BKN", type: "Altostratus", altitudeFt: 4000, ceiling: true)
                    },
                    weather: new List<string> { "Clear", "No significant weather" },
                    visibility: new Visibility(
                        distanceSm: 10,
                        distanceMeter: 16000,
                        distanceQualifier: null,
                        prevailingVisSm: 10,
                        prevailingVisMeter: 16000,
                        prevailingVisDistanceQualifier: null,
                        visReportedInMetric: true
                    ),
                    wind: new Wind(speedKts: 8, direction: 180, from: null, variable: false),
                    period: new Period(
                        dateStart: DateTime.UtcNow,
                        dateEnd: DateTime.UtcNow.AddHours(1)
                    ),
                    change: "No significant change",
                    ident: "EKCH",
                    tempC: 12,
                    dewpointC: 8,
                    pressureHg: 29.92,
                    pressureHpa: 1013,
                    reportedAsHpa: true,
                    densityAltitudeFt: 145,
                    autonomous: false
                ),
                forecast: new Forecast(
                    text: "Forecast: Clear skies, mild temperatures",
                    ident: "EKCH",
                    dateIssued: DateTime.UtcNow,
                    period: new Period(
                        dateStart: DateTime.UtcNow,
                        dateEnd: DateTime.UtcNow.AddHours(6)
                    ),
                    lat: 55.615,
                    lon: 12.656,
                    elevationFt: 141,
                    conditions: new List<Conditions>
                    {
                    new Conditions(
                        text: "Forecast condition",
                        dateIssued: DateTime.UtcNow.AddHours(1),
                        lat: 55.615,
                        lon: 12.656,
                        elevationFt: 141,
                        relativeHumidity: 60,
                        flightRules: "VFR",
                        cloudLayers: new List<CloudLayer>
                        {
                            new CloudLayer(coverage: "SCT", type: "Cumulus", altitudeFt: 1500, ceiling: false)
                        },
                        cloudLayersV2: new List<CloudLayersV2>(),
                        weather: new List<string> { "Sunny" },
                        visibility: new Visibility(
                            distanceSm: 10,
                            distanceMeter: 16000,
                            distanceQualifier: null,
                            prevailingVisSm: 10,
                            prevailingVisMeter: 16000,
                            prevailingVisDistanceQualifier: null,
                            visReportedInMetric: true
                        ),
                        wind: new Wind(speedKts: 5, direction: 200, from: null, variable: false),
                        period: new Period(
                            dateStart: DateTime.UtcNow.AddHours(1),
                            dateEnd: DateTime.UtcNow.AddHours(2)
                        ),
                        change: "Slight increase in wind",
                        ident: "EKCH",
                        tempC: 13,
                        dewpointC: 9,
                        pressureHg: 29.90,
                        pressureHpa: 1012,
                        reportedAsHpa: true,
                        densityAltitudeFt: 150,
                        autonomous: false
                    )
                    }
                ),
                windsAloft: null
            );
        }
        public static List<Report> CreateSampleReports(int count = 3)
        {
            var reports = new List<Report>();

            for (int i = 0; i < count; i++)
            {
                string icao = $"ICAO{i + 1:D3}"; // ICAO1, ICAO2, ICAO3...
                var report = new Report(
                    conditions: new Conditions(
                        text: $"Clear skies report {i + 1}",
                        dateIssued: DateTime.UtcNow.AddHours(-i),
                        lat: 55.615 + i * 0.01,
                        lon: 12.656 + i * 0.01,
                        elevationFt: 141 + i,
                        relativeHumidity: 60 + i,
                        flightRules: "VFR",
                        cloudLayers: new List<CloudLayer>
                        {
                        new CloudLayer(coverage: "FEW", type: "Cumulus", altitudeFt: 1200 + i*100, ceiling: false)
                        },
                        cloudLayersV2: new List<CloudLayersV2>(),
                        weather: new List<string> { "Clear" },
                        visibility: new Visibility(
                            distanceSm: 10,
                            distanceMeter: 16000,
                            distanceQualifier: null,
                            prevailingVisSm: 10,
                            prevailingVisMeter: 16000,
                            prevailingVisDistanceQualifier: null,
                            visReportedInMetric: true
                        ),
                        wind: new Wind(speedKts: 8 + i, direction: 180, from: null, variable: false),
                        period: new Period(
                            dateStart: DateTime.UtcNow.AddHours(-i),
                            dateEnd: DateTime.UtcNow.AddHours(-i + 1)
                        ),
                        change: "No significant change",
                        ident: icao,
                        tempC: 12 + i,
                        dewpointC: 8 + i,
                        pressureHg: 29.92,
                        pressureHpa: 1013,
                        reportedAsHpa: true,
                        densityAltitudeFt: 145 + i,
                        autonomous: false
                    ),
                    forecast: new Forecast(
                        text: $"Forecast {i + 1}",
                        ident: icao,
                        dateIssued: DateTime.UtcNow.AddHours(-i),
                        period: new Period(
                            dateStart: DateTime.UtcNow.AddHours(-i),
                            dateEnd: DateTime.UtcNow.AddHours(-i + 6)
                        ),
                        lat: 55.615 + i * 0.01,
                        lon: 12.656 + i * 0.01,
                        elevationFt: 141 + i,
                        conditions: new List<Conditions>
                        {
                        new Conditions(
                            text: $"Forecast condition {i + 1}",
                            dateIssued: DateTime.UtcNow.AddHours(-i + 1),
                            lat: 55.615 + i * 0.01,
                            lon: 12.656 + i * 0.01,
                            elevationFt: 141 + i,
                            relativeHumidity: 60 + i,
                            flightRules: "VFR",
                            cloudLayers: new List<CloudLayer>
                            {
                                new CloudLayer(coverage: "SCT", type: "Cumulus", altitudeFt: 1500 + i*100, ceiling: false)
                            },
                            cloudLayersV2: new List<CloudLayersV2>(),
                            weather: new List<string> { "Sunny" },
                            visibility: new Visibility(
                                distanceSm: 10,
                                distanceMeter: 16000,
                                distanceQualifier: null,
                                prevailingVisSm: 10,
                                prevailingVisMeter: 16000,
                                prevailingVisDistanceQualifier: null,
                                visReportedInMetric: true
                            ),
                            wind: new Wind(speedKts: 5 + i, direction: 200, from: null, variable: false),
                            period: new Period(
                                dateStart: DateTime.UtcNow.AddHours(-i + 1),
                                dateEnd: DateTime.UtcNow.AddHours(-i + 2)
                            ),
                            change: "Slight increase in wind",
                            ident: icao,
                            tempC: 13 + i,
                            dewpointC: 9 + i,
                            pressureHg: 29.90,
                            pressureHpa: 1012,
                            reportedAsHpa: true,
                            densityAltitudeFt: 150 + i,
                            autonomous: false
                        )
                        }
                    ),
                    windsAloft: null
                );

                reports.Add(report);
            }

            return reports;
        }

    }
}
