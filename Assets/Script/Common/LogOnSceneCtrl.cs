using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnSceneCtrl : MonoBehaviour
{
    GameObject obj;
    private void Awake()
    {
        //GameObject obj = Resources.Load("UIPrefab/UIScene/UI Root_LogOnScene") as GameObject;
        // obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene,"UI Root_LogOnScene",cache:true);
        obj=SceneUIMgr.Instance.LoadSceneUI(SceneUIMgr.SceneUIType.LogOn);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    Destroy(obj);
        //}
        //else if(Input.GetKeyUp(KeyCode.L))
        //{
        //    obj = SceneUIMgr.Instance.LoadSceneUI(SceneUIMgr.SceneUIType.LogOn,cache: true);
        //}
    }
}
