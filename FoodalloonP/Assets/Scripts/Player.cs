using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            GameVars.foodForce -= 0.8f;
            GameVars.rottenPoints += 1;
            //Debug.Log(rb.gravityScale);
        }
        Destroy(col.gameObject);
    }
}
