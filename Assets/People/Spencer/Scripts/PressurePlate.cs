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

    // Update is called once per frame
    void Update()
    {
        
        if (isActivated == true)
        {
            if (transform.position.y > minHeight)
            {
                transform.position -= new Vector3(0, 1 * Time.deltaTime, 0);
            }
        }
        else
        {
            Vector3 objectPosition = gameObject.transform.position;
            objectPosition.y += Time.deltaTime;
            if (objectPosition.y >= maxHeight)
            {
                transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
            }
        }


    }

    private void ChangeOtherObject()
    {
        if (gameObjectPassedIn.TryGetComponent<LockedDoor>(out LockedDoor door))
        {
            door.ChangeLocked();
        }
        else if (gameObjectPassedIn.TryGetComponent<HorizontalPlatform>(out HorizontalPlatform hPlatform))
        {
            hPlatform.GetComponent<HorizontalPlatform>().enabled = true;
        }
        else if (gameObjectPassedIn.TryGetComponent<VerticalPlatform>(out VerticalPlatform vPlatform))
        {
            vPlatform.GetComponent<VerticalPlatform>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(transform.position.y >= maxHeight) isActivated = true;

        if (needsSecond == true && otherPressurePlate.isActivated)
        {
            ChangeOtherObject();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isActivated = false;
    }
}
