using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using B83.Win32;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using System;
using TMPro;
using RestClient.Core;
using RestClient.Core.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class ImageToText : MonoBehaviour
{ 
    public static StringBuilder text = new StringBuilder();
    public InputField inputField;

    [SerializeField]
    private string baseUrl = "https://westeurope.api.cognitive.microsoft.com/vision/v3.0/ocr?language=unk&detectOrientation=true";

    [SerializeField]
    private string clientId;

    [SerializeField]
    private string clientSecret;

    [SerializeField]
    private string imageToOCR = "";

    bool hasStarted = false;
    //bool oneTime = false;

    public void imgToText()
    {
        // do something with the dropped file names. aPos will contain the 
        // mouse position within the window where the files has been dropped.
        
       
        text = new StringBuilder();
        hasStarted = false;
        //oneTime = true;


        //Debug.LogError(inputField.text);

        //Debug.LogError("E imagine");
        // setup the request header
        RequestHeader clientSecurityHeader = new RequestHeader
                {
                    Key = clientId,
                    Value = clientSecret
                };

                // setup the request header
                RequestHeader contentTypeHeader = new RequestHeader
                {
                    Key = "Content-Type",
                    Value = "application/json"
                };

                // validation
                if (string.IsNullOrEmpty(imageToOCR))
                {
                    Debug.LogError("imageToOCR needs to be set through the inspector...");
                    return;
                }

                // build image url required by Azure Vision OCR
                ImageUrl imageUrl = new ImageUrl { Url = imageToOCR };

                //ImageUrl imageUrl = new ImageUrl { Url = path };
                // send a post request
                StartCoroutine(RestWebClient.Instance.HttpPost(baseUrl, JsonUtility.ToJson(imageUrl), (r) => OnRequestComplete(r), new List<RequestHeader>
                {
                    clientSecurityHeader,
                    contentTypeHeader
                }));

           

            //textAfisare.text = "Recieved file! Press the button below to scan the file!";


            



        // Debug.LogError(InputString.getValue());

    }

    void OnRequestComplete(Response response)
    {
        //Debug.LogError($"Status Code: {response.StatusCode}");
        //Debug.LogError($"Data: {response.Data}");
        //Debug.LogError($"Error: {response.Error}");

        if (string.IsNullOrEmpty(response.Error) && !string.IsNullOrEmpty(response.Data))
        {
            AzureOCRResponse azureOCRResponse = JsonUtility.FromJson<AzureOCRResponse>(response.Data);

            //header.text = $"Orientation: {azureOCRResponse.orientation} Language: {azureOCRResponse.language} Text Angle: {azureOCRResponse.textAngle}";

            string words = string.Empty;
            foreach (var region in azureOCRResponse.regions)
            {
                foreach (var line in region.lines)
                {
                    foreach (var word in line.words)
                    {
                        words += word.text + " ";
                        if (word.text.Equals(".") || word.text.Equals(";") || word.text.Equals("!") || word.text.Equals("?"))
                            words += "\n";
                    }
                }
            }

            text.Append(words);

            InputString.setValue(text.ToString());
            //Debug.LogError(InputString.getValue());
        } else
        {
            text.Append("We are sorry! Something went wrong, please try again!");

            InputString.setValue(text.ToString());
        }

    }

    public class ImageUrl
    {
        public string Url;
    }

    public void Update()
    {
        
        
       
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
            hasStarted = true;
        //if (Input.GetKeyDown(KeyCode.Delete))
            //oneTime = false;
        if (hasStarted == true )
        {
            imageToOCR = inputField.text;
            //Debug.LogError(inputField.text);
            imgToText(); 
        }
            
    }

    public String getText()
    {
        return text.ToString();
    }
}
