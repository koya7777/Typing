using System.Collections.Generic;
using UnityEngine;

public static class RomajiToHiragana
{
    private static readonly Dictionary<string, string> romajiToHiraganaMap = new Dictionary<string, string>
    {
        {"a", "‚ "}, {"i", "‚¢"}, {"u", "‚¤"}, {"e", "‚¦"}, {"o", "‚¨"},
        {"ka", "‚©"}, {"ki", "‚«"}, {"ku", "‚­"}, {"ke", "‚¯"}, {"ko", "‚±"},
        {"sa", "‚³"}, {"shi", "‚µ"}, {"su", "‚·"}, {"se", "‚¹"}, {"so", "‚»"},
        {"ta", "‚½"}, {"chi", "‚¿"}, {"tsu", "‚Â"}, {"te", "‚Ä"}, {"to", "‚Æ"},
        {"na", "‚È"}, {"ni", "‚É"}, {"nu", "‚Ê"}, {"ne", "‚Ë"}, {"no", "‚Ì"},
        {"ha", "‚Í"}, {"hi", "‚Ð"}, {"fu", "‚Ó"}, {"he", "‚Ö"}, {"ho", "‚Ù"},
        {"ma", "‚Ü"}, {"mi", "‚Ý"}, {"mu", "‚Þ"}, {"me", "‚ß"}, {"mo", "‚à"},
        {"ya", "‚â"}, {"yu", "‚ä"}, {"yo", "‚æ"},
        {"ra", "‚ç"}, {"ri", "‚è"}, {"ru", "‚é"}, {"re", "‚ê"}, {"ro", "‚ë"},
        {"wa", "‚í"}, {"wo", "‚ð"}, {"n", "‚ñ"}
    };

    private static readonly Dictionary<string, string> hiraganaToRomajiMap = new Dictionary<string, string>
    {
        {"‚ ", "a"}, {"‚¢", "i"}, {"‚¤", "u"}, {"‚¦", "e"}, {"‚¨", "o"},
        {"‚©", "ka"}, {"‚«", "ki"}, {"‚­", "ku"}, {"‚¯", "ke"}, {"‚±", "ko"},
        {"‚³", "sa"}, {"‚µ", "shi"}, {"‚·", "su"}, {"‚¹", "se"}, {"‚»", "so"},
        {"‚½", "ta"}, {"‚¿", "chi"}, {"‚Â", "tsu"}, {"‚Ä", "te"}, {"‚Æ", "to"},
        {"‚È", "na"}, {"‚É", "ni"}, {"‚Ê", "nu"}, {"‚Ë", "ne"}, {"‚Ì", "no"},
        {"‚Í", "ha"}, {"‚Ð", "hi"}, {"‚Ó", "fu"}, {"‚Ö", "he"}, {"‚Ù", "ho"},
        {"‚Ü", "ma"}, {"‚Ý", "mi"}, {"‚Þ", "mu"}, {"‚ß", "me"}, {"‚à", "mo"},
        {"‚â", "ya"}, {"‚ä", "yu"}, {"‚æ", "yo"},
        {"‚ç", "ra"}, {"‚è", "ri"}, {"‚é", "ru"}, {"‚ê", "re"}, {"‚ë", "ro"},
        {"‚í", "wa"}, {"‚ð", "wo"}, {"‚ñ", "n"}
    };

    public static string RomajiToHiraganaConvert(string input)
    {
        string hiragana = "";
        int index = 0;

        while (index < input.Length)
        {
            bool matched = false;
            foreach (var kvp in romajiToHiraganaMap)
            {
                if (input.Substring(index).StartsWith(kvp.Key))
                {
                    hiragana += kvp.Value;
                    index += kvp.Key.Length;
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                hiragana += input[index];
                index++;
            }
        }

        return hiragana;
    }

    public static string HiraganaToRomajiConvert(string input)
    {
        string romaji = "";
        int index = 0;

        while (index < input.Length)
        {
            bool matched = false;
            foreach (var kvp in hiraganaToRomajiMap)
            {
                if (input.Substring(index).StartsWith(kvp.Key))
                {
                    romaji += kvp.Value;
                    index += kvp.Key.Length;
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                romaji += input[index];
                index++;
            }
        }

        return romaji;
    }
}
