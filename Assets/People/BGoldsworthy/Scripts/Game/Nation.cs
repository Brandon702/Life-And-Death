using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nation : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] public int money;
    [SerializeField] public int manpower;
    [SerializeField] public int prestiege;
    [SerializeField] public int buildingMaterials;
    [SerializeField] public int militarySupplies;
    [SerializeField] public int civilianSupplies;
    [SerializeField] public int luxuryGoods;
    [SerializeField] private Nation[] allies; //List of people that will help when a war breaks out
    [SerializeField] private Nation[] rivals; //List of people that will attempt to attack you in a moment of weakness
    [SerializeField] private Nation[] warAllies; //List of active allied forces in wars you are participating in
    [SerializeField] private Nation[] warEnemies; //List of active enemy forces in wars you are participating in
    public Province[] provinces;
    public Color nationColor;

    public void Awake()
    {
        nationColor.a = 0.8f;
        name = gameObject.name;
        foreach(Province province in provinces)
        {
            province.owner = name;
        }
    }

}
