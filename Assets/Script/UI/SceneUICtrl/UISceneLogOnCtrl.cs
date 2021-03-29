using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneLogOnCtrl : UISceneBase
{
        
    protected override void OnStart()
    {
        base.OnStart();
        StartCoroutine(OpenLogOnWindow());
    }

    private IEnumerator OpenLogOnWindow()
    {
        yield return new WaitForSeconds(1);
        GameObject obj = WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
    }
    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.O))
    //    {
    //        GameObject obj = WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
    //    }
    //    else if (Input.GetKey(KeyCode.C))
    //    {
    //        WindowUIMgr.Instance.CloseWindow(WindowUIType.LogOn);
    //    }
    //}
}
