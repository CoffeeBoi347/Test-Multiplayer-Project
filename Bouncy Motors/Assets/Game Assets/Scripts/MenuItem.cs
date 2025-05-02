using UnityEngine;

public class MenuItem : MonoBehaviour, IMenu
{
    [SerializeField] private MenuName _eMenuName;

    public MenuName eMenuName
    {
        get => _eMenuName;
        set => _eMenuName = value;
    }


    private void Start()
    {
        GameManager.instance.AddMenu(this);
        Debug.Log("ADDED!");
    }
    
    public void OpenMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        this.gameObject.SetActive(false);
    }
}