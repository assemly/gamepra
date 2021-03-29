using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtil
{
    /// <summary>
    /// ��ȡ�򴴽����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T GetOrCreateComponet<T>(this GameObject obj) where T:MonoBehaviour
    {
        T t = obj.GetComponent<T>();
        if (t==null)
        {
            t = obj.AddComponent<T>();
        }
        return t;
       }
}
