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
    /// 下一个打开窗口
    /// </summary>
   

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
