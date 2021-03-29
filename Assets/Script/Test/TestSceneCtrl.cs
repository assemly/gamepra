using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneCtrl : MonoBehaviour
{
    public static TestSceneCtrl Instance;
    // Start is called before the first frame update
    //创建箱子的区域
    [SerializeField]
    private Transform transCreateBox;

    //箱子的父物体
    [SerializeField]
    private Transform boxParent;

    private GameObject m_BoxPrefab;

    private int m_CurrCount = 0;
    private int m_MaxCount = 10;
    private float m_NextCloneTime = 0f;

    private string m_BoxKey = "BoxKey";
    private int m_PrevCount;

    
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        m_BoxPrefab = Resources.Load("RolePrefab/Item/xiangzi") as GameObject;
        //Debug.Log(m_BoxPrefab.name);
        m_PrevCount = PlayerPrefs.GetInt(m_BoxKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_CurrCount < m_MaxCount)
        {
            if(Time.time > m_NextCloneTime)
            {
                
                m_NextCloneTime = Time.time + 3f;
                //clone
                GameObject objClone = Instantiate(m_BoxPrefab) as GameObject;
                objClone.transform.parent = boxParent;

                objClone.transform.position = transCreateBox.transform.TransformPoint(new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f)));
                BoxCtrl boxCtrl = objClone.GetComponent<BoxCtrl>();
                if (boxCtrl != null)
                {
                    boxCtrl.Onhit = BoxHit;
                    m_CurrCount++;
                }
                

            }
        }

        //if (Input.GetMouseButtonUp(1))
        //{
        //    for(int i = 0; i < 10; i++)
        //    {
        //        BoxCtrl.Instance.TestLog();
        //    }
            
        //}
    }

    void BoxHit(GameObject obj)
    {
        m_PrevCount++;
        PlayerPrefs.SetInt(m_BoxKey, m_PrevCount);
        Debug.Log("累计拾取" + m_PrevCount);
        m_CurrCount--;
        GameObject.Destroy(obj);
    }
}
