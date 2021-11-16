using UnityEngine;
using System.Collections.Generic;


public class Ambient : MonoBehaviour
{
    public int selection;
    private List<bool> interactions = new List<bool>();
    private MenuController menuController;

    private void Start()
    {
        interactions.Add(false);
        interactions.Add(false);
        interactions.Add(false);
        menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactions[selection] = false;
    }
}

