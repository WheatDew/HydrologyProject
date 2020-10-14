using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    public InputField userName,passWord;
    private Button m_button;

    void Start()
    {
        ManagementModuleSpawner.Account.Add("1", "1");
        m_button = GetComponent<Button>();
        m_button.onClick.AddListener(OpenMainPage);
    }

    public void OpenMainPage()
    {
        if (ManagementModuleSpawner.Account.ContainsKey(userName.text)&&ManagementModuleSpawner.Account[userName.text]==passWord.text)
        {
            FindObjectOfType<MainPageModuleSpawner>().DisplayMainPage();
            FindObjectOfType<ModelModuleSpawner>().DisplayModel();
            FindObjectOfType<LoginModuleSpawner>().DestroyLoginPage();
        }
    }
}
