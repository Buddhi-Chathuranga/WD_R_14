using Project1;
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


namespace WorkingDaysAndHours
{
    public partial class Add_session_to_time_table : Form
    {
        public Add_session_to_time_table()
        {
            InitializeComponent();
        }

        AddSessionSe c = new AddSessionSe();

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Please fill data");
            }
            else
            {
                c.Faculty = comboBox1.Text;
                c.Lecturer = comboBox2.Text;
                c.Session_Type = comboBox3.Text;
                c.Department = comboBox4.Text;
                c.Center = comboBox5.Text;
                c.Session = comboBox6.Text;


                var success = c.Insert(c);
                if (success == true)
                {
                    MessageBox.Show("New contact Successfull insert");

                }
                else
                {
                    MessageBox.Show("New contact Unsuccessfull insert");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
        }


        SqlConnection con = new SqlConnection(@"Data Source=wdr-14.database.windows.net;Initial Catalog=wdr-14;User ID=it19149936;Password=16011999b@;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void Add_session_to_time_table_Load(object sender, EventArgs e)
        {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select FirstName+' '+LastName AS Names from Lecturer_Table;", con);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                ada.Fill(data);

                comboBox2.DataSource = data;
                comboBox2.DisplayMember = "Names";
                comboBox2.SelectedIndex = -1;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            var Add_Location1 = new AddLoc();
            Add_Location1.Show();
            
        }
    }
}
