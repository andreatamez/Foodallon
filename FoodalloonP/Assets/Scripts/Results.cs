using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {

    public AudioClip winMixClip;
    public AudioClip levelupClip;
    public AudioClip looseClip;
    private AudioSource audioWin;
    private AudioSource audioLevel;
    private AudioSource audioLoose;

    public Text score;
    public Text badScore;
    public Sprite[] backgrounds;

    public int levelToUnlock = 2;

    void Start () {
        Performance();
    }

    public AudioSource LoadClips(AudioClip clip)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip;
        return newAudio;
    }

    public void Awake()
    {
        audioWin = LoadClips(winMixClip);
        audioLevel = LoadClips(levelupClip);
        audioLoose = LoadClips(looseClip);
    }

    void Performance()
    {
        int len = backgrounds.Length;
        float finalScore = FinalScore();

        if (finalScore > 0.8)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 1];
            audioWin.Play();
            if (GameVars.levelToUnlock <= 4) { GameVars.levelToUnlock++; }
            PlayerPrefs.SetInt(GameVars.versionName,GameVars.levelToUnlock);
        }
        else if (finalScore <= 0.8 && finalScore > 0.6)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 2];
            audioLevel.Play();
            if (GameVars.levelToUnlock <= 4) { GameVars.levelToUnlock++; }
            PlayerPrefs.SetInt(GameVars.versionName, GameVars.levelToUnlock);
        }
        else if (finalScore <= 0.6 && finalScore > 0.4)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 3];
            audioLoose.Play();
        }
        else if (finalScore <= 0.4 && finalScore > 0.2)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 4];
            audioLoose.Play();
        }
        else if (finalScore <= 0.2)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[len - 5];
            audioLoose.Play();
        }
    }

    private float FinalScore()
    {
        return (float) (GameVars.points - (GameVars.rottenPoints * 0f)) / (GameVars.totalFood * 0.70f); // entre 0.7 y 0.9
    }
	
	void Update () {
        score.text = "Score: " + FinalScore() * 100f + "%";
        badScore.text = "Rotten: " + GameVars.rottenPoints;
    }
}
