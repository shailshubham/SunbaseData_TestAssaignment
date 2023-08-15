using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator GetJason()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://www.my-server.com"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                ClientDatabase.instance.clientList = JsonUtility.FromJson<ClientDatabase.ClientList>(request.downloadHandler.text);
                ClientDatabase.instance.onDataDownloaded?.Invoke();
            }
        }
    }
}
