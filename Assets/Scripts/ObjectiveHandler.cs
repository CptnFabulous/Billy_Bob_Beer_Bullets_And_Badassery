using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerHealth))]
public class ObjectiveHandler : MonoBehaviour
{
    [Header("Condition markers")]
    public Spawner enemySpawner; // Used to check how many aliens need to be spawned
    public string enemyTag; // Used to check for aliens that already exist in the level
    PlayerHealth player; // used to check if player has died

    [HideInInspector] public int remainingAliens; // How many more aliens need to be killed to win game

    [Header("Menus")] // Self explanatory
    public Canvas headsUpDisplay;
    public Canvas pauseMenu;
    public Canvas winMenu;
    public Canvas failMenu;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerHealth>();
    }
    

    // Update is called once per frame
    void Update()
    {
        remainingAliens = enemySpawner.amountToSpawn + GameObject.FindGameObjectsWithTag(enemyTag).Length; // Finds enemies currently in the level, plus enemies that have not yet spawned, to determine how many more aliens the player needs to defeat
        //print(enemySpawner.amountToSpawn + "/" + GameObject.FindGameObjectsWithTag(enemyTag).Length);
        if (remainingAliens <= 0) // If all aliens have been killed
        {
            
            WinGame(); //Display win screen
        }
        else if(player.currentHealth <= 0) // If player dies
        {
            
            FailScreen(); // Display fail screen
        }
    }

    void WinGame()
    {
        // Disable all menus except for win screen
        print("Game won");
        headsUpDisplay.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        failMenu.gameObject.SetActive(false);
        winMenu.gameObject.SetActive(true);
    }

    void FailScreen()
    {
        // Disable all menus except for fail screen
        print("Game lost");
        headsUpDisplay.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        winMenu.gameObject.SetActive(false);
        failMenu.gameObject.SetActive(true);
    }
}
