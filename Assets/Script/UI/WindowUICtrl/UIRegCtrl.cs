using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRegCtrl : UIWindowBase
{
    /// <summary>
    /// 昵称
    /// </summary>
    [SerializeField]
    private UIInput m_InputNickName;
    [SerializeField]
    private UIInput m_InputPwd;
    [SerializeField]
    private UIInput m_InputPwd2;
    [SerializeField]
    private UILabel m_LblTip;
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.name)
        {
            case "btnToLogOn":
                BtnToLogOn();
                break;
            case "btnReg":
                Reg();
                break;
        }
    }

    /// <summary>
    /// 去登录窗口
    /// </summary>
    private void BtnToLogOn()
    {
        this.Close();
        m_NextOpenWindow = WindowUIType.LogOn;
        //WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
    }

    private void Reg()
    {
        string nickName = m_InputNickName.value.Trim();
        string pwd = m_InputPwd.value.Trim();
        string pwd2 = m_InputPwd2.value.Trim();

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
        if (string.IsNullOrEmpty(pwd2))
        {
            m_LblTip.text = "请输入确认密码";
            return;
        }

        if (pwd != pwd2)
        {
            m_LblTip.text = "输入确认密码不一致";
            return;
        }

        PlayerPrefs.SetString(GlobalInit.MMO_NICKNAME, nickName);
        PlayerPrefs.SetString(GlobalInit.MMO_PWD, pwd);

        SceneMgr.Instance.LoadToCity();
    }
 
}
