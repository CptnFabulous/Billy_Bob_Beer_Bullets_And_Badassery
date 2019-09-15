using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameSceneName;

    public void PlayGame() // Loads game level
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame() // Quits game
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
