using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class NewMonoBehaviourScript : MonoBehaviourPunCallbacks
{
    public GameObject painelLogin, PainelRoom, background;
    public InputField playerName, roomName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        painelLogin.SetActive(false);
        PainelRoom.SetActive(false);
        background.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            //PhotonNetwork.Disconnect();
            painelLogin.SetActive(!painelLogin.activeSelf);
            background.SetActive(!background.activeSelf);
        }
    }

    public void Login()
    {
        PhotonNetwork.NickName = playerName.text;
        PhotonNetwork.ConnectUsingSettings();
        painelLogin.SetActive(false);
        PainelRoom.SetActive(true);
    }

    public void CreateRoom()
    {
        PhotonNetwork.JoinOrCreateRoom(roomName.text, new RoomOptions { MaxPlayers = 10 }, TypedLobby.Default);
        painelLogin.SetActive(false);
        PainelRoom.SetActive(false);
        background.SetActive(false);
    }

    // CONECTADO
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected to Master");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");      
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from Master: " + cause.ToString());
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join random room: " + message);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room! Spawnig player....");
        print(PhotonNetwork.CurrentRoom.Name);
        print(PhotonNetwork.CurrentRoom.PlayerCount);
        print(PhotonNetwork.NickName);
    }
}
