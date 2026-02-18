using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class NewMonoBehaviourScript : MonoBehaviourPunCallbacks
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            PhotonNetwork.Disconnect();
        }
    }

    // CONECTADO
    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected to Master");
    }

    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();
        Debug.Log("Joined Lobby");
        PhotonNetwork.JoinRandomRoom();        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from Master: " + cause.ToString());
        // base.OnDisconnected(cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("Failed to join random room: " + message);
        //PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 10 });
        PhotonNetwork.CreateRoom(null, new RoomOptions { });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
        //base.OnJoinedRoom();
    }
}
