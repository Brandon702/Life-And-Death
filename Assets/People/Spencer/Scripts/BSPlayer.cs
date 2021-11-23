using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPlayer : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody2D rb;
<<<<<<< HEAD



    private void Start()
    {
        //So time doesn't stand still.
        Time.timeScale = 1;
    }

=======
    private void Start()
    {
        Time.timeScale = 1;
    }
>>>>>>> 63ea95bb854d92257082e0c8992cce795a43fdd6
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
