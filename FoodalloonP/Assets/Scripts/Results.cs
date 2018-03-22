using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {

    public Text score;
    public Text badScore;

    // Use this for initialization
    void Start () {
		
	}
	
	void Update () {
        score.text = "Score: " + GameVars.points;
        badScore.text = "Rotten: " + GameVars.rottenPoints;
    }
}
