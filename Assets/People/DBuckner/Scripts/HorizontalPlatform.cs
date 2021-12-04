using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform left;
    [SerializeField]
    private Transform right;

    private List<Rigidbody2D> connectedTransforms = new List<Rigidbody2D>();

    bool goingLeft = true;

    private void Update()
    {
        if(goingLeft)
        {
            transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
            if (transform.position.x < left.position.x) goingLeft = false;
        }
        else
        {
            transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
            if (transform.position.x > right.position.x) goingLeft = true;
        }
        if (connectedTransforms.Count > 0)
        {
            foreach (Rigidbody2D t in connectedTransforms)
            {
                if (goingLeft)
                {
                    t.MovePosition(t.position + new Vector2(-1 * Time.deltaTime, 0));
                }
                else
                {
                    t.MovePosition(t.position + new Vector2(Time.deltaTime, 0));
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
