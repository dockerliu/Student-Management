using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class StudentClassService
    {
        /// <summary>
        /// 获取学生班级
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetClasses()
        {
            string sql = "SELECT ClassId,ClassName FROM StudentClass ";
            MySqlDataReader objReader= SQLHelper.GetReader(sql);
            List<StudentClass> list = new List<StudentClass>();
            while (objReader.Read())
            {
                list.Add(new StudentClass()
                {
                    ClassId = Convert.ToInt32(objReader["ClassId"]),
                    ClassName = objReader["ClassName"].ToString()
                }); 
            }
            objReader.Close();
            return list;
        }
    }
}
