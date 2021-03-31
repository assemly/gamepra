using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
using System;

/// <summary>
/// ����
/// </summary>
public class EasyTouchEvent : MonoBehaviour
{
    public static EasyTouchEvent Instance;

    /// <summary>
    /// ��ҵ������
    /// </summary>
    public System.Action OnPlayerClickGround;

    /// <summary>
    /// ��ָ����ö��
    /// </summary>
    public enum FingerDir
    {
        Left,
        Right,
        Up,
        Down
    }

    public enum ZoomType
    {
        In,
        Out
    }
    /// <summary>
    /// ����ί��
    /// </summary>
    public System.Action<FingerDir> OnSwip;

    /// <summary>
    ///  ����ί��
    /// </summary>
    public System.Action<ZoomType> OnZoom;
    private Vector2 m_tempFinger1Pos;
    private Vector2 m_tempFinger2Pos;
    private Vector2 m_OldFinger1Pos;
    private Vector2 m_OldFinger2Pos;

    /// <summary>
    /// ��ָ�ϴ�λ��
    /// </summary>
    /// 
    private Vector2 m_OldFingerPos;
    /// <summary>
    /// ��ָ��������
    /// </summary>
    private Vector2 m_Dir;

    /// <summary>
    /// ��ָ��һ������
    /// </summary>
    private int m_PrevFinger = -1;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(OnZoom != null)
            {
                OnZoom(ZoomType.In);
            }
            
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (OnZoom != null)
            {
                OnZoom(ZoomType.Out);
            }
        }
#elif UNITY_ANDROID || UNITY_IPHONE
        if (Input.touchCount > 1)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                m_tempFinger1Pos = Input.GetTouch(0).position;
                m_tempFinger2Pos = Input.GetTouch(1).position;

                if(Vector2.Distance(m_OldFinger1Pos,m_OldFinger2Pos) < Vector2.Distance(m_tempFinger1Pos, m_tempFinger2Pos))
                {
                    if (OnZoom != null)
                    {
                        OnZoom(ZoomType.In);
                    }//�Ŵ�
                }
                else
                {
                    if (OnZoom != null)
                    {
                        OnZoom(ZoomType.Out);
                    }
                }
                m_OldFinger1Pos = Input.GetTouch(0).position;
                m_OldFinger2Pos = Input.GetTouch(1).position;
            }
        }
#endif

    }

    private void OnEnable()
    {
        EasyTouch.On_TouchDown += OnTouchDown;
        EasyTouch.On_TouchStart += OnTouchStart;
        EasyTouch.On_TouchUp += OnTouchUp;
        EasyTouch.On_Swipe += OnSwipeMove;
        EasyTouch.On_SwipeStart += OnSwipStart;
        EasyTouch.On_SwipeEnd += OnSwipEnd;
    }
    private void OnDisable()
    {
        EasyTouch.On_TouchDown -= OnTouchDown;
        EasyTouch.On_TouchStart -= OnTouchStart;
        EasyTouch.On_TouchUp -= OnTouchUp;
        EasyTouch.On_Swipe -= OnSwipeMove;
        EasyTouch.On_SwipeStart -= OnSwipStart;
        EasyTouch.On_SwipeEnd -= OnSwipEnd;
    }

    private void OnDestroy()
    {
        EasyTouch.On_TouchDown -= OnTouchDown;
        EasyTouch.On_TouchStart -= OnTouchStart;
        EasyTouch.On_TouchUp -= OnTouchUp;
        EasyTouch.On_Swipe -= OnSwipeMove;
        EasyTouch.On_SwipeStart -= OnSwipStart;
        EasyTouch.On_SwipeEnd -= OnSwipEnd;
    }

    private void OnTouchDown(Gesture gesture)
    {
        m_PrevFinger = 1;
        //Debug.Log("����");
    }

    void OnTouchUp(Gesture gesture)
    {
        if(m_PrevFinger == 1)
        {
            m_PrevFinger = -1;
            if (OnPlayerClickGround != null)
            {
                OnPlayerClickGround();
            }
            
        }
        Debug.Log("��������");
    }



    void OnSwipStart(Gesture gesture)
    {
        m_PrevFinger = 2;
        m_OldFingerPos = gesture.position;
        Debug.Log("������ʼ");
    }

    void OnSwipeMove(Gesture gesture)
    {
        m_PrevFinger = 3;
        //Debug.Log(gesture.swipeVector);
        m_Dir = gesture.position - m_OldFingerPos;
        if(m_Dir.y < m_Dir.x && m_Dir.y > -m_Dir.x)
        {
            if (OnSwip != null)
            {
                OnSwip(FingerDir.Right);
            }
           // Debug.Log(m_Dir + "��");
        }else if(m_Dir.y > m_Dir.x && m_Dir.y < -m_Dir.x)
        {
            if (OnSwip != null)
            {
                OnSwip(FingerDir.Left);
            }
           // Debug.Log(m_Dir + "��");
        }
        else if (m_Dir.y > m_Dir.x && m_Dir.y > -m_Dir.x)
        {
            if (OnSwip != null)
            {
                OnSwip(FingerDir.Up);
            }
            //Debug.Log(m_Dir + "��");
        }
        else
        {
            if (OnSwip != null)
            {
                OnSwip(FingerDir.Down);
            }
            //Debug.Log(m_Dir + "��");
        }
        //else if (gesture.swipeVector.x > 0 && gesture.swipeVector.y < 0)
        //{
        //    Debug.Log(gesture.swipeVector+"��");
        //}
        //else if (gesture.swipeVector.x < 0 && gesture.swipeVector.y > 0)
        //{
        //    Debug.Log(gesture.swipeVector+"��");
        //}
    }

    void OnSwipEnd(Gesture gesture)
    {
        m_PrevFinger = 4;
        //Debug.Log("��������");
    }
    void OnTouchStart(Gesture gesture)
    {
        //Debug.Log("������ʼ" + gesture.startPosition);
    }

   
    
}
