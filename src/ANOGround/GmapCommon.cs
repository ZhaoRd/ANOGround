using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//***************************************************//
//**阿木社区编写(AMOV AUTO),玩也要玩的专业！
//** www.amovauto.com
//***本代码仅供参考，如有疑问请上社区论坛或者QQ群询问//
namespace ANOGround
{
    [Serializable]
    public class GMapMarkerWP : GMarkerGoogle //航点图标，图标上可带航点编号
    {
        const float rad2deg = (float)(180 / Math.PI);
        const float deg2rad = (float)(1.0 / rad2deg);

        string wpno = "";//航点编号
        public bool selected = false;

        public GMapMarkerWP(PointLatLng p, string wpno)
            : base(p, GMarkerGoogleType.green)
        {
            this.wpno = wpno;
        }

        public override void OnRender(Graphics g)
        {
            if (selected)//如果选中了该航点，则在航点周围画一个以图标尺寸为直径的虚线圆圈
            {
                Pen Pen = new Pen(Brushes.Red, 2);
                Pen.DashStyle = DashStyle.Dash;
                //g.FillEllipse(Brushes.Red, new Rectangle(this.LocalPosition, this.Size));
                //g.DrawArc(Pens.Red,new Rectangle(this.LocalPosition,this.Size),0,360);
                g.DrawArc(Pen, new Rectangle(this.LocalPosition, this.Size), 0, 360);
            }
            base.OnRender(g);
            //标记航点编号
            var midw = LocalPosition.X + 10;//图标中心点X
            var midh = LocalPosition.Y + 3;//图标中心点Y
            var txtsize = TextRenderer.MeasureText(wpno, SystemFonts.DefaultFont);//指定文本的尺寸（像素点）
            if (txtsize.Width > 15) midw -= 4;
            g.DrawString(wpno, SystemFonts.DefaultFont, Brushes.Black, new PointF(midw, midh));//航点号,字体,笔色,坐标
        }
    }
    public class GMapMarkerPlane : GMapMarker //飞机飞行图标，包括飞行中的一些指示线
    {
        const float rad2deg = (float)(180 / Math.PI);
        const float deg2rad = (float)(1.0 / rad2deg);

        private readonly Bitmap icon = global::ANOGround.Properties.Resources.planetracker;

        float heading = 0;
        float cog = -1;
        float target = -1;
        float nav_bearing = -1;

        public GMapMarkerPlane(PointLatLng p, float heading, float cog, float nav_bearing, float target)//坐标,机头朝向,
            : base(p)
        {
            this.heading = heading;//机头朝向,0:Up;180:Down
            this.cog = cog;//course over ground，地速方向
            this.target = target;//目标航点朝向
            this.nav_bearing = nav_bearing;//当前导航航向
            Size = icon.Size;
        }

        public override void OnRender(Graphics g)
        {
            Matrix temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);
            g.RotateTransform(-Overlay.Control.Bearing);

            int length = 500;
            // anti NaN
            try
            {
                //画出机头朝向直线
                g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length, (float)Math.Sin((heading - 90) * deg2rad) * length);
            }
            catch { }
            //画出导航方向直线
            g.DrawLine(new Pen(Color.Green, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length, (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
            //画出地速方向直线
            g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length, (float)Math.Sin((cog - 90) * deg2rad) * length);
            //画出目标点朝向直线
            g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length, (float)Math.Sin((target - 90) * deg2rad) * length);

            // anti NaN
            try
            {
                float desired_lead_dist = 100;
                //Overlay层宽度方向对应的经度距离[m]
                double width = (Overlay.Control.MapProvider.Projection.GetDistance(Overlay.Control.FromLocalToLatLng(0, 0), Overlay.Control.FromLocalToLatLng(Overlay.Control.Width, 0)) * 1000.0);
                //Overlay层宽度方向像素点数/对应的经度距离[m] = pixel / meter: 变换系数
                double m2pixelwidth = Overlay.Control.Width / width;

                float radius = 100;//转弯半径？MainV2.comPort.MAV.cs.radius
                float alpha = ((desired_lead_dist * (float)m2pixelwidth) / radius) * rad2deg;

                if (radius < -1)
                {
                    // fixme 
                    float p1 = (float)Math.Cos((cog) * deg2rad) * radius + radius;
                    float p2 = (float)Math.Sin((cog) * deg2rad) * radius + radius;
                    g.DrawArc(new Pen(Color.HotPink, 2), p1, p2, Math.Abs(radius) * 2, Math.Abs(radius) * 2, cog, alpha);//画出转弯弧
                }
                else if (radius > 1)
                {
                    // correct
                    float p1 = (float)Math.Cos((cog - 180) * deg2rad) * radius + radius;
                    float p2 = (float)Math.Sin((cog - 180) * deg2rad) * radius + radius;
                    g.DrawArc(new Pen(Color.HotPink, 2), -p1, -p2, radius * 2, radius * 2, cog - 180, alpha);//画出转弯弧
                }
            }
            catch { }

            try
            {
                g.RotateTransform(heading);//按机头朝向旋转图标
            }
            catch { }
            g.DrawImageUnscaled(icon, icon.Width / -2, icon.Height / -2);//按图标原尺寸画出图标

            g.Transform = temp;
        }
    }
}
