using System;
using UnityEngine;

public class UnitTracker : MonoBehaviour
{
    public static UnitTracker instance;
    public int units = 10;

    public static int Units { get { return instance != null ? instance.units : 10; } }

    private void Awake()
    {
        if (instance != null)
        { Destroy(gameObject); instance.units = 10; return; }

        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public static void Remove(int amount)
    {
        instance.units = Math.Max(0, instance.units - amount);
    }
}
