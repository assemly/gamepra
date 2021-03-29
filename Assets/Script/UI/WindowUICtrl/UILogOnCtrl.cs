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
    /// ��һ���򿪴���
    /// </summary>
   

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
        WindowUIMgr.Instance.CloseWindow(WindowUIType.LogOn);
        m_NextOpenWindow = WindowUIType.Reg;
        
        
    }
    // Start is called before the first frame update

    protected override void BeforeOnDestroy()
    {
        if(m_NextOpenWindow == WindowUIType.Reg)
        { 
            WindowUIMgr.Instance.OpenWindow(WindowUIType.Reg);
        }
    }

}
