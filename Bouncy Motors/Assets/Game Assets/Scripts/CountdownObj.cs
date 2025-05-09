using Photon.Pun;
using UnityEngine;

public class CountdownObj : MonoBehaviourPun
{
    public GameObject countdownObj;

    private void Start()
    {
        countdownObj.SetActive(false);
    }

    [PunRPC]
    public void EnableCountdown()
    {
        countdownObj.SetActive(true);
    }
}