using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public bool move = false;

    public void Move()
    {
        move = true;
        Main.score -= Camera.main.GetComponent<GameObjectsList>().bid;
    }
}
