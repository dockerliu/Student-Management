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
        DataTable dt;
        public FrmScoreQuery()
        {
            InitializeComponent();
            cboClass.DataSource = objClass.GetClasses();
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassID";
            cboClass.SelectedIndex = -1;
            dt = objScore.GetScoreByClassName();
        }  
   
        //根据班级名称动态筛选
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dt == null) return;
            dgvScoreList.DataSource = null;
            dt.DefaultView.RowFilter =string.Format("ClassName like '{0}'",cboClass.Text);
                dgvScoreList.DataSource = dt;
          
            
        }
        //显示全部成绩
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dgvScoreList.AutoGenerateColumns = false;
            dgvScoreList.DataSource = objScore.GetScoreList("");
        }
        //根据C#成绩动态筛选
        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            if (dt == null||txtScore.Text.Trim().Length<1) return;
            dgvScoreList.DataSource = null;
            dt.DefaultView.RowFilter = string.Format("CSharp > '{0}'", txtScore.Text);
            dgvScoreList.DataSource = dt;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

