using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {
    public float speed = 5f;
    Vector3 originalPos;

    void Start () {
        originalPos = gameObject.transform.position;
    }

	void Update () {
        transform.Translate(-speed * Time.deltaTime, 0 , 0);
	}

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "EndMap")
        {
            Debug.Log("Plane Crash");
            gameObject.transform.position = originalPos;
        }
    }
}
