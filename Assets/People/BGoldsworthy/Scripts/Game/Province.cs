using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum terrain
{
    Glacial,
    Tundra,
    Highland,
    Coastal,
    Forest,
    Woods,
    Marsh,
    Grassland,
    Mountain,
    Steppes,
    Jungle,
    Drylands,
    Savanna,
    Desert,
    Hills,
    Farmlands,
    Ruined_Metropolis,
    Restored_Metropolis,
    Island,
    Wasteland
}

public class Province : MonoBehaviour
{
    public string owner;
    public string provName;
    //public int provID;
    public int development;
    //[SerializeField] private string state;
    [SerializeField] private terrain provTerrain;
    public List<Province> adjacentProvinces;

    public void Start()
    {
        provName = gameObject.name;

        //Set Random Development (1st num inclusive, 2nd num exclusive IE: 1,3 is 1-2)
        switch(provTerrain)
        {
            case terrain.Glacial:
                development = Random.Range(1, 3);
                break;
            case terrain.Tundra:
                development = Random.Range(1, 4);
                break;
            case terrain.Highland:
                development = Random.Range(1, 6);
                break;
            case terrain.Coastal:
                development = Random.Range(1, 6);
                break;
            case terrain.Forest:
                development = Random.Range(1, 5);
                break;
            case terrain.Woods:
                development = Random.Range(2, 6);
                break;
            case terrain.Marsh:
                development = Random.Range(1, 3);
                break;
            case terrain.Grassland:
                development = Random.Range(2, 8);
                break;
            case terrain.Mountain:
                development = Random.Range(1, 3);
                break;
            case terrain.Steppes:
                development = Random.Range(1, 4);
                break;
            case terrain.Jungle:
                development = Random.Range(1, 3);
                break;
            case terrain.Drylands:
                development = Random.Range(1, 5);
                break;
            case terrain.Savanna:
                development = Random.Range(1, 4);
                break;
            case terrain.Desert:
                development = 1;
                break;
            case terrain.Hills:
                development = Random.Range(1, 6);
                break;
            case terrain.Farmlands:
                development = Random.Range(4, 10);
                break;
            case terrain.Ruined_Metropolis:
                development = Random.Range(5, 11);
                break;
            case terrain.Restored_Metropolis:
                development = Random.Range(15, 31);
                break;
            case terrain.Island:
                development = Random.Range(4, 10);
                break;
            case terrain.Wasteland:
                development = 1;
                break;
            default:
                break;
        }
    }

    //public Province(int dev, float state, float terrain, float provID, int provName)
    //{
    //    this.development = dev;
    //    this.state = state.ToString();
    //    this.provTerrain = (terrain)terrain;
    //    this.provName = provName.ToString();
    //    this.provID = (int)provID;
    //}
}
