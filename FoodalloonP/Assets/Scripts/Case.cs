using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour {
    public AudioClip caseClip;
	void Start () {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().clip = caseClip;
        gameObject.GetComponent<AudioSource>().volume = 0.3f;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EndMap")
        {
            Debug.Log("stop sound");
            gameObject.GetComponent<AudioSource>().Stop();
            //Destroy(this);
        }
    }
}
