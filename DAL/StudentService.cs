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
        /// 新增学员验证学生身份证是否有重复
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
        /// 修改学员验证学生身份证是否有重复
        /// </summary>
        /// <param name="IDCard"></param>
        /// <returns></returns>
        public bool IsIDCardExisted(string IDCard,string studentId)
        {
            string sql = "select count(1) from Students where StudentIdNo={0} and StudentId<> {1}";
            sql = string.Format(sql, IDCard,studentId);
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql)) > 0;
        }
        /// <summary>
        /// 新增学员验证学生卡号是否有重复
        /// </summary>
        /// <param name="IDCard"></param>
        /// <returns></returns>
        public bool IsCardExisted(string CardNo, string studentId)
        {
            string sql = "select count(1) from Students where CardNo={0}  and StudentId<> {1}";
            sql = string.Format(sql, CardNo,studentId);
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql)) > 0;
        }
        /// <summary>
        /// 修改学员验证学生卡号是否有重复
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

        /// <summary>
        /// 通过学号修改学生信息
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public bool ModifyStudent(Student objStudent)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("UPDATE Students SET StudentName='{0}',Gender='{1}',Birthday='{2}',");
            sqlBuilder.Append("StudentIdNo='{3}',Age={4},PhoneNumber='{5}',StudentAddress='{6}',CardNo='{7}',ClassId='{8}',StuImage='{9}'");
            sqlBuilder.Append(" WHERE StudentId={10}");
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
                objStudent.Gender,objStudent.Birthday,objStudent.StudentIdNo,
                objStudent.Age,objStudent.PhoneNumber,objStudent.StudentAddress,objStudent.CardNo,
                objStudent.ClassId,objStudent.StuImage,objStudent.StudentId
                );
            try
            {
                return SQLHelper.Update(sql) > 0;
            }
            catch (MySqlException ex)
            {
                //扑捉数据库操作异常
                throw new Exception("保存修改的数据出现错误！"+ex.Message);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据学生学号删除信息
        /// </summary>
        /// <param name="StudentID"></param>
        /// <returns></returns>
        public bool DeleteByStudentID(string StudentID)
        {
            string sql = "DELETE FROM Students WHERE StudentId=" + StudentID;
            try
            {

                return SQLHelper.Update(sql) > 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number==547)
                {
                    throw new Exception("当前学号被其他数据引用，不能直接被删除！"+ex.Message);
                }
                else
                {
                    throw new Exception("删除学员发生错误！" + ex.Message);
                }
                
            }
            catch(Exception ex) { throw new Exception("删除学员失败！"+ex.Message); }
            
        }
           
    }
}
