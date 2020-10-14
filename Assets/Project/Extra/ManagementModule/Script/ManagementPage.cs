using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagementPage : MonoBehaviour
{
    public Button b1, b2, b3, b4;

    public GameObject g1, g2, g3, g4;

    public Sprite Normal, Pressed;

    private void Start()
    {
        b1.onClick.AddListener(SetG1);
        b2.onClick.AddListener(SetG2);
        b3.onClick.AddListener(SetG3);
        b4.onClick.AddListener(SetG4);

        //测试账号
        AddUser("1", "1");
    }

    public void ClearAll()
    {
        g1.SetActive(false);
        g2.SetActive(false);
        g3.SetActive(false);
        g4.SetActive(false);
    }
    public void SetAllNormal()
    {
        g1.GetComponent<Image>().sprite = Normal;
        g2.GetComponent<Image>().sprite = Normal;
        g3.GetComponent<Image>().sprite = Normal;
        g4.GetComponent<Image>().sprite = Normal;

    }

    public void SetG1()
    {
        ClearAll();
        SetAllNormal();
        g1.SetActive(true);
        g1.GetComponent<Image>().sprite = Pressed;

    }

    public void SetG2()
    {
        ClearAll();
        SetAllNormal();
        g2.GetComponent<Image>().sprite = Pressed;
        g2.SetActive(true);
    }

    public void SetG3()
    {
        ClearAll();
        SetAllNormal();
        g3.GetComponent<Image>().sprite = Pressed;
        g3.SetActive(true);
    }

    public void SetG4()
    {
        ClearAll();
        SetAllNormal();
        g4.GetComponent<Image>().sprite = Pressed;
        g4.SetActive(true);
    }

    //登录功能
    public void AddUser(string userName,string password)
    {
        if(!ManagementModuleSpawner.Account.ContainsKey(userName))
        ManagementModuleSpawner.Account.Add(userName, password);
        ManagementModuleSpawner.WriteAccount();
    }


}
