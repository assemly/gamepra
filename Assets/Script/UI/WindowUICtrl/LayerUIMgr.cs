using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// UI�㼶������
/// </summary>
public class LayerUIMgr :Singleton<LayerUIMgr>
{
    /// <summary>
    /// UIPanelDepth�㼶���
    /// </summary>
    private int m_UIPanelDepth = 50;

    /// <summary>
    /// ����
    /// </summary>
    public void Reset()
    {
        m_UIPanelDepth = 50;
    }

    /// <summary>
    /// ��鴰�����������û�д򿪴��� ����
    /// </summary>
    public void CheckOpenWindow()
    {
        if(WindowUIMgr.Instance.OpenWindowCount == 0)
        {
            Reset();
        }
    }
    /// <summary>
    /// ���ò㼶
    /// </summary>
    /// <param name="obj"></param>
    public void SetLayer(GameObject obj)
    {
        m_UIPanelDepth += 1;

        UIPanel[] panArr = obj.GetComponentsInChildren<UIPanel>();

        if (panArr.Length > 0)
        {
            for (int i = 0; i < panArr.Length; i++)
            {
                panArr[i].depth += m_UIPanelDepth;
            }
        }
    }
}
