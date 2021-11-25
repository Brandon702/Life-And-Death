using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPlayer : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody2D rb;

    private bool isTriggered = false;
    private Collider2D button;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);

        if (Input.GetKeyDown(KeyCode.E) && isTriggered == true)
        {
            Debug.Log("button pushed");
            button.gameObject.GetComponent<Button>().buttonActivation = true;
            button.gameObject.GetComponent<Button>().OnClick();
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


}
