using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InternetAccess : MonoBehaviour
{
    [SerializeField] private string[] urls;
    int counter = 0;

    public IEnumerator TestConnection()
    {
        foreach (string url in urls)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            Debug.Log("URL " + url + " Error " + request.isNetworkError);

            if (request.isNetworkError == false)
            {
                Main.internetAccess = true;
                Main.internetChecked = true;
                yield break;
            }
            else
                counter++;
        }

        if (counter == urls.Length)
            Main.internetChecked = true;
    }
}
