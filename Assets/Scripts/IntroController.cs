using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class IntroController : MonoBehaviour
{
    public Button playButton;
    public Button minimizeButton; // Minimize button
    public Button maximizeButton; // Maximize button
    public Button closeButton;    // Close button

    #if UNITY_STANDALONE_WIN
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(System.IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern System.IntPtr GetActiveWindow();
    private const int SW_MINIMIZE = 6;
    private const int SW_MAXIMIZE = 3;
    private const int SW_RESTORE = 9;
    #endif

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        if (minimizeButton != null)
        {
            minimizeButton.onClick.AddListener(OnMinimizeButtonClicked);
        }

        if (maximizeButton != null)
        {
            maximizeButton.onClick.AddListener(OnMaximizeButtonClicked);
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(OnCloseButtonClicked);
        }
    }

    void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void OnMinimizeButtonClicked()
    {
        #if UNITY_STANDALONE_WIN
        ShowWindow(GetActiveWindow(), SW_MINIMIZE);
        #endif
    }

    void OnMaximizeButtonClicked()
    {
        #if UNITY_STANDALONE_WIN
        ShowWindow(GetActiveWindow(), SW_MAXIMIZE);
        #endif
    }

    void OnCloseButtonClicked()
    {
        Application.Quit();
    }
}

