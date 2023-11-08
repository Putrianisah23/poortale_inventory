using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToggle : MonoBehaviour
{
    public void ToggleFullscreen(bool isFullscreen)
    {
       Screen.fullScreen = isFullscreen;

        if (isFullscreen)
        {
            Debug.Log("Mode fullscreen diaktifkan.");
        }
        else
        {
            Debug.Log("Mode windowed diaktifkan.");
        }
    }
}
