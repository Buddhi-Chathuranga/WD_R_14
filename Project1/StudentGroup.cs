using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project1
{
    class StudentGroup
    {
        public int ID { get; set; }
        public String academicYearSemister { get; set; }
        public String program { get; set; }
        public int groupNumber { get; set; }
        public int subGroupNumber { get; set; }
        public String groupID { get; set; }
        public String subGroupID { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=wdr-14.database.windows.net;Initial Catalog=wdr-14;User ID=it19149936;Password=16011999b@;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public String Insert(StudentGroup s)
        {
            String st = "Erorr";
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Open();

            try
            {

                String sql = "INSERT INTO StudentGroup(AcademicYearSem, Program, GroupNumber, SubGroupNumber, GroupID, SubGroupID) VALUES (@AcademicYearSemister, @Program, @GroupNumber, @SubGroupNumber, @GroupID, @SubGroupID);";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@AcademicYearSemister", s.academicYearSemister);
                cmd.Parameters.AddWithValue("@Program", s.program);
                cmd.Parameters.AddWithValue("@GroupNumber", s.groupNumber);
                cmd.Parameters.AddWithValue("@SubGroupNumber", s.subGroupNumber);
                cmd.Parameters.AddWithValue("@GroupID", s.groupID);
                cmd.Parameters.AddWithValue("@SubGroupID", s.subGroupID);

                cmd.ExecuteNonQuery();

                st = "Success Insert";
            }
            catch (Exception ex)
            {
                st = ex.Message;

            }
            finally
            {
                conn.Close();
            }

            return st;
        }

        public String Update(StudentGroup s, int id)
        {
            String st = "Erorr";
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Open();

            try
            {

                String sql = "UPDATE StudentGroup SET AcademicYearSem=@AcademicYearSemister, Program=@Program, GroupNumber=@GroupNumber, SubGroupNumber=@SubGroupNumber, GroupID=@GroupID, SubGroupID=@SubGroupID WHERE ID=@id;";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@AcademicYearSemister", s.academicYearSemister);
                cmd.Parameters.AddWithValue("@Program", s.program);
                cmd.Parameters.AddWithValue("@GroupNumber", s.groupNumber);
                cmd.Parameters.AddWithValue("@SubGroupNumber", s.subGroupNumber);
                cmd.Parameters.AddWithValue("@GroupID", s.groupID);
                cmd.Parameters.AddWithValue("@SubGroupID", s.subGroupID);

                cmd.ExecuteNonQuery();

                st = "Success Update";
            }
            catch (Exception ex)
            {
                st = ex.Message;

            }
            finally
            {
                conn.Close();
            }

            return st;
        }



    }
}
