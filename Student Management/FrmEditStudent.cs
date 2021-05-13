using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Models.Ext;
using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmEditStudent : Form
    {
        StudentClassService objClassservice = new StudentClassService();
        StudentService objStudnetservice = new StudentService();
        public FrmEditStudent()
        {
            InitializeComponent();
        }

        public FrmEditStudent(StudentExt studentext)
        {
            InitializeComponent();
            //��ʼ������
            txtStudentId.Text = studentext.StudentId.ToString();
            txtAddress.Text = studentext.StudentAddress;
            dtpBirthday.Text = studentext.Birthday.ToShortDateString();
            txtCardNo.Text = studentext.CardNo;
            cboClassName.Text = studentext.ClassName;
            
            txtPhoneNumber.Text = studentext.PhoneNumber;
            txtStudentIdNo.Text = studentext.StudentIdNo;
            txtStudentName.Text = studentext.StudentName;
            pbStu.Image = studentext.StuImage.Length == 0 ? Image.FromFile("default.png") : (Image)new SerializeObjectToString().DeserializeObject(studentext.StuImage);

            if (studentext.Gender == "��") this.rdoMale.Checked = true;
            else rdoFemale.Checked = true;
            //��ʼ���༶������
            cboClassName.DataSource = objClassservice.GetClasses();
            cboClassName.DisplayMember = "ClassName";
            cboClassName.ValueMember = "ClassID";
            cboClassName.Text = studentext.ClassName;
        }


        //�ύ�޸�
        private void btnModify_Click(object sender, EventArgs e)
        {
            //������֤
            if (txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("����дѧԱ����!", "��֤��ʾ:");
                txtStudentName.Focus();
                return;
            }
            if (!rdoFemale.Checked && !rdoMale.Checked)
            {
                MessageBox.Show("��ѡ��ѧԱ�Ա�!", "��֤��ʾ:");

                return;
            }
            if ((DateTime.Now.Year - Convert.ToDateTime(dtpBirthday.Text).Year) < 18)
            {
                MessageBox.Show("ѧԱ���䲻��С��18��,���޸ĳ�������!", "��֤��ʾ:");
                dtpBirthday.Focus();
                return;
            }
            if (cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��ѧԱ�༶!", "��֤��ʾ:");
                cboClassName.Focus();
                return;
            }
            if (txtStudentIdNo.Text.Trim().Length < 18)
            {
                MessageBox.Show("ѧԱ���֤�Ų���ȷ,����18λ!", "��֤��ʾ:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }
            if (!DataValidate.IsIdentityCard(txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("ѧԱ���֤�Ų���ȷ!", "��֤��ʾ:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }
            //��֤���֤��������������Ǻ�
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
            }
            else
                day = Convert.ToDateTime(dtpBirthday.Text).Day.ToString();
            string birthDay = Convert.ToDateTime(dtpBirthday.Text).Year + month + day;

            if (!txtStudentIdNo.Text.Trim().Contains(birthDay))
            {
                MessageBox.Show("ѧԱ���֤����������ڲ�ƥ��!", "��֤��ʾ:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }

            //��֤ѧ�����֤�Ƿ��ظ�
            if (objStudnetservice.IsIDCardExisted(txtStudentIdNo.Text.Trim(),txtStudentId.Text.Trim()))
            {
                MessageBox.Show("ѧԱ���֤�����ظ�!", "��֤��ʾ:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }
            if (txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("������ѧԱ����!", "��֤��ʾ:");
                txtCardNo.Focus();
                return;
            }
            //��֤ѧ�������Ƿ��ظ�
            if (objStudnetservice.IsCardExisted(txtCardNo.Text.Trim(), txtStudentId.Text.Trim()))
            {
                MessageBox.Show("ѧԱ�������ظ�!", "��֤��ʾ:");
                txtCardNo.Focus();
                txtCardNo.SelectAll();
                return;
            }

            //��װѧ����Ϣ
            Student student = new Student()
            {
                StudentName = txtStudentName.Text.Trim(),
                Gender = rdoMale.Checked ? "��" : "Ů",
                Birthday = Convert.ToDateTime(dtpBirthday.Text),
                Age = DateTime.Now.Year - Convert.ToDateTime(dtpBirthday.Text).Year,
                ClassId = Convert.ToInt32(cboClassName.SelectedValue),
                StudentIdNo = txtStudentIdNo.Text.Trim(),
                CardNo = txtCardNo.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                StudentAddress = txtAddress.Text.Trim(),
                StudentId = Convert.ToInt32(txtStudentId.Text.Trim()),

                StuImage = pbStu.Image == null ? "" : new SerializeObjectToString().SerializeObject(pbStu.Image)
            };

            //�ύ����
            try
            {

               
                //�ж��Ƿ񱣴�ɹ�
                if (objStudnetservice.ModifyStudent(student))
                {
                    MessageBox.Show("ѧԱ�޸ĳɹ�!", "�޸���ʾ:");
                    
                        Close();
                }
                else
                {
                    MessageBox.Show("�޸�ʧ��!", "�޸���ʾ:");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("�޸�ʧ��" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //ѡ����Ƭ
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if (result==DialogResult.OK)
            {
                pbStu.Image = Image.FromFile(fileDialog.FileName);
            }

        }
     
    }
}