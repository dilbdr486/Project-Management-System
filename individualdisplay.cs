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
    public partial class individualdisplay : Form
    {
        public individualdisplay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\LEVEL51PC\\OneDrive\\Desktop\\dot net\\c#\\dil bahadur\\lab2\\CosmosProject\\CosmosProject\\Database1.mdf\";Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from tbl where id = '"+textBox1.Text+"'";
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                pName.Text = ds.Tables[0].Rows[0][1].ToString();
                s1.Text = ds.Tables[0].Rows[0][2].ToString();
                s2.Text = ds.Tables[0].Rows[0][3].ToString();
                s3.Text = ds.Tables[0].Rows[0][4].ToString();
                s4.Text = ds.Tables[0].Rows[0][5].ToString();
                sName.Text = ds.Tables[0].Rows[0][6].ToString();
                batch.Text = ds.Tables[0].Rows[0][7].ToString();
                semester.Text = ds.Tables[0].Rows[0][8].ToString();
                program.Text = ds.Tables[0].Rows[0][9].ToString();
            }
            else
            {
                MessageBox.Show("No Record Found","No Match",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pName.Text = null;
            s1.Text = null;
            s2.Text = null;
            s3.Text = null;
            s4.Text = null;
            sName.Text = null;
            batch.Text = null;
            semester.Text = null;
            program.Text = null;
            textBox1.Text = null;
        }
    }
}
