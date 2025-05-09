using Photon.Pun;
using UnityEngine;
public class PipeMove : MonoBehaviourPun, IPunObservable
{
    public float speedObj;
    public Vector3 networkPos;
    private void Update()
    {
        if(transform.position.x <= -20f)
        {
            Destroy(gameObject);
        }

        if (photonView.IsMine)
        {
            transform.Translate(Vector2.left * speedObj, 0f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, networkPos, Time.deltaTime * 10f);
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            networkPos = (Vector3)stream.ReceiveNext();
        }
    }
}