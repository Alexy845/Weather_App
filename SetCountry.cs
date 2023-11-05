using Weather_App.Enum;

namespace Weather_App;

public class SetCountry
{
    public static void SetCountryEnum(int index)
    {
        switch (index + 1)
        {
            case 1:
                MainWindow.country = Country.Afrikaan;
                return;
            case 2:
                MainWindow.country = Country.Albanian;
                return;
            case 3:
                MainWindow.country = Country.Arabic;
                return;
            case 4:
                MainWindow.country = Country.Azerbaijani;
                return;
            case 5:
                MainWindow.country = Country.Bulgarian;
                return;
            case 6:
                MainWindow.country = Country.Catalan;
                return;
            case 7:
                MainWindow.country = Country.Czech;
                return;
            case 8:
                MainWindow.country = Country.Danish;
                return;
            case 9:
                MainWindow.country = Country.German;
                return;
            case 10:
                MainWindow.country = Country.Greek;
                return;
            case 11:
                MainWindow.country = Country.English;
                return;
            case 12:
                MainWindow.country = Country.Basque;
                return;
            case 13:
                MainWindow.country = Country.Persian;
                return;
            case 14:
                MainWindow.country = Country.Finnish;
                return;
            case 15:
                MainWindow.country = Country.French;
                return;
            case 16:
                MainWindow.country = Country.Galician;
                return;
            case 17:
                MainWindow.country = Country.Hebrew;
                return;
            case 18:
                MainWindow.country = Country.Hindi;
                return;
            case 19:
                MainWindow.country = Country.Croatian;
                return;
            case 20:
                MainWindow.country = Country.Hungarian;
                return;
            case 21:
                MainWindow.country = Country.Indonesian;
                return;
            case 22:
                MainWindow.country = Country.Italian;
                return;
            case 23:
                MainWindow.country = Country.Japanese;
                return;
            case 24:
                MainWindow.country = Country.Korean;
                return;
            case 25:
                MainWindow.country = Country.Lithuanian;
                return;
            case 26:
                MainWindow.country = Country.Macedonian;
                return;
            case 27:
                MainWindow.country = Country.Norwegian;
                return;
            case 28:
                MainWindow.country = Country.Dutch;
                return;
            case 29:
                MainWindow.country = Country.Polish;
                return;
            case 30:
                MainWindow.country = Country.Portuguese;
                return;
            case 31:
                MainWindow.country = Country.PortuguêsBrasil;
                return;
            case 32:
                MainWindow.country = Country.Romanian;
                return;
            case 33:
                MainWindow.country = Country.Russian;
                return;
            case 34:
                MainWindow.country = Country.Swedish;
                return;
            case 35:
                MainWindow.country = Country.Slovak;
                return;
            case 36:
                MainWindow.country = Country.Slovenian;
                return;
            case 37:
                MainWindow.country = Country.Spanish;
                return;
            case 38:
                MainWindow.country = Country.Serbian;
                return;
            case 39:
                MainWindow.country = Country.Thai;
                return;
            case 40:
                MainWindow.country = Country.Turkish;
                return;
            case 41:
                MainWindow.country = Country.Ukrainian;
                return;
            case 42:
                MainWindow.country = Country.Vietnamese;
                return;
            case 43:
                MainWindow.country = Country.ChineseSimplified;
                return;
            case 44:
                MainWindow.country = Country.ChineseTraditional;
                return;
            case 45:
                MainWindow.country = Country.Zulu;
                return;
            default:
                MainWindow.country = Country.English;
                return;
        }
    }
}