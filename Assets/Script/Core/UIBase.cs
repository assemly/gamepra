using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有UI的基类
/// </summary>
public class UIBase : MonoBehaviour
{


    

    private void Awake()
    {
        

        OnAwake();
    }

    private void BtnClick(GameObject go)
    {
        OnBtnClick(go);
    }

    private void OnDestroy()
    {
        BeforeOnDestroy();
    }
    // Start is called before the first frame update
    void Start()
    {

        UIButton[] btnArr = GetComponentsInChildren<UIButton>(true);
        for (int i = 0; i < btnArr.Length; i++)
        {
            UIEventListener.Get(btnArr[i].gameObject).onClick = BtnClick;
        }
        OnStart();
    }

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void OnBtnClick(GameObject go) { }
    protected virtual void BeforeOnDestroy() { }
}
