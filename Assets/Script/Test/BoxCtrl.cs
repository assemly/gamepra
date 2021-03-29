using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCtrl : MonoBehaviour
{
    /*
    private Vector3 m_TargetPos = Vector3.zero;
    [SerializeField]
    private float m_Speed = 10f;
    */
    //private float g_Speed = 10f;
    // Start is called before the first frame update
    private static BoxCtrl _Instance;

    public static BoxCtrl Instance
    {
        get
        {
            if(_Instance ==null)
            {
                GameObject obj = new GameObject("BoxCtrl");
                _Instance = obj.AddComponent<BoxCtrl>();
                DontDestroyOnLoad(obj);

            }
            return _Instance;
        }
    }

    public void TestLog()
    {
        Debug.Log("执行单例");
    }

    public System.Action<GameObject> Onhit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.localPosition = gameObject.transform.localPosition + new Vector3(0, -1 * g_Speed * Time.deltaTime, 0);
        #region 点击屏幕向前移动
        /*
        if (Input.GetMouseButtonUp(0) || Input.touchCount == 1)
        {
            //Debug.Log("Test");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.name.Equals("Ground", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    m_TargetPos = hitInfo.point;
                    
                }
            }

        }

        if (m_TargetPos != Vector3.zero)
        {
            if (Vector3.Distance(m_TargetPos,transform.position) > 0.1f)
            {
                transform.LookAt(m_TargetPos);
                transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);
            }


        }
        */
        #endregion


    }

    public void Hit()
    {
        if(Onhit != null)
        {
            Onhit(gameObject);
        }
    }

}
