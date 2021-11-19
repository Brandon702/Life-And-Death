using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLock : MonoBehaviour
{
    private bool one, two, three, four, five = false;
    private LockedDoor door;
    private SpriteRenderer[] lights;

    private void Start()
    {
        door = gameObject.GetComponent<LockedDoor>();
        lights = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    public void Button(int num)
    {
        switch (num)
        {
            case 1:
                one = !one;
                two = !two;
                four = !four;
                break;
            case 2:
                one = !one;
                three = !three;
                break;
            case 3:
                two = !two;
                three = !three;
                five = !five;
                break;
            case 4:
                one = !one;
                three = !three;
                four = !four;
                break;
            case 5:
                three = !three;
                four = !four;
                five = !five;
                break;
        }

        checkAll();
    }

    private void checkAll()
    {
        if (one && two && three && four && five && door.Locked)
        {
            door.ChangeLocked();
            lights[1].enabled = false;
            lights[2].enabled = false;
            lights[3].enabled = false;
            lights[4].enabled = false;
            lights[5].enabled = false;
        }
        if (one) lights[1].color = Color.red; else lights[1].color = Color.white;
        if (two) lights[2].color = Color.red; else lights[2].color = Color.white;
        if (three) lights[3].color = Color.red; else lights[3].color = Color.white;
        if (four) lights[4].color = Color.red; else lights[4].color = Color.white;
        if (five) lights[5].color = Color.red; else lights[5].color = Color.white;
    }

}
