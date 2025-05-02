using UnityEngine;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    public int noOfMenus;
    public List<IMenu> allMenus = new List<IMenu>();

    public void AddMenu(IMenu menuName)
    {
        allMenus.Add(menuName);
        if(allMenus.Count >= noOfMenus)
        {
            Debug.Log("All menus have been added!");
            OpenEMenu(MenuName.Nickname);
        }
    }

    public void OpenEMenu(MenuName EMenuName)
    {
        foreach(var i in allMenus)
        {
            if(i.eMenuName == EMenuName)
            {
                i.OpenMenu();
            }
            else
            {
                i.CloseMenu();
            }
        }
    }
}

public interface IMenu
{
    public MenuName eMenuName { get; set; }
    public void OpenMenu();
    public void CloseMenu();
}

public enum MenuName
{
    Nickname,
    MainMenu,
    FindRoom,
    CreateRoom,
    ChooseMap,
    WaitingList
}