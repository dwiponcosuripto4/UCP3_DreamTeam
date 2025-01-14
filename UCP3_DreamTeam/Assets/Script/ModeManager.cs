using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public static ModeManager Instance;
    public bool isVsCOM = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetVsCOMMode()
    {
        isVsCOM = true;
    }

    public void SetPlayerVsPlayerMode()
    {
        isVsCOM = false;
    }
}
