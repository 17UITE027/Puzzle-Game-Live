using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerModel : MonoBehaviour
{
   public List<string> Words { get; } = new List<string> { "Pour", "Water", "Flower", "Blossom" };
    public List<string> SelectedWords { get; private set; } = new List<string>();
    public string CorrectSentence { get; } = "Pour Water";

    public void AddWord(string word)
    {
        if (SelectedWords.Count < 2 && !SelectedWords.Contains(word))
        {
            SelectedWords.Add(word);
        }
    }

    public bool IsCorrectSentence()
    {
        return string.Join(" ", SelectedWords) == CorrectSentence;
    }

    public void ClearSelectedWords()
    {
        SelectedWords.Clear();
    }
}
