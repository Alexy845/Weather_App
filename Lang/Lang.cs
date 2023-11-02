namespace Weather_App.Lang;

public class Lang
{
    public static string LangToCode(string lang)
    {
        switch (lang)
        {
            case "Afrikaans":
                return "af";
            case "Albanian":
                return "sq";
            case "Arabic":
                return "ar";
            case "Azerbaijani":
                return "az";
            case "Bulgarian":
                return "bg";
            case "Catalan":
                return "ca";
            case "Czech":
                return "cs";
            case "Danish":
                return "da";
            case "German":
                return "de";
            case "Greek":
                return "el";
            case "English":
                return "en";
            case "Basque":
                return "eu";
            case "Persian":
                return "fa";
            case "Finnish":
                return "fi";
            case "French":
                return "fr";
            case "Galician":
                return "gl";
            case "Hebrew":
                return "he";
            case "Hindi":
                return "hi";
            case "Croatian":
                return "hr";
            case "Hungarian":
                return "hu";
            case "Indonesian":
                return "id";
            case "Italian":
                return "it";
            case "Japanese":
                return "ja";
            case "Korean":
                return "kr";
            case "Latvian":
                return "la";
            case "Lithuanian":
                return "lt";
            case "Macedonian":
                return "mk";
            case "Norwegian":
                return "no";
            case "Dutch":
                return "nl";
            case "Polish":
                return "pl";
            case "Portuguese":
                return "pt";
            case "Portuguese (Brazil)":
                return "pt_br";
            case "Romanian":
                return "ro";
            case "Russian":
                return "ru";
            case "Swedish":
                return "sv";
            case "Slovak":
                return "sk";
            case "Slovenian":
                return "sl";
            case "Spanish":
                return "es";
            case "Serbian":
                return "sr";
            case "Thai":
                return "th";
            case "Turkish":
                return "tr";
            case "Ukrainian":
                return "uk";
            case "Vietnamese":
                return "vi";
            case "Chinese Simplified":
                return "zh_cn";
            case "Chinese Traditional":
                return "zh_tw";
            case "Zulu":
                return "zu";
            default:
                return "en";
        }
    }
}