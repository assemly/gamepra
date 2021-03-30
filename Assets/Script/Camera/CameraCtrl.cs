using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    public static CameraCtrl Instance;

    [SerializeField]
    private Transform m_CameraUpAndDown;
    [SerializeField]
    private Transform m_CameraZoomContainer;
    [SerializeField]
    private Transform m_CameraContainer;

    public void Init()
    {
        m_CameraUpAndDown.transform.localEulerAngles = new Vector3(Mathf.Clamp(m_CameraUpAndDown.transform.localEulerAngles.x, 35f, 80f), 0, 0);
        m_CameraContainer.localPosition = new Vector3(0, 0, Mathf.Clamp(m_CameraContainer.localPosition.z, -5, 5));
    }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
    /// <summary>
    /// 设置摄像机的方法 0 左 1 右<paramref name="type"/>
    /// </summary>
    /// <param name="type"></param>
    public void SetCameraRotate(int type)
    {
        transform.Rotate(0, 40 * Time.deltaTime*(type==0?-1:1), 0);
    }
    /// <summary>
    /// 0 上 1 下
    /// </summary>
    /// <param name="type"></param>
    public void SetCameraUpAndDown(int type)
    {
        m_CameraUpAndDown.transform.Rotate(30 * Time.deltaTime * (type == 0 ? -1 : 1), 0, 0);
        m_CameraUpAndDown.transform.localEulerAngles = new Vector3(Mathf.Clamp(m_CameraUpAndDown.transform.localEulerAngles.x, 35f, 80f), 0, 0);
    }
    /// <summary>
    /// 0 拉近 1拉远
    /// </summary>
    /// <param name="type"></param>
    public  void SetCameraZoom(int type)
    {
        //m_CameraContainer.transform.TransformPoint(0, 0, m_CameraContainer.transform.position.z+ 10 * Time.deltaTime * (type == 0 ? -1 : 1));
        m_CameraContainer.Translate(Vector3.forward * 30 * Time.deltaTime * (type == 0 ? -1 : 1));
        m_CameraContainer.localPosition = new Vector3(0, 0, Mathf.Clamp(m_CameraContainer.localPosition.z,-5,5));
    }

    /// <summary>
    /// 实时看着主角
    /// </summary>
    public void AutoLookAt(Vector3 pos)
    {
        m_CameraZoomContainer.LookAt(pos);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 15f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 14f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 12f);
    }
}
