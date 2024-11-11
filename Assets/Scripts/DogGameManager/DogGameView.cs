
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DogGameView : MonoBehaviour
{
    public TextMeshProUGUI InstructionText;
    public TextMeshProUGUI Instruction;
    public Button[] WordButtons;
    public GameObject Background2;
    public BackgroundSwitcher backgroundSwitcher; 
    private Animator backgroundAnimator;
    public GameObject ResetButton;

    void Start()
    {
        if (Background2 != null)
        {
            backgroundAnimator = Background2.GetComponent<Animator>();
            Background2.SetActive(false); 
        }
    }

    public void UpdateInstructionText(string message)
    {
        InstructionText.text = message;
    }

    public void UpdateButtonText(int index, string text)
    {
        if (WordButtons[index] != null)
        {
            WordButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }

    public void ResetGameView()
    {
        
        foreach (var button in WordButtons)
        {
            button.interactable = true; 
            button.gameObject.SetActive(true); 
        }
        InstructionText.gameObject.SetActive(true); 
        
        ResetButton.SetActive(true);
    }

    public void PlayBackgroundAnimation()
    {
        if (Background2 != null && backgroundAnimator != null)
        {
            HideButtonsAndInstruction(); 
            if (backgroundSwitcher != null)
            {
                backgroundSwitcher.SwitchBackground(); 
            }
            Background2.SetActive(true); 
            backgroundAnimator.Play("Background2Animation"); 
        }
    }

    private void HideButtonsAndInstruction()
    {
        
        foreach (var button in WordButtons)
        {
            button.gameObject.SetActive(false);
        }
        
        Instruction.gameObject.SetActive(false);
        ResetButton.SetActive(false);
    }
}
