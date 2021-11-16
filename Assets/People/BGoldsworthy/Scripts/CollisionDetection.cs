using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Province collided once");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Provinces are persistantly touching");
    }

    
}
