using Photon.Pun;
using TMPro;
using UnityEngine;

public class ChatMessage : MonoBehaviourPun
{
    [Header("Chatbox")]

    public GameObject chatBox;
    public GameObject messageObj;
    public Transform messageParent;
    public bool hasOpened = false;

    [Header("Values")]

    public TMP_InputField messageBox;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            hasOpened = true;
            chatBox.SetActive(true);
        }

        if (hasOpened && Input.GetKeyDown(KeyCode.Return))
        {
            string message = messageBox.text;
            if(!string.IsNullOrEmpty(message))
            {
                photonView.RPC("SendMessage", RpcTarget.All, PhotonNetwork.NickName, message);
            }
        }
    }

    [PunRPC]
    void SendMessage(string sender, string messageChat)
    {
        Debug.Log("SENDING MESSAGE!");
        MessageInfo message = Instantiate(messageObj, messageParent).GetComponent<MessageInfo>();
        message.playerName.text = sender;
        message.playerMessage.text = messageChat;
    }
}