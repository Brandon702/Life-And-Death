using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform top;
    [SerializeField]
    private Transform bottom;

    private List<Transform> connectedTransforms = new List<Transform>();

    private bool goingUp = true;

    private void Start()
    {
        //So time doesn't stand still.
        Time.timeScale = 1;
    }

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
            foreach (Transform t in connectedTransforms)
            {
                if (goingUp)
                {
                    t.position += new Vector3(0, 1 * Time.deltaTime, 0);
                }
                else
                {
                    t.position -= new Vector3(0, 1 * Time.deltaTime, 0);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        connectedTransforms.Add(collision.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        connectedTransforms.Remove(collision.transform);
    }
}
