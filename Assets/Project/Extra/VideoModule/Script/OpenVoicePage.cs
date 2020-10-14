using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenVoicePage : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            if (FindObjectOfType<VideoModuleSpawner>().VoicePage == null)
                FindObjectOfType<VideoModuleSpawner>().CreateVoicePage();
            else
                FindObjectOfType<VideoModuleSpawner>().DestroyVoicePage();
        });
    }
}
