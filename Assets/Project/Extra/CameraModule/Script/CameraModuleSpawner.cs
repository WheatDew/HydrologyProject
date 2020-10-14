using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject AssignCameraPrefab;
    private GameObject CameraGroup;

    private void Start()
    {
        CreateCamera();
    }

    public void CreateCamera()
    {
        CameraGroup = Instantiate(AssignCameraPrefab);
    }

    public void DestroyCamera()
    {
        Destroy(CameraGroup.gameObject);
    }
}
