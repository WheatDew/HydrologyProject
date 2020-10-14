using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoButton : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<StructureCognitiveModuleSpawner>().DestroyAll();
            FindObjectOfType<GateControllerSpawner>().DestroyAll();
            FindObjectOfType<SoilModuleSpawner>().DestroyAll();
            FindObjectOfType<IrrigateModuleSpawner>().DestroyAll();
            FindObjectOfType<WaterQualityModuleSpawner>().DestroyAll();
            FindObjectOfType<MainPageModuleSpawner>().SetVideoGroup();
            FindObjectOfType<VideoModuleSpawner>().CreateVideoGroup();
            FindObjectOfType<VideoModuleSpawner>().CreateVideoPoint();
        });
    }
}
