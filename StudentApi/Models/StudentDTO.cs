using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StudentApi.Models
{
  public partial class Student
  {
    #region #region Methods 
    private static string connectionString()
    {
      return "Server=localhost;database=XXXXX;user=sa;password=XXXXX";
    }

    public static void Insert(Student student)
    {
      using(SqlConnection sqlConn = new SqlConnection(connectionString()))
      {
        sqlConn.Open();
        
        SqlCommand sqlCommand = new SqlCommand($"INSERT INTO students(name, student_id, grades) VALUES (@name, @student_id, @grades)", sqlConn);
        sqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
        sqlCommand.Parameters["@name"].Value = student.Name;

        sqlCommand.Parameters.AddWithValue("@student_id", student.StudentId);
        sqlCommand.Parameters.AddWithValue("@grades", string.Join(",", student.Grades.ToArray()));
        
        sqlCommand.ExecuteNonQuery();

        sqlConn.Close();
      }
    }
    public static void Update(Student student)
    {
      SqlConnection sqlConn = new SqlConnection(connectionString());
      sqlConn.Open();
      
      SqlCommand sqlCommand = new SqlCommand($"UPDATE students SET name=@name, student_id=@student_id, grades=@grades where id=@id", sqlConn);
      sqlCommand.Parameters.AddWithValue("@id", student.Id);
      sqlCommand.Parameters.AddWithValue("@name", student.Name);
      sqlCommand.Parameters.AddWithValue("@student_id", student.StudentId);
      sqlCommand.Parameters.AddWithValue("@grades", string.Join(",", student.Grades.ToArray()));
      sqlCommand.ExecuteNonQuery();

      sqlConn.Close();
      sqlConn.Dispose();
    }

    public static void RemoveById(int id)
    {
      SqlConnection sqlConn = new SqlConnection(connectionString());
      sqlConn.Open();
      
      SqlCommand sqlCommand = new SqlCommand($"DELETE FROM students WHERE id={id}", sqlConn);
      sqlCommand.ExecuteNonQuery();

      sqlConn.Close();
      sqlConn.Dispose();
    }

    public static List<Student> GetAll()
    {
      var students = new List<Student>();

      SqlConnection sqlConn = new SqlConnection(connectionString());
      sqlConn.Open();
      
      SqlCommand sqlCommand = new SqlCommand("SELECT * FROM students", sqlConn);
      var reader = sqlCommand.ExecuteReader();
      while(reader.Read())
      {
        var grades = new List<double>();
        string strGrades = reader["grades"].ToString();
        foreach(var grade in strGrades.Split(','))
        {
          grades.Add(Convert.ToDouble(grade));
        }

        var student = new Student()
        {
          Id = Convert.ToInt32(reader["id"]),
          Name= reader["name"].ToString(),
          StudentId = reader["student_id"].ToString(),
          Grades = grades,
        };

        students.Add(student);
      }

      sqlConn.Close();
      sqlConn.Dispose();
      
      return students;
    }
    #endregion
  }
  
}