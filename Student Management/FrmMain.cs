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
            //��ʼ������
            lblCurrentUser.Text = Program.currentAmin.AdminName + "]";
            panelForm.BackgroundImage = Image.FromFile("mainbg.png");
            lblVersion.Text = "�汾��:" + ConfigurationSettings.AppSettings["sysversion"].ToString();
        }

        #region Ƕ�봰����ʾ
        /// <summary>
        /// �򿪴���
        /// </summary>
        /// <param name="objForm"></param>
        private void OpenForm(Form objForm)
        {
            objForm.TopLevel = false;//����ǰ�������óɷǶ����ؼ�
            objForm.WindowState = FormWindowState.Maximized;
            objForm.FormBorderStyle = FormBorderStyle.None;
            objForm.Parent = panelForm;//ָ����ǰ�Ӵ�����ʾ������
            objForm.Show();
        }
        /// <summary>
        /// �رմ���
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
     
        //��ʾ�����ѧԱ����       
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {          
            FrmAddStudent objForm = new FrmAddStudent();
            CloseForm();
            OpenForm(objForm);

        }
        //���ڴ�      
        private void tsmi_Card_Click(object sender, EventArgs e)
        {
            FrmAttendance objForm = new FrmAttendance();
            CloseForm();
            OpenForm(objForm);

        }
        //�ɼ����ٲ�ѯ��Ƕ����ʾ��
        private void tsmiQuery_Click(object sender, EventArgs e)
        {
            FrmScoreQuery objForm = new FrmScoreQuery();
            CloseForm();
            OpenForm(objForm);

        }
        //ѧԱ����Ƕ����ʾ��
        private void tsmiManageStudent_Click(object sender, EventArgs e)
        {
            FrmStudentManage objForm = new FrmStudentManage();
            CloseForm();
            OpenForm(objForm);

        }
        //��ʾ�ɼ���ѯ���������    
        private void tsmiQueryAndAnalysis_Click(object sender, EventArgs e)
        {
            FrmScoreManage objForm = new FrmScoreManage();
            CloseForm();
            OpenForm(objForm);
        }
        //���ڲ�ѯ
        private void tsmi_AQuery_Click(object sender, EventArgs e)
        {
            FrmAttendanceQuery objForm = new FrmAttendanceQuery();
            CloseForm();
            OpenForm(objForm);
        }
        #endregion

        #region �˳�ϵͳȷ��

        //�˳�ϵͳ
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// �˳�ϵͳǰȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resut = MessageBox.Show("ȷ��Ҫ�˳���", "�˳�ȷ����", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resut == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region ����

        //�����޸�
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
     
        //���ʹ���
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