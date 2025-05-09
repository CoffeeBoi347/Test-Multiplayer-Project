using Photon.Pun;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviourPunCallbacks, IPunObservable
{
    public string playerName;
    public Vector3 startPos;
    public Rigidbody2D rb;
    public float velocity;
    public float jumpPower;
    public ParticleSystem blastFX;
    public Vector3 networkPos;
    public PlayerNameTest playerNameTst;
    private void Start()
    {
        startPos = transform.position;  
        rb = GetComponent<Rigidbody2D>();
        playerNameTst = GetComponent<PlayerNameTest>();
        playerNameTst.playerNameTxt.text = PhotonNetwork.NickName;
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            InputControls();
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, networkPos, Time.deltaTime * 10f);
        }
    }

    void InputControls()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(velocity, jumpPower);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) // if you are the owner of the photon view object
        {
            stream.SendNext(transform.position);
            stream.SendNext(rb.velocity);
        }

        else // if you are not then let others read your data
        {
            networkPos = (Vector3)stream.ReceiveNext();
            rb.velocity = (Vector3)stream.ReceiveNext();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            blastFX.Play();
            StartCoroutine(GoBackToStart(0.1f));
            StartCoroutine(ChangeColor(0.1f));
        }
    }

    private IEnumerator GoBackToStart(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = startPos;
    }

    private IEnumerator ChangeColor(float time)
    {
        var spriteComponent = transform.GetComponent<SpriteRenderer>();
        spriteComponent.color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(time);
        spriteComponent.color = new Color32(255, 255, 255, 255);
    }
}