using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRegCtrl : UIWindowBase
{
    /// <summary>
    /// �ǳ�
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
    /// ȥ��¼����
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
            m_LblTip.text = "�������ǳ�";
            return;
        }
        if (string.IsNullOrEmpty(pwd))
        {
            m_LblTip.text = "����������";
            return;
        }
        if (string.IsNullOrEmpty(pwd2))
        {
            m_LblTip.text = "������ȷ������";
            return;
        }

        if (pwd != pwd2)
        {
            m_LblTip.text = "����ȷ�����벻һ��";
            return;
        }

        PlayerPrefs.SetString(GlobalInit.MMO_NICKNAME, nickName);
        PlayerPrefs.SetString(GlobalInit.MMO_PWD, pwd);

        SceneMgr.Instance.LoadToCity();
    }
 
}
