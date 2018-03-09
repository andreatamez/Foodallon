using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timeLeft = 5.0f;
    public Text text;
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        text.text = "Time: " + Mathf.Round(timeLeft) + "s";
        if (timeLeft < 0)
        {
            //Application.Quit();
            Debug.Log("END");
            EditScene.ChangeScene("Score");
        }
	}
}
