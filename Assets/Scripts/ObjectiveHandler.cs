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

    [HideInInspector] public int remainingAliens;

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
        remainingAliens = enemySpawner.amountToSpawn + GameObject.FindGameObjectsWithTag(enemyTag).Length;
        print(enemySpawner.amountToSpawn + "/" + GameObject.FindGameObjectsWithTag(enemyTag).Length);
        if (remainingAliens <= 0)
        {
            //Game is won
            
            WinGame();
        }
        else if(player.currentHealth <= 0)
        {
            
            FailScreen();
        }
    }

    void WinGame()
    {
        print("Game won");
        headsUpDisplay.gameObject.SetActive(false);
        print("a");
        pauseMenu.gameObject.SetActive(false);
        print("b");
        failMenu.gameObject.SetActive(false);
        print("c");
        winMenu.gameObject.SetActive(true);
        print("d");
        
    }

    void FailScreen()
    {
        print("Game lost");
        headsUpDisplay.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        winMenu.gameObject.SetActive(false);
        failMenu.gameObject.SetActive(true);
    }
}
