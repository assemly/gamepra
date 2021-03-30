using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���д���UI�Ļ���
/// </summary>
public class UIWindowBase : UIBase
{
    /// <summary>
    /// �ҵ�����
    /// </summary>
    [SerializeField]
    public WindowUIContainerType containerType = WindowUIContainerType.Center;
    /// <summary>
    /// �򿪷�ʽ
    /// </summary>
    [SerializeField]
    public WindowShowStyle showStyle = WindowShowStyle.Normal;
    /// <summary>
    /// Ч������ʱ��
    /// </summary>
    [SerializeField]
    public float duration=0.2f;

    /// <summary>
    /// ��ǰ��������
    /// </summary>
    [HideInInspector]
    public WindowUIType CurrentUIType;

    protected WindowUIType m_NextOpenWindow = WindowUIType.None;

    /// <summary>
    /// �رմ���
    /// </summary>
    protected virtual void Close()
    {
        WindowUIMgr.Instance.CloseWindow(CurrentUIType);
    }

    /// <summary>
    /// ����ǰת����
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
