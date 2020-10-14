using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IrrigateButton : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<StructureCognitiveModuleSpawner>().DestroyAll();
            FindObjectOfType<GateControllerSpawner>().DestroyAll();
            FindObjectOfType<VideoModuleSpawner>().DestroyAll();
            FindObjectOfType<SoilModuleSpawner>().DestroyAll();
            FindObjectOfType<WaterQualityModuleSpawner>().DestroyAll();
            FindObjectOfType<IrrigateModuleSpawner>().CreateIrrigateGroup();
            FindObjectOfType<IrrigateModuleSpawner>().CreateIrrigatePoint();
        });
    }
}
