using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControllerSpawner : MonoBehaviour
{
    [SerializeField]
    private RectTransform SensorPointPrefab;
    [System.NonSerialized]
    public RectTransform SensorPoint;

    [SerializeField]
    private RectTransform WaterLevelWarningPrefab;
    [System.NonSerialized]
    public RectTransform WaterLevelWarning;

    [SerializeField]
    private GameObject HistoryDataPrefab;
    [System.NonSerialized]
    public GameObject HistoryData;

    [SerializeField]
    private RectTransform GatePointPrefab;
    [System.NonSerialized]
    private RectTransform GatePoint;

    [SerializeField]
    private GateHightControllerGroup GateHightControllerGroupPrefab;
    [System.NonSerialized]
    public GateHightControllerGroup GateHightControllerGroup;

    private ModelModuleSpawner modelModuleSpawner;

    public void CreateSensorPoint()
    {
        if (SensorPoint == null)
        {
            SensorPoint = Instantiate(SensorPointPrefab, FindObjectOfType<Canvas>().transform);
            WaterLevelWarning = Instantiate(WaterLevelWarningPrefab, FindObjectOfType<Canvas>().transform);
            modelModuleSpawner = FindObjectOfType<ModelModuleSpawner>();
            CreateGatePoint();
            StartCoroutine(UpdataPosition());
        }
    }

    public void DestroySensorPoint()
    {
        if(SensorPoint!=null)
        Destroy(SensorPoint.gameObject);
        if(WaterLevelWarning!=null)
        Destroy(WaterLevelWarning.gameObject);
    }

    //历史曲线
    public void CreateHistoryData()
    {
        if (HistoryData == null)
            HistoryData = Instantiate(HistoryDataPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyHistoryData()
    {
        if(HistoryData!=null)
        Destroy(HistoryData.gameObject);
    }

    //闸门点
    public void CreateGatePoint()
    {
        if (GatePoint == null)
            GatePoint = Instantiate(GatePointPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyGatePoint()
    {
        if (GatePoint != null)
            Destroy(GatePoint.gameObject);
    }

    //闸门高度控制组
    public void CreateGateHightController()
    {
        if (GateHightControllerGroup == null)
            GateHightControllerGroup = Instantiate(GateHightControllerGroupPrefab, FindObjectOfType<Canvas>().transform);
    }

    public void DestroyGateHightController()
    {
        if (GateHightControllerGroup != null)
            Destroy(GateHightControllerGroup.gameObject);
    }

    IEnumerator UpdataPosition()
    {
        while (true)
        {
            if(SensorPoint!=null)
            SensorPoint.position = Camera.main.WorldToScreenPoint(modelModuleSpawner.mapModel.Sensor1.position);
            if(GatePoint!=null)
            GatePoint.position = Camera.main.WorldToScreenPoint(modelModuleSpawner.mapModel.Gate1.position);
            yield return null;
        }
    }

    public void DestroyAll()
    {
        DestroyHistoryData();
        DestroyGatePoint();
        DestroyGateHightController();
        DestroySensorPoint();
    }
}
