using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����UI������
/// </summary>
public class WindowUIMgr : Singleton<WindowUIMgr>
{
    //�ֵ�洢
    private Dictionary<WindowUIType, UIWindowBase> m_DicWindow = new Dictionary<WindowUIType, UIWindowBase>();

    //�Ѵ򿪴��ڵ�����
    public int OpenWindowCount
    {
        get
        {
            return m_DicWindow.Count;
        }
    }

    #region OpenWindow �򿪴���
    /// <summary>
    /// ���ش���
    /// </summary>
    /// <param name="type">��������</param>
    /// <returns></returns>  //, WindowUIContainerType containerType = WindowUIContainerType.Center, WindowShowStyle showStyle = WindowShowStyle.Normal, bool cache = true
    public GameObject OpenWindow(WindowUIType type)
    {
        if (type == WindowUIType.None) return null;
        GameObject obj = null;

        //������ڲ����� ��
        if (!m_DicWindow.ContainsKey(type))
        {
            //�������Ա��ⴰ�ڹ���switch̫�� ö�ٵ����ƺ�Ԥ���Ӧ
            obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, string.Format("pan{0}", type.ToString()), cache: true);
            if (obj == null) return null;

            UIWindowBase windowBase = obj.GetComponent<UIWindowBase>();
            if (windowBase == null) return null;

            m_DicWindow.Add(type, windowBase);

            windowBase.CurrentUIType = type;
            //switch (type)
            //{
            //    case WindowUIType.LogOn:
            //        obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, "panLogOn", cache);
            //        break;
            //    case WindowUIType.Reg:
            //        obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, "panReg", cache);
            //        break;

            //}
            Transform transParent = null;
            switch (windowBase.containerType)
            {
                case WindowUIContainerType.Center:
                    transParent = SceneUIMgr.Instance.CurrentUIScene.Container_Center;
                    break;
            }
            obj.transform.parent = transParent;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            NGUITools.SetActive(obj, false);
            StartShowWindow(windowBase, true);
        }
        else
        {
            obj = m_DicWindow[type].gameObject;
        }
       
          

        

        //�㼶����
        LayerUIMgr.Instance.SetLayer(obj);

        
        
        return obj;
    }
    #endregion

    #region  CloseWindow �رմ���
    /// <summary>
    /// �رմ���
    /// </summary>
    /// <param name="type"></param>
    public void CloseWindow(WindowUIType type)
    {
        if (m_DicWindow.ContainsKey(type))
        {
            StartShowWindow(m_DicWindow[type], false);
        }
    }
    #endregion

    #region  StartShowWindow �Ƿ�򿪴���
    /// <summary>
    /// ��ʼ�򿪴���
    /// </summary>
    /// <param name="windowBase"></param>
    /// <param name="isOpen"></param>
    private void StartShowWindow(UIWindowBase windowBase, bool isOpen)
    {
        switch (windowBase.showStyle)
        {
            case WindowShowStyle.Normal:
                ShowNormal(windowBase, isOpen);
                break;
            case WindowShowStyle.CenterToBig:
                ShowCenterToBig(windowBase, isOpen);
                break;
            case WindowShowStyle.FromTop:
                ShowFromDir(windowBase,0,isOpen);
                break;
            case WindowShowStyle.FromDown:
                ShowFromDir(windowBase, 1, isOpen);
                break;
            case WindowShowStyle.FromLeft:
                ShowFromDir(windowBase, 2, isOpen);
                break;
            case WindowShowStyle.FromRight:
                ShowFromDir(windowBase, 3, isOpen);
                break;
        }
    }
    #endregion

    #region ���ִ�Ч��

    private void ShowNormal(UIWindowBase windowBase , bool isOpen)
    {
        if (isOpen)
        {
            NGUITools.SetActive(windowBase.gameObject, true);
        }
        else
        {
            DestoryWindow(windowBase);
        }
    }

    /// <summary>
    /// �м���
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="isOpen"></param>
    private void ShowCenterToBig(UIWindowBase windowBase, bool isOpen)
    {
        TweenScale ts = windowBase.gameObject.GetOrCreateComponet<TweenScale>();
        ts.animationCurve = GlobalInit.Instance.UIAnimationCurve;
        ts.from = Vector3.zero;
        ts.to = Vector3.one;
        ts.duration = windowBase.duration;
        ts.SetOnFinished(() =>
        {
            if (!isOpen)
                DestoryWindow(windowBase);
        });
        NGUITools.SetActive(windowBase.gameObject, true);
        if (!isOpen) ts.Play(isOpen);
    }
    /// <summary>
    /// �Ӳ�ͬ�������
    /// </summary>
    /// <param name="windowBase"></param>
    /// <param name="dirType">0=���� 1=���� 2=���� 3=����</param>
    /// <param name="isOpen"></param>
    private void ShowFromDir(UIWindowBase windowBase,int dirType, bool isOpen)
    {
        TweenPosition tp = windowBase.gameObject.GetOrCreateComponet<TweenPosition>();
        tp.animationCurve = GlobalInit.Instance.UIAnimationCurve;

        Vector3 from = Vector3.zero;
        switch (dirType)
        {
            case 0:
                from = new Vector3(0, 1000, 0);
                break;
            case 1:
                from = new Vector3(0, -1000, 0);
                break;
            case 2:
                from = new Vector3(-1400, 0, 0);
                break;
            case 3:
                from = new Vector3(1400, 0, 0);
                break;
        }
        tp.from = from;

        tp.to = Vector3.one;
        tp.duration = windowBase.duration;
        tp.SetOnFinished(() =>
        {
            if (!isOpen)
                DestoryWindow(windowBase);
        });
        NGUITools.SetActive(windowBase.gameObject, true);
        if (!isOpen) tp.Play(isOpen);
    }
    #endregion

    /// <summary>
    /// ���ٴ���
    /// </summary>
    /// <param name="obj"></param>
    /// 
    private void DestoryWindow(UIWindowBase windowBase)
    {
        m_DicWindow.Remove(windowBase.CurrentUIType);
        Object.Destroy(windowBase.gameObject);
        
    }
}