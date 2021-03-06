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
            //初始化班级
            cboClass.DataSource = ojbStudentClass.GetClasses();
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassId";
            cboClass.SelectedIndex = -1;
        }
        //按照班级查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要查询的班级!", "查询提示:");
                return;
            }
            list = objStudnetService.GetStudentsByClassId(cboClass.SelectedValue.ToString());
            dgvStudentList.AutoGenerateColumns = false;
            dgvStudentList.DataSource = list;

        }
        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            if (txtStudentId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入要查询的学号!", "查询提示:");
                return;
            }
            StudentExt objStudent = objStudnetService.GetStudentByStuID(txtStudentId.Text.Trim());
            FrmStudentInfo studentInfo = new FrmStudentInfo(objStudent);
            studentInfo.Show();

        }
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {

        }
        //双击选中的学员对象并显示详细信息
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //修改学员对象
        private void btnEidt_Click(object sender, EventArgs e)
        {
            if (dgvStudentList.RowCount == 0 || dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("没有要修改的学员信息!", "打印提示:");
                return;
            }
            //修改学员信息
            string stuid = dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            StudentExt objStudentExt = objStudnetService.GetStudentByStuID(stuid);
            objStudentExt.StudentId = Convert.ToInt32(stuid);
            //显示修改窗体
            FrmEditStudent frmEditStudent = new FrmEditStudent(objStudentExt);
            DialogResult result= frmEditStudent.ShowDialog();
            if (result==DialogResult.Cancel)
            {
                btnQuery_Click(null, null);
            }
        }
        //删除学员对象
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvStudentList.RowCount == 0 || dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("没有要删除的学员信息!", "删除提示:");
                
                return;
            }
            //删除学员信息确定
            if ((MessageBox.Show("确定要删除 ["+dgvStudentList.CurrentRow.Cells["StudentName"].Value.ToString()+"] 吗？","删除提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes))
            {
                string studentID = dgvStudentList.CurrentRow.Cells["studentID"].Value.ToString();
                //根据学号删除信息
                if (objStudnetService.DeleteByStudentID(studentID))
                {
                    MessageBox.Show("删除的学员成功!", "删除提示:");

                    btnQuery_Click(null, null);
                }
            }
        }
        //姓名降序
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
        //学号降序
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
        //添加行号
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(dgvStudentList, e);
        }
        //打印当前学员信息
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvStudentList.RowCount == 0||dgvStudentList.CurrentRow==null)
            {
                MessageBox.Show("没有要打印的学员信息!", "打印提示:");
                return;
            }
            //打印学员信息
            string stuid = dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            StudentExt objStudentExt = objStudnetService.GetStudentByStuID(stuid);
            objStudentExt.StudentId = Convert.ToInt32( stuid);
            //调用Excel模板实现打印
            new PrintStudent().ExecutePrint(objStudentExt);
        }
     
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
    #region 实现排序
    /// <summary>
    /// 按学生I名字降序排列
    /// </summary>
    class NameDESC : IComparer<StudentExt>
    {
        public int Compare(StudentExt x, StudentExt y)
        {
            return y.StudentName.CompareTo(x.StudentName);
        }
    }
    /// <summary>
    /// 按学生ID降序排列
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