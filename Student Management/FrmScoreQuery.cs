using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace StudentManager
{
    public partial class FrmScoreQuery : Form
    {      
        public FrmScoreQuery()
        {
            InitializeComponent();
        
        }  
   
        //根据班级名称动态筛选
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }
        //显示全部成绩
        private void btnShowAll_Click(object sender, EventArgs e)
        {
         
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

