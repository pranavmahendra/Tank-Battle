using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonosingletonGeneric<T> : MonoBehaviour where T:MonosingletonGeneric<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    
    protected virtual void Awake()
	{
        if (instance == null)
		{
            instance = (T)this;
		}
        else
		{
            Debug.Log("Someone is trying to create new instance");
            Destroy(this);
		}
	}
    
}
