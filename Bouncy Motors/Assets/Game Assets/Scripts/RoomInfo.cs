using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfoUI : MonoBehaviour
{
    public TMP_Text roomName;
    public Image roomColor;
    public TMP_Text roomPlayers;
    public Button roomJoin;

    public void JoinRoom()
    {
        PhotonNetworkManager.Instance.JoinRoom(roomName.text);
    }
}