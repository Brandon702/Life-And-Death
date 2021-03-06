using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects;

    public bool buttonActivation = false;

    public enum eButtonType
    {
        UnlockDoor,
        MovePlatform,
        ComboLock,
        ChangeWalls
    }

    public eButtonType buttonType;

    // Update is called once per frame
    public void OnClick()
    {
        Debug.Log("Button activated");
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
                        if (wall.GetComponent<GhostWall>() != null)
                        {
                            Destroy(wall.GetComponent<GhostWall>());
                        }
                        else
                        {
                            wall.AddComponent<GhostWall>();
                        }
                    }
                }
                else
                {
                    foreach (GameObject wall in objects)
                    {
                        if (wall.GetComponent<GhostWall>() != null)
                        {
                            Destroy(wall.GetComponent<GhostWall>());
                        }
                        else
                        {
                            wall.AddComponent<GhostWall>();
                        }
                    }
                }
                    break;
            default:
                break;
        }
    }
}
