using Photon.Pun;
using UnityEngine;

public class CameraFollow : MonoBehaviourPun
{
    public Vector3 cameraOffset = new Vector3(0f, 0f, -10f);
    private Transform mainCamera;
    public float speed;
    private void Start()
    {
        if (photonView.IsMine)
        {
            mainCamera = Camera.main.transform;
        }
    }

    private void LateUpdate()
    {
        if(photonView.IsMine && mainCamera != null) 
        {
            Vector3 newPos = transform.position + cameraOffset;
            Vector3 desiredPos = Vector3.MoveTowards(transform.position, newPos, speed);
            mainCamera.transform.localPosition = desiredPos;
        }
    }

}