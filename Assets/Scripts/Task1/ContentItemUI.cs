using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContentItemUI : MonoBehaviour
{
    public TextMeshProUGUI Label;
    public TextMeshProUGUI Points;
    public bool isManager;
    public int id;

    public void OnButtonClick()
    {
        ClientListVisualiser.instance.selectedID = id;
        ClientListVisualiser.instance.Label.text = Label.text;
        ClientListVisualiser.instance.ShowInfo();
    }
}
