using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSpawner : MonoBehaviour {

    public GameObject casePrefab;

    public Transform[] spawnPoints;
    public float min = .1f;
    public float max = 1f;


    void Start()
    {
        StartCoroutine(SpawnCase());
    }

    IEnumerator SpawnCase()
    {
        while (true)
        {
            float delay = Random.Range(min, max);
            yield return new WaitForSeconds(delay);
            int index = Random.Range(0, spawnPoints.Length);
            Transform point = spawnPoints[index];
            GameObject caseObject = Instantiate(casePrefab, point.position, point.rotation);
            Destroy(caseObject, 5f);
        }
    }



}
