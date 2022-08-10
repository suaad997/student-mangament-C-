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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text==Properties.Settings.Default.username && txtpass.Text==Properties.Settings.Default.password)
            {
                this.Visible = false;
            }
            else if (txtname.Text != Properties.Settings.Default.username && txtpass.Text != Properties.Settings.Default.password)
            {
                txtname.Clear();
                txtpass.Clear();
                MessageBox.Show("المعلومات غير متطابقة");
            }
            else if (txtpass.Text != Properties.Settings.Default.password)
            {
                txtpass.Clear();
                MessageBox.Show("كلمة المرور خطأ ");
            }
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txtpass.Focus();
               
            }
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
