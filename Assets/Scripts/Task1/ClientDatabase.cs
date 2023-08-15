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
        bool isManager;
        int id;
        string label;
    }
    [System.Serializable]
    public class ClientInfo
    {
        string adress;
        string name;
        int points;
    }

    [System.Serializable]
    public class Data
    {
        public ClientInfo _1;
        public ClientInfo _2;
        public ClientInfo _3;
    }

    [System.Serializable]
    public class ClientList
    {
        public Client[] clients;
        Data data;
    }
}
