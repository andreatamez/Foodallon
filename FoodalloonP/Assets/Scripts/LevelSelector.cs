﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public Button[] levelButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt(GameVars.versionName, 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if ( i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Select (string level)
    {
        ContMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
        SceneManager.LoadScene(level);
    }

    public void ReturnMenu()
    {
        ContMusic.Instance.gameObject.GetComponent<AudioSource>().UnPause();
        SceneManager.LoadScene("Menu");
        GameVars.ResetVars();
    } 
}
