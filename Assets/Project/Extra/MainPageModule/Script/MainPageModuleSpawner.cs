using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageModuleSpawner : MonoBehaviour
{
    public GameObject Background,MainPageGroup,SystemGroup,
        ProjectGroup_StructureCognitive,ProjectGroup_GateController,ProjectGroup_Soil;

    private GameObject projectGroup;

    private Transform canvas;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>().transform;
    }

    public void DisplayMainPage()
    {
        GameObject background = Instantiate(Background, canvas);
        GameObject mainPageGroup = Instantiate(MainPageGroup, canvas);
        GameObject systemGroup = Instantiate(SystemGroup, canvas);
        projectGroup = Instantiate(ProjectGroup_StructureCognitive, canvas);
    }

    public void SetStructureCognitiveGroup()
    {
        if (projectGroup != null)
        {
            Destroy(projectGroup);
            projectGroup = Instantiate(ProjectGroup_StructureCognitive, canvas);
        }
    }

    public void SetGateControllerGroup()
    {
        if (projectGroup != null)
        {
            Destroy(projectGroup);
            projectGroup = Instantiate(ProjectGroup_GateController, canvas);
        }
    }

    public void SetVideoGroup()
    {
        if (projectGroup != null)
        {
            Destroy(projectGroup);
        }
    }

    public void SetSoilGroup()
    {
        if (projectGroup != null)
        {
            Destroy(projectGroup);
            projectGroup = Instantiate(ProjectGroup_Soil, canvas);
        }
    }
}
