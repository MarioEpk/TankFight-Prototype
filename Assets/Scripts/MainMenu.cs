using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        try
        {
            SceneManager.LoadScene("TankFightPrototype");
        }
        catch
        {
            Debug.LogError("Invalid scene loaded, in MainMenu.cs  - PlayGame() function");
        }
    }

    public void QuitGame()
    {
            Application.Quit();
    }
    
}
