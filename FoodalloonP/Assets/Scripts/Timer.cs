using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public EditScene editScene;
    public float timeLeft = 5.0f;
    public Text text;

    private void Start()
    {
        
    }

    void Update () {
        timeLeft -= Time.deltaTime;
        text.text = "Time: " + Mathf.Round(timeLeft) + " s";
        if (timeLeft < 0)
        {
            Debug.Log("END");
            editScene.ChangeScene("Score");
            //EditScene.ChangeScene("Score");
        }
	}
}
