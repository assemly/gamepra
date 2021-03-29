using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ResourcesMgr:Singleton<ResourcesMgr>
{

    #region ResourceType ��Դ����
    public enum ResourceType
    {
       
        /// <summary>
        /// ����UI
        /// </summary>
        UIScene,
        /// <summary>
        /// ����
        /// </summary>
        UIWindow,
        /// <summary>
        /// ��ɫ
        /// </summary>
        Role,
        /// <summary>
        /// ��Ч
        /// </summary>
        Effect
        
    }
    #endregion
    /// <summary>
    /// Ԥ����б�
    /// </summary>
    private Hashtable m_PrefabTable;
    public ResourcesMgr()
    {
        m_PrefabTable = new Hashtable();
    }
    #region  Load��Դ
    /// <summary>
    /// ������Դ
    /// </summary>
    /// <param name="type">��Դ����</param>
    /// <param name="path">��·��</param>
    /// <param name="cache">�Ƿ���뻺��</param>
    /// <returns>����Ԥ���¡��</returns>
    public GameObject Load(ResourceType type,string path,bool cache=false)
    {
        
        GameObject obj = null;
        if (m_PrefabTable.Contains(path))
        {
            Debug.Log("������Դ����");
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

    #region Dispose�ͷ���Դ
    /// <summary>
    /// �ͷ���Դ
    /// </summary>
    public override void Dispose()
    {
        base.Dispose();
        m_PrefabTable.Clear();
        //��δʹ����Դ�ͷ�
        Resources.UnloadUnusedAssets();
    }
    #endregion
}
