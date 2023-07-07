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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace CosmosProject
{
    public partial class AddProject : Form
    {


        private string sourceFilePath; // Variable to store the selected source file path
        private string destinationDirectoryPath = @"D:\test";
        public AddProject()
        {
            InitializeComponent();
        }
        private void AddProject_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\LEVEL51PC\\OneDrive\\Desktop\\dot net\\c#\\dil bahadur\\lab2\\CosmosProject\\CosmosProject\\Database1.mdf\";Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select max(ID) from tbl";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Int64 abc = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
            label13.Text = (abc+1).ToString();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox7.Text != "")
            {
                string ProjectName = textBox1.Text;
                string student1 = textBox2.Text;
                string student2 = textBox3.Text;
                string student3 = textBox4.Text;
                string student4 = textBox5.Text;
                string SupervisorName = textBox6.Text;
                string Batch = comboBox1.Text;
                string Semester = comboBox2.Text;
                string Program = comboBox3.Text;
                string FileID = textBox7.Text;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\LEVEL51PC\\OneDrive\\Desktop\\dot net\\c#\\dil bahadur\\lab2\\CosmosProject\\CosmosProject\\Database1.mdf\";Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO tbl(ProjectName,Student1,Student2,Student3,Student4,SupervisorName,Batch,Semester,Program,FileID) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox7.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("your data is submitted");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please Enter The Complete Data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            textBox7.Text = null;
        }

        private void Browse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFilePath = openFileDialog.FileName;
                textBox7.Text = sourceFilePath;
            }
        }
    }
}
