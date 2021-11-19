using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects;

    private bool buttonActivation = false;

    public enum eButtonType
    {
        UnlockDoor,
        MovePlatform,
        ComboLock,
        ChangeWalls
    }

    public eButtonType buttonType;

    // Update is called once per frame
    void Update()
    {
        switch (buttonType)
        {
            case eButtonType.UnlockDoor:
                if(buttonActivation == true && objects != null)
                {
                    foreach(GameObject door in objects)
                    {
                        door.GetComponent<LockedDoor>().ChangeLocked();
                    }
                }
                break;
            case eButtonType.MovePlatform:
                if (buttonActivation == true && objects != null)
                {
                    foreach (GameObject platform in objects)
                    {
                        platform.GetComponent<HorizontalPlatform>().enabled = true;
                        platform.GetComponent<VerticalPlatform>().enabled = true;
                    }
                }
                break;
            case eButtonType.ComboLock:

                break;
            case eButtonType.ChangeWalls:
                if (buttonActivation == true && objects != null)
                {
                    foreach (GameObject wall in objects)
                    {
                        wall.GetComponent<GhostWall>().enabled = true;
                    }
                }
                else
                {
                    foreach (GameObject wall in objects)
                    {
                        wall.GetComponent<GhostWall>().enabled = false;
                    }
                }
                    break;
            default:
                break;
        }
    }
}
