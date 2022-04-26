using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    public override void OnStartServer()
    {
        Debug.Log("Server started");
        //NetworkServer.RegisterHandler<PosMessage>(OnCreateCharacter);
    }

    public override void OnStopServer()
    {
        Debug.Log("Server stopped");
    }

    public override void OnStartClient()
    {
        Debug.Log("Client started");
        
    }

    public override void OnStopClient()
    {
        Debug.Log("Client stopped");
    }

    public void OnCreateCharacter(NetworkConnection conn, PosMessage message)
    {
        var go = _cubeSpawner.Spawn();
        //NetworkServer.AddPlayerForConnection(conn, go);
    }
}
