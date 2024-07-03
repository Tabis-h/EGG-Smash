using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    [Space]
    public Transform spawnpoint;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("connected to server");
        PhotonNetwork.JoinLobby();
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("test",null,null);
        Debug.Log("connected to room");
        GameObject _player = PhotonNetwork.Instantiate(player.name,spawnpoint.position,Quaternion.identity);
    }
}
