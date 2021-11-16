using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    string content;
    string opt1;
    string opt2;
    Action action;
    [SerializeField] GameObject eventWindow;
    MenuController menuController;

    public void Start()
    {
        menuController = GameObject.Find("Controllers").GetComponent<MenuController>();
        eventWindow = menuController.eventWindow;
        eventWindow.SetActive(false);
    }

    public void EventFired(string content, string opt1, string opt2, Action action)
    {
        eventWindow.SetActive(true);
        this.content = content;
        this.opt1 = opt1;
        this.opt2 = opt2;
        this.action = action;
    }

    
}
