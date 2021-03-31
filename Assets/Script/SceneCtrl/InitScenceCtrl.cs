using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScenceCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLogOn());
    }

   private IEnumerator LoadLogOn()
    {
        yield return new WaitForSeconds(2f);
        SceneMgr.Instance.LoadLogOn();
    }
}
