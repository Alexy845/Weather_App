using System;
using System.Globalization;
using System.Linq;

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
}
