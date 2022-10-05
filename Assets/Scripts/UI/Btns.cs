using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btns : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(Main.levels[name]);
    }

    public void CheckInternetAccess()
    {
        StartCoroutine(GetComponent<InternetAccess>().TestConnection());
    }

    void Update()
    {
        if (name == "NextBtn1" && Main.internetChecked)
        {
            if (Main.internetAccess)
            {
                SceneManager.LoadScene(Main.levels[name + "_1"]);
                Main.internetChecked = false;
                Main.internetAccess = false;
            }
            else
            {
                SceneManager.LoadScene(Main.levels[name + "_2"]);
                Main.internetChecked = false;
            }
        }
    }
}
