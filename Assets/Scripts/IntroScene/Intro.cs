using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    AudioSource myaudio;

    // Start is called before the first frame update
    void Start()
    {
        myaudio = GetComponent<AudioSource>();


#if !UNITY_EDITOR
               Invoke("PlayAudio", 3f);
#endif

        Invoke("Skip", 27f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayAudio()
    {
        myaudio.Play();
    }

    public void Skip()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Round1");
    }
}
