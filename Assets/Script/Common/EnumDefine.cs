using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region WindowUIType ��������
public enum WindowUIType
{   
    /// <summary>
    /// δ����
    /// </summary>
    None,
    /// <summary>
    /// ��¼����
    /// </summary>
    LogOn,

    /// <summary>
    /// ע�ᴰ��
    /// </summary>
    Reg
}
#endregion

#region WindowUIContainerType UI��������
public enum WindowUIContainerType
{
    TopLeft, //����
    TopRight, //����
    BottomLeft, //
    BottomRight,
    Center
}
#endregion

#region WindowShowStyle ���ڵ�����ʽ
/// <summary>
/// ���ڵ�����ʽ
/// </summary>
public enum WindowShowStyle
{
    Normal,         //����
    CenterToBig,    //�м�Ŵ�
    FromTop,        //�Ӷ���
    FromDown,       //�ӵײ�
    FromLeft,       //����
    FromRight       //����
}
#endregion

