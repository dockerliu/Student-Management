using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using DAL;

namespace StudentManager
{
    public partial class FrmMain : Form
    {
        [Obsolete]
        public FrmMain()
        {
            InitializeComponent();
            //MessageBox.Show(SQLHelper.connString);
            //初始化背景
            lblCurrentUser.Text = Program.currentAmin.AdminName + "]";
            panelForm.BackgroundImage = Image.FromFile("mainbg.png");
            lblVersion.Text = "版本号:" + ConfigurationSettings.AppSettings["sysversion"].ToString();
        }

        #region 嵌入窗体显示
        /// <summary>
        /// 打开窗体
        /// </summary>
        /// <param name="objForm"></param>
        private void OpenForm(Form objForm)
        {
            objForm.TopLevel = false;//将当前窗体设置成非顶级控件
            objForm.WindowState = FormWindowState.Maximized;
            objForm.FormBorderStyle = FormBorderStyle.None;
            objForm.Parent = panelForm;//指定当前子窗体显示的容器
            objForm.Show();
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void CloseForm()
        {
            foreach (Control item in panelForm.Controls)
            {
                if (item is Form)
                {
                    Form form = (Form)item;
                    form.Close();
                    panelForm.Controls.Remove(item);
                }
            }
        }
     
        //显示添加新学员窗体       
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {          
            FrmAddStudent objForm = new FrmAddStudent();
            CloseForm();
            OpenForm(objForm);

        }
        //考勤打卡      
        private void tsmi_Card_Click(object sender, EventArgs e)
        {
            FrmAttendance objForm = new FrmAttendance();
            CloseForm();
            OpenForm(objForm);

        }
        //成绩快速查询【嵌入显示】
        private void tsmiQuery_Click(object sender, EventArgs e)
        {
            FrmScoreQuery objForm = new FrmScoreQuery();
            CloseForm();
            OpenForm(objForm);

        }
        //学员管理【嵌入显示】
        private void tsmiManageStudent_Click(object sender, EventArgs e)
        {
            FrmStudentManage objForm = new FrmStudentManage();
            CloseForm();
            OpenForm(objForm);

        }
        //显示成绩查询与分析窗口    
        private void tsmiQueryAndAnalysis_Click(object sender, EventArgs e)
        {
            FrmScoreManage objForm = new FrmScoreManage();
            CloseForm();
            OpenForm(objForm);
        }
        //考勤查询
        private void tsmi_AQuery_Click(object sender, EventArgs e)
        {
            FrmAttendanceQuery objForm = new FrmAttendanceQuery();
            CloseForm();
            OpenForm(objForm);
        }
        #endregion

        #region 退出系统确认

        //退出系统
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 退出系统前确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resut = MessageBox.Show("确定要退出吗？", "退出确定：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resut == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region 其他

        //密码修改
        private void tmiModifyPwd_Click(object sender, EventArgs e)
        {
            FrmModifyPwd objPwd = new FrmModifyPwd();
            objPwd.ShowDialog();
        }

        private void tsbAddStudent_Click(object sender, EventArgs e)
        {
            tsmiAddStudent_Click(null, null);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsmiManageStudent_Click(null, null);
        }
        private void tsbScoreAnalysis_Click(object sender, EventArgs e)
        {
            tsmiQueryAndAnalysis_Click(null, null);
        }
        private void tsbModifyPwd_Click(object sender, EventArgs e)
        {
            tmiModifyPwd_Click(null, null);
        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbQuery_Click(object sender, EventArgs e)
        {
            tsmiQuery_Click(null, null);
        }   
     
        //访问官网
        private void tsmi_linkxkt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://www.68s.org");
        }

        private void tsmi_about_Click(object sender, EventArgs e)
        {
            FrmAbout objAbout = new FrmAbout();
            objAbout.Show();
        }


        #endregion

        
    }
}