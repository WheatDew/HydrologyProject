using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryDataButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<GateControllerSpawner>().CreateHistoryData();
        });
    }
}
