using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform top;
    [SerializeField]
    private Transform bottom;

    private List<Rigidbody2D> connectedTransforms = new List<Rigidbody2D>();

    private bool goingUp = true;

    private void Update()
    {
        if(goingUp)
        {
            transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
            if (transform.position.y > top.position.y) goingUp = false;
        }
        else
        {
            transform.position -= new Vector3(0, 1 * Time.deltaTime, 0);
            if (transform.position.y < bottom.position.y) goingUp = true;
        }
        if (connectedTransforms.Count > 0)
        {
            foreach (Rigidbody2D t in connectedTransforms)
            {
                if (goingUp)
                {
                    t.MovePosition(t.position + new Vector2(0, 1 * Time.deltaTime));
                }
                else
                {
                    t.MovePosition(t.position + new Vector2(0, -1 * Time.deltaTime));
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        connectedTransforms.Add(collision.rigidbody);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        connectedTransforms.Remove(collision.rigidbody);
    }
}
