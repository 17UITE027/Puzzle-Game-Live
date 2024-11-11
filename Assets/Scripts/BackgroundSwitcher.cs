// Scripts/BackgroundSwitcher.cs
using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;

    public void SwitchBackground()
    {
        if (background1 != null)
        {
            background1.SetActive(false); // Disable background1
        }
        
        if (background2 != null)
        {
            background2.SetActive(true); // Enable background2
        }
    }
}

