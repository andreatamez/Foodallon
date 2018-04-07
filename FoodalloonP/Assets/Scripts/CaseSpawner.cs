using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSpawner : MonoBehaviour {
    public AudioClip flyClip;
    private AudioSource audioFly;

    public GameObject casePrefab;
    public float timePeriod = 10f;
    public Transform[] spawnPoints;
    public float min = 0.5f;
    public float max = 0.5f;

    void Start()
    {    
        StartCoroutine(period());
    }

    public AudioSource LoadClips(AudioClip clip)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip;
        return newAudio;
    }

    public void Awake()
    {
        audioFly = LoadClips(flyClip);
    }

    IEnumerator period()
    {
        while (true)
        {
            yield return new WaitForSeconds(GameVars.timeLimit-0.5f);
            StartCoroutine("SpawnCase");
            audioFly.Play();
            yield return new WaitForSeconds(GameVars.timeLimit);
            StopCoroutine("SpawnCase");
            audioFly.Stop();
        } 
    }

    IEnumerator SpawnCase()
    {
        Debug.Log("start");
        while (true)
        {
            float delay = Random.Range(min, max);
            yield return new WaitForSeconds(delay);
            int index = Random.Range(0, spawnPoints.Length);
            Transform point = spawnPoints[index];
            GameObject caseObject = Instantiate(casePrefab, point.position, point.rotation);
            Destroy(caseObject, 2f);
        }
    }
}
