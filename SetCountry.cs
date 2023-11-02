using Weather_App.Enum;

namespace Weather_App;

public class SetCountry
{
    public static void SetCountryEnum(int index)
    {
        switch (index + 1)
        {
            case 1:
                MainWindow.Country = Country.Afrikaan;
                return;
            case 2:
                MainWindow.Country = Country.Albanian;
                return;
            case 3:
                MainWindow.Country = Country.Arabic;
                return;
            case 4:
                MainWindow.Country = Country.Azerbaijani;
                return;
            case 5:
                MainWindow.Country = Country.Bulgarian;
                return;
            case 6:
                MainWindow.Country = Country.Catalan;
                return;
            case 7:
                MainWindow.Country = Country.Czech;
                return;
            case 8:
                MainWindow.Country = Country.Danish;
                return;
            case 9:
                MainWindow.Country = Country.German;
                return;
            case 10:
                MainWindow.Country = Country.Greek;
                return;
            case 11:
                MainWindow.Country = Country.English;
                return;
            case 12:
                MainWindow.Country = Country.Basque;
                return;
            case 13:
                MainWindow.Country = Country.Persian;
                return;
            case 14:
                MainWindow.Country = Country.Finnish;
                return;
            case 15:
                MainWindow.Country = Country.French;
                return;
            case 16:
                MainWindow.Country = Country.Galician;
                return;
            case 17:
                MainWindow.Country = Country.Hebrew;
                return;
            case 18:
                MainWindow.Country = Country.Hindi;
                return;
            case 19:
                MainWindow.Country = Country.Croatian;
                return;
            case 20:
                MainWindow.Country = Country.Hungarian;
                return;
            case 21:
                MainWindow.Country = Country.Indonesian;
                return;
            case 22:
                MainWindow.Country = Country.Italian;
                return;
            case 23:
                MainWindow.Country = Country.Japanese;
                return;
            case 24:
                MainWindow.Country = Country.Korean;
                return;
            case 25:
                MainWindow.Country = Country.Lithuanian;
                return;
            case 26:
                MainWindow.Country = Country.Macedonian;
                return;
            case 27:
                MainWindow.Country = Country.Norwegian;
                return;
            case 28:
                MainWindow.Country = Country.Dutch;
                return;
            case 29:
                MainWindow.Country = Country.Polish;
                return;
            case 30:
                MainWindow.Country = Country.Portuguese;
                return;
            case 31:
                MainWindow.Country = Country.Português_Brasil;
                return;
            case 32:
                MainWindow.Country = Country.Romanian;
                return;
            case 33:
                MainWindow.Country = Country.Russian;
                return;
            case 34:
                MainWindow.Country = Country.Swedish;
                return;
            case 35:
                MainWindow.Country = Country.Slovak;
                return;
            case 36:
                MainWindow.Country = Country.Slovenian;
                return;
            case 37:
                MainWindow.Country = Country.Spanish;
                return;
            case 38:
                MainWindow.Country = Country.Serbian;
                return;
            case 39:
                MainWindow.Country = Country.Thai;
                return;
            case 40:
                MainWindow.Country = Country.Turkish;
                return;
            case 41:
                MainWindow.Country = Country.Ukrainian;
                return;
            case 42:
                MainWindow.Country = Country.Vietnamese;
                return;
            case 43:
                MainWindow.Country = Country.Chinese_Simplified;
                return;
            case 44:
                MainWindow.Country = Country.Chinese_Traditional;
                return;
            case 45:
                MainWindow.Country = Country.Zulu;
                return;
            default:
                MainWindow.Country = Country.English;
                return;
        }
    }
}