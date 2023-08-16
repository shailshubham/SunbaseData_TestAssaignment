using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class ClientListVisualiser : MonoBehaviour
{
    [SerializeField] GameObject contentItemUIPrefeb;
    [SerializeField] GameObject contentItemParent;
    List<ContentItemUI> contentItemUiList = new List<ContentItemUI>();
    [SerializeField] TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown.value = 0;
        ClientDatabase.instance.onDataDownloaded += ShowUI;
    }
    private void OnDestroy()
    {
        ClientDatabase.instance.onDataDownloaded -= ShowUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowUI()
    {
        foreach(ClientDatabase.Client client in ClientDatabase.instance.clientList.clients)
        {
            GameObject item = Instantiate(contentItemUIPrefeb);
            ContentItemUI contentItemUI = item.GetComponent<ContentItemUI>();
            contentItemUI.Label.text = client.label;
            contentItemUI.Points.text = ClientDatabase.instance.GetClientInfo(client.id).points.ToString();
            contentItemUI.isManager = client.isManager;
            contentItemUI.id = client.id;
            contentItemUI.transform.SetParent(contentItemParent.transform);
            contentItemUiList.Add(contentItemUI);
        }
    }

    public void OnDropDownValueChange()
    {
        foreach(ContentItemUI item in contentItemUiList)
        {
            if(dropdown.value == 0)
            {
                item.gameObject.SetActive(true);
            }
            else if(dropdown.value == 1)
            {
                if(item.isManager)
                {
                    item.gameObject.SetActive(true);
                }
                else
                {
                    item.gameObject.SetActive(false);
                }
            }
            else if(dropdown.value == 2)
            {
                if (!item.isManager)
                {
                    item.gameObject.SetActive(true);
                }
                else
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }
}
