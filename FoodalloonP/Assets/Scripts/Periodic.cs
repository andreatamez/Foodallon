using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Periodic : MonoBehaviour {
    float time = 5f;
    float InstanceTimer = 5f;

	void Start () {
    }
	
	void Update () {
        creatPrefab();
        //Debug.Log(InstanceTimer);
    }

    void creatPrefab()
    {
        InstanceTimer -= Time.deltaTime;

        if (InstanceTimer <= -0 && GameVars.period)
        {
            Debug.Log("Delete");
            InstanceTimer = time;
            GameVars.period = false;
        }

        if (InstanceTimer <= -0 && !GameVars.period)
        {
            
            Debug.Log("Create");
            GameVars.period = true;
            InstanceTimer = time;
        }
    }
}
