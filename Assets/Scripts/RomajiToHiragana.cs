using System.Collections.Generic;
using UnityEngine;

public static class RomajiToHiragana
{
    private static readonly Dictionary<string, string> romajiToHiraganaMap = new Dictionary<string, string>
    {
        {"a", "あ"}, {"i", "い"}, {"u", "う"}, {"e", "え"}, {"o", "お"},
        {"ka", "か"}, {"ki", "き"}, {"ku", "く"}, {"ke", "け"}, {"ko", "こ"},
        {"sa", "さ"}, {"shi", "し"}, {"su", "す"}, {"se", "せ"}, {"so", "そ"},
        {"ta", "た"}, {"chi", "ち"}, {"tsu", "つ"}, {"te", "て"}, {"to", "と"},
        {"na", "な"}, {"ni", "に"}, {"nu", "ぬ"}, {"ne", "ね"}, {"no", "の"},
        {"ha", "は"}, {"hi", "ひ"}, {"fu", "ふ"}, {"he", "へ"}, {"ho", "ほ"},
        {"ma", "ま"}, {"mi", "み"}, {"mu", "む"}, {"me", "め"}, {"mo", "も"},
        {"ya", "や"}, {"yu", "ゆ"}, {"yo", "よ"},
        {"ra", "ら"}, {"ri", "り"}, {"ru", "る"}, {"re", "れ"}, {"ro", "ろ"},
        {"wa", "わ"}, {"wo", "を"}, {"n", "ん"}
    };

    private static readonly Dictionary<string, string> hiraganaToRomajiMap = new Dictionary<string, string>
    {
        {"あ", "a"}, {"い", "i"}, {"う", "u"}, {"え", "e"}, {"お", "o"},
        {"か", "ka"}, {"き", "ki"}, {"く", "ku"}, {"け", "ke"}, {"こ", "ko"},
        {"さ", "sa"}, {"し", "shi"}, {"す", "su"}, {"せ", "se"}, {"そ", "so"},
        {"た", "ta"}, {"ち", "chi"}, {"つ", "tsu"}, {"て", "te"}, {"と", "to"},
        {"な", "na"}, {"に", "ni"}, {"ぬ", "nu"}, {"ね", "ne"}, {"の", "no"},
        {"は", "ha"}, {"ひ", "hi"}, {"ふ", "fu"}, {"へ", "he"}, {"ほ", "ho"},
        {"ま", "ma"}, {"み", "mi"}, {"む", "mu"}, {"め", "me"}, {"も", "mo"},
        {"や", "ya"}, {"ゆ", "yu"}, {"よ", "yo"},
        {"ら", "ra"}, {"り", "ri"}, {"る", "ru"}, {"れ", "re"}, {"ろ", "ro"},
        {"わ", "wa"}, {"を", "wo"}, {"ん", "n"}
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
