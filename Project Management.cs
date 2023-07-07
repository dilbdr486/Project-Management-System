using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmosProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToLower() == "admin" && textBox2.Text.ToLower() == "admin")
            {
                menuStrip1.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("your password is invalid or incorrect.");
            }
        }

        private void addProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProject add = new AddProject();
            add.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void searchProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchProject s = new SearchProject();
            s.Show();
        }

        private void indivudaulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            individualdisplay i = new individualdisplay();
            i.Show();
        }

        private void exitSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure? This Will Delete Your Unsaved Data","Confirmation Daialog!",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void projectRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveProject r = new RemoveProject();
            r.Show();
        }
    }
}
