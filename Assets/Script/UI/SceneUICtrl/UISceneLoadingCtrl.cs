using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Loading场景UI控制器
/// </summary>
public class UISceneLoadingCtrl : UISceneBase
{
    [SerializeField]
    private UIProgressBar m_Progress;

    [SerializeField]
    private UILabel m_lblProcess;

    [SerializeField]
    private UISprite m_SprProcessLight;

    /// <summary>
    /// 设置进度条值
    /// </summary>
    /// <param name="value"></param>
    public void SetProgressValue(float value)
    {
        m_SprProcessLight.transform.localPosition = new Vector3(1000f * value, 0, 0);
        m_Progress.value = value;
        m_lblProcess.text = string.Format("{0}%", (int)(value * 100));
        
    }
}
