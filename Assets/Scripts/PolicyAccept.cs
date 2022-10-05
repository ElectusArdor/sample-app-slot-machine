using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolicyAccept : MonoBehaviour
{
    Vector3 startPos;
    public GameObject switchBG;
    Color startColor;

    public void Start()
    {
        startPos = transform.localPosition;
        startColor = switchBG.GetComponent<Image>().color;

        if (Main.PolicyWasAccepted)
        {
            transform.localPosition = new Vector3(startPos.x + 39.7f, startPos.y, startPos.z);
            switchBG.GetComponent<Image>().color = new Color(0.2901961f, 0.854902f, 0.3882353f, 1);
        }
    }
    public void Switch()
    {
        if(!Main.PolicyWasAccepted)
        {
            transform.localPosition = new Vector3(startPos.x + 39.7f, startPos.y, startPos.z);
            Main.PolicyWasAccepted = true;
            switchBG.GetComponent<Image>().color = new Color(0.2901961f, 0.854902f, 0.3882353f, 1);
        }
        else
        {
            transform.localPosition = startPos;
            Main.PolicyWasAccepted = false;
            switchBG.GetComponent<Image>().color = startColor;
        }
    }
}
