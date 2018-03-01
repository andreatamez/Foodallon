using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    Rigidbody2D rb;
    public float startForce = 0.1f;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * -startForce, ForceMode2D.Impulse);
	}

	void Update () {
		
	}
}
