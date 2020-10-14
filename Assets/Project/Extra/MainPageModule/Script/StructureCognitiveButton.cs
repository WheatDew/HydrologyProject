using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureCognitiveButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<GateControllerSpawner>().DestroyAll();
            FindObjectOfType<VideoModuleSpawner>().DestroyAll();
            FindObjectOfType<SoilModuleSpawner>().DestroyAll();
            FindObjectOfType<IrrigateModuleSpawner>().DestroyAll();
            FindObjectOfType<WaterQualityModuleSpawner>().DestroyAll();
            FindObjectOfType<StructureCognitiveModuleSpawner>().CreateCognitiveElement();
            FindObjectOfType<MainPageModuleSpawner>().SetStructureCognitiveGroup();
        });
    }
}
