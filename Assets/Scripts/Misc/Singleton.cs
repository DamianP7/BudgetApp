﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generyczna klasa ułatwiająca tworzenie i używanie singledonów
/// </summary>
/// <typeparam name="T">Klasa, z której ma zostać utworzony singledon</typeparam>
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public bool dontDestroyOnLoad = false;

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if(dontDestroyOnLoad)
                DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}