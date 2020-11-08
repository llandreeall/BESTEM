using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DontDieOnLoad : MonoBehaviour
{

    private static DontDieOnLoad obj = null;


    public InputField inputField;

    private Text temp;
    private Text tempHelper;
    private TermsManager termsMan;

    private string finalString;

    public string textulhelper;
    public string textul;
    bool hasStarted = false;
    bool oneTime = false;
    [SerializeField] TermsManager termsManager;
    string str = "A string with many words";
    string[] strArr;
    bool isGood = false;
    public void MyFunction()
    {
        strArr = inputField.text.Split('.');

        hasStarted = false;
        oneTime = true;

        for (int i = 0; i < strArr.Length; i++)
        {
            isGood = false;
            for (int j = 0; j < termsManager.strings.Length; j++)
                if (strArr[i].Contains(termsManager.strings[j]))
                {
                    Debug.Log(textul);
                    textul += "<color=red>" + strArr[i] + "." + "</color>";
                    isGood = true;
                }
            if (isGood == false)
                textul += strArr[i] + ".";

        }


        //textulhelper.text = textul;


    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        if (obj == null)
        {
            obj = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Object.Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name=="PasteScene")
        {
            temp = GameObject.FindGameObjectWithTag("InputField").GetComponent<Text>() ;
            termsMan = GameObject.FindGameObjectWithTag("TermsManager").GetComponent<TermsManager>();
            textul = temp.text;
            termsManager = termsMan;



            strArr = textul.Split('.');

            hasStarted = false;
            oneTime = true;

            Debug.Log(textul);

            for (int i = 0; i < strArr.Length; i++)
            {
               
                isGood = false;
                for (int j = 0; j < termsManager.strings.Length; j++)
                    if (strArr[i].Contains(termsManager.strings[j]))
                    {
                        Debug.Log("asasas");
                        Debug.Log(textul);
                        textul += "<color=red>" + strArr[i] + "." + "</color>";
                        isGood = true;
                    }
                if (isGood == false)
                    textul += strArr[i] + ".";

            }

            Debug.Log(textul);

            finalString = textul;



            textulhelper = finalString;



        }
        else
       

        if (SceneManager.GetActiveScene().name == "ResultScene")
        {
            tempHelper = GameObject.FindGameObjectWithTag("HelperText").GetComponent<Text>();
            termsManager = termsMan;

            




        }

        
       
       

       

    }
}
