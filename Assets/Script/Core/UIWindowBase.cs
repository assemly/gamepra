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
}
