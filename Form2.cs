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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginApplication
{
    public partial class Form2 : Form
    {
        private SqlConnection con;

        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=DESKTOP-R536M6E\\SQLEXPRESS;Initial Catalog=programmingTutorialDB;Integrated Security=True;");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R536M6E\\SQLEXPRESS;Initial Catalog=programmingTutorialDB;Integrated Security=True;");
            con.Open();
            SqlCommand command = new SqlCommand("INSERT INTO ProductInfo_Tab (iteamname, design, color) VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "','" + comboBox1.Text + "')", con);
            command.ExecuteNonQuery();
            MessageBox.Show("SUCCESSFULLY INSERT");
            con.Close();
            BindData();
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from ProductInfo_Tab ", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("UPDATE ProductInfo_Tab SET IteamName='" + textBox2.Text + "', Design='" + textBox3.Text + "', color='" + comboBox1.Text + "' WHERE productId='" + int.Parse(textBox1.Text) + "'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully updated");
            BindData();
            ReloadForm();
        }


        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand command = new SqlCommand(" delete ProductInfo_Tab  where productId= '" + int.Parse(textBox1.Text) + "'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("successfully Delete");
           



        }
        private void ReloadForm()
        {
            // Reset text boxes and combo box
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1; // Reset selection

            // Reload data in DataGridView
            BindData();
        }

    }
}
