﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContMusic : MonoBehaviour {

    //Play Global
    private static ContMusic instance = null;

    void Start()
    {
        
    }

    public static ContMusic Instance
    {
        get { return instance; }
    }

    void Awake()
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
    //Play Gobal End

    // Update is called once per frame
    void Update()
    {

    }

}
