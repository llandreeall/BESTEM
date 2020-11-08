using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipLogin : MonoBehaviour
{
    
    public void Skip()
    {
        SceneManager.LoadScene("mainScene");
    }

}
