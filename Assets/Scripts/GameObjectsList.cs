using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsList : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject spinBtn, score;
    public int bid;

    private void Awake()
    {
        spinBtn = GameObject.Find("SpinBtn");
        bid = 10;
    }
}
