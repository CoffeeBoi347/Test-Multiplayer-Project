using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GroundAndPipeSpawner : MonoBehaviourPun
{
    [Header("Objects To Spawn")]

    public GameObject pipeObj;
    public GameObject groundObj;

    [Header("Spawning Positions")]

    public Transform pipeTransform;
    public Transform groundTransform;

    [Header("Values")]

    public float timerObjPipe = 0f;
    public float timerObjGround = 0f;
    public float maxTimerPipe;
    public float maxTimerGround;
    public float minPosY = 0.4f;
    public float maxPosY = 4f;

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            timerObjPipe += Time.deltaTime;
            timerObjGround += Time.deltaTime;

            if (timerObjPipe >= maxTimerPipe)
            {
                SpawnPipe();
                timerObjPipe = 0f;
            }

            if (timerObjGround >= maxTimerGround)
            {
                //     SpawnGround();
                timerObjGround = 0f;
            }
        }
        else if(!PhotonNetwork.IsMasterClient)
        {
            return;
        }
    }

    void SpawnPipe()
    {
        float posY = Random.Range(maxPosY, minPosY);
        Vector3 spawnPos = new Vector3(pipeTransform.position.x, posY, 1f);
        Instantiate(pipeObj, spawnPos, Quaternion.identity);
    }

    void SpawnGround()
    {
        Vector3 spawnPosition = groundTransform.position;
        PhotonNetwork.Instantiate(groundObj.name, spawnPosition, Quaternion.identity);
    }

}