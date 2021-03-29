using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleCtrl : MonoBehaviour
{
    private Vector3 m_TargetPos = Vector3.zero;
    private CharacterController m_CharacterController;
    [SerializeField]
    private float m_Speed = 10f;
    [SerializeField]
    private float m_RotationSpeed = 0.2f;
    /// <summary>
    /// 转身目标
    /// </summary>
    private Quaternion m_TargetQuaternion;
    //private bool m_Rotationover = false;
    // Start is called before the first frame update

 
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        if(CameraCtrl.Instance != null)
        {
            CameraCtrl.Instance.Init();
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonUp(0))
        {
            GameObject[] boxArr = GameObject.FindGameObjectsWithTag("Boxs");
            if (boxArr != null && boxArr.Length >0)
            { 
                for(int i=0;i<boxArr.Length;i++)
                {
                    boxArr[i].transform.localPosition = boxArr[i].transform.localPosition + new Vector3(0, 0, 10);
                }
                
            }
        }
        return;
        */
        if (m_CharacterController == null) return;
        if (Input.GetMouseButtonUp(0) || Input.touchCount == 1)
        {
            //Debug.Log("Test");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray,out hitInfo))
            {
                if(hitInfo.collider.gameObject.name.Equals("Ground",System.StringComparison.InvariantCultureIgnoreCase))
                {
                    m_TargetPos = hitInfo.point;
                    //m_Rotationover = false;
                    m_RotationSpeed = 0;
                }
            }

        }
     if (!m_CharacterController.isGrounded)
        {
            m_CharacterController.Move((transform.position + new Vector3(0, -1000, 0)) - transform.position);
        }

     if (Input.GetMouseButtonUp(1))
        {
            //Collider[] colliderArr = Physics.OverlapSphere(transform.position, 3, 1 << LayerMask.NameToLayer("Item"));
            //if (colliderArr.Length > 0)
            //{
            //    for (int i = 0; i < colliderArr.Length; i++)
            //    {
            //        Debug.Log("找到了箱子" + colliderArr[i].gameObject.name);
            //    }

            //}
            //else
            //{
            //    Debug.Log("未找到了箱子");
            //}
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item")))
            {
                BoxCtrl boxCtrl = hit.collider.GetComponent<BoxCtrl>();
                if(boxCtrl != null)
                {
                    boxCtrl.Hit();
                }
                //Debug.Log(hit.collider.gameObject.name);
            }
        }

        if (m_TargetPos != Vector3.zero)
        {
            //Debug.DrawLine(Camera.main.transform.position, m_TargetPos);
            if (Vector3.Distance(m_TargetPos,transform.position) > 0.1f)
            {
                //transform.LookAt(m_TargetPos);
                //transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);
                Vector3 direction = m_TargetPos - transform.position;
                direction = direction.normalized;
                direction = direction * Time.deltaTime * m_Speed;
                direction.y = 0;
                // transform.LookAt(new Vector3(m_TargetPos.x,transform.position.y,m_TargetPos.z));

                //让角色缓慢转身
                /*if(!m_Rotationover)
                {
                    m_RotationSpeed += 0.2f;
                    m_TargetQuaternion = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, m_TargetQuaternion, Time.deltaTime * m_RotationSpeed);
                
                if (Quaternion.Angle(m_TargetQuaternion,transform.rotation) < 1f)
                {
                    m_RotationSpeed = 1;
                    m_Rotationover = true;
                }
                }*/
                if (m_RotationSpeed <=1)
                {
                    m_RotationSpeed += 5f * Time.deltaTime;
                    m_TargetQuaternion = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, m_TargetQuaternion, m_RotationSpeed);
                }
                m_CharacterController.Move(direction);
            }
            
        }

        CameraAutoFollow();
    }

    private void CameraAutoFollow()
    {
        if (CameraCtrl.Instance == null) return;
        CameraCtrl.Instance.transform.position = gameObject.transform.position;
        CameraCtrl.Instance.AutoLookAt(gameObject.transform.position);
        if (Input.GetKey(KeyCode.A))
        {
            CameraCtrl.Instance.SetCameraRotate(0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CameraCtrl.Instance.SetCameraRotate(1);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            CameraCtrl.Instance.SetCameraUpAndDown(1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CameraCtrl.Instance.SetCameraUpAndDown(0);
        }
        else if (Input.GetKey(KeyCode.I))
        {
            CameraCtrl.Instance.SetCameraZoom(1);
        }
        else if (Input.GetKey(KeyCode.O))
        {
            CameraCtrl.Instance.SetCameraZoom(0);
        }

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 3);
    //}
}
