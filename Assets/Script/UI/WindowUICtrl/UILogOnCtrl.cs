using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��¼����UI������
/// </summary>
public class UILogOnCtrl : UIWindowBase
{
    /// <summary>
    /// �ǳ�
    /// </summary>
    [SerializeField]
    private UIInput m_InputNickName;
    /// <summary>
    /// ����
    /// </summary>
    [SerializeField]
    private UIInput m_InputPWD;

    [SerializeField]
    private UILabel m_LblTip;
   

    #region OnBtnClick ��д����OnBtnClick
    /// <summary>
    /// ��д����OnBtnClick
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
    /// ��ע�ᴰ��
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
            m_LblTip.text = "�������ǳ�";
            return;
        }
        if (string.IsNullOrEmpty(pwd))
        {
            m_LblTip.text = "����������";
            return;
        }

        string oldNickName = PlayerPrefs.GetString(GlobalInit.MMO_NICKNAME);
        string oldPwd = PlayerPrefs.GetString(GlobalInit.MMO_PWD);

        if(oldNickName != nickName || oldPwd != pwd)
        {
            m_LblTip.text = "��������ǳƻ��������";
            return;
        }
        SceneMgr.Instance.LoadToCity();
    }

}
