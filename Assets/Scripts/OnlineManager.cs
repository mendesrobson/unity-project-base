using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OnlineManager : MonoBehaviourPunCallbacks
{
    public GameObject painelLogin, PainelRoom, background;
    public InputField playerName, roomName;

    public GameObject playersPrefab;

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
        Debug.Log("Connecting to Master Server...");
    }

    public void CreateRoom()
    {
        PhotonNetwork.JoinOrCreateRoom(roomName.text, new RoomOptions(), TypedLobby.Default);
        painelLogin.SetActive(false);
        PainelRoom.SetActive(false);
        background.SetActive(false);
    }

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
        Debug.Log("Disconnected");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join random room");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room! Spawnig player....");
        print(PhotonNetwork.CurrentRoom.Name);
        print(PhotonNetwork.CurrentRoom.PlayerCount);
        print(PhotonNetwork.NickName);
       // PhotonNetwork.Instantiate(playersPrefab.name, new Vector3(Random.Range(1, 7), 0, Random.Range(1, 7)), Quaternion.Euler(0, 45, 0), 0);
    }
}
