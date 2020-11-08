﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Text text;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
            form.AddField("name", nameField.text);
            form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if(www.text == "0:Player added")
        {
            Debug.Log("User created successfully.");
            text.text = "User created successfully.";
        }
        else
        {
         Debug.Log("User creation failed. Error #" + www.text);
            text.text = "User creation failed. Error #" + www.text;
        }
    }

    public void VerifyImputs()
    {
        submitButton.interactable = (nameField.text.Length >= 2 && passwordField.text.Length >= 2);
    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoginScene");
    }

}
