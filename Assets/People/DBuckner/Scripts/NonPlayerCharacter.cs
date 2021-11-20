using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    private bool possessed = false;

    public void PossessNPC()
    {
        possessed = true;
        this.gameObject.SetActive(false);
    }

    public void UnPossessNPC()
    {
        possessed = false;
        this.gameObject.SetActive(true);
        this.transform.position = GameObject.FindGameObjectWithTag("Ghost").transform.position;
    }
}
