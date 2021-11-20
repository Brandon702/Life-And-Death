using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private List<GameObject> players = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ghost" || collision.gameObject.tag == "Player")
        {
            players.Add(collision.gameObject);
            CheckPlayers();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ghost" || collision.gameObject.tag == "Player")
        {
            players.Remove(collision.gameObject);
        }
    }

    private void CheckPlayers()
    {
        if(players.Count == 2)
        {
            foreach(GameObject g in players)
            {
                if(g.tag == "Player")
                {
                    //Stop Movement
                }
                else if(g.tag == "Ghost")
                {
                    //Stop Movement
                }
            }
            //Timer Countdown (?)
            //End Level
        }
    }
}
