using System;

namespace Weather_App;

public class Conversion
{
    public static float KelvinToCelsius(float kelvin)
    {
        return (float)Math.Floor(kelvin - 273.15f);
    }
}
