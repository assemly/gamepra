using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景管理器
/// </summary>
public class SceneMgr : Singleton<SceneMgr>
{
    /// <summary>
    /// 当前场景类型
    /// </summary>
    public SceneType CurrentSceneType
    {
        get;
        private set;
    }
    /// <summary>
    /// 去登录场景
    /// </summary>
    public void LoadLogOn()
    {
        CurrentSceneType = SceneType.LogOn;
        SceneManager.LoadScene("Scene_LogOn");
    }
    /// <summary>
    /// 去城镇场景
    /// </summary>
    public void LoadToCity()
    {
        CurrentSceneType = SceneType.City;
        SceneManager.LoadScene("GameScene_Cunzhuang");
        
    }
}
