/*----------------------------------------------- 
// DockerLiu版权所有。 
// 文件名： 
// 文件功能描述： 
// 创建标识： 
// 修改标识： 
// 修改描述： 
//-----------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

/// <summary> 
/// 作者:DockerLiu
/// 邮箱:DockerLiu2019@Gmail.com 
/// 网站：www.68s.org 
/// </summary>
namespace UpdatePro
{
    /// <summary>
    /// 升级管理器核心业务类
    /// </summary>
    public class UpdateManager
    {
        public UpdateManager()
        {
            //1、初始化对象属性
            LastUpdateInfo = new UpdateInfo();
            NowUpdateInfo = new UpdateInfo();
            //2、给属性赋值


        }

        //属性
        /// <summary>
        /// 上次更新的文件信息
        /// </summary>
        public UpdateInfo LastUpdateInfo { get; set; }
        /// <summary>
        /// 本次更新的文件信息
        /// </summary>
        public UpdateInfo NowUpdateInfo { get; set; }

        /// <summary>
        /// 是否需要更新
        /// </summary>
       public bool IsUpdate
        {
            get {
                DateTime dt1 = Convert.ToDateTime(LastUpdateInfo.UpdateTime);
                DateTime dt2 = Convert.ToDateTime(NowUpdateInfo.UpdateTime);
                return dt2 > dt1;
            }
        }

        /// <summary>
        /// 获取存放更新文件的临时目录
        /// </summary>
        public string TempFilePath
        {
            get
            {
                string newTempPath = Environment.GetEnvironmentVariable("Temp")+"\\Updatefiles";
                if (!Directory.Exists(newTempPath))
                {
                    Directory.CreateDirectory(newTempPath);
                }
                return newTempPath;
            }
        }

        //方法

        /// <summary>
        /// 从本地获取上次更新的信息并封装到属性[服务器URL、版本、和更新时间]
        /// </summary>
        void GetLastUpdateTime()
        {
            FileStream myFile = new FileStream("UpdateList.xml", FileMode.Open);
            XmlTextReader xmlReader = new XmlTextReader(myFile);
            while (xmlReader.Read())
            {
                switch (xmlReader.Name)
                {
                    case "URLAdress":
                        LastUpdateInfo.UpdateURL = xmlReader.GetAttribute("URL");
                        break;
                    case "Version":
                        LastUpdateInfo.Version = xmlReader.GetAttribute("Num");
                        break;
                        case "UpdateTime":
                        LastUpdateInfo.UpdateTime = Convert.ToDateTime(xmlReader.GetAttribute("Date"));
                        break;

                    default:
                        break;
                }
            }
            xmlReader.Close();
            myFile.Close();
        }

    }
     
}
