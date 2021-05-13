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
            //初始化班级下拉框
            cboClassName.DataSource = ojbStudentClass.GetClasses();
            cboClassName.DisplayMember = "ClassName";
            cboClassName.ValueMember = "ClassId";
            cboClassName.SelectedIndex = -1;
        }
        //添加新学员

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
          
        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        //选择新照片
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
         
        }
    }
}