using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayButton : MonoBehaviour
{
    public Button playButton; 
    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }
    }

    void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
