﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    
    public AudioClip jumpClip;
    public AudioClip rottenClip;
    private AudioSource audioJump;
    private AudioSource audioRotten;

    Rigidbody2D rb;
    public float jumpForce = 10f;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    public AudioSource LoadClips(AudioClip clip)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip;
        //newAudio.playOnAwake = true;
        return newAudio;
    }

    public void Awake()
    {
        audioJump = LoadClips(jumpClip);
        audioRotten = LoadClips(rottenClip);
    }

    void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            audioJump.Play();
        }
	}

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "EndMap")
        {
            Debug.Log("out of bounds");
            GameVars.ResetVars();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (col.tag == "Food")
        {
            Debug.Log("crash");
            GameVars.points += 1;
        }

        if (col.tag == "case")
        {
            Debug.Log("Crash case");
            rb.gravityScale += 1.5f;
        }

        if (col.tag == "Rotten Food")
        {
            //Debug.Log("Rotten");
            //rb.gravityScale += 1.5f;
            audioRotten.Play();
            GameVars.foodForce -= 0.8f;
            GameVars.rottenPoints += 1;
        }
        Destroy(col.gameObject);
    }
}
