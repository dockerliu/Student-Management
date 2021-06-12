using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdatePro
{
    public partial class FrmUpdate : Form
    {
        UpdateManager objUpdateManager = new UpdateManager();
        public FrmUpdate()
        {
            InitializeComponent();
        }

        //退出、取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消升级吗？","升级提示：",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                Application.ExitThread();
                Application.Exit();
            }
            Close();
        }
        //完成
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (objUpdateManager.CopyFile())//调用复制方法，复制新文件到程序根目录
                {
                    //启用主程序
                    System.Diagnostics.Process.Start("Student Management.exe");
                    //关闭升级程序
                    Application.ExitThread();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = false;
            try
            {
                lblUpdateStatus.Text = "正在下载更新文件，请稍后...";
                lblTips.Text = "点击'取消'可以结束升级...";
                //开始下载文件，同时异步显示下载百分比
                objUpdateManager.DownLoadFiles();

                lblTips.Text = "全部文件已下载，点‘完成’结束升级。";
                lblUpdateStatus.Visible = false;
                btnCancel.Visible = false;
                btnFinish.Location = btnCancel.Location;
                btnFinish.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Init()
        {
            //1、设置相关按钮
            btnFinish.Visible = false;
            //2、将同步显示进度的方法与委托变量关联
            objUpdateManager.ShowProgressDelegate = ShowUpdateProgress;
            //3、显示需要更新的文件列表
            List<string[]> fileList = objUpdateManager.NowUpdateInfo.fileList;
            foreach (string[] item in fileList)
            {
                lvUpdateList.Items.Add(new ListViewItem(item));
            }
            //4、显示当前版本号和最近一次更新的时间
            lblVersion.Text = objUpdateManager.LastUpdateInfo.Version;
            lblLastUpdateTime.Text = objUpdateManager.LastUpdateInfo.UpdateTime.ToString();

        }

        /// <summary>
        /// 根据委托定义同步显示百分比的方法
        /// </summary>
        /// <param name="fileIndex">文件顺序</param>
        /// <param name="finishedPercent">已经完成的百分比</param>
        void ShowUpdateProgress(int fileIndex,int finishedPercent)
        {
            //在列表框对应的文件信息最后显示下载百分比
            lvUpdateList.Items[fileIndex].SubItems[3].Text = finishedPercent + "%";
            pbDownLoadFile.Maximum = 100;
            pbDownLoadFile.Value = finishedPercent;
        }
    }
}
