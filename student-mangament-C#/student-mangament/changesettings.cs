using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_mangament
{
    public partial class changesettings : Form
    {
        public changesettings()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void changesettings_Load(object sender, EventArgs e)
        {
            usern.Text = Properties.Settings.Default.username;
        }

        private void usern_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.username = usern.Text;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Properties.Settings.Default.password)
            {
                if (textBox3.Text == textBox2.Text)
                {
                    Properties.Settings.Default.password = textBox2.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("تم الحفظ");
                    this.Visible = false;
                }
                else label5.Visible = true;
            }
            else label6.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
