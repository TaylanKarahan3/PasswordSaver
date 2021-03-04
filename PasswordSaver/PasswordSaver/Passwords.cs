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
    public partial class Passwords : Form
    {
        public Passwords()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=PHOENIX;Initial Catalog=Password;Integrated Security=True");

        void list()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_pswrd", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
        private void Passwords_Load(object sender, EventArgs e)
        {
            list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("update tbl_pswrd set pass=@p1 where Id=@p2", connection);
            cmd.Parameters.AddWithValue("@p1", txtpass.Text);
            cmd.Parameters.AddWithValue("@p2", txtid.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Password is Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
            list();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtwebsite.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            txtpass.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_pswrd where Id=@p1 and Website=@p2 and Pass=@p3", connection);
            cmd.Parameters.AddWithValue("@p1", txtid.Text);
            cmd.Parameters.AddWithValue("@p2", txtwebsite.Text);
            cmd.Parameters.AddWithValue("@p3", txtpass.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Password Deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            connection.Close();
            list();
        }
    }
}
