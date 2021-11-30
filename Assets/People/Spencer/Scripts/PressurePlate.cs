using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool needsSecond = false;
    public bool isActivated = false;
    [SerializeField]
    private PressurePlate otherPressurePlate;
    [SerializeField]
    private GameObject gameObjectPassedIn;
    private Vector3 objectPosition;



    // Update is called once per frame
    void Update()
    {
        objectPosition = gameObject.transform.position;

        objectPosition.y -= Time.deltaTime;

        if (isActivated == true)
        {
            Vector3 objectPosition = gameObject.transform.position;
            gameObject.transform.position = new Vector3(objectPosition.x, objectPosition.y, objectPosition.z);
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        isActivated = true;
        
    }
}
