using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ����������
/// </summary>
public class SceneMgr : Singleton<SceneMgr>
{
    /// <summary>
    /// ��ǰ��������
    /// </summary>
    public SceneType CurrentSceneType
    {
        get;
        private set;
    }
    /// <summary>
    /// ȥ��¼����
    /// </summary>
    public void LoadLogOn()
    {
        CurrentSceneType = SceneType.LogOn;
        SceneManager.LoadScene("Scene_LogOn");
    }
    /// <summary>
    /// ȥ���򳡾�
    /// </summary>
    public void LoadToCity()
    {
        CurrentSceneType = SceneType.City;
        SceneManager.LoadScene("GameScene_Cunzhuang");
        
    }
}
