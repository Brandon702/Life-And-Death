using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform top;
    [SerializeField]
    private Transform bottom;

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
    }

}
