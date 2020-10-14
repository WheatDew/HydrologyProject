using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateControllerButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<StructureCognitiveModuleSpawner>().DestroyAll();
            FindObjectOfType<VideoModuleSpawner>().DestroyAll();
            FindObjectOfType<SoilModuleSpawner>().DestroyAll();
            FindObjectOfType<IrrigateModuleSpawner>().DestroyAll();
            FindObjectOfType<WaterQualityModuleSpawner>().DestroyAll();
            FindObjectOfType<MainPageModuleSpawner>().SetGateControllerGroup();
            FindObjectOfType<GateControllerSpawner>().CreateSensorPoint();
        });
    }
}
