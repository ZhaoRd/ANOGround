using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ANOGround.FlightPlanner
{
    class PlannParameInit
    {
         private Dictionary<string, string[]> cmdParamNames = new Dictionary<string, string[]>();


         public void updateCMDParams(DataGridViewComboBoxColumn Command)
        {
            cmdParamNames = readCMDXML();

            List<string> cmds = new List<string>();

            foreach (string item in cmdParamNames.Keys)
            {
                cmds.Add(item);
            }

            cmds.Add("UNKNOWN");

            Command.DataSource = cmds;
            
        }



         Dictionary<string, string[]> readCMDXML()
         {
             Dictionary<string, string[]> cmd = new Dictionary<string, string[]>();

             // do lang stuff here

             string file = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "mavcmd.xml";

             if (!File.Exists(file))
             {
                 CustomMessageBox.Show("Missing mavcmd.xml file");
                 return cmd;
             }

             using (XmlReader reader = XmlReader.Create(file))
             {
                 reader.Read();
                 reader.ReadStartElement("CMD");
                 //if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduPlane ||
                 //    MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.Ateryx)
                 //{
                     reader.ReadToFollowing("APM");
                 ////}
                 //else if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduRover)
                 //{
                 //    reader.ReadToFollowing("APRover");
                 //}
                 //else
                 //{
                 //    reader.ReadToFollowing("AC2");
                 //}

                 XmlReader inner = reader.ReadSubtree();

                 inner.Read();

                 inner.MoveToElement();

                 inner.Read();

                 while (inner.Read())
                 {
                     inner.MoveToElement();
                     if (inner.IsStartElement())
                     {
                         string cmdname = inner.Name;
                         string[] cmdarray = new string[7];
                         int b = 0;

                         XmlReader inner2 = inner.ReadSubtree();

                         inner2.Read();

                         while (inner2.Read())
                         {
                             inner2.MoveToElement();
                             if (inner2.IsStartElement())
                             {
                                 cmdarray[b] = inner2.ReadString();
                                 b++;
                             }
                         }

                         cmd[cmdname] = cmdarray;
                     }
                 }
             }

             return cmd;
         }


    }
    }
  
