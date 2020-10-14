using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoilTemperatureButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate {
            FindObjectOfType<SoilModuleSpawner>().CreateSoilTemperature();
        });
    }
}
