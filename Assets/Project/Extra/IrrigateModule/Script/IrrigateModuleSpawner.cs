using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IrrigateModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject IrrigateGroupPrefab;
    [System.NonSerialized]
    public GameObject IrrigateGroup;

    [SerializeField]
    private RectTransform IrrigatePointPrefab;
    [System.NonSerialized]
    public RectTransform IrrigatePoint;

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
            if (IrrigatePoint != null)
                IrrigatePoint.position = Camera.main.WorldToScreenPoint(modelModuleSpawner.mapModel.Gate1.position);
            yield return null;
        }
    }

    public void CreateIrrigateGroup()
    {
        if (IrrigateGroup == null)
            IrrigateGroup = Instantiate(IrrigateGroupPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyIrrigateGroup()
    {
        if (IrrigateGroup != null)
            Destroy(IrrigateGroup);
    }

    public void CreateIrrigatePoint()
    {
        if (IrrigatePoint == null)
            IrrigatePoint = Instantiate(IrrigatePointPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyIrrigatePoint()
    {
        if (IrrigatePoint != null)
            Destroy(IrrigatePoint.gameObject);
    }

    public void DestroyAll()
    {
        DestroyIrrigateGroup();
        DestroyIrrigatePoint();
        StopAllCoroutines();
    }
}
