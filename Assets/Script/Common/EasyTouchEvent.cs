using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
using System;

/// <summary>
/// 手势
/// </summary>
public class EasyTouchEvent : MonoBehaviour
{
    public static EasyTouchEvent Instance;

    /// <summary>
    /// 玩家点击地面
    /// </summary>
    public System.Action OnPlayerClickGround;

    /// <summary>
    /// 手指方向枚举
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
    /// 滑动委托
    /// </summary>
    public System.Action<FingerDir> OnSwip;

    /// <summary>
    ///  缩放委托
    /// </summary>
    public System.Action<ZoomType> OnZoom;
    private Vector2 m_tempFinger1Pos;
    private Vector2 m_tempFinger2Pos;
    private Vector2 m_OldFinger1Pos;
    private Vector2 m_OldFinger2Pos;

    /// <summary>
    /// 手指上次位置
    /// </summary>
    /// 
    private Vector2 m_OldFingerPos;
    /// <summary>
    /// 手指滑动方向
    /// </summary>
    private Vector2 m_Dir;

    /// <summary>
    /// 手指上一个操作
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
                    }//放大
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
        //Debug.Log("按下");
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
        Debug.Log("触摸结束");
    }



    void OnSwipStart(Gesture gesture)
    {
        m_PrevFinger = 2;
        m_OldFingerPos = gesture.position;
        Debug.Log("滑动开始");
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
           // Debug.Log(m_Dir + "右");
        }else if(m_Dir.y > m_Dir.x && m_Dir.y < -m_Dir.x)
        {
            if (OnSwip != null)
            {
                OnSwip(FingerDir.Left);
            }
           // Debug.Log(m_Dir + "左");
        }
        else if (m_Dir.y > m_Dir.x && m_Dir.y > -m_Dir.x)
        {
            if (OnSwip != null)
            {
                OnSwip(FingerDir.Up);
            }
            //Debug.Log(m_Dir + "上");
        }
        else
        {
            if (OnSwip != null)
            {
                OnSwip(FingerDir.Down);
            }
            //Debug.Log(m_Dir + "下");
        }
        //else if (gesture.swipeVector.x > 0 && gesture.swipeVector.y < 0)
        //{
        //    Debug.Log(gesture.swipeVector+"左");
        //}
        //else if (gesture.swipeVector.x < 0 && gesture.swipeVector.y > 0)
        //{
        //    Debug.Log(gesture.swipeVector+"右");
        //}
    }

    void OnSwipEnd(Gesture gesture)
    {
        m_PrevFinger = 4;
        //Debug.Log("滑动结束");
    }
    void OnTouchStart(Gesture gesture)
    {
        //Debug.Log("触摸开始" + gesture.startPosition);
    }

   
    
}
