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
    /// 成绩方法
    /// </summary>
    public class ScoreListService
    {
        /// <summary>
        /// 获取全校全部成绩
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<StudentExt> GetScoreList(string className)
        {
            string sql = "SELECT Students.StudentId,StudentName,ClassName,CSharp,SQLServerDB FROM Students ";
            sql += "INNER JOIN StudentClass ON Students.ClassId=StudentClass.ClassId ";
            sql += "INNER JOIN ScoreList ON ScoreList.StudentId=Students.StudentId ";
            if (className!=null&& className.Length>0)
            {
                sql += " where ClassName='{0}'";
                sql = string.Format(sql, className);

            }

            MySqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentExt> list =new List<StudentExt>(); ;
            while (objReader.Read())
            {
               
                list .Add( new StudentExt { 
                StudentId=Convert.ToInt32(objReader["StudentId"]),
                StudentName=objReader["StudentName"].ToString(),
                ClassName=objReader["ClassName"].ToString(),
                CSharp=objReader["CSharp"].ToString(),
                SQLServerDB=objReader["SQLServerDB"].ToString(),

                });
            }objReader.Close();
            return list;
        }

        /// <summary>
        /// 获取平均分和缺考人数
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> GetScoreInfo(string ClassID="")
        {
            string sql;
            if (ClassID!="")
            {
                sql = "SELECT COUNT(1) stuCount, AVG(CSharp) avgCsharp, AVG(SQLServerDB) avgSql FROM ScoreList INNER JOIN Students WHERE Students.StudentId = ScoreList.StudentId AND ClassId =  "+ClassID+";";
                sql += "SELECT COUNT(1) as absentCount FROM Students WHERE StudentId NOT IN (SELECT StudentId FROM ScoreList)  AND ClassId ="+ClassID;
            }
            else
            {
                sql = "SELECT  COUNT(1) stuCount,AVG(CSharp) avgCsharp,AVG(SQLServerDB) avgSql  FROM ScoreList; ";
                sql += "SELECT COUNT(1) as absentCount FROM Students WHERE StudentId NOT IN (SELECT StudentId FROM ScoreList)";
            }
            Dictionary<string, string> scoreList = new Dictionary<string, string>();
            MySqlDataReader objReader = SQLHelper.GetReader(sql);
            if (objReader.Read())
            {
                scoreList.Add("stuCount", objReader["stuCount"].ToString());
                scoreList.Add("avgCsharp", objReader["avgCsharp"].ToString());
                scoreList.Add("avgSql", objReader["avgSql"].ToString());
            }
            if (objReader.NextResult())//跳转到另一个结果集
            {
                if (objReader.Read())
                {

                scoreList.Add("absentCount", objReader["absentCount"].ToString());
                }
            }

            return scoreList;
        }
        /// <summary>
        /// 获取未参加考试的学员姓名
        /// </summary>
        /// <returns></returns>
        public List<string > GetAbsentList(string classid="")
        {
            string sql = "SELECT StudentName  FROM Students WHERE StudentId NOT IN (SELECT StudentId FROM ScoreList)";
            if (classid!="")
            {
                sql += " AND ClassId = " + classid;
            }
            MySqlDataReader objReader = SQLHelper.GetReader(sql);
            List<string> list = new List<string>();
            while (objReader.Read())
            {
                list.Add(objReader["StudentName"].ToString());
            }

            objReader.Close();
            return list;
        }

       public DataTable GetScoreByClassName()
        {
            string sql = "SELECT Students.StudentId,StudentName,ClassName,CSharp,SQLServerDB FROM Students ";
            sql += "INNER JOIN StudentClass ON Students.ClassId=StudentClass.ClassId ";
            sql += "INNER JOIN ScoreList ON ScoreList.StudentId=Students.StudentId ";
            
            return SQLHelper.GetByClassName(sql);
        }
    }
}
