using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NationController : MonoBehaviour
{
    public Nation[] nations;
    private MenuController menuController;

    void Start()
    {
        menuController = GameObject.Find("Controllers").GetComponent<MenuController>();
        nations = FindObjectsOfType<Nation>();
        GenerateBorders();
        //menuController.nationController = GameObject.Find("Systems").GetComponent<NationController>();
    }

    void GenerateBorders()
    {
        foreach(Nation nation in nations)
        {

            foreach(Province province in nation.provinces)
            {
                //Find province & find the parent of the province for the renderer
                Renderer renderer = province.GetComponentInParent<Renderer>();
                //renderer.material.color = nation.nationColor;
                renderer.material.SetColor("Color_3b93f290a376422c92b977b01d2ef92b", nation.nationColor);
                renderer.material.SetFloat("Vector1_be34be51f63b41189dbcb6091b35e448", nation.nationColor.a);
                province.owner = nation.name;
            }
        }
    }
}
