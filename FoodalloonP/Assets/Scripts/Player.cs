using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpForce = 10f;
    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
	}

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Food")
        {
            Debug.Log("crash");
            //rb.gravityScale += 0.5f;
            Destroy(col.gameObject);
            return;
        }

    }
}
