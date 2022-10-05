using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolicyAcceptionCheck : MonoBehaviour
{
    void Start()
    {
        if (!Main.PolicyWasAccepted)
        {
            Destroy(GetComponent<Button>());
            GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f, 1);
        }
    }
}
