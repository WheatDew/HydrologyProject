using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{

    public void SetTarget(Transform target,Vector3 position)
    {
        transform.position = position;
        transform.LookAt(target);
    }
}
