using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    public AudioClip startClip;
    private AudioSource audioStart;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(Press());
        }
    }

    public AudioSource LoadClips(AudioClip clip)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip;
        return newAudio;
    }

    public void Awake()
    {
        audioStart = LoadClips(startClip);
    }

    IEnumerator Press()
    {
        audioStart.Play();
        yield return new WaitForSeconds(1.5f);
        ChangeScene("Menu");
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
