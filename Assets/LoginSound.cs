using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginSound : MonoBehaviour
{
    public AudioClip sound;
    private Button button;
    public AudioSource source { get { return GetComponent<AudioSource>(); } }

    private bool rightScene = true;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;




    }

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

    public int count = 0;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "LoginScene" && rightScene == true)
        {
            button = GameObject.FindGameObjectWithTag("LoginButton").GetComponent<Button>();
            button.onClick.AddListener(() => PlaySound());
            rightScene = false;
            //Debug.Log(count);
            count++;
        }
        if (SceneManager.GetActiveScene().name != "Register")
        {
            rightScene = true;
        }
    }
}
