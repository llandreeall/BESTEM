using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    // Start is called before the first frame update
  
    public AudioClip audio;
    private AudioSource aud;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void PlayButton()
    {
        AudioSource.PlayClipAtPoint(audio, new Vector3(5, 1, 2));
    }

}
