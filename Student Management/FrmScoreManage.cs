using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DAL;
using Models;


namespace StudentManager
{
    public partial class FrmScoreManage : Form
    {
        StudentClassService objClass = new StudentClassService();
        ScoreListService objScore = new ScoreListService();
        public FrmScoreManage()
        {
            InitializeComponent();
            cboClass.DataSource = objClass.GetClasses();
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassID";
            cboClass.SelectedIndex = -1;
        }
        //根据班级查询      
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentClass coSelected = (StudentClass)cboClass.SelectedItem;
            gbStat.Text = "班级考试成绩统计";
           
            dgvScoreList.AutoGenerateColumns = false;
            dgvScoreList.DataSource = objScore.GetScoreList(cboClass.Text);
            Dictionary<string, string> scoreDic = new Dictionary<string, string>();
            if (cboClass.SelectedIndex != -1)
            {
               
                //统计平均分数
                scoreDic = objScore.GetScoreInfo(coSelected.ClassId.ToString());
            }
            else
            {
                scoreDic = objScore.GetScoreInfo();
            }
          
            lblAttendCount.Text = scoreDic["stuCount"];
            lblDBAvg.Text = scoreDic["avgSql"];
            lblCSharpAvg.Text = scoreDic["avgCsharp"];
            lblCount.Text = scoreDic["absentCount"];
            //显示缺考人员
            lblList.DataSource = null;
            if ( cboClass.SelectedIndex != -1)
            {
                lblList.DataSource = objScore.GetAbsentList(coSelected.ClassId.ToString());
            }
            else
            lblList.DataSource = objScore.GetAbsentList();
        }
        //统计全校考试成绩
        private void btnStat_Click(object sender, EventArgs e)
        {
            gbStat.Text = "全校考试成绩统计";
            dgvScoreList.AutoGenerateColumns = false;
            dgvScoreList.DataSource = objScore.GetScoreList("");
            //统计平均分数
            Dictionary<string, string> scoreDic = objScore.GetScoreInfo();
            lblAttendCount.Text = scoreDic["stuCount"];
            lblDBAvg.Text = scoreDic["avgSql"];
            lblCSharpAvg.Text = scoreDic["avgCsharp"];
            lblCount.Text =scoreDic["absentCount"];

            //显示缺考人员
            lblList.DataSource = null;
            lblList.DataSource = objScore.GetAbsentList();
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}