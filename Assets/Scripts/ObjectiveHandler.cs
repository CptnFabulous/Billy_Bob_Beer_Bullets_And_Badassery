using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerHealth))]
public class ObjectiveHandler : MonoBehaviour
{
    [Header("Condition markers")]
    public Spawner enemySpawner;
    public string enemyTag;
    PlayerHealth player;

    [Header("Menus")]
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
        print(enemySpawner.amountToSpawn + "/" + GameObject.FindGameObjectsWithTag(enemyTag).Length);
        if (enemySpawner.amountToSpawn <= 0 && GameObject.FindGameObjectsWithTag(enemyTag) == null)
        {
            //Game is won
            print("Game won");
            WinGame();
        }
        else if(player.currentHealth <= 0)
        {
            print("Game lost");
            FailScreen();
        }
    }

    void WinGame()
    {
        headsUpDisplay.enabled = false;
        pauseMenu.enabled = false;
        failMenu.enabled = false;
        winMenu.enabled = true;
    }

    void FailScreen()
    {
        headsUpDisplay.enabled = false;
        pauseMenu.enabled = false;
        winMenu.enabled = false;
        failMenu.enabled = true;
    }
}
