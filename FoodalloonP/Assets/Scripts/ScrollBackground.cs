using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour {

    public Text text;
    float speed = 0.6f;
    Renderer rend;

    // Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2 (Time.time * speed, 0);
        rend.material.mainTextureOffset = offset;

        // Points
        text.text = "Points: " + GameVars.points;
    }
}
