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

public class FileDragAndDrop : MonoBehaviour
{
    List<string> log = new List<string>();
    string path;

    public static StringBuilder text = new StringBuilder();


    public Text textAfisare;


    void OnEnable ()
    {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnFiles;
    }
    void OnDisable()
    {
        UnityDragAndDropHook.UninstallHook();
    }

    void OnFiles(List<string> aFiles, POINT aPos)
    {
        // do something with the dropped file names. aPos will contain the 
        // mouse position within the window where the files has been dropped.
        string str = "Dropped " + aFiles.Count + " files at: " + aPos + "\n\t" +
            aFiles.Aggregate((a, b) => a + "\n\t" + b);
        string extension = System.IO.Path.GetExtension(aFiles.Aggregate((a, b) => a + "\n\t" + b));
        text = new StringBuilder();
        if (extension.Equals(".txt") || extension.Equals(".pdf") || extension.Equals(".doc") )
        {
            //do something
            path = aFiles.Aggregate((a, b) => a + "\n\t" + b);
            

            if (extension.Equals(".pdf"))
            {
                try
                {
                    using (PdfReader reader = new PdfReader(path))
                    {

                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }

                    }
                }
                catch(Exception)
                {
                    textAfisare.text = "<color=red>" + "This file doesn't contain text" + "</color>";
                }
                //Debug.LogError(text.ToString());
            } else if (extension.Equals(".txt"))
            {
                List<string> textList = File.ReadAllLines(path).ToList();

                foreach(string line in textList)
                {
                    text.Append(line);
                    text.Append("\n");
                }
                //Debug.LogError(text.ToString());
            }
            
            else 
            {
                StreamReader sr = new StreamReader(path);
                text.Append(sr.ReadToEnd());
                //Debug.LogError(text.ToString());
            }
            //Debug.LogError(text.ToString());
            try
            {
                //gameObject.GetComponent<Text>().text = text.ToString();
            }
            catch(Exception e)
            {
                text.Append(e);
            }

            textAfisare.text = "Recieved file! Press the button below to scan the file!\n";
            
            
            InputString.setValue(text.ToString());

        } else
            textAfisare.text = "<color=red>" + "Wrong file type! Please drop a text/pdf file." + "</color>";


        
        
       // Debug.LogError(InputString.getValue());

    }


    public String getText()
    {
        return text.ToString();
    }
}
