using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class HostConnect : MonoBehaviour
{
    NetworkManager manager;
    public GameObject HostConnect_go;

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    public void HostFunction()
    {
        manager.StartHost();
        HostConnect_go.SetActive(false);
    }

    public void ConnectFunction()
    {
        Debug.Log("Connecting");
        manager.networkAddress = "127.0.0.3";
        manager.StartClient();
        Debug.Log("connected");
        HostConnect_go.SetActive(false);
    }
}
