using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Models;
using Models.Ext;
using MySql.Data.MySqlClient;

namespace DAL
{
    /// <summary>
    /// 学员数据访问类
    /// </summary>
    public class StudentService
    {
        /// <summary>
        /// 验证学生身份证是否有重复
        /// </summary>
        /// <param name="IDCard"></param>
        /// <returns></returns>
        public bool IsIDCardExisted(string IDCard)
        {
            string sql = "select count(1) from Students where StudentIdNo={0}";
            sql = string.Format(sql, IDCard);
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql)) > 0;
        }
        /// <summary>
        /// 验证学生卡号是否有重复
        /// </summary>
        /// <param name="IDCard"></param>
        /// <returns></returns>
        public bool IsCardExisted(string CardNo)
        {
            string sql = "select count(1) from Students where CardNo={0}";
            sql = string.Format(sql, CardNo);
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql)) > 0;
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int AddStudent(Student student)
        {
            string sql = "INSERT INTO Students(StudentName,Age,Gender,Birthday,CardNo,ClassId,StudentIdNo,PhoneNumber,StudentAddress,StuImage ) ";
            sql += "VALUES('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
            sql = string.Format(sql, student.StudentName,student.Age,student.Gender,student.Birthday,student.CardNo,student.ClassId,student.StudentIdNo,student.PhoneNumber,student.StudentAddress,student.StuImage);
            try
            {

                return SQLHelper.Update(sql);

            }
            catch (Exception ex)
            {

                throw new Exception("保存数据错误!"+ex.Message);
            }
        }

        /// <summary>
        /// 根据班级编号查询学员信息
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public List<StudentExt>  GetStudentsByClassId(string ClassID)
        {
            string sql = "SELECT  StudentId,StudentName,Gender,Birthday,className FROM Students";
            sql += " INNER JOIN StudentClass ON Students.ClassId=StudentClass.ClassId";
            sql += " WHERE Students.ClassId=" + ClassID;
            MySqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentExt> list = new List<StudentExt>();
            while (objReader.Read())
            {
                list.Add(new StudentExt
                {
                    StudentId=Convert.ToInt32(objReader["StudentId"]),
                    StudentName=objReader["StudentName"].ToString(),
                    Gender=objReader["Gender"].ToString(),
                    Birthday=Convert.ToDateTime(objReader["Birthday"]),
                    ClassName=objReader["ClassName"].ToString()
                });
            }

            return list;
        }
        /// <summary>
        /// 根据学号查询学生信息
        /// </summary>
        /// <param name="StuID"></param>
        /// <returns></returns>
        public StudentExt GetStudentByStuID(string StuID)
        {
            string sql = "SELECT   StudentName,Age,Gender,Birthday,CardNo,ClassName,StudentIdNo,PhoneNumber,StudentAddress,StuImage  FROM Students";
            sql += " INNER JOIN StudentClass ON Students.ClassId=StudentClass.ClassId";
            sql += " WHERE Students.StudentId=" + StuID;

            MySqlDataReader objReader = SQLHelper.GetReader(sql);
            StudentExt studentExt = new StudentExt();
            if (objReader.Read())
            {
                studentExt=  new StudentExt
               {
                    StudentName = objReader["StudentName"].ToString(),
                    Age = Convert.ToInt32( objReader["Age"]),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    CardNo = objReader["CardNo"].ToString(),
                    ClassName = objReader["ClassName"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    StuImage = objReader["StuImage"].ToString(),
                }; 
            }

            return studentExt;
        }
    }
}
