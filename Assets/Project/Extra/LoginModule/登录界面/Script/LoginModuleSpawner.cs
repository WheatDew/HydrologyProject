using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject LoginPagePrefab;
    [System.NonSerialized]
    public GameObject LoginPage;
    private Canvas currentCanvas;

    private void Start()
    {
        //因为是查找场景中第一个canvas，所以务必保证场景里只有一个canvas
        currentCanvas = FindObjectOfType<Canvas>();
        DisplayLoginPage();
    }

    public void DisplayLoginPage()
    {
        LoginPage = Instantiate(LoginPagePrefab, currentCanvas.transform);
    }

    public void DestroyLoginPage()
    {
        Destroy(LoginPage.gameObject);
    }
}
