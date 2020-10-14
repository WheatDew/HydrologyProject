using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterQualityModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject WaterQualityGroupPrefab;
    [System.NonSerialized]
    public GameObject WaterQualityGroup;

    [SerializeField]
    private RectTransform WaterQualityPointPrefab;
    [System.NonSerialized]
    public RectTransform WaterQualityPoint;

    private ModelModuleSpawner modelModuleSpawner;

    private void Start()
    {
        modelModuleSpawner = FindObjectOfType<ModelModuleSpawner>();
        StartCoroutine(UpdatePosition());
    }

    IEnumerator UpdatePosition()
    {
        while (true)
        {
            if (WaterQualityPoint != null)
                WaterQualityPoint.position = Camera.main.WorldToScreenPoint(modelModuleSpawner.mapModel.Gate1.position);
            yield return null;
        }
    }

    public void CreateWaterQualityGroup()
    {
        if (WaterQualityGroup == null)
            WaterQualityGroup = Instantiate(WaterQualityGroupPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyWaterQualityGroup()
    {
        if (WaterQualityGroup != null)
            Destroy(WaterQualityGroup);
    } 

    public void CreateWaterQualityPoint()
    {
        if (WaterQualityPoint == null)
            WaterQualityPoint = Instantiate(WaterQualityPointPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyWaterQualityPoint()
    {
        if (WaterQualityPoint != null)
            Destroy(WaterQualityPoint.gameObject);
    }

    public void DestroyAll()
    {
        DestroyWaterQualityGroup();
        DestroyWaterQualityPoint();
    }
}
