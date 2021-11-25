using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private bool locked = true;
    public bool Locked { get => locked; }
    [SerializeField]
    private GameObject doorSprite;

    public void ChangeLocked()
    {
        if (locked) Unlock();
        else Lock();
    }

    private void Unlock()
    {
        locked = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Lock()
    {
        locked = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
