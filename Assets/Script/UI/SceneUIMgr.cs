using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 场景UI管理器
/// </summary>
public class SceneUIMgr :Singleton<SceneUIMgr>
{
    /// <summary>
    /// 场景UI类型
    /// </summary>
   public enum SceneUIType
    {   /// <summary>
        /// 登录
        /// </summary>
        LogOn,
        /// <summary>
        /// 加载
        /// </summary>
        Loading,
        /// <summary>
        /// 主城
        /// </summary>
        MainCity
    }
    /// <summary>
    /// 当前场景UI
    /// </summary>
    public UISceneBase CurrentUIScene;
    #region LoadSceneUI 加载场景UI
    /// <summary>
    /// 加载场景UI
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject LoadSceneUI(SceneUIType type,bool cache=false)
    {
        GameObject obj = null;
        switch (type)
        {
            case SceneUIType.LogOn:
                obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene,"UI Root_LogOnScene",cache);
                CurrentUIScene = obj.GetComponent<UISceneLogOnCtrl>();
                break;
            case SceneUIType.Loading:
                break;
            case SceneUIType.MainCity:
                break;
        }
        return obj;
    }
    #endregion
}
