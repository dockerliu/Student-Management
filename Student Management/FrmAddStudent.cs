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
        StudentService objStudnetService = new StudentService();
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
            //数据验证
            if (txtStudentName.Text.Trim().Length==0)
            {
                MessageBox.Show("请填写学员姓名!","验证提示:");
                txtStudentName.Focus();
                return;
            }
            if (!rdoFemale.Checked&&!rdoMale.Checked)
            {
                MessageBox.Show("请选择学员性别!", "验证提示:");
               
                return;
            }
            if ((DateTime.Now.Year-Convert.ToDateTime(dtpBirthday.Text).Year)<18)
            {
                MessageBox.Show("学员年龄不能小于18岁,请修改出生日期!", "验证提示:");
                dtpBirthday.Focus();
                return;
            }
            if (cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择学员班级!", "验证提示:");
                cboClassName.Focus();
                return;
            }
            if (txtStudentIdNo.Text.Trim().Length<18)
            {
                MessageBox.Show("学员身份证号不正确,不够18位!", "验证提示:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }
            if (!DataValidate.IsIdentityCard(txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("学员身份证号不正确!", "验证提示:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }
            //验证身份证号与出生日期相吻合
            string month = string.Empty;
            string day = string.Empty;
            if (Convert.ToDateTime(dtpBirthday.Text).Month < 10)
            {
                month = "0" + Convert.ToDateTime(dtpBirthday.Text).Month;
            }
            else
                month = Convert.ToDateTime(dtpBirthday.Text).Month.ToString();
            if (Convert.ToDateTime(dtpBirthday.Text).Day < 10)
            {
                day = "0" + Convert.ToDateTime(dtpBirthday.Text).Day;
            }else
                day =  Convert.ToDateTime(dtpBirthday.Text).Day.ToString();
            string birthDay= Convert.ToDateTime(dtpBirthday.Text).Year+month+day;

            if (!txtStudentIdNo.Text.Trim().Contains(birthDay))
            {
                MessageBox.Show("学员身份证号与出生日期不匹配!", "验证提示:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }

            //验证学生身份证是否重复
            if (objStudnetService.IsIDCardExisted(txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("学员身份证号有重复!", "验证提示:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }
            if (txtCardNo.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入学员卡号!", "验证提示:");
                txtCardNo.Focus();
                return;
            }
            //验证学生卡号是否重复
            if (objStudnetService.IsCardExisted(txtCardNo.Text.Trim()))
            {
                MessageBox.Show("学员卡号有重复!", "验证提示:");
                txtCardNo.Focus();
                txtCardNo.SelectAll();
                return;
            }

            //封装学生信息
            Student student = new Student()
            {
                StudentName = txtStudentName.Text.Trim(),
                Gender = rdoMale.Checked ? "男" : "女",
                Birthday = Convert.ToDateTime(dtpBirthday.Text),
                Age = DateTime.Now.Year - Convert.ToDateTime(dtpBirthday.Text).Year,
                ClassId = Convert.ToInt32(cboClassName.SelectedValue),
                StudentIdNo = txtStudentIdNo.Text.Trim(),
                CardNo=txtCardNo.Text.Trim(),
                PhoneNumber=txtPhoneNumber.Text.Trim(),
                StudentAddress=txtAddress.Text.Trim(),
                
                StuImage =pbStu.Image==null?"":new SerializeObjectToString().SerializeObject(pbStu.Image)
            };

            //提交对象
            try
            {

                int objAdd = objStudnetService.AddStudent(student);
                //判断是否保存成功
                if (objAdd > 0)
                {
                    DialogResult result = MessageBox.Show("学员添加成功!是否继续添加?", "添加提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        foreach (Control item in gbStudent.Controls)
                        {
                            if (item is TextBox)
                            {
                                item.Text = "";
                            }
                            else if (item is RadioButton)
                            {
                                ((RadioButton)item).Checked = false;
                            }
                            else if (item is ComboBox)
                            {
                                ((ComboBox)item).SelectedIndex = -1;
                            }
                        }
                        pbStu.Image = null;
                        dtpBirthday.Text = DateTime.Now.ToString();
                    }
                    else
                        Close();

                }
                else
                {
                    MessageBox.Show("添加失败!", "添加提示:");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("添加失败" + ex.Message);
            }

        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        //选择新照片
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                pbStu.Image = Image.FromFile(openFile.FileName);
            }
        }
    }
}