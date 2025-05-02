using UnityEngine;
using Photon.Pun;
using System.Collections;
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

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Photon is connected!");
        GameManager.instance.OpenEMenu(MenuName.MainMenu);
    }



}