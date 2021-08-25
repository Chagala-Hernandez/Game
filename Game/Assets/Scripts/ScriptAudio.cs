using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAudio : MonoBehaviour
{
    public static ScriptAudio scriptAudio;
    AudioSource audioSource;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if(ScriptAudio.scriptAudio == null)
        {
            ScriptAudio.scriptAudio = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
            Destroy(gameObject);
    }


    public static void Pause()
    {
        scriptAudio.audioSource.Stop();
    }

    public static void Play()
    {
        scriptAudio.audioSource.Play();
    }
}
