using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace StudentManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        [Obsolete]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //显示登陆窗体
            FrmUserLogin login = new FrmUserLogin();
            DialogResult result= login.ShowDialog();
            if (result==DialogResult.OK)
            {
                //主窗体显示
                Application.Run(new FrmMain());
            }
            else
            {
                Application.Exit();//退出整个应用程序
            }

            
        }
        //定义一个全局变量
        public static Admin currentAmin=null;
    }

}
