using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ghost")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
