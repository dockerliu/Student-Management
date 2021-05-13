using Models.Ext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace StudentManager
{
    public partial class FrmStudentInfo : Form
    {
        public FrmStudentInfo()
        {
            InitializeComponent();
        }
        public FrmStudentInfo(StudentExt studentext)
        {
            InitializeComponent();
            //初始化变量
            lblAddress .Text= studentext.StudentAddress;
            lblBirthday.Text = studentext.Birthday.ToShortDateString();
            lblCardNo.Text = studentext.CardNo;
            lblClass.Text = studentext.ClassName;
            lblGender.Text = studentext.Gender;
            lblPhoneNumber.Text = studentext.PhoneNumber;
            lblStudentIdNo.Text = studentext.StudentIdNo;
            lblStudentName.Text = studentext.StudentName;
            pbStu.Image = studentext.StuImage.Length==0 ? Image.FromFile("default.png") : (Image)new SerializeObjectToString().DeserializeObject(studentext.StuImage);
        }

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}