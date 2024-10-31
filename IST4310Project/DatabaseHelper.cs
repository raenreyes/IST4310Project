using IST4310Project.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace IST4310Project
{
    public static class DatabaseHelper
    {
        const string connectionString = "Data Source=DESKTOP-BEFCII3\\SQLEXPRESS; Initial Catalog=IST4310; Integrated Security=true; MultipleActiveResultSets=true";

        static readonly SqlConnection _sqlConnection = new SqlConnection(connectionString);

        public static IEnumerable<Student> GetStudents()
        {
            const string studentsQuery = "SELECT * FROM dbo.Student";
            var command = new SqlCommand(studentsQuery,_sqlConnection);
            if (_sqlConnection.State != ConnectionState.Open) {

                _sqlConnection.Open();
            }
                
            var reader = command.ExecuteReader();
            while (reader.Read()) {
                yield return (new Student
                {
                    StudentId = (int)reader[0],
                    FirstName = reader[1] == null ? string.Empty : reader[1].ToString(),
                    LastName = reader[2] == null ? string.Empty : reader[2].ToString(),
                    Gender = reader[3] == null ? string.Empty : reader[3].ToString(),
                    Department = reader[4] == null ? string.Empty : reader[4].ToString(),
                    Height = (int)reader[5],
                    Major = reader[6] == null ? string.Empty : reader[6].ToString(),
                    Email = reader[7] == null ? string.Empty : reader[7].ToString(),
                    Password = reader[8] == null ? string.Empty : reader[8].ToString(),
                });
                

            }
        }
        public static void InsertNew(string firstName, string lastName, string email, string password,
                                  string gender, int height, string dept, string major)
        {
            const string studentsInsertQuery = "INSERT INTO [dbo].[Student] ([FirstName],[LastName],[Gender],[Department],[Height],[Major],[Email],[Password]) " +
                "VALUES (@FirstName, @LastName, @Gender, @Department, @Height, @Major, @Email, @Password)";
            var command = new SqlCommand(studentsInsertQuery, _sqlConnection);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Department", dept);
            command.Parameters.AddWithValue("@Height", height);
            command.Parameters.AddWithValue("@Major", major);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            if (_sqlConnection.State != ConnectionState.Open)
            {

                _sqlConnection.Open();
            }
            var reader = command.ExecuteNonQuery();
           
        }
    }
}
