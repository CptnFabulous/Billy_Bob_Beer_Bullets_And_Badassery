using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public GameObject hudUI;
    public Button pauseButton;
    public Button resumeButton;
    public Button quitButton;
    public string mainMenuScene;


    public static bool GameIsPaused = false;

    private void Start()
    {
        // Adds listeners for pause, resume and quit buttons
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(() => LoadScene(mainMenuScene));

        Resume(); // Unpauses game
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // When pause button is pressed
        {
            if(GameIsPaused) // Checks whether game is paused or not, and pauses or unpauses appropriately
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    

    void Resume()
    {
        // Disables pause menu, reenables heads up display and unfreezes time
        pauseMenuUI.SetActive(false);
        hudUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        // Enables pause menu, disables heads up display and freezes time
        hudUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    

    public void LoadScene(string sceneName) // Loads the scene.
    {
        SceneManager.LoadScene(sceneName);
    }

    /*
    public void LoadMenu()
    {
        Debug.Log("Loading Game");
    }

    public void ExitGame()
    {
        Debug.Log("Exitting Game");
    }
    */
}
