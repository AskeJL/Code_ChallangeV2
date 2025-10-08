using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WeatherDocument
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

    public record Metar(
        [property: JsonPropertyName("report")] Report report
    );
    public record Report(
        [property: JsonPropertyName("conditions")] Conditions conditions,
        [property: JsonPropertyName("forecast")] Forecast forecast,
        [property: JsonPropertyName("windsAloft")] WindsAloft? windsAloft
    );

    public record CloudLayer(
        [property: JsonPropertyName("coverage")] string coverage,
        [property: JsonPropertyName("type")] string type,
        [property: JsonPropertyName("altitudeFt")] float? altitudeFt,
        [property: JsonPropertyName("ceiling")] bool? ceiling
    );

    public record CloudLayersV2(
        [property: JsonPropertyName("coverage")] string coverage,
        [property: JsonPropertyName("type")] string type,
        [property: JsonPropertyName("altitudeFt")] float? altitudeFt,
        [property: JsonPropertyName("ceiling")] bool? ceiling
    );

    public record Conditions(
        [property: JsonPropertyName("text")] string text,
        [property: JsonPropertyName("dateIssued")] DateTime? dateIssued,
        [property: JsonPropertyName("lat")] double? lat,
        [property: JsonPropertyName("lon")] double? lon,
        [property: JsonPropertyName("elevationFt")] float? elevationFt,
        [property: JsonPropertyName("relativeHumidity")] float? relativeHumidity,
        [property: JsonPropertyName("flightRules")] string flightRules,
        [property: JsonPropertyName("cloudLayers")] IReadOnlyList<CloudLayer> cloudLayers,
        [property: JsonPropertyName("cloudLayersV2")] IReadOnlyList<CloudLayersV2> cloudLayersV2,
        [property: JsonPropertyName("weather")] IReadOnlyList<string> weather,
        [property: JsonPropertyName("visibility")] Visibility visibility,
        [property: JsonPropertyName("wind")] Wind wind,
        [property: JsonPropertyName("period")] Period period,
        [property: JsonPropertyName("change")] string change,
        [property: JsonPropertyName("ident")] string ident,
        [property: JsonPropertyName("tempC")] float? tempC,
        [property: JsonPropertyName("dewpointC")] float? dewpointC,
        [property: JsonPropertyName("pressureHg")] double? pressureHg,
        [property: JsonPropertyName("pressureHpa")] float? pressureHpa,
        [property: JsonPropertyName("reportedAsHpa")] bool? reportedAsHpa,
        [property: JsonPropertyName("densityAltitudeFt")] float? densityAltitudeFt,
        [property: JsonPropertyName("autonomous")] bool? autonomous
    );

    public record Forecast(
        [property: JsonPropertyName("text")] string text,
        [property: JsonPropertyName("ident")] string ident,
        [property: JsonPropertyName("dateIssued")] DateTime? dateIssued,
        [property: JsonPropertyName("period")] Period period,
        [property: JsonPropertyName("lat")] double? lat,
        [property: JsonPropertyName("lon")] double? lon,
        [property: JsonPropertyName("elevationFt")] float? elevationFt,
        [property: JsonPropertyName("conditions")] IReadOnlyList<Conditions> conditions
    );

    public record Period(
        [property: JsonPropertyName("dateStart")] DateTime? dateStart,
        [property: JsonPropertyName("dateEnd")] DateTime? dateEnd
    );

    public record Visibility(
        [property: JsonPropertyName("distanceSm")] double? distanceSm,
        [property: JsonPropertyName("distanceMeter")] float? distanceMeter,
        [property: JsonPropertyName("distanceQualifier")] float? distanceQualifier,
        [property: JsonPropertyName("prevailingVisSm")] double? prevailingVisSm,
        [property: JsonPropertyName("prevailingVisMeter")] float? prevailingVisMeter,
        [property: JsonPropertyName("prevailingVisDistanceQualifier")] float? prevailingVisDistanceQualifier,
        [property: JsonPropertyName("visReportedInMetric")] bool? visReportedInMetric
    );

    public record Wind(
        [property: JsonPropertyName("speedKts")] float? speedKts,
        [property: JsonPropertyName("direction")] float? direction,
        [property: JsonPropertyName("from")] float? from,
        [property: JsonPropertyName("variable")] bool? variable
    );

    public record WindsAloft(
        [property: JsonPropertyName("lat")] double? lat,
        [property: JsonPropertyName("lon")] double? lon,
        [property: JsonPropertyName("dateIssued")] DateTime? dateIssued,
        [property: JsonPropertyName("windsAloft")] IReadOnlyList<WindsAloft> windsAloft,
        [property: JsonPropertyName("source")] string source,
        [property: JsonPropertyName("validTime")] DateTime? validTime,
        [property: JsonPropertyName("period")] Period period,
        [property: JsonPropertyName("windTemps")] WindTemps windTemps
    );

    public record WindTemps(
        [property: JsonPropertyName("0")] _0 _0,
        [property: JsonPropertyName("3000")] _3000 _3000,
        [property: JsonPropertyName("6000")] _6000 _6000,
        [property: JsonPropertyName("9000")] _9000 _9000,
        [property: JsonPropertyName("12000")] _12000 _12000,
        [property: JsonPropertyName("15000")] _15000 _15000,
        [property: JsonPropertyName("18000")] _18000 _18000,
        [property: JsonPropertyName("21000")] _21000 _21000,
        [property: JsonPropertyName("24000")] _24000 _24000,
        [property: JsonPropertyName("27000")] _27000 _27000,
        [property: JsonPropertyName("30000")] _30000 _30000,
        [property: JsonPropertyName("33000")] _33000 _33000,
        [property: JsonPropertyName("36000")] _36000 _36000,
        [property: JsonPropertyName("39000")] _39000 _39000,
        [property: JsonPropertyName("42000")] _42000 _42000,
        [property: JsonPropertyName("45000")] _45000 _45000,
        [property: JsonPropertyName("48000")] _48000 _48000,
        [property: JsonPropertyName("51000")] _51000 _51000,
        [property: JsonPropertyName("54000")] _54000 _54000
    );

    public record _0(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _12000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _15000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _18000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _21000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _24000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _27000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _3000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _30000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _33000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _36000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _39000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _42000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _45000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _48000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _51000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _54000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _6000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

    public record _9000(
        [property: JsonPropertyName("directionFromTrue")] float? directionFromTrue,
        [property: JsonPropertyName("knots")] float? knots,
        [property: JsonPropertyName("celsius")] float? celsius,
        [property: JsonPropertyName("altitude")] float? altitude,
        [property: JsonPropertyName("isLightAndVariable")] bool? isLightAndVariable,
        [property: JsonPropertyName("isGreaterThan199Knots")] bool? isGreaterThan199Knots,
        [property: JsonPropertyName("turbulence")] bool? turbulence,
        [property: JsonPropertyName("icing")] bool? icing
    );

}
