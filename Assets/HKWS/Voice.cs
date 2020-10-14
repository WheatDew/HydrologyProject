using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PreviewDemo;
using System;
using System.Runtime.InteropServices;
using System.IO;

public class Voice : MonoBehaviour
{
    private int lVoiceComHandle = -1;
    private Int32 m_lUserID = -1;
    private uint iLastErr = 0;
    private string str;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Login();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            //开始语音对讲 Start two-way talk
            CHCNetSDK.VOICEDATACALLBACKV30 VoiceData = new CHCNetSDK.VOICEDATACALLBACKV30(VoiceDataCallBack);//预览实时流回调函数

            lVoiceComHandle = CHCNetSDK.NET_DVR_StartVoiceCom_V30(m_lUserID, 1, true, VoiceData, IntPtr.Zero);
            //bNeedCBNoEncData [in]需要回调的语音数据类型：0- 编码后的语音数据，1- 编码前的PCM原始数据

            if (lVoiceComHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_StartVoiceCom_V30 failed, error code= " + iLastErr;
                Debug.Log(str);
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //停止语音对讲 Stop two-way talk
            if (!CHCNetSDK.NET_DVR_StopVoiceCom(lVoiceComHandle))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_StopVoiceCom failed, error code= " + iLastErr;
                Debug.Log(str);
                return;
            }
        }
    }

    public void VoiceDataCallBack(int lVoiceComHandle, IntPtr pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, System.IntPtr pUser)
    {
        byte[] sString = new byte[dwBufSize];
        Marshal.Copy(pRecvDataBuffer, sString, 0, (Int32)dwBufSize);

        if (byAudioFlag == 0)
        {
            //将缓冲区里的音频数据写入文件 save the data into a file
            string str = "PC采集音频文件.pcm";
            FileStream fs = new FileStream(str, FileMode.Create);
            int iLen = (int)dwBufSize;
            fs.Write(sString, 0, iLen);
            fs.Close();
        }
        if (byAudioFlag == 1)
        {
            //将缓冲区里的音频数据写入文件 save the data into a file
            string str = "设备音频文件.pcm";
            FileStream fs = new FileStream(str, FileMode.Create);
            int iLen = (int)dwBufSize;
            fs.Write(sString, 0, iLen);
            fs.Close();
        }

    }

    public CHCNetSDK.NET_DVR_USER_LOGIN_INFO struLogInfo;
    CHCNetSDK.LOGINRESULTCALLBACK LoginCallBack = null;
    public CHCNetSDK.NET_DVR_DEVICEINFO_V40 DeviceInfo;

    private void Login()
    {
        CHCNetSDK.NET_DVR_Init();
        if (m_lUserID < 0)
        {

            struLogInfo = new CHCNetSDK.NET_DVR_USER_LOGIN_INFO();

            //设备IP地址或者域名
            byte[] byIP = System.Text.Encoding.Default.GetBytes("192.168.1.64");
            struLogInfo.sDeviceAddress = new byte[129];
            byIP.CopyTo(struLogInfo.sDeviceAddress, 0);

            //设备用户名
            byte[] byUserName = System.Text.Encoding.Default.GetBytes("admin");
            struLogInfo.sUserName = new byte[64];
            byUserName.CopyTo(struLogInfo.sUserName, 0);

            //设备密码
            byte[] byPassword = System.Text.Encoding.Default.GetBytes("daqing123");
            struLogInfo.sPassword = new byte[64];
            byPassword.CopyTo(struLogInfo.sPassword, 0);

            struLogInfo.wPort = ushort.Parse("8000");//设备服务端口号

            if (LoginCallBack == null)
            {
                //LoginCallBack = new CHCNetSDK.LOGINRESULTCALLBACK(cbLoginCallBack);//注册回调函数                    
            }
            struLogInfo.cbLoginResult = LoginCallBack;
            struLogInfo.bUseAsynLogin = false; //是否异步登录：0- 否，1- 是 

            DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V40();

            //登录设备 Login the device
            m_lUserID = CHCNetSDK.NET_DVR_Login_V40(ref struLogInfo, ref DeviceInfo);
            if (m_lUserID < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_Login_V40 failed, error code= " + iLastErr; //登录失败，输出错误号
                Debug.Log(str);
                return;
            }
            else
            {
                //登录成功
                Debug.Log("Login Success!");
            }

        }
        //else
        //{
        //    //注销登录 Logout the device
        //    if (m_lRealHandle >= 0)
        //    {
        //        MessageBox.Show("Please stop live view firstly");
        //        return;
        //    }

        //    if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
        //    {
        //        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
        //        str = "NET_DVR_Logout failed, error code= " + iLastErr;
        //        MessageBox.Show(str);
        //        return;
        //    }
        //    m_lUserID = -1;
        //    btnLogin.Text = "Login";
        //}
        return;
    }

}
