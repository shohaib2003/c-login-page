using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            
                

            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R536M6E\\SQLEXPRESS;Initial Catalog=loginapp;Integrated Security=True;");
            con.Open();
            string query = "select count(*) from loginapp where username=@username and password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", txtUser.Text);
            cmd.Parameters.AddWithValue("@password", txtPass.Text);
            int count= (int)cmd.ExecuteScalar();
            con.Close();

            if (count == 1)
            {
                MessageBox.Show("Login successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hide Form1
                this.Hide();

                // Show Form2
                using (Form2 f2 = new Form2())
                {
                    f2.ShowDialog(); // Show Form2 as a modal dialog
                }
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar=checkBox1.Checked?'\0' :'*';
        }
    }
}
