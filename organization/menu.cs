using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace organization
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 frm = new Form1();
                frm.Show();
                Hide();
            }
            catch { }
        }

        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ConnectToDB sr = new ConnectToDB();
                admin frm = new admin();
                frm.Show();
                Hide();
                sr.query = "UPDATE Роли SET  vhod='false' WHERE login='" + admin.dis + "'";
                sr.ExecSQL(sr.query);
            }
            catch {  }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Istorya frm = new Istorya();
                frm.Show();
                Hide();
            }
            catch {  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Zajavki frm = new Zajavki();
                frm.Show();
               // Hide();
                this.Dispose();
            }
            catch {  }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Narjad frm = new Narjad();
                frm.Show();
                this.Dispose();
            }
            catch { }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                sroki frm = new sroki();
                frm.Show();
                this.Dispose();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                adminKA frm = new adminKA();
                frm.Show();
                //Hide();
                this.Dispose();
            }
            catch {  }
        }

        private void menu_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                parol frm = new parol();
                frm.Show();
                this.Dispose();
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                RUR frm = new RUR();
                frm.Show();
                this.Dispose();
            }
            catch {}
        }

    }
}
