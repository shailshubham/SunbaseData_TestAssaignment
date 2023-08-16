using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDatabase : MonoBehaviour
{
    public static ClientDatabase instance;
    public ClientList clientList = new ClientList();
    public delegate void OnDataDownloaded();
    public OnDataDownloaded onDataDownloaded;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class Client
    {
        public bool isManager;
        public int id;
        public string label;
    }
    [System.Serializable]
    public class ClientInfo
    {
        public string address;
        public string name;
        public int points;
    }

    [System.Serializable]
    public class Data
    {
        [JsonProperty("1")]
        public ClientInfo _1;
        [JsonProperty("2")]
        public ClientInfo _2;
        [JsonProperty("3")]
        public ClientInfo _3;
    }

    [System.Serializable]
    public class ClientList
    {
        public Client[] clients;
        public Data data;
    }

    public ClientInfo GetClientInfo(int id)
    {
        switch(id)
        {
            case 1:
                return clientList.data._1;
            case 2:
                return clientList.data._2;
            case 3:
                return clientList.data._3;
        }
        return null;
    }
}
