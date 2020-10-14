using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoModuleSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject VideoGroupPrefab;
    [System.NonSerialized]
    public GameObject VideoGroup;

    [SerializeField]
    public RectTransform VideoPointPrefab;
    [System.NonSerialized]
    public RectTransform VideoPoint;

    [SerializeField]
    public GameObject VoicePagePrefab;
    [System.NonSerialized]
    public GameObject VoicePage;

    [SerializeField]
    private GameObject FullScreenPagePrefab;
    [System.NonSerialized]
    public GameObject FullScreenPage;

    private ModelModuleSpawner modelModuleSpawner;

    public void Start()
    {
        modelModuleSpawner = FindObjectOfType<ModelModuleSpawner>();
        StartCoroutine(PositionUpdata());
    }

    IEnumerator PositionUpdata()
    {
        while (true)
        {
            if (VideoPoint != null)
                VideoPoint.position = Camera.main.WorldToScreenPoint(modelModuleSpawner.mapModel.Video1.position);
            yield return null;
        }
    }

    //创建UI组
    public void CreateVideoGroup()
    {
        if (VideoGroup == null)
            VideoGroup = Instantiate(VideoGroupPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyVideoGroup()
    {
        if (VideoGroup != null)
            Destroy(VideoGroup);
    }

    //创建摄像头点
    public void CreateVideoPoint()
    {
        if (VideoPoint == null)
            VideoPoint = Instantiate(VideoPointPrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyVideoPoint()
    {
        if (VideoPoint != null)
            Destroy(VideoPoint.gameObject);
    }

    //创建对讲界面
    public void CreateVoicePage()
    {
        if (VoicePage == null)
            VoicePage = Instantiate(VoicePagePrefab, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyVoicePage()
    {
        if (VoicePage != null)
            Destroy(VoicePage);
    }

    //创建全屏画面
    public void CreateFullScreenPage()
    {
        if (FullScreenPage == null)
            FullScreenPage = Instantiate(FullScreenPagePrefab, FindObjectOfType<Canvas>().transform);
    }

    public void DestroyFullScreenPage()
    {
        if (FullScreenPage != null)
            Destroy(FullScreenPage);
    }

    public void DestroyAll()
    {
        DestroyVideoGroup();
        DestroyVideoPoint();
        DestroyVoicePage();
        DestroyFullScreenPage();
    }
}
