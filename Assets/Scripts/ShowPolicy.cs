using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPolicy : MonoBehaviour
{
    public GameObject Policy, canvas;
    private GameObject policy;

    public void CreatePolicyWindow()
    {
        policy = Instantiate(Policy) as GameObject;
        policy.transform.SetParent(canvas.transform, false);
    }
}
