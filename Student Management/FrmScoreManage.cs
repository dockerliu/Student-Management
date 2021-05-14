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
        //���ݰ༶��ѯ      
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentClass coSelected = (StudentClass)cboClass.SelectedItem;
            gbStat.Text = "�༶���Գɼ�ͳ��";
           
            dgvScoreList.AutoGenerateColumns = false;
            dgvScoreList.DataSource = objScore.GetScoreList(cboClass.Text);
            Dictionary<string, string> scoreDic = new Dictionary<string, string>();
            if (cboClass.SelectedIndex != -1)
            {
               
                //ͳ��ƽ������
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
            //��ʾȱ����Ա
            lblList.DataSource = null;
            if ( cboClass.SelectedIndex != -1)
            {
                lblList.DataSource = objScore.GetAbsentList(coSelected.ClassId.ToString());
            }
            else
            lblList.DataSource = objScore.GetAbsentList();
        }
        //ͳ��ȫУ���Գɼ�
        private void btnStat_Click(object sender, EventArgs e)
        {
            gbStat.Text = "ȫУ���Գɼ�ͳ��";
            dgvScoreList.AutoGenerateColumns = false;
            dgvScoreList.DataSource = objScore.GetScoreList("");
            //ͳ��ƽ������
            Dictionary<string, string> scoreDic = objScore.GetScoreInfo();
            lblAttendCount.Text = scoreDic["stuCount"];
            lblDBAvg.Text = scoreDic["avgSql"];
            lblCSharpAvg.Text = scoreDic["avgCsharp"];
            lblCount.Text =scoreDic["absentCount"];

            //��ʾȱ����Ա
            lblList.DataSource = null;
            lblList.DataSource = objScore.GetAbsentList();
        }
        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}