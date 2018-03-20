using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {
    public float speed = 5f;
    bool moving = false;
    float saveTime;
    Vector3 originalPos;

    void Start () {
        saveTime = Time.time;
        originalPos = gameObject.transform.position;
    }

	void Update () {
        Move();
	}

    private void Move()
    {
        if (Time.time - saveTime >= 10)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EndMap")
        {
            Debug.Log("Plane Crash");
            saveTime = Time.time;
            gameObject.transform.position = originalPos;
        }
    }
}
