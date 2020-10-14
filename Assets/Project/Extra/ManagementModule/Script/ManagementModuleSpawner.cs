using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ManagementModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ManagementGroupPrefab;
    [System.NonSerialized]
    public GameObject ManagementGroup;

    public static Dictionary<string, string> Account = new Dictionary<string, string>();

    public void CreateManagementGroup()
    {
        if (ManagementGroup == null)
            ManagementGroup = Instantiate(ManagementGroupPrefab, FindObjectOfType<Canvas>().transform);
    }

    public void DestroyManagementGroup()
    {
        if (ManagementGroup != null)
            Destroy(ManagementGroup);
    }

    public void DestroyAll()
    {
        DestroyManagementGroup();
    }

    public static void WriteAccount()
    {
        string text = "";
        foreach(var item in Account)
        {
            text += item.Key + " " + item.Value + "\n";
        }
        System.IO.File.WriteAllText(Application.streamingAssetsPath + "Account.txt",text,Encoding.UTF8);
    }
}
