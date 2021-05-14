/*----------------------------------------------- 
// DockerLiu版权所有。 
// 文件名： 
// 文件功能描述： 
// 创建标识： 
// 修改标识： 
// 修改描述： 
//-----------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary> 
/// 作者:DockerLiu
/// 邮箱:DockerLiu2019@Gmail.com 
/// 网站：www.68s.org 
/// </summary>
namespace DAL
{
    /// <summary>
    /// 考勤数据访问类
    /// </summary>
   public class AttendanceService
    {
        /// <summary>
        /// 获取学员总人数
        /// </summary>
        /// <returns></returns>
        public int GetAllStudent()
        {
            string sql = "select count(1) from Students";
            try
            {
                return Convert.ToInt32( SQLHelper.GetSingleResult(sql));
            }
            catch (Exception ex)
            {

                throw new Exception("暂时无法获取学员总数:"+ex.Message);
            }
        }
        /// <summary>
        /// 查询打卡学员人数
        /// </summary>
        /// <param name="dt">需要查询的日期</param>
        /// <param name="IsToday">是否是今天</param>
        /// <returns></returns>
        public int GetAttendStudents(DateTime dt,bool IsToday)
        {
            DateTime dt1;
            if (IsToday)
            {
                dt1 =Convert.ToDateTime( SQLHelper.GetServerTime().ToShortDateString());
            }
            else
            {
                dt1 = dt;
            }
            DateTime dt2 = dt1.AddDays(1);//结束时间是当前时间加1天
            string sql = "SELECT COUNT(DISTINCT(CardNo)) FROM Attendance WHERE DTime BETWEEN '{0}' AND '{1}'";
            sql = string.Format(sql, dt1, dt2);

            try
            {
                return Convert.ToInt32( SQLHelper.GetSingleResult(sql));
            }
            catch (Exception ex)
            {

                throw new Exception("获取数据失败:"+ex.Message);
            }


        }
        /// <summary>
        /// 新增考勤记录
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public string AddRecord(string cardNo)
        {
            string sql = "INSERT INTO Attendance(CardNo,DTime) VALUES('{0}','{1}')";
            sql = string.Format(sql, cardNo, DateTime.Now);
            try
            {
                SQLHelper.Update(sql);
                return "Success";
            }
            catch (Exception ex)
            {
                return "打卡失败,请联系管理员:" + ex.Message;
            }
        }

    }
}
