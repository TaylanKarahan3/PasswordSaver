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

namespace PasswordSaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=PHOENIX;Initial Catalog=Password;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_pswrd (WebSite, Pass) values (@p1,@p2) ", connection);
            cmd.Parameters.AddWithValue("@p1", txtwebname.Text);
            cmd.Parameters.AddWithValue("@p2",txtpassword.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Password Saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if(txtwebname.Text=="Web Site...")
            {
                txtwebname.Clear();
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password...")
            {
                txtpassword.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Passwords psw = new Passwords();
            psw.Show();
        }
    }
}
