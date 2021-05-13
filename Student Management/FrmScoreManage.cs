using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace StudentManager
{
    public partial class FrmScoreManage : Form
    {
        public FrmScoreManage()
        {
            InitializeComponent();
        }
        //根据班级查询      
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //统计全校考试成绩
        private void btnStat_Click(object sender, EventArgs e)
        {

        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}