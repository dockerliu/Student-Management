using System;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.IO;
using System.Drawing;
using Models.Ext;

namespace StudentManager
{
    class PrintStudent
    {
        /// <summary>
        /// 在Excel中打印学生信息
        /// </summary>
        /// <param name="studentExt"></param>
        public void ExecutePrint(StudentExt studentExt)
        {
            //1、定义一个Excel工作薄
            Application excelApp = new Application();
            //2、获取已创建好的工作薄路径
            string excelBookPath = Environment.CurrentDirectory + "\\StudentInfo.xls";
            //3、将现有的工作薄加入已定义的工作薄集合中
            excelApp.Workbooks.Add(excelBookPath);
            //4、获取第一个工作表
            Worksheet objSheet = excelApp.Worksheets[1];
            //5、在当前的Excel工作表中写入数据
            if (studentExt.StuImage.Length!=0)
            {
                //将图片保存到指定的位置
                Image objimage = (Image)new SerializeObjectToString().DeserializeObject(studentExt.StuImage);
                if (File.Exists(Environment.CurrentDirectory+"\\Student.jpg"))
                {
                    File.Delete(Environment.CurrentDirectory + "\\Student.jpg");
                }
                else
                {
                    objimage.Save(Environment.CurrentDirectory + "\\Student.jpg");
                    objSheet.Shapes.AddPicture(Environment.CurrentDirectory + "\\Student.jpg", MsoTriState.msoFalse, MsoTriState.msoTrue, 10, 50, 70, 80);
                    //使用完毕后删除保存的图片
                    File.Delete(Environment.CurrentDirectory + "\\Student.jpg");

                }
            }
            //写入其他相关的数据
            objSheet.Cells[4, 4] = studentExt.StudentId;
            objSheet.Cells[4, 6] = studentExt.StudentName;
            objSheet.Cells[4, 7] = studentExt.Gender;
            objSheet.Cells[6, 4] = studentExt.ClassName;
            objSheet.Cells[6, 6] = studentExt.PhoneNumber;
            objSheet.Cells[8, 4] = studentExt.StudentAddress;
            //6、打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview(true);
            //7、释放对象
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);//释放
            excelApp = null;

        }
    }
}
