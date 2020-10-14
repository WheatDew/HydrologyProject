using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject SoilGroupPrefab;
    [System.NonSerialized]
    public GameObject SoilGroup;

    [SerializeField]
    private GameObject SoilTemperaturePrefab;
    [System.NonSerialized]
    public GameObject SoilTemperature;

    [SerializeField]
    private GameObject SoilMaxPrefab;
    [System.NonSerialized]
    public GameObject SoilMax;

    [SerializeField]
    private RectTransform SoilPointPrefab;
    [System.NonSerialized]
    public RectTransform SoilPoint;

    private ModelModuleSpawner modelModuleSpawner;

    public void Start()
    {
        modelModuleSpawner = FindObjectOfType<ModelModuleSpawner>();
        StartCoroutine(UpdatePosition());
    }

    IEnumerator UpdatePosition()
    {
        while (true)
        {
            if (SoilPoint != null)
                SoilPoint.position = Camera.main.WorldToScreenPoint(modelModuleSpawner.mapModel.Video1.position);
            yield return null;
        }
    }

    public void CreateSoilGroup()
    {
        if (SoilGroup == null)
            SoilGroup = Instantiate(SoilGroupPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroySoilGroup()
    {
        if (SoilGroup != null)
            Destroy(SoilGroup);
    }

    public void CreateSoilTemperature()
    {
        if (SoilTemperature == null)
            SoilTemperature = Instantiate(SoilTemperaturePrefab, FindObjectOfType<Canvas>().transform);
    }

    public void DestroySoilTemperature()
    {
        if (SoilTemperature != null)
            Destroy(SoilTemperature);
    }

    //创建土壤数据大图
    public void CreateSoilMax()
    {
        if (SoilMax == null)
            SoilMax = Instantiate(SoilMaxPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroySoilMax()
    {
        if (SoilMax != null)
            Destroy(SoilMax);
    }

    //创建土壤数据点
    public void CreateSoilPoint()
    {
        if (SoilPoint == null)
            SoilPoint = Instantiate(SoilPointPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroySoilPoint()
    {
        if (SoilPoint != null)
            Destroy(SoilPoint.gameObject);
    }

    public void DestroyAll()
    {
        DestroySoilGroup();
        DestroySoilTemperature();
        DestroySoilMax();
        DestroySoilPoint();
    }
}
