﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRegister : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Register");
    }

    public void goToRegister()
    {
        DelaySceneLoad();
    }

}
