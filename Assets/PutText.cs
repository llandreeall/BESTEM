using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutText : MonoBehaviour
{
    public Text textul;

    private void Start()
    {
        textul.text = InputString.getValue()+InputString.getValue2();
        InputString.setValue("");
        InputString.setValue2("");
    }

}
