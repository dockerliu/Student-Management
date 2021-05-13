using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAL;



namespace StudentManager
{
    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
           
           
        }

        AdminService adminService = new AdminService();

        //登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //数据验证
            if (txtLoginId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录账号！", "登录提示：");
                txtLoginId.Focus();
                return;

            }

            if (!DataValidate.IsInteger(txtLoginId.Text.Trim()))
            {
                MessageBox.Show("登录账号必须是正整数！", "登录提示：");
                txtLoginId.Focus();
                txtLoginId.SelectAll();
                return;
            }

            if (txtLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录密码！", "登录提示：");
                txtLoginPwd.Focus();
                return;

            }

            //提交用户信息
            Admin objAdmin = new Admin()
            {
                LoginId = Convert.ToInt32(txtLoginId.Text.Trim()),
                LoginPwd = txtLoginPwd.Text.Trim()
            };
            try
            {

                objAdmin = adminService.AdminLogin(objAdmin);
                if (objAdmin==null)
                {
                    MessageBox.Show("登陆账号或密码错误！", "登陆提示：");
                }
                else
                {
                    Program.currentAmin = objAdmin;//保存当前登陆用户
                    this.DialogResult = DialogResult.OK;//设置当前登陆成功
                    Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("登陆失败！","登陆提示：");
            }
        }
          
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
