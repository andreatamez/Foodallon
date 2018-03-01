using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {

    public GameObject foodPrefab;
    public Transform[] spawnPoints;
    public float min = .1f;
    public float max = 3f;

	
	void Start () {
        StartCoroutine(SpawnFood());	
	}

    IEnumerator SpawnFood()
    {
        while (true)
        {
            float delay = Random.Range(min, max);
            yield return new WaitForSeconds(delay);
            int index = Random.Range(0, spawnPoints.Length);
            Transform point = spawnPoints[index];
            GameObject food = Instantiate(foodPrefab, point.position, point.rotation);
            Destroy(food, 5f);
        }
    }
}
