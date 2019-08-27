using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerHealth))]
public class ObjectiveHandler : MonoBehaviour
{
    [Header("Condition markers")]
    public Spawner enemySpawner;
    public GameObject enemyToDefeat;
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
        if (enemySpawner.amountToSpawn <= 0 && GameObject.Find(enemyToDefeat.name) == null)
        {
            //Game is won
            headsUpDisplay.enabled = false;
            pauseMenu.enabled = false;
            failMenu.enabled = false;
            winMenu.enabled = true;
        }
        else if(player.currentHealth <= 0)
        {
            headsUpDisplay.enabled = false;
            pauseMenu.enabled = false;
            winMenu.enabled = false;
            failMenu.enabled = true;
        }
    }
}
