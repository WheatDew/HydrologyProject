using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterQualityButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<StructureCognitiveModuleSpawner>().DestroyAll();
            FindObjectOfType<GateControllerSpawner>().DestroyAll();
            FindObjectOfType<VideoModuleSpawner>().DestroyAll();
            FindObjectOfType<SoilModuleSpawner>().DestroyAll();
            FindObjectOfType<IrrigateModuleSpawner>().DestroyAll();
            FindObjectOfType<WaterQualityModuleSpawner>().CreateWaterQualityGroup();
            FindObjectOfType<WaterQualityModuleSpawner>().CreateWaterQualityPoint();
        });
    }
}
