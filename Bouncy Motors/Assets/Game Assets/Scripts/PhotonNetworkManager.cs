using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonNetworkManager : MonoBehaviourPunCallbacks
{
    public static PhotonNetworkManager Instance;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
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
    }
}