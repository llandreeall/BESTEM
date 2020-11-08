using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListenerNotDie : MonoBehaviour
{
    // Start is called before the first frame update
    private static ListenerNotDie obj = null;
    void Start()
    {
        DontDestroyOnLoad(this);

        // tre sa gasesc un fix pentru asta sa nu mai creeze mai multe neverDie dar sa pastreze originalul

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
}
