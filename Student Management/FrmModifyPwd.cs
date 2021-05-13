using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace StudentManager
{
    public partial class FrmModifyPwd : Form
    {
        public FrmModifyPwd()
        {
            InitializeComponent();
        }
        AdminService AdminService = new AdminService();

        //修改密码
        private void btnModify_Click(object sender, EventArgs e)
        {
            //校验旧密码是否正确
            if (txtOldPwd.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入原密码！", "修改提示");
                txtOldPwd.Focus();
                return;
            }
            if (txtOldPwd.Text.Trim() != Program.currentAmin.LoginPwd)
            {
                MessageBox.Show("您输入的原密码不正确！", "修改提示");
                txtOldPwd.Focus();
                txtOldPwd.SelectAll();
                return;
            }
            if (txtNewPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入新密码！", "修改提示");
                txtNewPwd.Focus();
                return;
            }
            if (txtNewPwd.Text.Trim()!=txtNewPwdConfirm.Text.Trim())
            {
                MessageBox.Show("两次输入新密码不一致！请重新输入新密码！", "修改提示");
                txtNewPwd.Focus();
                return;
            }

            //将新密码更新到数据库
            if( AdminService.ModifyPwd(Program.currentAmin.LoginId.ToString(), txtNewPwd.Text.Trim()) > 0)
            { 
                MessageBox.Show("密码修改成功！请妥善保管！", "修改提示");
                Program.currentAmin.LoginPwd = txtNewPwd.Text.Trim();
                Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
