using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Transform startPos;
    public Transform endPos;

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        var posY = Random.Range(startPos.position.y, endPos.position.y);
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-6.59f, posY, 1f), Quaternion.identity);
    }

}