using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyFrameRate : MonoBehaviour {
    public static DontDestroyFrameRate instance = null;
    public static DontDestroyFrameRate Instance()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
