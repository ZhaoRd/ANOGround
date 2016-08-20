using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANOGround
{
    public struct GBL_FLAG
    {
        /// <summary>
        /// 程序的初始状态
        /// </summary>
        public bool nothing;
        /// <summary>
        /// 飞行状态
        /// </summary>
        public bool flight;
        /// <summary>
        /// 数据回放状态
        /// </summary>
        public bool repaly;
        /// <summary>
        /// 接收线程启动标志
        /// </summary>
        public bool threadRcvState;
        /// <summary>
        /// 发送线程启动标志
        /// </summary>
        public bool threadSenState;
        /// <summary>
        /// 窗口监听状态
        /// </summary>
        public bool portListening;//是否没有执行完invoke相关操作
        /// <summary>
        /// 窗口关闭状态
        /// </summary>
        public bool portClosing;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke
        /// <summary>
        /// 航路规划状态切换。true:处于航路规划状态;false:处于实时显示状态
        /// </summary>
        public bool bRoutePlan;

        public bool markerentered;
        /// <summary>
        /// 航点被选中状态
        /// </summary>
        public bool markerselected;

    }
}
