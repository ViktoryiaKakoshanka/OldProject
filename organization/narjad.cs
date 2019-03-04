using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Owc11;
using System.Collections.Concurrent;

using System.Data.SqlClient;

namespace organization
{
    public partial class Narjad : Form
    {
        public Narjad()
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
                if (w == 1) dataGridView1.DataSource = sr.GetUsersTable(sql).Tables[0];
                //
                if (w == 2) dataGridView2.DataSource = sr.GetUsersTable(sql).Tables[0];
                sr.cn.Close();
            }
            catch { }

        }
        #endregion
static public int w = 0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int master = 0;
            z = "SELECT id_master FROM dbo.MASTER WHERE FIO='" + comboBox2.Text + "'";
            reader = sr.ReadSQLExec(z);
            while (reader.Read())
            {
                master = Convert.ToInt32(reader[0]);
            }
            sr.cn.Close();

            w = 2;
            string q = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM as г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, Zajavki.Примечание AS Проблемы, Zajavki.mesto_nahogdenia as [Место нахождения], Zajavki.тел, Zajavki.data AS [Дата и время заявки], Zajavki.id_zajzvki, SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы] FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE Zajavki.status_vipolnenia='False' and Zajavki.id_master=" + master;
            con(q);
            w = 0;
        }


        private void dob_e_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menu frm2 = new menu();
                frm2.Show();//открываем форму для админа                   
                this.Dispose();//скрываем форму входа
            }
            catch {  }
        }

        private void Narjad_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Items.Clear();
                z = "SELECT FIO FROM dbo.MASTER";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0]);
                }
                comboBox2.Text = comboBox2.Items[0].ToString();
                sr.cn.Close();

                comboBox3.Items.Clear(); comboBox5.Items.Clear();
                z = "SELECT NAMEGOR FROM dbo.SPR_GOR";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader[0]);
                    comboBox5.Items.Add(reader[0]);
                }
                comboBox3.Text = comboBox3.Items[0].ToString();
                comboBox5.Text = comboBox5.Items[0].ToString();
                sr.cn.Close();

                //ZAJAVKI ne raspr
                w = 1;
                string q123 = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM AS г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, Zajavki.id_zajzvki, SPR_GOR.NGOR, Zajavki.mesto_nahogdenia  as [Место нахождения], Zajavki.тел FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE (((Zajavki.id_master) Is Null)) ORDER BY data desc";
                con(q123);
                w = 0;

                //ZAJAVKI raspr
                w = 2;
                string q = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM as г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, Zajavki.Примечание AS Проблемы, Zajavki.mesto_nahogdenia  as [Место нахождения], Zajavki.тел, Zajavki.data AS [Дата и время заявки], Zajavki.id_zajzvki, SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы] FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE (((Zajavki.status_vipolnenia)='False') AND ((Zajavki.id_master) Is Not Null))  ORDER BY data desc";
                con(q);
                w = 0;
            }
            catch {  }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;

                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].Width = 40;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[3].Width = 30;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[5].Width = 40;
                dataGridView1.Columns[6].Width = 40;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[9].Width = 100;
                label6.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[11].Value.ToString() + ". " + dataGridView1.CurrentRow.Cells[12].Value.ToString() + ".";


               // try
                {
                    //sr.cn.Close();
                    comboBox1.Items.Clear();
                    z = "SELECT MASTER.FIO FROM SPR_GOR INNER JOIN (MASTER INNER JOIN GOR_MASTER ON MASTER.id_master = GOR_MASTER.id_master) ON SPR_GOR.NGOR = GOR_MASTER.NGOR WHERE SPR_GOR.NAMEGOR='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
                    reader = sr.ReadSQLExec(z);
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader[0]);
                    }
                    comboBox1.Text = comboBox1.Items[0].ToString();
                    sr.cn.Close();

                }
                //catch { MessageBox.Show("51"); }


            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                comboBox1.Items.Clear();
                z = "SELECT MASTER.FIO FROM SPR_GOR INNER JOIN (MASTER INNER JOIN GOR_MASTER ON MASTER.id_master = GOR_MASTER.id_master) ON SPR_GOR.NGOR = GOR_MASTER.NGOR WHERE SPR_GOR.NAMEGOR='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                 comboBox1.Text = comboBox1.Items[0].ToString();
                sr.cn.Close();
            }
            catch {  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int master = 0;
                z = "SELECT MASTER.id_master FROM MASTER WHERE MASTER.FIO='" + comboBox1.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    master = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();

                sr.query = "UPDATE Zajavki SET Zajavki.id_master = " + master + " WHERE Zajavki.id_zajzvki=" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value);
                sr.ExecSQL(sr.query);


                //ZAJAVKI
                w = 1;
                string q123 = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM AS г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, Zajavki.id_zajzvki, SPR_GOR.NGOR, Zajavki.mesto_nahogdenia  as [Место нахождения], Zajavki.тел FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE (((Zajavki.id_master) Is Null))  ORDER BY data desc";
                con(q123);
                w = 0;

                //ZAJAVKI raspr
                w = 2;
                string q = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM as г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, Zajavki.Примечание AS Проблемы, Zajavki.mesto_nahogdenia  as [Место нахождения], Zajavki.тел, Zajavki.data AS [Дата и время заявки], Zajavki.id_zajzvki, SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы] FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE (((Zajavki.status_vipolnenia)='False') AND ((Zajavki.id_master) Is Not Null))";
                con(q);
                w = 0;

                dataGridView1.Focus();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dozvon frm2 = new dozvon();
                frm2.Show();//открываем форму для админа                   
                this.Dispose();//скрываем форму входа
            }
            catch {}
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                label11.Text = dataGridView2.CurrentRow.Cells[15].Value.ToString();
                label14.Text = dataGridView2.CurrentRow.Cells[16].Value.ToString();
                label17.Text = dataGridView2.CurrentRow.Cells[17].Value.ToString();

                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                dataGridView2.Columns[14].Visible = false;
                dataGridView2.Columns[15].Visible = false;
                dataGridView2.Columns[16].Visible = false;
                dataGridView2.Columns[17].Visible = false;

                dataGridView2.Columns[0].Width = 30;
                dataGridView2.Columns[1].Width = 40;
                dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView2.Columns[3].Width = 30;
                dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView2.Columns[5].Width = 40;
                dataGridView2.Columns[6].Width = 40;
                dataGridView2.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView2.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView2.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView2.Columns[10].Width = 95;
                dataGridView2.Columns[18].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                label5.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString() + " " + dataGridView2.CurrentRow.Cells[13].Value.ToString() + ". " + dataGridView2.CurrentRow.Cells[14].Value.ToString() + ". ";

            }
            catch { }
        }

        public static bool v = false;

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //   MessageBox.Show(dataGridView2.CurrentRow.Cells[11].Value.ToString());

                sr.query = "UPDATE Zajavki SET status_vipolnenia= 'true', data_vipolnenia='" + dateTimePicker1.Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")) + "' WHERE Zajavki.id_zajzvki=" + Convert.ToInt32(dataGridView2.CurrentRow.Cells[11].Value);
                sr.ExecSQL(sr.query);
                

                //ZAJAVKI raspr
                w = 2;
                string q = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM as г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, Zajavki.Примечание AS Проблемы, Zajavki.mesto_nahogdenia as [Место нахождения], Zajavki.тел, Zajavki.data AS [Дата и время заявки], Zajavki.id_zajzvki, SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы] FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE (((Zajavki.status_vipolnenia)='False') AND ((Zajavki.id_master) Is Not Null))";
                con(q);
                w = 0;


                DateTime now = DateTime.Now;
                v = true;

                sr.query = "INSERT INTO zap_dejstvij_disp  values ('Наряд оформил','" + admin.dis + "','" + now.ToString() + "')";
                sr.ExecSQL(sr.query);
                v = false;
            }
            catch {  }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                //ZAJAVKI raspr
                w = 2;
                string q = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM as г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, Zajavki.Примечание AS Проблемы, Zajavki.mesto_nahogdenia as [Место нахождения], Zajavki.тел, Zajavki.data AS [Дата и время заявки], Zajavki.id_zajzvki, SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы] FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE (((Zajavki.status_vipolnenia)='False') AND ((Zajavki.id_master) Is Not Null))";
                con(q);
                w = 0;
            }
            catch {}
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                string str = "Наряды(txt)/";
                string s = "наряд " + comboBox2.Text + " " + now.ToShortDateString() + ".txt";
                System.IO.StreamWriter textFile = new System.IO.StreamWriter(str + s);

                int master = 0;
                z = "SELECT id_master FROM dbo.MASTER WHERE FIO='" + comboBox2.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    master = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();



                 z = "SELECT MASTER.tel_rab, MASTER.tel_rab1, MASTER.tel_dom, MASTER.tel_dom1, MASTER.tel_mob, MASTER.tel_mob1, MASTER.[e-mail] FROM MASTER WHERE id_master=" + master;
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {

                    textFile.WriteLine("                     Наряд №     от " + now.ToShortDateString());
                    textFile.WriteLine();
                    textFile.Write("Мастер " + comboBox2.Text);
                    textFile.Write("                тел.раб." + reader[0].ToString() + "\t");
                    textFile.WriteLine("тел.раб." + reader[1].ToString());

                    textFile.Write("                                  тел.дом." + reader[2].ToString() + "\t");
                    textFile.WriteLine("тел.дом.  " + reader[3].ToString());

                    textFile.Write("                                  тел.моб." + reader[4].ToString() + "\t");
                    textFile.WriteLine("тел.моб.  " + reader[5].ToString());
                    textFile.WriteLine("                                  e-mail:" + reader[6].ToString());
                    textFile.WriteLine();

                }
                sr.cn.Close();

                //#region baza
                z = "SELECT SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, Zajavki.data, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, problem_po_remontu_kabTV.problema FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (problem_po_remontu_kabTV INNER JOIN (SPR_AB INNER JOIN Zajavki ON SPR_AB.NDOG = Zajavki.NDOG) ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE Zajavki.status_vipolnenia='false' and Zajavki.id_master=" + master;
                reader = sr.ReadSQLExec(z);
                string fio = "", dataz = "", adres = "", prob = "";

                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    fio = reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString();
                    dataz = reader[3].ToString();
                    adres = reader[4].ToString() + " " + reader[5].ToString() + " " + reader[6].ToString() + " " + reader[7].ToString() + " дом " + reader[8].ToString() + " кв " + reader[9].ToString();
                    prob = reader[10].ToString();

                    textFile.WriteLine("Дата заявки:  " + dataz.ToString());
                    textFile.WriteLine("Абонент:      " + fio.ToString());
                    textFile.WriteLine("Адрес:        " + adres.ToString());
                    textFile.WriteLine("Проблема:     " + prob.ToString());
                    textFile.WriteLine();
                    textFile.WriteLine("----------------------------------------дата/время------подпись абонента ");
                    textFile.WriteLine();
                }
                sr.cn.Close();//закрываем соединение с БД
                System.Diagnostics.Process.Start("Наряды(txt)\\" + s);
                textFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                int gor = 0;
                z = "SELECT NGOR FROM dbo.SPR_GOR WHERE NAMEGOR='" + comboBox3.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    gor = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();

                w = 2;
                string q = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM as г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, Zajavki.Примечание AS Проблемы, Zajavki.mesto_nahogdenia  as [Место нахождения], Zajavki.тел, Zajavki.data AS [Дата и время заявки], Zajavki.id_zajzvki, SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы] FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE (((Zajavki.status_vipolnenia)='False') AND ((Zajavki.id_master) Is Not Null)) and SPR_AB.NGOR=" + gor;
                con(q);
                w = 0;
            }
            catch { }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int gor = 0;
                z = "SELECT NGOR FROM dbo.SPR_GOR WHERE NAMEGOR='" + comboBox5.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    gor = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();

                w = 1;
                string q123 = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM AS г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, Zajavki.id_zajzvki, SPR_GOR.NGOR, Zajavki.mesto_nahogdenia as [Место нахождения], Zajavki.тел FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE (((Zajavki.id_master) Is Null)) and SPR_AB.NGOR=" + gor + " ORDER BY data desc";
                con(q123);
                w = 0;
            }
            catch { }


        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                w = 2;
                string q = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM as г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, Zajavki.Примечание AS Проблемы, Zajavki.mesto_nahogdenia  as [Место нахождения], Zajavki.тел, Zajavki.data AS [Дата и время заявки], Zajavki.id_zajzvki, SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы] FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE Zajavki.status_vipolnenia='False' AND Zajavki.id_master Is Not Null and   SPR_AB.NDOG LIKE '%" + textBox1.Text + "%'";
                con(q);
                w = 0;
            }
            catch { }
        }


        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    comboBox1.Focus();
                    SendKeys.Send("{F4}");
                }
            }  
            catch { }
        }

        private void comboBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    comboBox1.Focus();
                    SendKeys.Send("{F4}");
                }
            }
            catch { }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void comboBox5_TextUpdate(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Zajavki frm = new Zajavki();
            frm.Show();
            this.Dispose();
        }
        static public bool prim;
        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                prim = true;

               /* sr.query = "UPDATE Zajavki SET Примечание = '" + dataGridView2.CurrentRow.Cells[7].Value.ToString() + "',[individ/kollectiv]=" + Convert.ToBoolean(dataGridView2.CurrentRow.Cells[0].Value) + " WHERE Zajavki.id_zajzvki=" + Convert.ToInt32(dataGridView2.CurrentRow.Cells[11].Value.ToString());// .Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))
                sr.ExecSQL(sr.query);*/

            }
            catch (Exception)
            {
                MessageBox.Show("Изменения в базе данных выполнить не удалось!", "Уведомление о результатах", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
             try
            {
                prim = true;

            sr.query = "UPDATE Zajavki SET Примечание = '" + dataGridView2.CurrentRow.Cells[7].Value.ToString() + "',[individ/kollectiv]='" + Convert.ToBoolean(dataGridView2.CurrentRow.Cells[0].Value) + "' WHERE Zajavki.id_zajzvki=" + Convert.ToInt32(dataGridView2.CurrentRow.Cells[11].Value.ToString());// .Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))
            sr.ExecSQL(sr.query);
            }
             catch (Exception)
             {
                 MessageBox.Show("Изменения в базе данных выполнить не удалось!", "Уведомление о результатах", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            try
            {
                w = 1;
                string q123 = "SELECT Zajavki.[individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG AS [№Дог], SPR_GOR.NAMEGOR AS город, SPR_T_UL.S_NAIM AS г, SPR_UL1.UL AS улица, SPR_AB.NDOM AS дом, SPR_AB.NKV AS кв, problem_po_remontu_kabTV.problema AS [Стандартные проблемы], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, Zajavki.id_zajzvki, SPR_GOR.NGOR, Zajavki.mesto_nahogdenia  as [Место нахождения], Zajavki.тел FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL WHERE (((Zajavki.id_master) Is Null)) ORDER BY data desc";
                con(q123);
                w = 0;
            }
            catch { }
        }









    }
}
