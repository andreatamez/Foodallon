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

    int GetRottenProb(string level)
    {
        int prob = 0;
        if (level == "NY")
        {
            prob = Random.Range(1, 101);
        }

        if (level == "Francia")
        {
            prob = Random.Range(1, 93);
        }

        if (level == "China")
        {
            prob = Random.Range(1, 87);
        }

        if (level == "Mexico")
        {
            prob = Random.Range(1, 77);
        }

        return prob;
    }

    Vector3 GetFoodScale(string level)
    {
        Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
        if (level == "NY")
        {
            scale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        if (level == "Francia")
        {
            scale = new Vector3(0.75f, 0.75f, 0.75f);
        }

        if (level == "China")
        {
            scale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        if (level == "Mexico")
        {
            scale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        return scale;
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            float delay = Random.Range(min, max);
            yield return new WaitForSeconds(delay);
            int index = Random.Range(0, spawnPoints.Length);
            Transform point = spawnPoints[index];
            string sceneName = SceneManager.GetActiveScene().name;
            //GameObject typeFood = (Random.Range(0, 2) == 1) ? foodPrefab : rottenFood;
            GameObject typeFood = (GetRottenProb(sceneName) >= 50) ? foodPrefab : rottenFood;
            if (typeFood == foodPrefab)
            {
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
                typeFood.transform.localScale = GetFoodScale(sceneName);
                GameVars.totalFood += 1;
            }
            else
            {
                typeFood.GetComponent<SpriteRenderer>().sprite = rotten;
                typeFood.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            
            GameObject food = Instantiate(typeFood, point.position, point.rotation);
            Destroy(food, 5f);
        }
    }
}
