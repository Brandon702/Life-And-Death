using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool needsSecond = false;
    public bool isActivated = false;
    public float maxHeight;
    public float minHeight;
    [SerializeField]
    private PressurePlate otherPressurePlate;
    [SerializeField]
    private GameObject gameObjectPassedIn;
    private Vector3 objectPosition;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        objectPosition = gameObject.transform.position;

        if (isActivated == true)
        {
            Debug.Log("activated");
            Vector3 objectPosition = gameObject.transform.position;
            objectPosition.y -= Time.deltaTime;
            //gameObject.transform.position = new Vector3(objectPosition.x, objectPosition.y, objectPosition.z);
            if (objectPosition.y <= minHeight)
            {
                objectPosition.y = minHeight;
            }
        }
        else if(isActivated == false)
        {
            Vector3 objectPosition = gameObject.transform.position;
            objectPosition.y += Time.deltaTime;
            if (objectPosition.y >= maxHeight)
            {
                objectPosition.y = maxHeight;
            }
        }
        gameObject.transform.position = new Vector3(objectPosition.x, objectPosition.y, objectPosition.z);

        if (needsSecond == true && otherPressurePlate.isActivated == true)
        {
            if(gameObjectPassedIn.TryGetComponent<LockedDoor>(out LockedDoor door))
            {
                door.ChangeLocked();
            }
            else if(gameObjectPassedIn.TryGetComponent<HorizontalPlatform>(out HorizontalPlatform hPlatform))
            {
                hPlatform.GetComponent<HorizontalPlatform>().enabled = true;
            }
            else if(gameObjectPassedIn.TryGetComponent<VerticalPlatform>(out VerticalPlatform vPlatform))
            {
                vPlatform.GetComponent<VerticalPlatform>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Here");
        isActivated = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isActivated = false;
    }
}
