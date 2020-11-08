using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputString : MonoBehaviour
{
    public static InputString IS = new InputString();
    
    private static string textString;

    public static string TextString
    {
        get { return textString; }
        set { textString = value; }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (IS == null)
        {
            IS = GameObject.FindGameObjectWithTag("InputString").GetComponent<InputString>();
        }
    }

    public static void setValue(string val)
    {
        textString = val;
    }

    public static string getValue()
    {
        return textString ;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "TestScene")
        {
            Debug.LogError(InputString.getValue());
        }
    }
}
