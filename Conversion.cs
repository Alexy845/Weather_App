using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;

namespace Weather_App;

public class Conversion
{
    public static float KelvinToCelsius(float kelvin)
    {
        return (float)Math.Floor(kelvin - 273.15f);
    }

    public static string GetCountryCode(string countryName)
    {
        var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Select(x => new RegionInfo(x.Name));
        var region = regions.FirstOrDefault(r => r.EnglishName.Contains(countryName));
        return region != null ? region.TwoLetterISORegionName : "Country not found";
    }
    
    public static void DownloadImageFromUrl(string imageUrl, string saveLocation)
    {
        using (WebClient webClient = new WebClient())
        {
            webClient.DownloadFile(imageUrl, saveLocation);
        }
    }

    public static string KelvinToFahrenheit(float mainTemp)
    {
        return Math.Floor(mainTemp * 9 / 5 - 459.67f).ToString(CultureInfo.CurrentCulture);
    }
}
