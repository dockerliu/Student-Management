using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DAL;
using Models;
using Models.Ext;

namespace StudentManager
{
    public partial class FrmStudentManage : Form
    {
        StudentClassService ojbStudentClass = new StudentClassService();
        StudentService objStudnetService = new StudentService();
        List<StudentExt> list;
        public FrmStudentManage()
        {

            InitializeComponent();
            //��ʼ���༶
            cboClass.DataSource = ojbStudentClass.GetClasses();
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassId";
            cboClass.SelectedIndex = -1;
        }
        //���հ༶��ѯ
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��Ҫ��ѯ�İ༶!", "��ѯ��ʾ:");
                return;
            }
            list = objStudnetService.GetStudentsByClassId(cboClass.SelectedValue.ToString());
            dgvStudentList.AutoGenerateColumns = false;
            dgvStudentList.DataSource = list;

        }
        //����ѧ�Ų�ѯ
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            if (txtStudentId.Text.Trim().Length == 0)
            {
                MessageBox.Show("������Ҫ��ѯ��ѧ��!", "��ѯ��ʾ:");
                return;
            }
            StudentExt objStudent = objStudnetService.GetStudentByStuID(txtStudentId.Text.Trim());
            FrmStudentInfo studentInfo = new FrmStudentInfo(objStudent);
            studentInfo.Show();

        }
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {

        }
        //˫��ѡ�е�ѧԱ������ʾ��ϸ��Ϣ
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //�޸�ѧԱ����
        private void btnEidt_Click(object sender, EventArgs e)
        {

        }
        //ɾ��ѧԱ����
        private void btnDel_Click(object sender, EventArgs e)
        {

        }
        //��������
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
            if (dgvStudentList.RowCount == 0)
            {
                return;
            }
            list.Sort(new NameDESC());
            dgvStudentList.DataSource = null;
            dgvStudentList.DataSource = list;
        }
        //ѧ�Ž���
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {
            if (dgvStudentList.RowCount == 0)
            {
                return;
            }
            list.Sort(new StuIDDESC());
            dgvStudentList.DataSource = null;
            dgvStudentList.DataSource = list;
        }
        //����к�
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(dgvStudentList, e);
        }
        //��ӡ��ǰѧԱ��Ϣ
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvStudentList.RowCount == 0||dgvStudentList.CurrentRow==null)
            {
                MessageBox.Show("û��Ҫ��ӡ��ѧԱ��Ϣ!", "��ӡ��ʾ:");
                return;
            }
            //��ӡѧԱ��Ϣ
            string stuid = dgvStudentList.CurrentRow.Cells["ѧ��"].Value.ToString();
            MessageBox.Show(stuid);
        }
     
        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
    #region ʵ������
    /// <summary>
    /// ��ѧ��I���ֽ�������
    /// </summary>
    class NameDESC : IComparer<StudentExt>
    {
        public int Compare(StudentExt x, StudentExt y)
        {
            return y.StudentName.CompareTo(x.StudentName);
        }
    }
    /// <summary>
    /// ��ѧ��ID��������
    /// </summary>
    class StuIDDESC : IComparer<StudentExt>
    {
        public int Compare(StudentExt x, StudentExt y)
        {
            return y.StudentId.CompareTo(x.StudentId);
        }
    }

    #endregion
}