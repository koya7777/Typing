using System.Collections.Generic;
using UnityEngine;

public static class RomajiToHiragana
{
    private static readonly Dictionary<string, string> romajiToHiraganaMap = new Dictionary<string, string>
    {
        {"a", "��"}, {"i", "��"}, {"u", "��"}, {"e", "��"}, {"o", "��"},
        {"ka", "��"}, {"ki", "��"}, {"ku", "��"}, {"ke", "��"}, {"ko", "��"},
        {"sa", "��"}, {"shi", "��"}, {"su", "��"}, {"se", "��"}, {"so", "��"},
        {"ta", "��"}, {"chi", "��"}, {"tsu", "��"}, {"te", "��"}, {"to", "��"},
        {"na", "��"}, {"ni", "��"}, {"nu", "��"}, {"ne", "��"}, {"no", "��"},
        {"ha", "��"}, {"hi", "��"}, {"fu", "��"}, {"he", "��"}, {"ho", "��"},
        {"ma", "��"}, {"mi", "��"}, {"mu", "��"}, {"me", "��"}, {"mo", "��"},
        {"ya", "��"}, {"yu", "��"}, {"yo", "��"},
        {"ra", "��"}, {"ri", "��"}, {"ru", "��"}, {"re", "��"}, {"ro", "��"},
        {"wa", "��"}, {"wo", "��"}, {"n", "��"}
    };

    private static readonly Dictionary<string, string> hiraganaToRomajiMap = new Dictionary<string, string>
    {
        {"��", "a"}, {"��", "i"}, {"��", "u"}, {"��", "e"}, {"��", "o"},
        {"��", "ka"}, {"��", "ki"}, {"��", "ku"}, {"��", "ke"}, {"��", "ko"},
        {"��", "sa"}, {"��", "shi"}, {"��", "su"}, {"��", "se"}, {"��", "so"},
        {"��", "ta"}, {"��", "chi"}, {"��", "tsu"}, {"��", "te"}, {"��", "to"},
        {"��", "na"}, {"��", "ni"}, {"��", "nu"}, {"��", "ne"}, {"��", "no"},
        {"��", "ha"}, {"��", "hi"}, {"��", "fu"}, {"��", "he"}, {"��", "ho"},
        {"��", "ma"}, {"��", "mi"}, {"��", "mu"}, {"��", "me"}, {"��", "mo"},
        {"��", "ya"}, {"��", "yu"}, {"��", "yo"},
        {"��", "ra"}, {"��", "ri"}, {"��", "ru"}, {"��", "re"}, {"��", "ro"},
        {"��", "wa"}, {"��", "wo"}, {"��", "n"}
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
