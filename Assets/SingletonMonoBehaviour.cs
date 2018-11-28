using UnityEngine;
using System.Collections;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    instance = (Instantiate(Resources.Load("Prefab/Singleton/" + typeof(T).Name)) as GameObject).GetComponent<T>();
                    if (instance == null)
                    {
                        Debug.LogWarning(typeof(T) + "is nothing");
                    }
                }
            }
            return instance;
        }
    }

    protected void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
            return true;
        }
        else if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
            return true;
        }

        Destroy(this);
        return false;
    }
}