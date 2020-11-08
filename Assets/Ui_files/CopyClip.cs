using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using UnityEngine.UI;

public class CopyClip : MonoBehaviour
{
    //Text TextBoxToUse;

    public Text textbox;
    private string TextBoxToUse;

    // Start is called before the first frame update
    void Start()
    {
        TextBoxToUse = textbox.text;
        Console.Write("as");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void CopyToClipboard()
    {
        Console.Write(TextBoxToUse);
        GUIUtility.systemCopyBuffer = TextBoxToUse;
    }


}
