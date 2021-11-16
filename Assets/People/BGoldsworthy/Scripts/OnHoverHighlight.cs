using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverHighlight : MonoBehaviour
{
    private Color startcolor;
    private Color Hovercolor;
    MenuController menuController;
    

    private void Awake()
    {
        menuController = GameObject.Find("Controllers").GetComponent<MenuController>();
    }

    //Include quick info about the province you are hovering over
    void OnMouseEnter()
    {
        menuController.hovering = true;
        if (GameController.Instance != null)
        {
            if (GameController.Instance.state != eState.PAUSE)
            {
                //startcolor = GetComponent<Renderer>().material.color;
                //GetComponent<Renderer>().material.SetColor("Color_3b93f290a376422c92b977b01d2ef92b", startcolor);
                Hovercolor = Color.white;
                Hovercolor.a = 0.4f;
                GetComponent<Renderer>().material.color = Hovercolor;
            }
        }
        else
        {
            //Debug.Log("Game Controller does not exist, overriding required GameController script, may cause instability");
            startcolor = GetComponent<Renderer>().material.color;
            Hovercolor = Color.white;
            Hovercolor.a = 0.4f;
            GetComponent<Renderer>().material.color = Hovercolor;
        }
    }
    void OnMouseExit()
    {
        menuController.hovering = false;
        GetComponent<Renderer>().material.color = startcolor;
    }
}
