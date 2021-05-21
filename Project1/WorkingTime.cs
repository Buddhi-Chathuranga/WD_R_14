using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingDaysAndHours
{
    class WorkingTime
    {

        public String EntryID { get; set; }

        public String Hours { get; set; }

        public String Minutes { get; set; }

        string myconnstring = @"Data Source=wdr-14.database.windows.net;Initial Catalog=wdr-14;User ID=it19149936;Password=16011999b@;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * from WorkingTime";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
        public bool Insert(WorkingTime c)
        {
            bool isSucces = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                conn.Open();
                string sql = "INSERT INTO WorkingTime(Hours,Minutes) VALUES(@Hours,@Minutes)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Hours", c.Hours);
                cmd.Parameters.AddWithValue("@Minutes", c.Minutes);


                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSucces = true;
                }
                else
                {
                    isSucces = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSucces;
        }
        public String Update(WorkingTime c, int id)
        {
            String isSuccess = "false";
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                conn.Open();
                String sql = "UPDATE WorkingTime SET Hours=@Hours,Minutes=@Minutes WHERE EntryID=@EntryID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Hours", c.Hours);
                cmd.Parameters.AddWithValue("@Minutes", c.Minutes);
                cmd.Parameters.AddWithValue("@EntryID", id);

                cmd.ExecuteNonQuery();
                isSuccess = "true";

            }
            catch (Exception ex)
            {
                isSuccess = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Delete(WorkingTime c, int id)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "DELETE FROM WorkingTime WHERE EntryID=@EntryID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@EntryID", id);

                conn.Open();

                cmd.ExecuteNonQuery();

                isSuccess = true;


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
