using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Tag
    {
        public String tagName { get; set; }
        public String tagCode { get; set; }
        public String relatedTag { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=wdr-14.database.windows.net;Initial Catalog=wdr-14;User ID=it19149936;Password=16011999b@;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public String Insert(Tag t)
        {
            String st = "Erorr";
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Open();

            try
            {
                String sql = "INSERT INTO Tag(TagName , TagCode , RelatedTag) VALUES (@TagName , @TagCode , @RelatedTag);";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TagName", t.tagName);
                cmd.Parameters.AddWithValue("@TagCode", t.tagCode);
                cmd.Parameters.AddWithValue("@RelatedTag", t.relatedTag);

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

        public String Update(Tag t , int id)
        {
            String st = "Erorr";
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Open();

            try
            {

                String sql = "UPDATE Tag SET TagName=@TagName , TagCode=@TagCode , RelatedTag=@RelatedTag WHERE Id=@id;";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@TagName", t.tagName);
                cmd.Parameters.AddWithValue("@TagCode", t.tagCode);
                cmd.Parameters.AddWithValue("@RelatedTag", t.relatedTag);

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
