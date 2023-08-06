using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPersist : MonoBehaviour
{
    void Awake()
    {
        int numOfScreenPersists = FindObjectsOfType<ScreenPersist>().Length;
        if(numOfScreenPersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ScreenDestroy()
    {
        Destroy(gameObject);
    }
}
