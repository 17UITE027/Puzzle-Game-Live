using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DogGameController : MonoBehaviour
{
    private DogGameView view;
    private string correctSentence;
    private int maxWords;

    public GameObject correctWordButton;
    public TextMeshProUGUI instructionText;
    public GameObject resetButton;
    public GameObject nextRoundButton; 
    private bool wordSelected = false;

    private HashSet<string> selectedWords = new HashSet<string>();

    void Start()
    {
        view = FindObjectOfType<DogGameView>();
        SetCorrectSentence();
        SetupButtons();

        resetButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ResetGame);

        nextRoundButton.SetActive(false);

        nextRoundButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnNextRoundButtonClicked);
        
        resetButton.SetActive(true);
    }

    void SetCorrectSentence()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        
        switch (sceneName)
        {
            case "dog":
                correctSentence = "Play with Dog";
                maxWords = 3;
                break;
            case "SampleScene":
                correctSentence = "Pour Water";
                maxWords = 2;
                break;
            default:
                break;
        }
    }

    void SetupButtons()
    {
        for (int i = 0; i < view.WordButtons.Length; i++)
        {
            int index = i;
            view.WordButtons[i].onClick.AddListener(() => OnWordButtonClicked(view.WordButtons[index].GetComponentInChildren<TextMeshProUGUI>().text));
        }
    }

    public void ResetGame()
    {
        selectedWords.Clear();
        wordSelected = false;
        instructionText.text = "Select a word to start";
        resetButton.SetActive(false);

        view.ResetGameView();
        StartCoroutine(ReactivateResetButton());
    }

    private IEnumerator<WaitForSeconds> ReactivateResetButton()
    {
        yield return new WaitForSeconds(3);
        resetButton.SetActive(true);
    }

    public void OnWordButtonClicked(string word)
    {
        if (selectedWords.Contains(word))
        {
            instructionText.text = $"{maxWords} unique words";
            return;
        }

        if (selectedWords.Count >= maxWords)
        {
            view.UpdateInstructionText($"You can only select up to {maxWords} words!");
            return;
        }
        else
        {
            instructionText.text = $"You have selected {selectedWords.Count} unique word(s).";
        }

        if (!selectedWords.Contains(word))
        {
            selectedWords.Add(word);
            view.UpdateInstructionText("Selected Words: " + string.Join(", ", selectedWords));

            if (selectedWords.Count == correctSentence.Split(' ').Length)
            {
                CheckSentence();
            }
        }
    }

    void CheckSentence()
    {
        string formedSentence = string.Join(" ", selectedWords);
        if (formedSentence == correctSentence)
        {
            view.UpdateInstructionText("Correct!");
            correctWordButton.SetActive(false);
            view.PlayBackgroundAnimation();

            
            nextRoundButton.SetActive(true);
        }
        else
        {
            view.UpdateInstructionText("Try Again!");
            selectedWords.Clear();
        }
    }

    
    void OnNextRoundButtonClicked()
    {
        string nextScene = SceneManager.GetActiveScene().name == "SampleScene" ? "dog" : "SampleScene";
        SceneManager.LoadScene(nextScene);
    }

    public bool IsCorrectWordSelected()
    {
        return true;
    }
}
