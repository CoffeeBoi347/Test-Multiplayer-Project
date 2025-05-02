using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField playerNickname;
    public Button playBtn;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("playerNickname"))
        {
            playerNickname.text = PlayerPrefs.GetString("playerNickname");
        }
        else
        {
            playerNickname.text = "Player_" + Random.Range(0000, 9999).ToString();
            PlayerPrefs.SetString("playerNickname", playerNickname.text);
        }
    }

    private void Start()
    {
        playBtn.onClick.AddListener(OnPlayButtonPressed);
    }

    private void OnPlayButtonPressed()
    {
        PhotonNetworkManager.Instance.ConnectedToServer(playerNickname.text);
    }
}