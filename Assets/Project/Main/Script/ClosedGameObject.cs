using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosedGameObject : MonoBehaviour
{
    public GameObject AssignObject;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            Destroy(AssignObject);
        });
    }
}
