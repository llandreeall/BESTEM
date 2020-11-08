using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Linq;
using UnityEngine.SceneManagement;

public class GetText : MonoBehaviour
{
    public InputField inputField;
    public Text textul;
    public Text textul2;

    [SerializeField] TermsManager termsManager;
    string str = "A string with many words";
    string[] strArr;
    bool isGood=false;
    public void MyFunction1()
    {
        strArr = inputField.text.Split('.');
       // strArr = inputField.text.Split('\n');
        for (int i = 0; i < strArr.Length; i++)
        {
            isGood = false;
            for (int j = 0; j < termsManager.strings.Length; j++)
                if (strArr[i].Contains(termsManager.strings[j]))
                {
                    textul.text += "<color=red>" + strArr[i] +"." + "</color>"+"\n";
                    isGood = true;
                }
            if (isGood == false)
                textul.text += strArr[i]+"."+"\n";

        }
        InputString.setValue(textul.text) ;
        
    }


    public void MyFunction2()
    {
        strArr = inputField.text.Split('.');

        for (int i = 0; i < strArr.Length; i++)
            for (int j = 0; j < termsManager.strings.Length; j++)
                if (strArr[i].Contains(termsManager.strings[j]))

                    textul2.text += "<color=red>" + strArr[i] + "." + "</color>"+"\n";

        InputString.setValue2(textul2.text);

    }

}
