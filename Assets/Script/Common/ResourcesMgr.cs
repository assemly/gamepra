using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ResourcesMgr:Singleton<ResourcesMgr>
{

    #region ResourceType 资源类型
    public enum ResourceType
    {
       
        /// <summary>
        /// 场景UI
        /// </summary>
        UIScene,
        /// <summary>
        /// 窗口
        /// </summary>
        UIWindow,
        /// <summary>
        /// 角色
        /// </summary>
        Role,
        /// <summary>
        /// 特效
        /// </summary>
        Effect
        
    }
    #endregion
    /// <summary>
    /// 预设的列表
    /// </summary>
    private Hashtable m_PrefabTable;
    public ResourcesMgr()
    {
        m_PrefabTable = new Hashtable();
    }
    #region  Load资源
    /// <summary>
    /// 加载资源
    /// </summary>
    /// <param name="type">资源类型</param>
    /// <param name="path">短路径</param>
    /// <param name="cache">是否放入缓存</param>
    /// <returns>返回预设克隆体</returns>
    public GameObject Load(ResourceType type,string path,bool cache=false)
    {
        
        GameObject obj = null;
        if (m_PrefabTable.Contains(path))
        {
            Debug.Log("缓存资源加载");
            obj = m_PrefabTable[path] as GameObject;
        }
        else
        {
            StringBuilder sbr = new StringBuilder();

            switch (type)
            {
                case ResourceType.UIScene:
                    sbr.Append("UIPrefab/UIScene/");
                    break;
                case ResourceType.UIWindow:
                    sbr.Append("UIPrefab/UIWindows/");
                    break;
                case ResourceType.Role:
                    sbr.Append("RolePrefab/");
                    break;
                case ResourceType.Effect:
                    sbr.Append("EffectPrefab/");
                    break;

            }
            sbr.Append(path);
            obj = Resources.Load(sbr.ToString()) as GameObject;
            if(cache)
            {
                m_PrefabTable.Add(path, obj);
               // m_PrefabTable[path] = obj;
            }
        }
            
        return GameObject.Instantiate(obj);

    }
    #endregion

    #region Dispose释放资源
    /// <summary>
    /// 释放资源
    /// </summary>
    public override void Dispose()
    {
        base.Dispose();
        m_PrefabTable.Clear();
        //把未使用资源释放
        Resources.UnloadUnusedAssets();
    }
    #endregion
}
