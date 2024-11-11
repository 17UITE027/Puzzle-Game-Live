using UnityEngine;

public class WindowControl : MonoBehaviour
{
    
    public void CloseApp()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
        #else
            Application.Quit(); 
        #endif
    }

    
    public void MinimizeApp()
    {
        #if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
            Screen.fullScreen = false;
            
        #endif
    }

    
    public void MaximizeApp()
    {
        Screen.fullScreen = !Screen.fullScreen; 
    }
}
