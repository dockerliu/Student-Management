using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using Models.Ext;

namespace StudentManager
{
  
    public partial class FrmAttendance : Form
    {
        Timer timer = new Timer();
        AttendanceService objAttendanceService = new AttendanceService();
        StudentService objStudentService = new StudentService();
        public FrmAttendance()
        {
            InitializeComponent();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick;
            lblCount.Text = objAttendanceService.GetAllStudent().ToString();
            ShowStat();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblYear.Text = DateTime.Now.Year.ToString();//年
            lblMonth.Text = DateTime.Now.Month.ToString();//月
            lblDay.Text = DateTime.Now.Day.ToString();//日
            lblTime.Text = DateTime.Now.ToLongTimeString();//时间
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    lblWeek.Text = "日";
                    break;
                case DayOfWeek.Monday:
                    lblWeek.Text = "一";
                    break;
                case DayOfWeek.Tuesday:
                    lblWeek.Text = "二";
                    break;
                case DayOfWeek.Wednesday:
                    lblWeek.Text = "三";
                    break;
                case DayOfWeek.Thursday:
                    lblWeek.Text = "四";
                    break;
                case DayOfWeek.Friday:
                    lblWeek.Text = "五";
                    break;
                case DayOfWeek.Saturday:
                    lblWeek.Text = "六";
                    break;
                default:
                    lblWeek.Text = "0";
                    break;
            }
        }

        //显示当前时间
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
        //学员打卡        
        private void txtStuCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtStuCardNo.Text.Trim().Length == 0|| e.KeyValue!=13)
                           return;
            //显示学员信息
            StudentExt objStudent = objStudentService.GetStudentByCardNo(txtStuCardNo.Text.Trim());
            if (objStudent.StudentName==null)
            {
                MessageBox.Show("卡号不正确,请重新打卡!","打卡提示:");
                lblInfo.Text = "打卡失败!";
                txtStuCardNo.SelectAll();
                lblStuName.Text = "";
                lblStuClass.Text = "";
                lblStuId.Text = "";
                pbStu.Image = null;
            }
            else
            {
                lblInfo.Text = "打卡成功!";               
                lblStuName.Text = objStudent.StudentName;
                lblStuClass.Text = objStudent.ClassName;
                lblStuId.Text = objStudent.StudentId.ToString();
                pbStu.Image =objStudent.StuImage.Trim().Length==0?
                    Image.FromFile("default.png")
                    : (Image) new SerializeObjectToString().DeserializeObject(objStudent.StuImage);
                //添加打卡信息
                string result = objAttendanceService.AddRecord(txtStuCardNo.Text.Trim());
                if (result!= "Success")
                {
                    lblInfo.Text = "打卡失败!";
                    MessageBox.Show(result, "打卡提示:");
                }
                else
                {
                    lblInfo.Text = "打卡成功!";
                    ShowStat();//更新打卡人数
                    txtStuCardNo.Text = "";
                    txtStuCardNo.Focus();
                }
            }


        }
        //结束打卡
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 显示出勤总数和应到人总数
        /// </summary>
        void ShowStat()
        {
            
            lblReal.Text = objAttendanceService.GetAttendStudents(DateTime.Now, true).ToString();
            lblAbsenceCount.Text =( Convert.ToInt32(lblCount.Text) - Convert.ToInt32(lblReal.Text)).ToString();

        }
     
    }
}
