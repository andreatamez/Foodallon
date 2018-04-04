using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {

    public Text score;
    public Text badScore;
    public Sprite[] backgrounds;

    void Start () {
        Performance();
    }

    void Performance()
    {
        int points = GameVars.points;
        int len = backgrounds.Length;
        if (points == 5)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 1];
        }
        else if (points == 4)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 2];
        }
        else if (points == 3)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 3];
        }
        else if (points == 2)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 4];
        }
        else if (points <= 1)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 5];
        }
    }
	
	void Update () {
        score.text = "Score: " + GameVars.points;
        badScore.text = "Rotten: " + GameVars.rottenPoints;
    }
}
