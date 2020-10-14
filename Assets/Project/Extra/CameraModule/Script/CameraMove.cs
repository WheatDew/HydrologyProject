using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject mainCamera;
    public bool isRunning=true;

    private void Start()
    {
        mainCamera = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (isRunning)
        {
            if (Input.GetMouseButton(2))
            {
                if(mainCamera.transform.position.y>1.2f)
                gameObject.transform.Translate(Vector3.down * Input.GetAxis("Mouse Y") * 0.2f, Space.Self);
                gameObject.transform.Translate(Vector3.left * Input.GetAxis("Mouse X") * 0.2f, Space.Self);
            }
            else if (Input.GetMouseButton(1))
            {
                gameObject.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"), Space.Self);
                gameObject.transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y"), Space.Self);
                gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 0);
            }

            if(!(mainCamera.transform.position.y<1.2f&&Input.GetAxis("Mouse ScrollWheel")>0))
            mainCamera.transform.localPosition += Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * 20f;
        }
    }
}
