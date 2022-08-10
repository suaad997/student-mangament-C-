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
using System.IO;

namespace student_mangament
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"data source =COMPUTER ; initail catalog=school_1 ; integrated security =true ");
        SqlDataAdapter d;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        string table_name="";

        private void filltable()
        { 
            d = new SqlDataAdapter("select * from"+table_name, con);
            dt.Rows.Clear();
            d.Fill(dt);
            dgv.DataSource = dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer4.Enabled = true;
            SqlDataAdapter d2 = new SqlDataAdapter("select * from " + table_name + "where student_id= " + dgv.CurrentRow.Cells[1].Value, con);
            DataTable dt2 = new DataTable();
            d2.Fill(dt2);
            tt1.Text = dt2.Rows[0]["student_name"].ToString();
            tt2.Text = dt2.Rows[0]["father_name"].ToString();
            tt3.Text = dt2.Rows[0]["address"].ToString();
            tt4.Text = dt2.Rows[0]["number_phone"].ToString();
            byte[] b= (byte []) (dt2.Rows[0]["photo"]);
            MemoryStream m = new MemoryStream(b);
            pictureBox4.Image = Image.FromStream(m);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هل تريد حذف السجل؟","",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                cmd = new SqlCommand("delete from"+table_name+"where student_id= "+dgv.CurrentRow.Cells[0].Value , con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                filltable();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.password!=""&&Properties.Settings.Default.username!="")
            {
                login l = new login();
                l.ShowDialog();
            }
            dgv.ForeColor = Color.Black;
            comboBox1.SelectedIndex = 1; 
                
        }

        private void الاعداداتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void اعداداتالحسابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new changesettings();
            frm.Show();
            
        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void الشعبةالاولىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table_name = "class1_s1";
            filltable();
            dgv.Columns[5].Width = 400;
        }

        private void الشعبةالثانيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table_name = "class1_s2";
            filltable();
        }

        private void الشعبةالاولىToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            table_name = "class2_s1";
            filltable();
        }

        private void الشعبةالثانيةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            table_name = "class2_s2";
            filltable();
        }

        private void الشعبةالاولىToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            table_name = "class3_s1";
            filltable();
        }

        private void الشعبةالثانيةToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            table_name = "class3_s2";
            filltable();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter d2 = new SqlDataAdapter("select * from "+table_name +"where "+comboBox1.Text+" like '%"+search.Text+"%'", con);
            DataTable dt2 = new DataTable();
            d2.Fill(dt2);
            dgv.DataSource = dt2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (table_name !="")
            {
                groupBox1.Enabled = true;
                count_student.Text = dgv.Rows.Count.ToString(); 
            }

        }

        private void count_student_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel2.Left = panel2.Left + 15;
            if (panel2.Left >= 39)
                timer2.Enabled = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            panel2.Left = panel2.Left - 15;
            if (panel2.Left <= -343)
                timer3.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer3.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (! (t1.Text=="" && t2.Text=="" && t3.Text == "" && t4.Text=="" && p1.Image==null))
            {
                byte[] b = null;
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                b =br.ReadBytes((int)fs.Length);
                con.Open();
                cmd = new SqlCommand("insert into" + table_name + "(student_name,father_name,address,number_phone,photo) values ('" + t1.Text + "','" + t2.Text + "','" + t3.Text + "'," + Convert.ToInt32(t4.Text) + ",@img);", con);
                    cmd.Parameters.Add(new SqlParameter("@img", b));
                cmd.ExecuteNonQuery();
                con.Close();
                t1.Clear(); t2.Clear(); t3.Clear(); t4.Clear(); p1.Image = null; 
            }
            filltable();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                p1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            panel3.Top = panel3.Top + 20;
            if (panel3.Top >= 140)
                timer4.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer5.Enabled = true;
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            panel3.Top = panel3.Top - 20;
            if (panel3.Top >= 983)
                timer5.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(t1.Text == "" && t2.Text == "" && t3.Text == "" && t4.Text == "" && p1.Image == null))
            {
                byte[] b = null;
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                b = br.ReadBytes((int)fs.Length);
                con.Open();
                cmd = new SqlCommand("update into" + table_name + "(student_name,father_name,address,number_phone,photo) values ('" + t1.Text + "','" + t2.Text + "','" + t3.Text + "'," + Convert.ToInt32(t4.Text) + ",@img);", con);
                cmd.Parameters.Add(new SqlParameter("@img", b));
                cmd.ExecuteNonQuery();
                con.Close();
                t1.Clear(); t2.Clear(); t3.Clear(); t4.Clear(); p1.Image = null;
            }
            filltable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer4.Enabled = true;
            SqlDataAdapter d2 = new SqlDataAdapter("select * from " + table_name + "where student_id= " + dgv.CurrentRow.Cells[1].Value, con);
            DataTable dt2 = new DataTable();
            d2.Fill(dt2);
            tt1.Text = dt2.Rows[0]["student_name"].ToString();
            tt2.Text = dt2.Rows[0]["father_name"].ToString();
            tt3.Text = dt2.Rows[0]["address"].ToString();
            tt4.Text = dt2.Rows[0]["number_phone"].ToString();
            byte[] b = (byte[])(dt2.Rows[0]["photo"]);
            MemoryStream m = new MemoryStream(b);
            pictureBox4.Image = Image.FromStream(m);
        }
    }
}
