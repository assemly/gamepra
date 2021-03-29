using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region WindowUIType 窗口类型
public enum WindowUIType
{   
    /// <summary>
    /// 未设置
    /// </summary>
    None,
    /// <summary>
    /// 登录窗口
    /// </summary>
    LogOn,

    /// <summary>
    /// 注册窗口
    /// </summary>
    Reg
}
#endregion

#region WindowUIContainerType UI容器类型
public enum WindowUIContainerType
{
    TopLeft, //左上
    TopRight, //右上
    BottomLeft, //
    BottomRight,
    Center
}
#endregion

#region WindowShowStyle 窗口弹出样式
/// <summary>
/// 窗口弹出样式
/// </summary>
public enum WindowShowStyle
{
    Normal,         //正常
    CenterToBig,    //中间放大
    FromTop,        //从顶部
    FromDown,       //从底部
    FromLeft,       //从左
    FromRight       //从右
}
#endregion

