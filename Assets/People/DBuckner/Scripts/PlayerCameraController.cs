using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private GameObject cameraGameObject;
    private Transform playerTransform;

    private void Start()
    {
        cameraGameObject = GetComponentInChildren<Camera>().gameObject;
    }

    public void MoveCamera()
    {
        playerTransform = GetComponent<Transform>();
        cameraGameObject.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
    }
}
