using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHightControllerGroup : MonoBehaviour
{
    public GameObject gate1, gate2, gate3, gate4;

    public void DispalyGate(int GateID)
    {
        HideAll();
        switch (GateID)
        {
            case 1:
                gate1.SetActive(true);
                break;
            case 2:
                gate2.SetActive(true);
                break;
            case 3:
                gate3.SetActive(true);
                break;
            case 4:
                gate4.SetActive(true);
                break;
        }
    }

    public void HideAll()
    {
        gate1.SetActive(false);
        gate2.SetActive(false);
        gate3.SetActive(false);
        gate4.SetActive(false);
    }
}
