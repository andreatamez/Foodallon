using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public float speed = 0.5f;
    Renderer rend;
    // Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2 (Time.time * speed, 0);
        rend.material.mainTextureOffset = offset;
    }
}
