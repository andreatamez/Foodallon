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
        float finalScore = FinalScore();
        if (finalScore <= 1 && finalScore > 0.8)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 1];
        }
        else if (finalScore <= 0.8 && finalScore > 0.6)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 2];
        }
        else if (finalScore <= 0.6 && finalScore > 0.4)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 3];
        }
        else if (finalScore <= 0.4 && finalScore > 0.2)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 4];
        }
        else if (finalScore <= 0.2)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 5];
        }
    }

    private float FinalScore()
    {
        return (float)(GameVars.points - GameVars.rottenPoints) / GameVars.totalFood;
    }
	
	void Update () {
        score.text = "Score: " + FinalScore() * 100f + "%";
        badScore.text = "Rotten: " + GameVars.rottenPoints;
    }
}
