using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = Main.score.ToString();
    }
}
