using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform left;
    [SerializeField]
    private Transform right;

    private bool goingLeft = true;

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
    }

}
