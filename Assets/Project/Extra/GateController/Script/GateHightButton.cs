using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateHightButton : MonoBehaviour
{
    public int gateID;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<GateControllerSpawner>().CreateGateHightController();
            FindObjectOfType<GateHightControllerGroup>().DispalyGate(gateID);
        });
    }
}
