using System.Collections.Generic;

public class DogGameModel
{
    public List<string> Words { get; } = new List<string> { "Play", "Eat", "Dog", "with", "Sleep" };
    public List<string> SelectedWords { get; private set; } = new List<string>();
    public string CorrectSentence { get; } = "Play with Dog";

    public void AddWord(string word)
    {
        if (SelectedWords.Count < 3 && !SelectedWords.Contains(word))
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
