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
using System.Net;

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
            GetLastUpdateInfo();
            GetNewUpdateInfo();

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
            get
            {
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
                string newTempPath = Environment.GetEnvironmentVariable("Temp") + "\\Updatefiles";
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
        private void GetLastUpdateInfo()
        {
            //FileStream myFile = new FileStream("UpdateList.xml", FileMode.Open);
            //XmlTextReader xmlReader = new XmlTextReader("UpdateList.xml");
            XmlTextReader xmlReader = new XmlTextReader("UpdateList.xml");
           while (xmlReader.Read())
                {
                    switch (xmlReader.Name)
                    {
                        case "URLAddress":
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
            //myFile.Close();
        }

        /// <summary>
        /// 从服务器获取最新更新文件到临时目录
        /// </summary>
        private void GetNewUpdateInfo()
        {
            //下载到临时目录
            string newXmlTempPath = TempFilePath + "\\UpdateList.xml";

            //远程下载
            WebClient objClient = new WebClient();
            objClient.DownloadFile(LastUpdateInfo.UpdateURL + "UpdateList.xml", newXmlTempPath);//前面是下载路径+文件名，后面是保存路径 
            //封装更新的信息
            FileStream myFile = new FileStream(newXmlTempPath, FileMode.Open);
            XmlTextReader xmlReader = new XmlTextReader(myFile);
            NowUpdateInfo.fileList = new List<string[]>();//因为这个是集合对象，使用前必须初始化（也可以把初始化放到NowUpdateInfo构造方法里）
            while (xmlReader.Read())
            {
                switch (xmlReader.Name)
                {

                    case "Version":
                        NowUpdateInfo.Version = xmlReader.GetAttribute("Num");
                        break;
                    case "UpdateTime":
                        NowUpdateInfo.UpdateTime = Convert.ToDateTime(xmlReader.GetAttribute("Date"));
                        break;
                    case "UpdateFile":
                        string ver = xmlReader.GetAttribute("Ver");
                        string fileName = xmlReader.GetAttribute("FileName");
                        string contentLength = xmlReader.GetAttribute("ContentLength");
                        NowUpdateInfo.fileList.Add(new string[] { fileName,contentLength,ver,"0"});                       
                        break;

                    default:
                        break;
                }
            }
            xmlReader.Close();
            myFile.Close();

        }
        
        #region 根据更新文件列表下载更新文件，并同并显示下载百分比

        //创建同步显示百分比的委托
        public delegate void ShowUpdateProgress(int fileIndex, int finishedPercent);
        //创建委托对象（在更新窗体中会有具体方法与之关联）
        public ShowUpdateProgress ShowProgressDelegate;

        /// <summary>
        /// 根据更新文件列表下载更新文件，并同并显示下载百分比
        /// </summary>
        public void DownLoadFiles()
        {
            List<string[]> fileList = NowUpdateInfo.fileList;//下载的文件列表
            //循环下载文件
            for (int i = 0; i < fileList.Count; i++)
            {
                //1、连接远程服务器指定文件并准备获取
                string fileName = fileList[i][0];//文件名
                string fileUrl = LastUpdateInfo.UpdateURL + fileName;//当前需要下载文件URL

                //2、获取远程数据
                WebRequest objWebRequest = WebRequest.Create(fileUrl);//根据文件URL连接服务器，创建请求对象
                WebResponse objWebResponse = objWebRequest.GetResponse();//根据请求对象创建响应对象
                Stream objStream = objWebResponse.GetResponseStream();//通过响应对象返回数据流对象
                StreamReader objReader = new StreamReader(objStream);//用数据流对象作为参数常见流读取器对象

                //3、在线读取已经连接的远程文件，并基于委托反馈文件读取（下载）进度
                long fileLength = objWebResponse.ContentLength;//通过响应对象获取接收的数据长度
                byte[] bufferByte = new byte[fileLength];//根据当前文件的字节数创建字节数组
                int allByte = bufferByte.Length;//得到总字节数
                int startByte = 0;//表示第一个字节
                while (fileLength > 0)
                {
                    System.Windows.Forms.Application.DoEvents();//该语句表示允许在一个线程中同时处理其他事件（如果没有该语句不能同步显示百分比）

                    int downLoadByte = objStream.Read(bufferByte, startByte, allByte);//开始读取字节流
                    if (downLoadByte == 0)//读完后跳出
                    {
                        break;
                    }
                    startByte += downLoadByte;//累加已经下载的字节数
                    allByte -= downLoadByte;//未下载的字节数

                    //计算完成的百分比（整数）
                    float part = (float)startByte / 1024;
                    float total = (float)bufferByte.Length / 1024;
                    int percent = Convert.ToInt32((part / total) * 100);

                    //4、通过委托变量显示更新的百分比
                    ShowProgressDelegate(i, percent);
                }
                //5、保存读取完毕的文件
                string newFileName = TempFilePath + "\\" + fileName;
                FileStream fs = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(bufferByte,0,bufferByte.Length);
                objStream.Close();
                objReader.Close();
                fs.Close();


            }
        }
        /// <summary>
        /// 交下载的文件复制到应用程序的目录
        /// </summary>
        /// <returns></returns>
        public bool CopyFile()
        {
            string[] files = Directory.GetFiles(TempFilePath);//文件路径+名字：abc\def\ab1.txt
            foreach (string name in files)
            {
                string currentFile = name.Substring(name.LastIndexOf(@"\") + 1);
                if (File.Exists(currentFile))//如果文件存在目录中，则先删掉
                {
                    File.Delete(currentFile);
                }
                File.Copy(name, currentFile);
            }
            return true;
        }
    } 
    #endregion

}
