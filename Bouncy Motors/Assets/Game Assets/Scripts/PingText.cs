using TMPro;
using UnityEngine;
using Photon.Pun;

public class PingText : MonoBehaviour
{
    public TMP_Text pingText;

    private void Update()
    {
        pingText.text = "PING: " + PhotonNetwork.GetPing().ToString();
    }
}