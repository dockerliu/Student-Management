using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        StudentClassService ojbStudentClass = new StudentClassService();

        public FrmAddStudent()
        {
            InitializeComponent();
            //��ʼ���༶������
            cboClassName.DataSource = ojbStudentClass.GetClasses();
            cboClassName.DisplayMember = "ClassName";
            cboClassName.ValueMember = "ClassId";
            cboClassName.SelectedIndex = -1;
        }
        //�����ѧԱ

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
          
        }
        //�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        //ѡ������Ƭ
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
         
        }
    }
}