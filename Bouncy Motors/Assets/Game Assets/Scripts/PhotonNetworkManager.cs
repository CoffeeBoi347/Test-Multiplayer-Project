using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class PhotonNetworkManager : MonoBehaviourPunCallbacks
{
    public static PhotonNetworkManager Instance;
    public PlayerInfo playerInfo;
    public Transform playerListParent;
    public RoomInfoUI roomInfo;
    public Transform roomInfoObj;
    public Transform roomParentObj;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void ConnectedToServer(string playerName)
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = playerName;
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Lobby joined!");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Photon is connected!");
        GameManager.instance.OpenEMenu(MenuName.MainMenu);
        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 60;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom(string roomName, RoomOptions roomOptions)
    {
        PhotonNetwork.CreateRoom(roomName, roomOptions);
        GameManager.instance.OpenEMenu(MenuName.MainMenu);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Room created!");
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Room joined!");
        GameManager.instance.OpenEMenu(MenuName.WaitingList);

        var playerInfo_ = Instantiate(playerInfo, playerListParent.transform);
        playerInfo_.playerName.text = PhotonNetwork.NickName;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log(newPlayer.NickName);
        var playerInfo_ = Instantiate(playerInfo, playerListParent.transform);
        playerInfo_.playerName.text = newPlayer.NickName;
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
        Debug.Log("Master client changed!");
    }

    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        for(int i = 0; i < roomParentObj.childCount; i++)
        {
            Destroy(roomParentObj.GetChild(i).gameObject);
        }

        foreach(var i in roomList)
        {
            RoomInfoUI roomInfo = Instantiate(roomInfoObj, roomParentObj).GetComponent<RoomInfoUI>();
            roomInfo.roomName.text = i.Name.ToString();
            roomInfo.roomPlayers.text = $"{i.PlayerCount} / {i.MaxPlayers}";
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}