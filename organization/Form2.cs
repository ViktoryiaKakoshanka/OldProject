using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace organization
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string put = Environment.CurrentDirectory + @"\";
                SqlConnection cn = new SqlConnection(@"Server=localhost\SQLEXPRESS; Integrated Security=true; Initial Catalog=org;");//" User ID=" + textBox3.Text + ";Password=" + textBox4.Text + ";");
                //SqlConnection cn = new SqlConnection(@"Server=tcp:EPBYVITW0217.minsk.epam.com\SQLEXPRESS; Integrated Security=true;");//" User ID=" + textBox3.Text + ";Password=" + textBox4.Text + ";");
                SqlCommand cmd = new SqlCommand();

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cmd.Connection = cn;
                

                string org_mdf = @"" + put + @"\" + textBox2.Text + ".mdf";
                string org_log = @"" + put + @"\" + textBox2.Text + ".ldf";

                string query = "CREATE DATABASE    org     ON (FILENAME = '" + org_mdf + "'),       (FILENAME = '" + org_log + "')    FOR ATTACH; ";
                cmd.CommandText = query;

                cn.Open();
                cmd.ExecuteNonQuery();

                cn.Close();

                string s = "ConnectedString.txt";
                System.IO.StreamWriter textFile = new System.IO.StreamWriter(s);

                textFile.WriteLine(cn.ConnectionString + "Initial Catalog=org; pooling=true; Password=" + textBox4.Text + ";");

                textFile.Close();

                MessageBox.Show("Подсоединение выполнено");
                admin frm3 = new admin();
                frm3.Show();//открываем форму для обычного пользователя
                this.Dispose();
            }
            catch { }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                admin frm3 = new admin();
                frm3.Show();//открываем форму для обычного пользователя
                this.Dispose();
            }
            catch { }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.MachineName.ToLower();
        }
    }
}
