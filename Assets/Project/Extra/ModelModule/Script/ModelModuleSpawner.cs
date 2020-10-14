using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private MapModel ModelPrefab;
    [System.NonSerialized]
    public MapModel mapModel;

    public void DisplayModel()
    {
        mapModel = Instantiate(ModelPrefab);
    }
}
