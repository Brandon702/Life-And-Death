using System;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        private MenuController menuController;


        void Start()
        {
            if(GameController.Instance != null)
            {
                if (GameController.Instance.state == eState.TITLE)
                {
                    menuController = GameObject.Find("Controllers").GetComponent<MenuController>();
                }
                else
                {
                    Debug.Log("Controller not found, if stating game normally this should not be visible");
                }
            }
            else
            {
                Debug.Log("GameController doesnt exist, if stating game normally this should not be visible");
            }
        }

        private void Update()
        {
            if (GameController.Instance.state == eState.GAME)
            {

                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                {
                    menuController.Pause();
                }
            }
        }
    }
}
