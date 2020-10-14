using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureCognitiveModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private RectTransform CognitiveElementPrefab;
    [System.NonSerialized]
    public RectTransform CognitiveElement;

    [SerializeField]
    private RectTransform CognitivePointPrefab;
    [System.NonSerialized]
    public RectTransform CognitivePoint;

    [SerializeField]
    private GameObject ProjectOverviewPrefab;
    [System.NonSerialized]
    public GameObject ProjectOverview;

    [SerializeField]
    private StructureCognitiveDetail StructureCognitiveDetailPrefab;
    [System.NonSerialized]
    public StructureCognitiveDetail StructureCognitiveDetail;

    private ModelModuleSpawner modelModuleSpawner;

    private void Start()
    {
        modelModuleSpawner = FindObjectOfType<ModelModuleSpawner>();
        StartCoroutine(UpdataPosition());
    }

    IEnumerator UpdataPosition()
    {
        while (true)
        {
            if (CognitiveElement != null && modelModuleSpawner != null)
            {
                CognitiveElement.position = Camera.main.WorldToScreenPoint(modelModuleSpawner.mapModel.Reservoir.position);

                if (CognitivePoint!=null)
                {
                    CognitivePoint.position = Camera.main.WorldToScreenPoint(modelModuleSpawner.mapModel.Spillway.position);
                }
            }
            yield return null;
        }
    }

    //创建结构认知元素
    public void CreateCognitiveElement()
    {
        if (CognitiveElement == null&& modelModuleSpawner != null)
        {
            CognitiveElement = Instantiate(CognitiveElementPrefab, FindObjectOfType<Canvas>().transform);
            FindObjectOfType<CameraMove>().transform.position = modelModuleSpawner.mapModel.ReservoirCamera.position;
            FindObjectOfType<CameraMove>().transform.rotation = modelModuleSpawner.mapModel.ReservoirCamera.rotation;
            Camera.main.transform.localPosition = Vector3.zero;
            FindObjectOfType<CameraMove>().isRunning = false;
        }
    }
    public void DestroyCognitiveElement()
    {
        if (CognitiveElement != null)
            Destroy(CognitiveElement.gameObject);
    }

    //创建项目概况
    public void CreateProjectOverview()
    {
        if (ProjectOverview == null)
            ProjectOverview = Instantiate(ProjectOverviewPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyProjectOverview()
    {
        if (ProjectOverview != null)
            Destroy(ProjectOverview.gameObject);
    }

    //创建结构认知信息
    public void CreateStructureCognitiveDetail()
    {
        if (StructureCognitiveDetail==null)
        {
            StructureCognitiveDetail = Instantiate(StructureCognitiveDetailPrefab,FindObjectOfType<Canvas>().transform);
        }
    }
    public void DestroyStructureCognitiveDetail()
    {
        if (StructureCognitiveDetail != null)
        {
            Destroy(StructureCognitiveDetail.gameObject);
        }
    }

    //创建结构认知点
    public void CreateCognitivePoint()
    {
        if (CognitivePoint == null)
        {
            CognitivePoint = Instantiate(CognitivePointPrefab, FindObjectOfType<Canvas>().transform);
        }
    }
    public void DestroyCognitivePoint()
    {
        if (CognitivePoint != null)
            Destroy(CognitivePoint.gameObject);
    }

    public void DestroyAll()
    {
        DestroyCognitiveElement();
        DestroyProjectOverview();
        DestroyStructureCognitiveDetail();
        DestroyCognitivePoint();
    }
}
