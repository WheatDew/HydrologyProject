using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoilButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<StructureCognitiveModuleSpawner>().DestroyAll();
            FindObjectOfType<GateControllerSpawner>().DestroyAll();
            FindObjectOfType<VideoModuleSpawner>().DestroyAll();
            FindObjectOfType<IrrigateModuleSpawner>().DestroyAll();
            FindObjectOfType<WaterQualityModuleSpawner>().DestroyAll();
            FindObjectOfType<MainPageModuleSpawner>().SetSoilGroup();
            FindObjectOfType<SoilModuleSpawner>().CreateSoilGroup();
            FindObjectOfType<SoilModuleSpawner>().CreateSoilPoint();
        });
    }
}
