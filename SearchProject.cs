using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmosProject
{
    public partial class SearchProject : Form
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\LEVEL51PC\OneDrive\Desktop\dot net\c#\dil bahadur\lab2\CosmosProject\CosmosProject\Database1.mdf"";Integrated Security=True";
        private string destinationDirectoryPath = @"C:";
        public SearchProject()
        {
            InitializeComponent();
        }

        private void SearchProject_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\LEVEL51PC\\OneDrive\\Desktop\\dot net\\c#\\dil bahadur\\lab2\\CosmosProject\\CosmosProject\\Database1.mdf\";Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from tbl where ID = '" + textBox1.Text + "'";
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "ViewFile")
            {
                string id;
                id = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["FileID"].Value);
                //SqlConnection connection = new SqlConnection(connectionstring);
                //connection.Open();
               

                string FilePath = Path.Combine(@id);
                if (!string.IsNullOrEmpty(destinationDirectoryPath))
                {
                    // Load the PDF document
                    PdfDocument pdfDocument = PdfDocument.Load(FilePath);

                    // Load the PDF document into the PdfRendererControl
                    pdfRenderer1.Load(pdfDocument);

                    // Set the initial zoom level if desired
                    pdfRenderer1.Zoom = 1;
                }


            }

        }
    }
}
