using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodSpawner : MonoBehaviour {

    public Sprite[] mxFood;
    public Sprite[] nyFood;
    public Sprite[] chFood;
    public Sprite[] frFood;
    public Sprite rotten;

    public GameObject foodPrefab;
    public GameObject rottenFood;

    public Transform[] spawnPoints;
    public float min = .1f;
    public float max = 3f;

	
	void Start ()
    {
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
            GameObject typeFood = (Random.Range(0, 2) == 1) ? foodPrefab : rottenFood;
            if (typeFood == foodPrefab)
            {
                string sceneName = SceneManager.GetActiveScene().name;
                if (sceneName == "NY")
                {
                    typeFood.GetComponent<SpriteRenderer>().sprite = nyFood[Random.Range(0, nyFood.Length)];
                }

                if (sceneName == "Francia")
                {
                    typeFood.GetComponent<SpriteRenderer>().sprite = frFood[Random.Range(0, frFood.Length)];
                }

                if (sceneName == "China")
                {
                    typeFood.GetComponent<SpriteRenderer>().sprite = chFood[Random.Range(0, chFood.Length)];
                }

                if (sceneName == "Mexico")
                {
                    typeFood.GetComponent<SpriteRenderer>().sprite = mxFood[Random.Range(0,mxFood.Length)];
                }
                typeFood.transform.localScale = (new Vector3(0.5f, 0.5f, 0.5f));
                GameVars.totalFood += 1;
            }
            else
            {
                typeFood.GetComponent<SpriteRenderer>().sprite = rotten;
                typeFood.transform.localScale = (new Vector3(0.2f, 0.2f, 0.2f));
            }
            
            GameObject food = Instantiate(typeFood, point.position, point.rotation);
            Destroy(food, 5f);
        }
    }
}
