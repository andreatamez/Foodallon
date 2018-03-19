using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public EditScene editScene;
    public Text text;

    void Update () {
        GameVars.timeLeft -= Time.deltaTime;
        text.text = "Time: " + Mathf.Round(GameVars.timeLeft) + " s";
        if (GameVars.timeLeft < 0)
        {
            Debug.Log("END");
            editScene.ChangeScene("Score");
        }
	}
}
