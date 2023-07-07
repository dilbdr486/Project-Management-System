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

namespace CosmosProject
{
    public partial class RemoveProject : Form
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\LEVEL51PC\OneDrive\Desktop\dot net\c#\dil bahadur\lab2\CosmosProject\CosmosProject\Database1.mdf"";Integrated Security=True";
        public RemoveProject()
        {
            InitializeComponent();
        }

        private void RmoveProject_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\LEVEL51PC\\OneDrive\\Desktop\\dot net\\c#\\dil bahadur\\lab2\\CosmosProject\\CosmosProject\\Database1.mdf\";Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from tbl";
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                int id;
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
               SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();

                if (MessageBox.Show("Are you sure? This Will Delete Your Data", "Confirmation Daialog!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string query = "delete from tbl where id =@code";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@code", id);
                    int result = cmd.ExecuteNonQuery();
                    if (result>0)
                    {
                        MessageBox.Show("delete succefully");
                    }
                    else
                    {
                        MessageBox.Show("Data not delete");
                    }
                    dataGridView1 = null;
                }

            }
        }
    }
}
