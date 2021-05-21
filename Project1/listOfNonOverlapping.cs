using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class listOfNonOverlapping : Form
    {
        public listOfNonOverlapping()
        {
            InitializeComponent();
        }

        public int ID = 0;
        SqlConnection con = new SqlConnection(@"Data Source=wdr-14.database.windows.net;Initial Catalog=wdr-14;User ID=it19149936;Password=16011999b@;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void Display()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            try
            {
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT *  FROM NonOverlapping", con);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView.DataSource = dt;
                dataGridView.Columns["ID"].Visible = false;
                con.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("Data loading Eorr !");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                if (ID == 0 || ID.ToString() == "")
                {
                    MessageBox.Show("Please Select a Row");
                }
                else
                {
                    String q = "DELETE FROM NonOverlapping WHERE ID=@ID";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("Success Delete");
                    ID = 0;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error While Deleteing");
            }
        }

        private void listOfNonOverlapping_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch (Exception ee)
            {

            }
        }
    }
}
