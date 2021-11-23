using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    float rotZ;
    float maxTime = .1f;
    float timer = .1f;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            rotZ += 5;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            timer = maxTime;
        }

    }
}
