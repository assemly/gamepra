using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRegCtrl : UIWindowBase
{
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.name)
        {
            case "btnToLogOn":
                BtnToLogOn();
                break;
            case "":
                break;
        }
    }

    private void BtnToLogOn()
    {
        WindowUIMgr.Instance.CloseWindow(WindowUIType.Reg);
        m_NextOpenWindow = WindowUIType.LogOn;
    }

    protected override void BeforeOnDestroy()
    {
        if(m_NextOpenWindow == WindowUIType.LogOn)
        {
            WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
        }
    }
}
