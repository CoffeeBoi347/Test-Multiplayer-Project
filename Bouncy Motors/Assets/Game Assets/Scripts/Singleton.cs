
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T> // creating an abstract class, T means a single instance of any object we want to access
{
    public static T instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
        }
    }
}