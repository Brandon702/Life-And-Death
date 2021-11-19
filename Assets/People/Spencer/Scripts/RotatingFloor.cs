using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFloor : MonoBehaviour
{
    float rotZ;
    float maxTime = .1f;
    float timer = .1f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            rotZ += 5;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            timer = maxTime;
        }
        
    }
}
