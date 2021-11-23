using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPlayer : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
    }
}
