using Photon.Pun;
using UnityEngine;

public class CountdownObj : MonoBehaviourPun
{
    public GameObject countdownObj;

    [PunRPC]
    public void EnableCountdown()
    {
        countdownObj.SetActive(true);
    }
}