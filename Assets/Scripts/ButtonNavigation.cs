using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonNavigation : MonoBehaviour
{
    public void ShowMenu()
    {
        SceneManager.LoadScene("Menu");
    }

	// To start the game by pressing the Start button
    public void StartGame()
    {
        SceneManager.LoadScene("gameplay");            
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("credits");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("howtoplay");
    }
}
