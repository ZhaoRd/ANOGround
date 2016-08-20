using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms;


namespace ANOGround
{
    class GmapClass
    {
        //*************************GMAP 的引用*****************************
   
      //  public Bitmap dispointpng = Bitmap.FromFile("F:\\MISSIONPLANNER\\test\\地面站雏形（油气储运V2.0版）\\MapIcon\\distance.png") as Bitmap;
        public GMapOverlay objects = new GMapOverlay("objects"); //放置marker的图层

        public GmapClass(Form1 from)
        {
     //axiSevenSegmentClockSMPTEX1.Time = System.
            //************************************主界面GMAP地图的加载项目*****************************************
            from.gmap.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;//设置为卫星必应地图
            //gmap.MapProvider = GMap.NET.MapProviders.WikiMapiaMapProvider.Instance ;//设置为卫星威客地图
            //gmap.MapProvider = GMap.NET.MapProviders.GoogleChinaHybridMapProvider.Instance;//设置为卫星谷歌地图
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;//设置为在线地图
            //gmap.Position = new PointLatLng(87.3643, 43.46);//
            from.gmap.Position = new PointLatLng(87.8700, 43.5800);//乌鲁木齐糖糖家的维度，经度
            //gmap.CacheLocation = @"F:\0无人机\VC# 串口通信实验\GMap.NET";//使能离线地图
            //C: \Users\Administrator\AppData\Local\GMap.NET  
            //@"F:\0无人机\VC# 串口通信实验\GMap.NET"
            //gmap.Manager.Mode = AccessMode.CacheOnly;//使能离线地图
            from.gmap.Bearing = 0;
            from.gmap.CanDragMap = true;
            from.gmap.GrayScaleMode = false;
            from.gmap.MarkersEnabled = true;
            from.gmap.ShowTileGridLines = false;//显示网格
            from.gmap.MaxZoom = 20;
            from.gmap.MinZoom = 2;
            from.gmap.Zoom = 14;
            //************************************航线规划GMAP地图的加载项目*****************************************
            from.gmap_setairway.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;//设置为卫星必应地图
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;//设置为在线地图
            from.gmap.Position = new PointLatLng(45.7543, 126.6281); ;//乌鲁木齐糖糖家的维度，经度
            from.gmap_setairway.Bearing = 0;
            from.gmap_setairway.CanDragMap = true;
            from.gmap_setairway.GrayScaleMode = false;
            from.gmap_setairway.MarkersEnabled = true;
            from.gmap_setairway.ShowTileGridLines = false;//显示网格
            from.gmap_setairway.MaxZoom = 20;
            from.gmap_setairway.MinZoom = 2;
            from.gmap_setairway.Zoom = 13;
         }

    }
}
