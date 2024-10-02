using UnityEngine;

[CreateAssetMenu(fileName = "WordList", menuName = "ScriptableObjects/WordList", order = 1)]
public class WordList : ScriptableObject
{
    public string[] hiraganaWords;
    public string[] romajiWords;
}
