using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSetting : MonoBehaviour
{
   
   public void PlayGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }
   public void Exit()
   {
   Application.Quit();
   }
    List<int> widths = new List<int>() {440, 550, 570};
    List<int> heights = new List<int>() {640, 960, 720};
    
    public void SetScreenSize (int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen); 
    }
    public void SetFullScreen (bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

}
   
//    [SerializeField] private GameObject _mainMenuCanvasGO;
//    [SerializeField] private GameObject _settingsMenuCanvasGO;

//    private bool isPaused;
   
//    public void Start()
//    {
//     _mainMenuCanvasGO.SetActive(false);
//     _settingsMenuCanvasGO.SetActive(false);
//    }

//    public void Update()
//    {
//     if (InputManager.instance.MenuOpenCloseInput);
//     {
//         if (isPaused)
//         {
//             Pause();
//         }
//         else
//         {
//             Unpause();
//         }
//     }
//    }

//    public void Pause()
//    {
//     isPaused = true;
//     Time.timeScale = 0f;

//     OpenMainMenu();
//    }

//     public void Unpause()
//     {
//         isPaused = false;
//         Time.timeScale = 1F;

//         CloseAllMenus();
//     }

//     private void OpenMainMenu()
//     {
//         _mainMenuCanvasGO.SetActive(true);
//         _settingsMenuCanvasGO.SetActive(false);
//     }

//     private void CloseAllMenus()
//     {
//         _mainMenuCanvasGO.SetActive(false);
//         _settingsMenuCanvasGO.SetActive(false);
//     }
