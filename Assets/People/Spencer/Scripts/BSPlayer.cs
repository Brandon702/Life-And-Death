using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPlayer : MonoBehaviour
{
    public float speed = 1;
    public Rigidbody2D rb;
    private bool onGround = true;

    private bool isTriggered = false;
    private Collider2D button;

    private PlayerCameraController pcc;

    private void Start()
    {
        Time.timeScale = 1;
        pcc = GetComponent<PlayerCameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);

        //pcc.MoveCamera();

        if (Input.GetKeyDown(KeyCode.E) && isTriggered == true)
        {
            Debug.Log("button pushed");
            button.gameObject.GetComponent<Button>().buttonActivation = true;
            button.gameObject.GetComponent<Button>().OnClick();
        }
    }

    public void OnMove(Vector2 input)
    {
        if(onGround) rb.MovePosition(rb.transform.position + new Vector3(input.x, 0, 0));
        else rb.MovePosition(rb.transform.position + new Vector3(input.x, -Time.deltaTime * speed * 10, 0));
    }

    public void Jump()
    {
        if(onGround)
        {
            onGround = false;
            rb.MovePosition(rb.transform.position + new Vector3(0, Time.deltaTime * speed * 10, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
        button = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }
    }
}
