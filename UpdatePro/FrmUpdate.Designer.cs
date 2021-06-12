
namespace UpdatePro
{
    partial class FrmUpdate
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastUpdateTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lvUpdateList = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUpdateStatus = new System.Windows.Forms.Label();
            this.lblTips = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbDownLoadFile = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = global::UpdatePro.Properties.Resources.update;
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(41, 28);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(69, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "软件自动升级程序";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(69, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前版本：";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVersion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblVersion.Location = new System.Drawing.Point(142, 78);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(56, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "1.0.0.2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(220, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "上次更新时间：";
            // 
            // lblLastUpdateTime
            // 
            this.lblLastUpdateTime.AutoSize = true;
            this.lblLastUpdateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblLastUpdateTime.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLastUpdateTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLastUpdateTime.Location = new System.Drawing.Point(324, 78);
            this.lblLastUpdateTime.Name = "lblLastUpdateTime";
            this.lblLastUpdateTime.Size = new System.Drawing.Size(125, 13);
            this.lblLastUpdateTime.TabIndex = 1;
            this.lblLastUpdateTime.Text = "2017-01-10 10：25";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(550, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "[需要更新的文件列表]";
            // 
            // lvUpdateList
            // 
            this.lvUpdateList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvUpdateList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvUpdateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chContent,
            this.chVersion,
            this.chProgress});
            this.lvUpdateList.FullRowSelect = true;
            this.lvUpdateList.GridLines = true;
            this.lvUpdateList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvUpdateList.HideSelection = false;
            this.lvUpdateList.Location = new System.Drawing.Point(327, 119);
            this.lvUpdateList.Name = "lvUpdateList";
            this.lvUpdateList.Size = new System.Drawing.Size(361, 140);
            this.lvUpdateList.TabIndex = 2;
            this.lvUpdateList.UseCompatibleStateImageBehavior = false;
            this.lvUpdateList.View = System.Windows.Forms.View.Details;
            // 
            // chFileName
            // 
            this.chFileName.Text = "组件名";
            this.chFileName.Width = 200;
            // 
            // chContent
            // 
            this.chContent.Text = "文件大小";
            this.chContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chVersion
            // 
            this.chVersion.Text = "版本号";
            this.chVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chVersion.Width = 50;
            // 
            // chProgress
            // 
            this.chProgress.Text = "进度";
            this.chProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chProgress.Width = 50;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UpdatePro.Properties.Resources.bg;
            this.pictureBox1.Location = new System.Drawing.Point(56, 119);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdateStatus.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpdateStatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUpdateStatus.Location = new System.Drawing.Point(53, 335);
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.Size = new System.Drawing.Size(119, 13);
            this.lblUpdateStatus.TabIndex = 1;
            this.lblUpdateStatus.Text = "正在等待升级中...";
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.BackColor = System.Drawing.Color.Transparent;
            this.lblTips.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTips.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTips.Location = new System.Drawing.Point(330, 273);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(202, 13);
            this.lblTips.TabIndex = 1;
            this.lblTips.Text = "点击“下一步”开始下载更新文件";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(327, 330);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(470, 330);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(613, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbDownLoadFile
            // 
            this.pbDownLoadFile.Location = new System.Drawing.Point(327, 305);
            this.pbDownLoadFile.Name = "pbDownLoadFile";
            this.pbDownLoadFile.Size = new System.Drawing.Size(361, 13);
            this.pbDownLoadFile.TabIndex = 5;
            // 
            // FrmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UpdatePro.Properties.Resources.升级用的背景图;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(707, 369);
            this.Controls.Add(this.pbDownLoadFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lvUpdateList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLastUpdateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.lblUpdateStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "升级管理程序";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLastUpdateTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader chContent;
        private System.Windows.Forms.ColumnHeader chVersion;
        private System.Windows.Forms.ColumnHeader chProgress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUpdateStatus;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar pbDownLoadFile;
        private System.Windows.Forms.ListView lvUpdateList;
    }
}

