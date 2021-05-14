using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using Models.Ext;

namespace StudentManager
{
    public partial class FrmScoreQuery : Form
    {
        StudentClassService objClass = new StudentClassService();
        ScoreListService objScore = new ScoreListService();
        public FrmScoreQuery()
        {
            InitializeComponent();
            cboClass.DataSource = objClass.GetClasses();
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassID";
            cboClass.SelectedIndex = -1;

        }  
   
        //根据班级名称动态筛选
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvScoreList.DataSource
        }
        //显示全部成绩
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dgvScoreList.AutoGenerateColumns = false;
            List<StudentExt> list= objScore.GetScoreList("");
            //list = (StudentExt)list.SelectMany(a => a.ClassName = cboClass.Text);
            dgvScoreList.DataSource = objScore.GetScoreList("");
        }
        //根据C#成绩动态筛选
        private void txtScore_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

