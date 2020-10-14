using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenFullScreenPage : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            if (FindObjectOfType<VideoModuleSpawner>().FullScreenPage == null)
                FindObjectOfType<VideoModuleSpawner>().CreateFullScreenPage();
            else
                FindObjectOfType<VideoModuleSpawner>().DestroyFullScreenPage();
        });
    }
}
