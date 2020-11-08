using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Linq;

public class TextWork : MonoBehaviour
{
    //public FileDragAndDrop fdd;
    //public ImageToText imTT;
    string textt;
    private string textul = "";
    
    [SerializeField] TermsManager termsManager;
    string str = "A string with many words";
    string[] strArr;
    bool isGood = false;
    public void MyFunction()
    {
        //Debug.LogError(InputString.getValue());
        textt = InputString.getValue();
        strArr = textt.Split('.');

        //hasStarted = false;
        //oneTime = true;

        for (int i = 0; i < strArr.Length; i++)
        {
            isGood = false;
            for (int j = 0; j < termsManager.strings.Length; j++)
                if (strArr[i].Contains(termsManager.strings[j]))
                {
                    //Debug.Log(textul.text);
                    textul += "<color=red>" + strArr[i] + "." + "</color>";
                    isGood = true;
                }
            if (isGood == false)
                textul += strArr[i] + ".";

        }

        InputString.setValue(textul);
       // Debug.LogError(InputString.getValue());

    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
            hasStarted = true;
        if (Input.GetKeyDown(KeyCode.Delete))
            oneTime = false;
        if (hasStarted == true && oneTime == false)
            MyFunction();*/
    }
}
