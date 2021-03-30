using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有窗口UI的基类
/// </summary>
public class UIWindowBase : UIBase
{
    /// <summary>
    /// 挂点类型
    /// </summary>
    [SerializeField]
    public WindowUIContainerType containerType = WindowUIContainerType.Center;
    /// <summary>
    /// 打开方式
    /// </summary>
    [SerializeField]
    public WindowShowStyle showStyle = WindowShowStyle.Normal;
    /// <summary>
    /// 效果持续时间
    /// </summary>
    [SerializeField]
    public float duration=0.2f;

    /// <summary>
    /// 当前窗口类型
    /// </summary>
    [HideInInspector]
    public WindowUIType CurrentUIType;

    protected WindowUIType m_NextOpenWindow = WindowUIType.None;

    /// <summary>
    /// 关闭窗口
    /// </summary>
    protected virtual void Close()
    {
        WindowUIMgr.Instance.CloseWindow(CurrentUIType);
    }

    /// <summary>
    /// 销毁前转窗口
    /// </summary>
    protected override void BeforeOnDestroy()
    {
        LayerUIMgr.Instance.CheckOpenWindow();
        if (m_NextOpenWindow == WindowUIType.None) return;
        WindowUIMgr.Instance.OpenWindow(m_NextOpenWindow);
        //if(m_NextOpenWindow == WindowUIType.Reg)
        //{ 
        //    WindowUIMgr.Instance.OpenWindow(WindowUIType.Reg);
        //}
    }
}
