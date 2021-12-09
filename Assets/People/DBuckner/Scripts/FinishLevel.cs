using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public MenuController menuController;

    private List<GameObject> players = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ghost" || collision.gameObject.tag == "Player")
        {
            players.Add(collision.gameObject);
            CheckPlayers();
        }
    }
    

    private void CheckPlayers()
    {
        if(players.Count == 1)
        {
            Debug.Log("YOU WIN");
            //Timer Countdown (?)
            //End Level
            menuController = GameObject.Find("Controllers").GetComponent<MenuController>();
            if(menuController != null)
            {
                Debug.Log("YOU WIN!!!!!");
                menuController.justWork("Game");
            }
        }
    }
}
