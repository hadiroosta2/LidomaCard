using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace LidomaCard
{
    [Serializable]
   public class userSetting
    {
         public  int drawArae_wight;
         public  int drawArae_height;
         public string projectName;
         public string projectPath;
         public int resolution;
         public string paperName;
         public bool orintation;
         public graphicList GList;
         public string background_image_path;
          public bool arondLine;
          public bool showGrid;
          public bool newObject;
        //int printCount ;
        //int zeroNumber;
        //List<String> favFount;

        public userSetting()
        {
            //printCount = 1;
            //zeroNumber = 0;
            //favFount = new List<string>();
            GList=new graphicList ();
            arondLine = false;
            showGrid = false;
            newObject = false;
            drawArae_wight = 0;
            drawArae_height = 0;
            background_image_path = "";
            projectName = "";
            projectPath = "";
            paperName = "";
        }

        //#region propertis
        //public int PrintCount
        //{
        //    get
        //    {
        //        return printCount;
        //    }
        //    set
        //    {
        //        printCount = value;
        //    }
        //}
     
        //public int ZeroNumber 
        //{
        //    get
        //    { 
        //        return zeroNumber;
        //    }

        //    set
        //    {
        //        zeroNumber=value ;
        //    }
        //}
        //public int Count
        //{
        //    get
        //    {
        //        return favFount.Count;
        //    }
        //}
        //#endregion

        //public String this[int index]
        //{
        //    get
        //    {
        //        if(index<0 | index>favFount.Count)
        //        {
        //            return null;
        //        }
        //        return favFount[index];
        //    }
        //}
        //public List<String> listItem()
        //{
        //    List<String> list = new List<string>();
        //    for (int i = 0; i <favFount.Count; i++)
        //    {
        //        list.Add(favFount[i]);
                
        //    }
        //    return list;
        //}
        //public void remove(string fontName)
        //{
        //    favFount.Remove(fontName);
        //}
       //public void add(string fontName)
       // {
       //   //  favFount.Add(fontName);
       //     favFount.Insert(0, fontName);
       // }

       //#region save & load
       ////public userSetting loadSetting()
       ////{
       ////    try
       ////    {
       ////         BinaryFormatter formater = new BinaryFormatter();
       ////         FileStream fs = new FileStream(Application.StartupPath + "\\data.dat", FileMode.OpenOrCreate, FileAccess.Read);
       ////         userSetting us = new userSetting();
           
       ////         us = (userSetting)formater.Deserialize(fs);
           
       ////         fs.Close();
       ////         return us;
       ////    }
       ////    catch
       ////    {
       ////        userSetting us = new userSetting();
       ////        us.PrintCount = 1;
       ////        us.ZeroNumber = 0;
       ////        us.favFount = new List<string> { "Arial" };
       ////        return us;

       ////    }
           
       ////}
       //// public void saveSetting()
       ////{

       ////    if (File.Exists(Application.StartupPath + "\\data.dat"))
       ////        {
       ////            BinaryFormatter formater = new BinaryFormatter();
       ////            FileStream fs = new FileStream(Application.StartupPath + "\\data.dat", FileMode.OpenOrCreate, FileAccess.Write);

       ////            formater.Serialize(fs, this);
       ////            fs.Close();
       ////        }
       ////        else
       ////        {
       ////            File.Create(Application.StartupPath + "\\data.dat");
       ////            BinaryFormatter formater = new BinaryFormatter();
       ////            FileStream fs = new FileStream(Application.StartupPath + "\\data.dat", FileMode.OpenOrCreate, FileAccess.Write);

       ////            formater.Serialize(fs, this);
       ////            fs.Close();
       ////        }
          
          

       ////}
       //#endregion

    }
}
