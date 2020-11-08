using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputString : MonoBehaviour
{
    public static InputString IS = new InputString();
    
    private static string textString;
    private static string textString2;

    public static string TextString
    {
        get { return textString; }
        set { textString = value; }
    }


    public static string TextString2
    {
        get { return textString2; }
        set { textString2 = value; }
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

    public static void setValue2(string val)
    {
        textString2 = val;
    }

    public static string getValue2()
    {
        return textString2;
    }

    void Update()
    {
       /* if(SceneManager.GetActiveScene().name == "ResultScene")
        {
            Debug.LogError(InputString.getValue());
        }*/
    }
}
