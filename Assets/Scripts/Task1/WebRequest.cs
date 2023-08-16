using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class WebRequest : MonoBehaviour
{
    [SerializeField] string requestWebAdress = "https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";
    string jsonText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetJason());
    }

    IEnumerator GetJason()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(requestWebAdress))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                jsonText = request.downloadHandler.text;
                
                ClientDatabase.instance.clientList = JsonConvert.DeserializeObject<ClientDatabase.ClientList>(jsonText);
                ClientDatabase.instance.onDataDownloaded?.Invoke();
            }
        }
    }
}
