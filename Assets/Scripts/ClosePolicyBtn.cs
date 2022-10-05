using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePolicyBtn : MonoBehaviour
{
    GameObject policy;

    private void Start()
    {
        policy = GameObject.FindGameObjectWithTag("PrivatePolicy");
    }

    public void Close()
    {
        Destroy(policy);
    }
}
