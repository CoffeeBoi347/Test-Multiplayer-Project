using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Nickname Lobby")]

    public TMP_InputField playerNickname;
    public Button playBtn;

    [Header("Main Lobby")]

    public Button roomCreateBtn;
    public Button findRoomBtn;
    public Button quitBtn;

    [Header("CreateRoom Lobby")]

    public TMP_InputField roomName;
    public Slider playersSlider;
    public Button createRoomBtn;


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
        roomCreateBtn.onClick.AddListener(OnCreateRoomButtonPressed);
        findRoomBtn.onClick.AddListener(OnFindRoomButtonPressed);
        quitBtn.onClick.AddListener(OnQuitRoomPressed);
        createRoomBtn.onClick.AddListener(OnRoomCreatedButtonPressed);
        
    }

    private void OnPlayButtonPressed()
    {
        PhotonNetworkManager.Instance.ConnectedToServer(playerNickname.text);
    }

    private void OnCreateRoomButtonPressed()
    {
        GameManager.instance.OpenEMenu(MenuName.CreateRoom);
    }

    private void OnFindRoomButtonPressed()
    {
        GameManager.instance.OpenEMenu(MenuName.FindRoom);
    }

    private void OnRoomCreatedButtonPressed()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = (int)playersSlider.value;
        roomOptions.EmptyRoomTtl = 30000;
        PhotonNetworkManager.Instance.CreateRoom(roomName.text, roomOptions);
    }

    private void OnQuitRoomPressed()
    {
        Application.Quit();
    }
}