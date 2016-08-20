using ANOGround.mavlink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//***************************************************//
//**阿木社区编写(AMOV AUTO),玩也要玩的专业！
//** www.amovauto.com
//***本代码仅供参考，如有疑问请上社区论坛或者QQ群询问//
namespace ANOGround
{
    class UpdateComUiThread
    {
        private MAVLinkInterface comPortMP;
        public delegate void readmavlink(MAVState MAV);
        //声明一个readmavlink类型的对象。该对象代表了返回值为空.  
        public readmavlink readmavlinkThread;
        public UpdateComUiThread(MAVLinkInterface comPort)
        {
            comPortMP = comPort;
        }

        public void readmavlinkdelegate()
        {
            while (comPortMP.BaseStream.IsOpen)
            {
                foreach (var MAV in comPortMP.MAVlist.GetMAVStates())
                {
                    try
                    {
                          MAV.cs.UpdateCurrentSettings(null, false, Form1.comPort, MAV);
                    }
                    catch (Exception ex)
                    {
                        ;//没有写，异常反馈！
                    }
                    readmavlinkThread(MAV);//调用委托对象MAVLINK数据UI更新线程，对应的ReadComThread是读取mavlink线程

                }
                Thread.Sleep(5);
            }
        }

   }
}    


    
 


