using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 登录窗口UI控制器
/// </summary>
public class UILogOnCtrl : UIWindowBase
{
    /// <summary>
    /// 昵称
    /// </summary>
    [SerializeField]
    private UIInput m_InputNickName;
    /// <summary>
    /// 密码
    /// </summary>
    [SerializeField]
    private UIInput m_InputPWD;

    [SerializeField]
    private UILabel m_LblTip;
   

    #region OnBtnClick 重写基类OnBtnClick
    /// <summary>
    /// 重写基类OnBtnClick
    /// </summary>
    /// <param name="go"></param>
    protected override void OnBtnClick(GameObject go)
    {
        //Debug.Log("go=" + go.name);
        switch (go.name)
        {
            case "btnLogOn":
                LogOn();
                break;
            case "btnToReg":
                BtnToReg();
                break;
        }
    }
    #endregion
  
    /// <summary>
    /// 打开注册窗口
    /// </summary>
    void BtnToReg()
    {
        //Destroy(gameObject);

        //GameObject obj = WindowUIMgr.Instance.OpenWindow(WindowUIType.Reg);
        //WindowUIMgr.Instance.OpenWindow(WindowUIType.Reg);
        this.Close();
        m_NextOpenWindow = WindowUIType.Reg;


    }
    // Start is called before the first frame update

    void LogOn()
    {
        string nickName = m_InputNickName.value.Trim();
        string pwd = m_InputPWD.value.Trim();

        if (string.IsNullOrEmpty(nickName))
        {
            m_LblTip.text = "请输入昵称";
            return;
        }
        if (string.IsNullOrEmpty(pwd))
        {
            m_LblTip.text = "请输入密码";
            return;
        }

        string oldNickName = PlayerPrefs.GetString(GlobalInit.MMO_NICKNAME);
        string oldPwd = PlayerPrefs.GetString(GlobalInit.MMO_PWD);

        if(oldNickName != nickName || oldPwd != pwd)
        {
            m_LblTip.text = "您输入的昵称或密码错误";
            return;
        }
        SceneMgr.Instance.LoadToCity();
    }

}
