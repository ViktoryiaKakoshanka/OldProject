using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using System.Data.SqlClient;

namespace organization
{
    public partial class dozvon : Form
    {
        public dozvon()
        {
            InitializeComponent();
        }

        ConnectToDB sr = new ConnectToDB();
        string z = "";
        SqlDataReader reader;


        #region подключение con и вывод данных в табл
        public void con(string sql)
        {
            try
            {
                sr.cn.Open();
                dataGridView1.DataSource = sr.GetUsersTable(sql).Tables[0];
                sr.cn.Close();
            }
            catch { }

        }
        #endregion

        private void dozvon_Load(object sender, EventArgs e)
        {
           
            try
            {
                comboBox1.Items.Clear();
                z = "SELECT FIO FROM dbo.MASTER";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
                sr.cn.Close();

                string q123 = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.id_zajzvki, Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE Zajavki.status_vipolnenia='True' and Zajavki.obratnij_dozvon= 'false'";
                con(q123);
            }
            catch { MessageBox.Show("1"); }
        }

        private void dozvon_FormClosed(object sender, FormClosedEventArgs e)
        {
            try{
            Narjad frm2 = new Narjad();
            frm2.Show();//открываем форму для админа                   
            this.Dispose();//скрываем форму входа
            }
            catch { MessageBox.Show("2"); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns[0].Width = 130;// фамилия
                dataGridView1.Columns[1].Width = 20;//имя
                dataGridView1.Columns[2].Width = 20;//отчество
                dataGridView1.Columns[19].Width = 30;//отчество
                dataGridView1.Columns[3].Visible = false; //станд пробл
                dataGridView1.Columns[4].Visible = false;//нест пробл
                dataGridView1.Columns[5].Visible = false;//дата и врем заявки
                dataGridView1.Columns[6].Visible = false;//тел1
                dataGridView1.Columns[7].Visible = false;//тел2
                dataGridView1.Columns[8].Visible = false;//тел3
                dataGridView1.Columns[9].Visible = false;//тип города
                dataGridView1.Columns[10].Visible = false;//город
                dataGridView1.Columns[11].Visible = false;//тип улицы
                dataGridView1.Columns[12].Visible = false;//улица
                dataGridView1.Columns[13].Visible = false;//дом
                dataGridView1.Columns[14].Visible = false;//кв
                dataGridView1.Columns[15].Width = 130;//мастер
                dataGridView1.Columns[16].Visible = false;//статус вып-я
                dataGridView1.Columns[17].Visible = false;//дата вып-я*/
                dataGridView1.Columns[18].Visible = false;//Zajavki.id_zajzvki
                label18.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString()+" "+dataGridView1.CurrentRow.Cells[1].Value.ToString()+" "+dataGridView1.CurrentRow.Cells[2].Value.ToString();//клиент
                label9.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();//тел1
                label10.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();//тел2
                label11.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();//тел3
                //adres
                label12.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[10].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[11].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[12].Value.ToString() + " дом " + dataGridView1.CurrentRow.Cells[13].Value.ToString() + " кв. " + dataGridView1.CurrentRow.Cells[14].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "")
                {
                    label13.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();//станд пробл
                }
                else 
                {
                    label13.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();//нест пробл
                }


                label14.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();//дата и врем заявки
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[16].Value) == true)
                    label15.Text = "Выполнено";//статус вып-я
                else label15.Text = "Не выполнено";
                
                label16.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();//дата вып-я
            }
            catch {  }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try{
                string q123 = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.id_zajzvki, Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE Zajavki.status_vipolnenia='True' and Zajavki.obratnij_dozvon= 'false' and SPR_AB.FAM LIKE '%" + textBox1.Text + "%'";
            con(q123);
            }
            catch { MessageBox.Show("4"); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{


                string q123 = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia,Zajavki.id_zajzvki, Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE Zajavki.status_vipolnenia='True' and Zajavki.obratnij_dozvon= 'false' and MASTER.FIO='" + comboBox1.Text+"'";
            con(q123);
            }
            catch {  }
        }

        public static bool v = false;

        private void button2_Click(object sender, EventArgs e)
        {
            try{
                string q123 = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia,Zajavki.id_zajzvki, Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE Zajavki.status_vipolnenia='True' and Zajavki.obratnij_dozvon= 'false' and    Zajavki.data  BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.ToShortDateString() + "'";
            con(q123);
            }
            catch { MessageBox.Show("6"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                sr.query = "UPDATE Zajavki SET obratnij_dozvon= 'true', data_dozvona='" + dateTimePicker1.Value.Date.ToShortDateString() + "' WHERE Zajavki.id_zajzvki=" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[18].Value);
                sr.ExecSQL(sr.query);
               
                string q123 = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.id_zajzvki, Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE Zajavki.status_vipolnenia='True' and Zajavki.obratnij_dozvon= 'false'";
                con(q123);

                DateTime now = DateTime.Now;
                v = true;


                sr.query = "INSERT INTO zap_dejstvij_disp  values ('Контроль провел','" + admin.dis + "','" + now.ToString() + "')";
                sr.ExecSQL(sr.query);
                v = false;
                }
            catch { MessageBox.Show("7"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{
                string q123 = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia,Zajavki.id_zajzvki, Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE Zajavki.status_vipolnenia='True' and Zajavki.obratnij_dozvon= 'false' and    Zajavki.data_vipolnenia  BETWEEN '" + dateTimePicker5.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker4.Value.Date.ToShortDateString() + "'";
            con(q123);
            }
            catch { MessageBox.Show("8"); }
        }

        private void label25_Click(object sender, EventArgs e)
        {
            try{
            textBox1.Text = "";
            string q123 = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.id_zajzvki, Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE Zajavki.status_vipolnenia='True' and Zajavki.obratnij_dozvon= 'false'";
            con(q123);
            }
            catch { MessageBox.Show("9"); }
        }

    }
}
