using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectOverviewButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            FindObjectOfType<StructureCognitiveModuleSpawner>().CreateProjectOverview();
        });
    }
}
