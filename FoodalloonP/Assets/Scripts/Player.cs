using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public AudioClip jumpClip;
    public AudioClip rottenClip;
    public AudioClip coinClip;
    public AudioClip caseClip;

    private AudioSource audioJump;
    private AudioSource audioRotten;
    private AudioSource audioCoin;
    private AudioSource audioCase;

    Rigidbody2D rb;
    public float jumpForce = 10f;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    public AudioSource LoadClips(AudioClip clip)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip;
        return newAudio;
    }

    public void Awake()
    {
        audioJump = LoadClips(jumpClip);
        audioRotten = LoadClips(rottenClip);
        audioCoin = LoadClips(coinClip);
        audioCase = LoadClips(caseClip);
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
            //Debug.Log("out of bounds");
            GameVars.ResetVars();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (col.tag == "Food")
        {
            //Debug.Log("crash");
            audioCoin.Play();
            GameVars.points += 1;
        }

        if (col.tag == "case")
        {
            //Debug.Log("Crash case");
            audioCase.Play();
            rb.gravityScale += 1.5f;
            GameVars.foodForce -= 0.15f;
        }

        if (col.tag == "Rotten Food")
        {
            //Debug.Log("Rotten");
            audioRotten.Play();
            GameVars.rottenPoints += 1;
        }

        if (col.tag == "Plane")
        {
            GameVars.ResetVars();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // se destruye todo lo que toca jugador
        // considerar ponerlo en condiciones individuales
        Destroy(col.gameObject);
    }
}
