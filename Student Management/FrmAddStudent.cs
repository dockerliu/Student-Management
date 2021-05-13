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
            //��ʼ���༶������
            cboClassName.DataSource = ojbStudentClass.GetClasses();
            cboClassName.DisplayMember = "ClassName";
            cboClassName.ValueMember = "ClassId";
            cboClassName.SelectedIndex = -1;
        }
        //�����ѧԱ

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //������֤
            if (txtStudentName.Text.Trim().Length==0)
            {
                MessageBox.Show("����дѧԱ����!","��֤��ʾ:");
                txtStudentName.Focus();
                return;
            }
            if (!rdoFemale.Checked&&!rdoMale.Checked)
            {
                MessageBox.Show("��ѡ��ѧԱ�Ա�!", "��֤��ʾ:");
               
                return;
            }
            if ((DateTime.Now.Year-Convert.ToDateTime(dtpBirthday.Text).Year)<18)
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
            if (txtStudentIdNo.Text.Trim().Length<18)
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
            }else
                day =  Convert.ToDateTime(dtpBirthday.Text).Day.ToString();
            string birthDay= Convert.ToDateTime(dtpBirthday.Text).Year+month+day;

            if (!txtStudentIdNo.Text.Trim().Contains(birthDay))
            {
                MessageBox.Show("ѧԱ���֤����������ڲ�ƥ��!", "��֤��ʾ:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }

            //��֤ѧ�����֤�Ƿ��ظ�
            if (objStudnetService.IsIDCardExisted(txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("ѧԱ���֤�����ظ�!", "��֤��ʾ:");
                txtStudentIdNo.Focus();
                txtStudentIdNo.SelectAll();
                return;
            }
            if (txtCardNo.Text.Trim().Length==0)
            {
                MessageBox.Show("������ѧԱ����!", "��֤��ʾ:");
                txtCardNo.Focus();
                return;
            }
            //��֤ѧ�������Ƿ��ظ�
            if (objStudnetService.IsCardExisted(txtCardNo.Text.Trim()))
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
                CardNo=txtCardNo.Text.Trim(),
                PhoneNumber=txtPhoneNumber.Text.Trim(),
                StudentAddress=txtAddress.Text.Trim(),
                
                StuImage =pbStu.Image==null?"":new SerializeObjectToString().SerializeObject(pbStu.Image)
            };

            //�ύ����
            try
            {

                int objAdd = objStudnetService.AddStudent(student);
                //�ж��Ƿ񱣴�ɹ�
                if (objAdd > 0)
                {
                    DialogResult result = MessageBox.Show("ѧԱ��ӳɹ�!�Ƿ�������?", "�����ʾ:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    MessageBox.Show("���ʧ��!", "�����ʾ:");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("���ʧ��" + ex.Message);
            }

        }
        //�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        //ѡ������Ƭ
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