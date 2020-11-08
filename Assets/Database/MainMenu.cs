using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Text text;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if(www.text[0]=='0')
        {
            DBManager.username = nameField.text;
           SceneManager.LoadScene("mainScene");
        }
        else
        {
            text.text="User login failed.Error #"+www.text;
        }

    }


    public void VerifyImputs()
    {
        submitButton.interactable = (nameField.text.Length >= 2 && passwordField.text.Length >= 2);
    }


    public void GoToRegister()
    {
        SceneManager.LoadScene("Register");
    }

    public void OnMeniuExit()
    {
        Application.Quit();
    }

}
