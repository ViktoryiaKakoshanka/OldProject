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
    public partial class Istorya : Form
    {
        public Istorya()
        {
            InitializeComponent();
        }

        string DopUslovie = "";
        ConnectToDB sr = new ConnectToDB();
        string z = "";
        SqlDataReader reader;

        string From = " FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL";
        string q = "";
        string Vsego = "";
        string Vip = "";
        string VipNarushSroka = "";
        string Kontrol = "";
        string NeKontrol = "";
        string NeVip = "";

        #region подключение con и вывод данных в табл
        public void con(string sql)
        {
           // try
            {
                if (sr.cn.State == ConnectionState.Open) sr.cn.Close();
                sr.cn.Open();
                dataGridView3.DataSource = sr.GetUsersTable(sql).Tables[0];
                sr.cn.Close();
            }
         //   catch { }

        }
        #endregion


        private void Istorya_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menu frm = new menu();
                frm.Show();
                this.Dispose();
            }
            catch { MessageBox.Show("27"); }
        }

        private void Istorya_Load(object sender, EventArgs e)
        {
            try
            {
                //созд comboBox3 gorod
                comboBox3.Items.Clear();
                z = "SELECT  NAMEGOR FROM SPR_GOR";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    comboBox3.Items.Add(reader[0]);
                }
                sr.cn.Close();//закрываем соединение с БД

                //созд comboBox1 masters
                comboBox1.Items.Clear();
                z = "SELECT FIO  FROM dbo.MASTER";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    comboBox1.Items.Add(reader[0]);
                }
                sr.cn.Close();//закрываем соединение с БД

             /*   string q123 = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki, Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL ";
                con(q123);

                string q = "SELECT Count(*) FROM Zajavki WHERE Zajavki.status_vipolnenia='true'";

                string l11 = "SELECT Count(*)  FROM Zajavki ";

                string l2 = "SELECT Count(*)  FROM Zajavki WHERE Zajavki.status_vipolnenia='true' AND Zajavki.data_okonch_sroka<data_vipolnenia";

                string l3 = "SELECT Count(*)  FROM Zajavki where Zajavki.obratnij_dozvon='true'";

                string l4 = "SELECT Count(*) FROM Zajavki WHERE Zajavki.status_vipolnenia='false'";

                string l5 = "SELECT Count(*)  FROM Zajavki where Zajavki.obratnij_dozvon='false'";

                //заявки выполнены
                reader = sr.ReadSQLExec(q);
                while (reader.Read())
                {
                    label8.Text = reader[0].ToString();
                }
                sr.cn.Close();

                //кол-во  заявок
                reader = sr.ReadSQLExec(l11);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    label40.Text = reader[0].ToString();
                }
                sr.cn.Close();//закрываем соединение с БД

                //кол-во вып-х с нарушением срока
                reader = sr.ReadSQLExec(l2);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    label41.Text = reader[0].ToString();
                }
                sr.cn.Close();//закрываем соединение с БД

                //кол-во дозвона
                reader = sr.ReadSQLExec(l3);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    label36.Text = reader[0].ToString();
                }
                sr.cn.Close();//закрываем соединение с БД

                //кол-во дозвона
                reader = sr.ReadSQLExec(l4);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    label11.Text = reader[0].ToString();
                }
                sr.cn.Close();//закрываем соединение с БД

                //кол-во "He дозвона"
                reader = sr.ReadSQLExec(l5);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    label35.Text = reader[0].ToString();
                }
                sr.cn.Close();//закрываем соединение с БД
                */
                zaprosi1();
                

            }
            catch { MessageBox.Show("28"); }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string q = " SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki,Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL    WHERE SPR_AB.FAM LIKE '%" + textBox2.Text + "%'";
                con(q);
            }
            catch { MessageBox.Show("29"); }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox4.Items.Clear();
                //созд comboBox4-улицы
                z = "SELECT  SPR_UL1.UL FROM SPR_GOR, SPR_UL1, [GOR-UL] WHERE  SPR_UL1.NUL = [GOR-UL].NUL and SPR_GOR.NGOR = [GOR-UL].NGOR and SPR_GOR.NAMEGOR= '" + comboBox3.Text+"'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    comboBox4.Items.Add(reader[0]);
                }
                sr.cn.Close();//закрываем соединение с БД

                zaprosi1();
                //поиск в базе по городу
            //    string q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki,Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL  WHERE SPR_GOR.NAMEGOR  = '" + comboBox3.Text+"'";
           //     con(q);
            }
            catch {  }
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                zaprosi1();
               /* string q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki,Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL   where SPR_UL1.UL='" + comboBox4.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox3.Text+"'";
                con(q);*/

            }
            catch { }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki,Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL  where SPR_UL1.UL='" + comboBox4.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox3.Text + "' and SPR_AB.NDOM like '%" + textBox3.Text + "%'";
                con(q);
            }
            catch {  }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                /*string q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki,Zajavki.[individ/kollectiv] as [инд/ кол] FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL  WHERE MASTER.FIO='" + comboBox1.Text+"'";
                con(q);*/
                zaprosi1();
            }
            catch {  }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "";
                textBox3.Text = "";
                zaprosi1();
                
            }
            catch {  }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.Columns[0].Width = 130;// фамилия
                dataGridView3.Columns[1].Width = 30;//имя
                dataGridView3.Columns[2].Width = 30;//отчество
                dataGridView3.Columns[21].Width = 30;//ind
                dataGridView3.Columns[3].Visible = false; //станд пробл
                dataGridView3.Columns[4].Visible = false;//нест пробл
                dataGridView3.Columns[5].Visible = false;//дата и врем заявки
                dataGridView3.Columns[6].Visible = false;//тел1
                dataGridView3.Columns[7].Visible = false;//тел2
                dataGridView3.Columns[8].Visible = false;//тел3
                dataGridView3.Columns[9].Visible = false;//тип города
                dataGridView3.Columns[10].Visible = false;//город
                dataGridView3.Columns[11].Visible = false;//тип улицы
                dataGridView3.Columns[12].Visible = false;//улица
                dataGridView3.Columns[13].Visible = false;//дом
                dataGridView3.Columns[14].Visible = false;//кв
                dataGridView3.Columns[15].Width = 130;//мастер
                dataGridView3.Columns[16].Visible = false;//статус вып-я
                dataGridView3.Columns[17].Visible = false;//дата вып-я*/
                dataGridView3.Columns[18].Visible = false;//статус дозвона
                dataGridView3.Columns[19].Visible = false;//дата дозвона*/
                dataGridView3.Columns[20].Visible = false;//Zajavki.id_zajzvki
                label18.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString() + " " + dataGridView3.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView3.CurrentRow.Cells[2].Value.ToString();//клиент
                label29.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();//тел1
                label26.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();//тел2
                label24.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString();//тел3
                //adres
                label13.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString() + " " + dataGridView3.CurrentRow.Cells[10].Value.ToString() + " " + dataGridView3.CurrentRow.Cells[11].Value.ToString() + " " + dataGridView3.CurrentRow.Cells[12].Value.ToString() + " дом " + dataGridView3.CurrentRow.Cells[13].Value.ToString() + " кв. " + dataGridView3.CurrentRow.Cells[14].Value.ToString();
                if (dataGridView3.CurrentRow.Cells[3].Value.ToString() == "")
                {
                    label32.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();//станд пробл
                }
                else
                {
                    label32.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();//нест пробл
                }


                label20.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();//дата и врем заявки
                if (Convert.ToBoolean(dataGridView3.CurrentRow.Cells[16].Value) == true)
                    label28.Text = "Выполнено";//статус вып-я
                else label28.Text = "Не выполнено";

                label25.Text = dataGridView3.CurrentRow.Cells[17].Value.ToString();//дата вып-я

                if (Convert.ToBoolean(dataGridView3.CurrentRow.Cells[18].Value) == true)
                    label3.Text = "Выполнено";//статус вып-я
                else label3.Text = "Не выполнено";

                label2.Text = dataGridView3.CurrentRow.Cells[19].Value.ToString();//дата вып-я
                

            }
            catch {  }
        }


        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                DopUslovie = "Zajavki.status_vipolnenia='true' and ";
                zaprosi1();
                DopUslovie = "";
            }
            catch {}
        }


        private void label7_Click(object sender, EventArgs e)
        {
            try
            {
                DopUslovie = "Zajavki.status_vipolnenia='false' and ";
                zaprosi1();
                DopUslovie = "";
            }
            catch {  }
        }

        private void label38_Click(object sender, EventArgs e)
        {
            try
            {
                DopUslovie = " Zajavki.obratnij_dozvon='true' and ";
                zaprosi1();
                DopUslovie = "";
                
            }
            catch {  }
        }

        private void label37_Click(object sender, EventArgs e)
        {
            try
            {
                DopUslovie = " Zajavki.obratnij_dozvon='false' and ";
                zaprosi1();
                DopUslovie = "";
            }
            catch {  }
        }

        private void label42_Click(object sender, EventArgs e)
        {
            try
            {
                DopUslovie = " Zajavki.status_vipolnenia='true' AND Zajavki.data_okonch_sroka<data_vipolnenia and ";
                zaprosi1();
                DopUslovie = "";
                
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            try
            {
                string SelectFrom = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM MASTER INNER JOIN (SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL) ON MASTER.id_master = Zajavki.id_master";
                string DataBetween = "'" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "'";
                DateTime now = DateTime.Now;
                    string str = "Наряды(txt)/";
                    string s = "Статистика по проблемам " + now.ToShortDateString() + ".txt";
                    string q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem GROUP BY problem_po_remontu_kabTV.problema";
                   
                   
                    System.IO.StreamWriter textFile = new System.IO.StreamWriter(str + s);

                   

                    textFile.WriteLine("              Статистика по проблемам      от " + now.ToShortDateString());

                    #region Запросы
                    //период
                    if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
                    {
                        #region
                        if (radioButton1.Checked == true)
                        {
                            #region

                            textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                            textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");

                            q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem WHERE Zajavki.data BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "' and dbo.Zajavki.id_master is not null GROUP BY problem_po_remontu_kabTV.problema";

                            #endregion
                        }
                        else
                        {
                            if (radioButton2.Checked == true)
                            {
                                #region
                                //по дате выполнения

                                textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                textFile.WriteLine("Отсортированная:  по дате выполнения заявки        ");
                                q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem WHERE Zajavki.data_vipolnenia BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "' GROUP BY problem_po_remontu_kabTV.problema";

                                #endregion
                            }
                            else
                            {
                                #region
                                //по дате дозвона

                                textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                textFile.WriteLine("Отсортированная:  по дате дозвона        ");
                                q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem WHERE Zajavki.data_dozvona BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "' GROUP BY problem_po_remontu_kabTV.problema";

                                #endregion
                            }
                        }
                        #endregion
                    }
                    else
                    {//период+город

                        string gor = "SELECT NGOR from dbo.SPR_GOR where NAMEGOR='" + comboBox3.Text + "'";

                        if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
                        {
                            #region
                            if (radioButton1.Checked == true)
                            {
                                #region

                                textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());

                                textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                textFile.WriteLine("                  по городу " + comboBox3.Text);
                                

                                q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG WHERE ((Zajavki.data Between '" + dateTimePicker2.Value.Date.ToShortDateString() + "' And '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ")) and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                #endregion
                            }
                            else
                            {
                                if (radioButton2.Checked == true)
                                {
                                    #region
                                    //по дате выполнения

                                    textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                    textFile.WriteLine("Отсортированная:  по дате выполнения заявки        ");
                                    textFile.WriteLine("                  по городу " + comboBox3.Text);
                                    q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG WHERE ((Zajavki.data_vipolnenia BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ")) GROUP BY problem_po_remontu_kabTV.problema";

                                    #endregion
                                }
                                else
                                {
                                    #region
                                    //по дате дозвона

                                    textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                    textFile.WriteLine("Отсортированная:  по дате дозвона        ");
                                    textFile.WriteLine("                  по городу " + comboBox3.Text);
                                    q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG WHERE ((Zajavki.data_dozvona BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ")) GROUP BY problem_po_remontu_kabTV.problema";

                                    #endregion
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            //период+город+ул
                            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == false && checkBox5.Checked == false)
                            {
                                #region
                                if (radioButton1.Checked == true)
                                {
                                    #region

                                    textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                    textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                    textFile.WriteLine("                  по городу " + comboBox3.Text);
                                    textFile.WriteLine("                  по улице " + comboBox4.Text);
                                    q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL WHERE ((Zajavki.data Between '" + dateTimePicker2.Value.Date.ToShortDateString() + "' And '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "')  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                    #endregion
                                }
                                else
                                {
                                    if (radioButton2.Checked == true)
                                    {
                                        #region
                                        //по дате выполнения

                                        textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                        textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                        textFile.WriteLine("                  по городу " + comboBox3.Text);
                                        textFile.WriteLine("                  по улице " + comboBox4.Text);
                                        q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL WHERE ((Zajavki.data_vipolnenia BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "')  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";
                                        #endregion
                                    }
                                    else
                                    {
                                        #region
                                        //по дате дозвона

                                        textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                        textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                        textFile.WriteLine("                  по городу " + comboBox3.Text);
                                        textFile.WriteLine("                  по улице " + comboBox4.Text);
                                        q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL WHERE ((Zajavki.data_dozvona BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "')  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                        #endregion
                                    }
                                }
                                #endregion
                            }
                            else
                            {//период+город+ул+дом
                                if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == false)
                                {
                                    #region
                                    if (radioButton1.Checked == true)
                                    {
                                        #region

                                        textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                        textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                        textFile.WriteLine("                  по городу " + comboBox3.Text);
                                        textFile.WriteLine("                  по улице " + comboBox4.Text);
                                        textFile.WriteLine("                  по дому " + textBox3.Text);
                                        q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL WHERE ((Zajavki.data Between '" + dateTimePicker2.Value.Date.ToShortDateString() + "' And '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "')  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                        #endregion
                                    }
                                    else
                                    {
                                        if (radioButton2.Checked == true)
                                        {
                                            #region
                                            //по дате выполнения

                                            textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                            textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                            textFile.WriteLine("                  по городу " + comboBox3.Text);
                                            textFile.WriteLine("                  по улице " + comboBox4.Text);
                                            textFile.WriteLine("                  по дому " + textBox3.Text);
                                            q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL WHERE ((Zajavki.data_vipolnenia BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "')  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                            #endregion
                                        }
                                        else
                                        {
                                            #region
                                            //по дате дозвона

                                            textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                            textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                            textFile.WriteLine("                  по городу " + comboBox3.Text);
                                            textFile.WriteLine("                  по улице " + comboBox4.Text);
                                            textFile.WriteLine("                  по дому " + textBox3.Text);
                                            q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL WHERE ((Zajavki.data_dozvona BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "')  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                            #endregion
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {//период+город+ул+дом+мастер
                                    string master = "SELECT id_master from dbo.MASTER where FIO='" + comboBox1.Text + "'";
                                    if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == true)
                                    {
                                        #region
                                        if (radioButton1.Checked == true)
                                        {
                                            #region

                                            textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                            textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                            textFile.WriteLine("                  по городу " + comboBox3.Text);
                                            textFile.WriteLine("                  по улице " + comboBox4.Text);
                                            textFile.WriteLine("                  по дому " + textBox3.Text);
                                            textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                            q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM MASTER INNER JOIN (SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL) ON MASTER.id_master = Zajavki.id_master WHERE ((Zajavki.data Between '" + dateTimePicker2.Value.Date.ToShortDateString() + "' And '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "' and MASTER.id_master=" + sr.id_kol(master).ToString() + " )  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                            #endregion
                                        }
                                        else
                                        {
                                            if (radioButton2.Checked == true)
                                            {
                                                #region
                                                //по дате выполнения

                                                textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                                textFile.WriteLine("                  по городу " + comboBox3.Text);
                                                textFile.WriteLine("                  по улице " + comboBox4.Text);
                                                textFile.WriteLine("                  по дому " + textBox3.Text);
                                                textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM MASTER INNER JOIN (SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL) ON MASTER.id_master = Zajavki.id_master WHERE ((Zajavki.data_vipolnenia BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' And '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "') AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "' and MASTER.id_master=" + sr.id_kol(master).ToString() + ")  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                #endregion
                                            }
                                            else
                                            {
                                                #region
                                                //по дате дозвона

                                                textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                                textFile.WriteLine("                  по городу " + comboBox3.Text);
                                                textFile.WriteLine("                  по улице " + comboBox4.Text);
                                                textFile.WriteLine("                  по дому " + textBox3.Text);
                                                textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM MASTER INNER JOIN (SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL) ON MASTER.id_master = Zajavki.id_master WHERE ((Zajavki.data_dozvona BETWEEN #" + dateTimePicker2.Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("en-US")) + "# AND #" + dateTimePicker3.Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("en-US")) + "#) AND (SPR_AB.NGOR=" + comboBox3.SelectedValue + ") and SPR_UL1.UL='" + comboBox4.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "' and MASTER.id_master=" + comboBox1.SelectedValue + ")  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                #endregion
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {//город+ул+дом+мастер
                                        if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == true)
                                        {
                                            #region

                                            textFile.WriteLine("Отсортированная:  по городу " + comboBox3.Text);
                                            textFile.WriteLine("                  по улице " + comboBox4.Text);
                                            textFile.WriteLine("                  по дому " + textBox3.Text);
                                            textFile.WriteLine("                  по мастеру " + comboBox1.Text);

                                            q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM MASTER INNER JOIN (SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL) ON MASTER.id_master = Zajavki.id_master WHERE (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + " and SPR_UL1.UL='" + comboBox4.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "' and MASTER.id_master=" + sr.id_kol(master).ToString() + " )  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                            #endregion
                                        }
                                        else
                                        {
                                            //город+ул+дом
                                            if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == false)
                                            {
                                                #region
                                                textFile.WriteLine("Отсортированная:  по городу " + comboBox3.Text);
                                                textFile.WriteLine("                  по улице " + comboBox4.Text);
                                                textFile.WriteLine("                  по дому " + textBox3.Text);
                                                q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM MASTER INNER JOIN (SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL) ON MASTER.id_master = Zajavki.id_master WHERE (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + " and SPR_UL1.UL='" + comboBox4.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "')  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                #endregion

                                            }
                                            else
                                            {
                                                //город+ул
                                                if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == false && checkBox5.Checked == false)
                                                {
                                                    #region
                                                    textFile.WriteLine("Отсортированная:  по городу " + comboBox3.Text);
                                                    textFile.WriteLine("                  по улице " + comboBox4.Text);
                                                    q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM MASTER INNER JOIN (SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL) ON MASTER.id_master = Zajavki.id_master WHERE (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + " and SPR_UL1.UL='" + comboBox4.Text + "' )  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                    #endregion

                                                }
                                                else
                                                {
                                                    //город
                                                    if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
                                                    {
                                                        #region

                                                        textFile.WriteLine("Отсортированная:  по городу " + comboBox3.Text);

                                                        q = "SELECT problem_po_remontu_kabTV.problema, Count(problem_po_remontu_kabTV.problema) AS sh_problema FROM MASTER INNER JOIN (SPR_UL1 INNER JOIN (SPR_AB INNER JOIN (problem_po_remontu_kabTV INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_UL1.NUL = SPR_AB.NUL) ON MASTER.id_master = Zajavki.id_master WHERE (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + "  )  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                        #endregion

                                                    }
                                                    else
                                                    {
                                                        //период+город+ул+мастер
                                                        if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == false && checkBox5.Checked == true)
                                                        {
                                                            #region
                                                            if (radioButton1.Checked == true)
                                                            {
                                                                #region

                                                                textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                                textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                                                textFile.WriteLine("                  по городу " + comboBox3.Text);
                                                                textFile.WriteLine("                  по улице " + comboBox4.Text);
                                                                textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                q = SelectFrom + " WHERE ((Zajavki.data Between " + DataBetween + ") AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "'  and MASTER.id_master=" + sr.id_kol(master).ToString() + " )  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                #endregion
                                                            }
                                                            else
                                                            {
                                                                if (radioButton2.Checked == true)
                                                                {
                                                                    #region
                                                                    //по дате выполнения

                                                                    textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                                    textFile.WriteLine("Отсортированная:  по дате выполнения заявки        ");
                                                                    textFile.WriteLine("                  по городу " + comboBox3.Text);
                                                                    textFile.WriteLine("                  по улице " + comboBox4.Text);
                                                                    textFile.WriteLine("                  по дому " + textBox3.Text);
                                                                    textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                    q = SelectFrom + " WHERE ((Zajavki.data_vipolnenia BETWEEN " + DataBetween + ") AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "' and MASTER.id_master=" + sr.id_kol(master).ToString() + ")  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                    #endregion
                                                                }
                                                                else
                                                                {
                                                                    #region
                                                                    //по дате дозвона

                                                                    textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                                    textFile.WriteLine("Отсортированная:  по дате дозвона        ");
                                                                    textFile.WriteLine("                  по городу " + comboBox3.Text);
                                                                    textFile.WriteLine("                  по улице " + comboBox4.Text);
                                                                    textFile.WriteLine("                  по дому " + textBox3.Text);
                                                                    textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                    q = SelectFrom + " WHERE ((Zajavki.data_dozvona BETWEEN " + DataBetween + ") AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and SPR_UL1.UL='" + comboBox4.Text + "'  and MASTER.id_master=" + sr.id_kol(master).ToString() + ")  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                    #endregion
                                                                }
                                                            }
                                                            #endregion
                                                        }
                                                        else
                                                        {
                                                            //период+город+мастер
                                                            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
                                                            {
                                                                #region
                                                                if (radioButton1.Checked == true)
                                                                {
                                                                    #region

                                                                    textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                                    textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                                                    textFile.WriteLine("                  по городу " + comboBox3.Text);
                                                                    textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                    q = SelectFrom + " WHERE ((Zajavki.data Between " + DataBetween + ") AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ")  and MASTER.id_master=" + sr.id_kol(master).ToString() + " )  and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                    #endregion
                                                                }
                                                                else
                                                                {
                                                                    if (radioButton2.Checked == true)
                                                                    {
                                                                        #region
                                                                        //по дате выполнения

                                                                        textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                                        textFile.WriteLine("Отсортированная:  по дате выполнения заявки        ");
                                                                        textFile.WriteLine("                  по городу " + comboBox3.Text);
                                                                        textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                        q = SelectFrom + " WHERE ((Zajavki.data_vipolnenia BETWEEN " + DataBetween + ") AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ") and MASTER.id_master=" + sr.id_kol(master).ToString() + ") and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                        #endregion
                                                                    }
                                                                    else
                                                                    {
                                                                        #region
                                                                        //по дате дозвона

                                                                        textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                                        textFile.WriteLine("Отсортированная:  по дате дозвона        ");
                                                                        textFile.WriteLine("                  по городу " + comboBox3.Text);
                                                                        textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                        q = SelectFrom + " WHERE ((Zajavki.data_dozvona BETWEEN " + DataBetween + ") AND (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + ")  and MASTER.id_master=" + sr.id_kol(master).ToString() + ") and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                        #endregion
                                                                    }
                                                                }
                                                                #endregion
                                                            }
                                                            else
                                                            {
                                                                //период+мастер
                                                                if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
                                                                {
                                                                    #region
                                                                    if (radioButton1.Checked == true)
                                                                    {
                                                                        #region

                                                                        textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                                        textFile.WriteLine("Отсортированная:  по дате принятия заявки        ");
                                                                        textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                        q = SelectFrom + " WHERE ((Zajavki.data Between " + DataBetween + ")   and MASTER.id_master=" + sr.id_kol(master).ToString() + " ) and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                        #endregion
                                                                    }
                                                                    else
                                                                    {
                                                                        if (radioButton2.Checked == true)
                                                                        {
                                                                            #region
                                                                            //по дате выполнения

                                                                            textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                                            textFile.WriteLine("Отсортированная:  по дате выполнения заявки        ");
                                                                            textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                            q = SelectFrom + " WHERE ((Zajavki.data_vipolnenia BETWEEN " + DataBetween + ")  and MASTER.id_master=" + sr.id_kol(master).ToString() + ") and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                            #endregion
                                                                        }
                                                                        else
                                                                        {
                                                                            #region
                                                                            //по дате дозвона

                                                                            textFile.WriteLine("              За период  c " + dateTimePicker2.Value.Date.ToShortDateString() + " по " + dateTimePicker3.Value.Date.ToShortDateString());
                                                                            textFile.WriteLine("Отсортированная:  по дате дозвона        ");
                                                                            textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                            q = SelectFrom + " WHERE ((Zajavki.data_dozvona BETWEEN " + DataBetween + ") and MASTER.id_master=" + sr.id_kol(master).ToString() + ") and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                            #endregion
                                                                        }
                                                                    }
                                                                    #endregion
                                                                }
                                                                else
                                                                {
                                                                    //город++мастер
                                                                    if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
                                                                    {

                                                                        #region

                                                                        textFile.WriteLine("Отсортированная:  по городу " + comboBox3.Text);
                                                                        textFile.WriteLine("                  по мастеру " + comboBox1.Text);
                                                                        q = SelectFrom + " WHERE (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + "  and MASTER.id_master=" + sr.id_kol(master).ToString() + " ) and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                        #endregion

                                                                    }
                                                                    else
                                                                    {
                                                                        //город+ул+мастер
                                                                        if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == false && checkBox5.Checked == true)
                                                                        {
                                                                            #region

                                                                            textFile.WriteLine("Отсортированная:  по городу " + comboBox3.Text);
                                                                            textFile.WriteLine("                  по улице " + comboBox4.Text);
                                                                            textFile.WriteLine("                  по мастеру " + comboBox1.Text);

                                                                            q = SelectFrom + " WHERE (SPR_AB.NGOR=" + sr.id_kol(gor).ToString() + " and SPR_UL1.UL='" + comboBox4.Text + "'  and MASTER.id_master=" + sr.id_kol(master).ToString() + " ) and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                            #endregion

                                                                        }
                                                                        else
                                                                        {
                                                                            //мастер
                                                                            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
                                                                            {
                                                                                #region

                                                                                textFile.WriteLine("Отсортированная:  по мастеру " + comboBox1.Text);

                                                                                q = SelectFrom + " WHERE (MASTER.id_master=" + sr.id_kol(master).ToString() + " ) and dbo.Zajavki.id_master is not null  GROUP BY problem_po_remontu_kabTV.problema";

                                                                                #endregion

                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }

                                }
                            }
                        }

                    }
                    #endregion
                
                    #region


                    reader = sr.ReadSQLExec(q);
                    while (reader.Read())
                    {
                        textFile.WriteLine();
                        textFile.Write(reader[0].ToString() + "________");
                        textFile.WriteLine(reader[1].ToString());

                    }
                    sr.cn.Close();
                System.Diagnostics.Process.Start("Наряды(txt)\\" + s);
                textFile.Close();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == true) { checkBox3.Visible = true; }
                else
                {
                    checkBox3.Visible = false;
                    checkBox4.Visible = false;

                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                }
            }
            catch { }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked == true) { checkBox4.Visible = true; }
                else
                {
                    checkBox4.Visible = false;
                    checkBox4.Checked = false;
                }
            }
            catch { }
        }

        private void label43_Click(object sender, EventArgs e) //пересчет
        {
          //  Pereschet();
            zaprosi1();
        }

        private void label39_Click(object sender, EventArgs e)
        {
            zaprosi1();
        }

        public void zaprosi1()
        {
            try
            {
                string ch1 = "", ch2 = "", ch3 = "", ch4 = "", ch5 = "", b = " and "; q = "";
                int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, kol = 0;

                #region period
                if (checkBox1.Checked == true)
                {

                    if (radioButton1.Checked == true)
                    {
                        ch1 = "   Zajavki.data BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.AddDays(1).ToShortDateString() + "' ";
                    }
                    else
                    {
                        if (radioButton2.Checked == true)
                        {
                            ch1 = "  Zajavki.data_vipolnenia BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.ToShortDateString() + "'  ";

                        }
                        else
                        {
                            ch1 = "  Zajavki.data_dozvona BETWEEN '" + dateTimePicker2.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker3.Value.Date.ToShortDateString() + "'  ";

                        }
                    }

                    c1 = 1;
                }
                else
                {
                    c1 = 0;
                }
                #endregion
                #region gor
                if (checkBox2.Checked == true)
                {
                    ch2 = " SPR_GOR.NAMEGOR='" + comboBox3.Text + "'";
                    c2 = 1;
                }
                else
                {
                    c2 = 0;
                }
                #endregion
                #region ul
                if (checkBox3.Checked == true)
                {
                    ch3 = "SPR_UL1.UL='" + comboBox4.Text + "' ";
                    c3 = 1;
                }
                else
                {
                    c3 = 0;
                }
                #endregion
                #region dom
                if (checkBox4.Checked == true)
                {
                    ch4 = "SPR_AB.NDOM like '" + textBox3.Text + "' ";
                    c4 = 1;
                }
                else
                {
                    c4 = 0;
                }
                #endregion
                #region master
                if (checkBox5.Checked == true)
                {
                    ch5 = " MASTER.FIO='" + comboBox1.Text + "'  ";
                    c5 = 1;
                }
                else
                {
                    c5 = 0;
                }
                #endregion
                #region
                if (c1 + c2 + c3 + c4 + c5 == 2)
                {
                    #region
                    kol = 1;
                    if (c1 == 1 && kol != 0) { ch1 = ch1 + b; kol--; }
                    if (c2 == 1 && kol != 0) { ch2 = ch2 + b; kol--; }
                    if (c3 == 1 && kol != 0) { ch3 = ch3 + b; kol--; }
                    if (c4 == 1 && kol != 0) { ch4 = ch4 + b; kol--; }
                    if (c5 == 1 && kol != 0) { ch5 = ch5 + b; kol--; }
                    #endregion
                }

                if (c1 + c2 + c3 + c4 + c5 == 3)
                {
                    #region
                    kol = 2;
                    if (c1 == 1 && kol != 0) { ch1 = ch1 + b; kol--; }
                    if (c2 == 1 && kol != 0) { ch2 = ch2 + b; kol--; }
                    if (c3 == 1 && kol != 0) { ch3 = ch3 + b; kol--; }
                    if (c4 == 1 && kol != 0) { ch4 = ch4 + b; kol--; }
                    if (c5 == 1 && kol != 0) { ch5 = ch5 + b; kol--; }
                    #endregion
                }
                if (c1 + c2 + c3 + c4 + c5 == 4)
                {
                    #region
                    kol = 3;
                    if (c1 == 1 && kol != 0) { ch1 = ch1 + b; kol--; }
                    if (c2 == 1 && kol != 0) { ch2 = ch2 + b; kol--; }
                    if (c3 == 1 && kol != 0) { ch3 = ch3 + b; kol--; }
                    if (c4 == 1 && kol != 0) { ch4 = ch4 + b; kol--; }
                    if (c5 == 1 && kol != 0) { ch5 = ch5 + b; kol--; }
                    #endregion
                }
                if (c1 + c2 + c3 + c4 + c5 == 5)
                {
                    #region
                    kol = 4;
                    if (c1 == 1 && kol != 0) { ch1 = ch1 + b; kol--; }
                    if (c2 == 1 && kol != 0) { ch2 = ch2 + b; kol--; }
                    if (c3 == 1 && kol != 0) { ch3 = ch3 + b; kol--; }
                    if (c4 == 1 && kol != 0) { ch4 = ch4 + b; kol--; }
                    if (c5 == 1 && kol != 0) { ch5 = ch5 + b; kol--; }
                    #endregion
                }
                #endregion

                if (c1 + c2 + c3 + c4 + c5 != 0)
                {
                    if (DopUslovie == "")
                        q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki,Zajavki.[individ/kollectiv] as [инд/ кол]" + From + " WHERE " + ch1 + ch2 + ch3 + ch4 + ch5 + "  ORDER BY Zajavki.id_zajzvki DESC";
                    else
                        q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki,Zajavki.[individ/kollectiv] as [инд/ кол] " + From + "  where " + DopUslovie + ch1 + ch2 + ch3 + ch4 + ch5 + "  ORDER BY Zajavki.id_zajzvki DESC";
                    con(q);
                    Vsego = "SELECT Count(*) " + From + " WHERE " + ch1 + ch2 + ch3 + ch4 + ch5 + " ";
                    Vip = "SELECT Count(*) " + From + " WHERE Zajavki.status_vipolnenia='true' and  " + ch1 + ch2 + ch3 + ch4 + ch5 + "  ";
                    VipNarushSroka = "SELECT Count(*) " + From + " WHERE Zajavki.status_vipolnenia='true' AND Zajavki.data_okonch_sroka<data_vipolnenia and " + ch1 + ch2 + ch3 + ch4 + ch5;
                    Kontrol = "SELECT Count(*) " + From + " WHERE  Zajavki.obratnij_dozvon='true' and  " + ch1 + ch2 + ch3 + ch4 + ch5 + "  ";
                    NeVip = "SELECT Count(*)  " + From + " WHERE  Zajavki.status_vipolnenia='false' and  " + ch1 + ch2 + ch3 + ch4 + ch5 + " ";
                    NeKontrol = "SELECT Count(*)  " + From + " where  Zajavki.obratnij_dozvon='false' and " + ch1 + ch2 + ch3 + ch4 + ch5 + "  ";

                }
                else
                {
                    string a = DopUslovie.Replace("and ", "");
                    if (DopUslovie == "")
                        q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki,Zajavki.[individ/kollectiv] as [инд/ кол]" + From + " ORDER BY Zajavki.id_zajzvki DESC";
                    else
                        q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki,Zajavki.[individ/kollectiv] as [инд/ кол] " + From + "  where " + a + "  ORDER BY Zajavki.id_zajzvki DESC";

                    con(q);
                    Vsego = "SELECT Count(*) " + From;
                    Vip = "SELECT Count(*) " + From + " WHERE Zajavki.status_vipolnenia='true' ";
                    VipNarushSroka = "SELECT Count(*) " + From + " WHERE Zajavki.status_vipolnenia='true' AND Zajavki.data_okonch_sroka<data_vipolnenia ";
                    Kontrol = "SELECT Count(*) " + From + " WHERE  Zajavki.obratnij_dozvon='true'  ";
                    NeVip = "SELECT Count(*)  " + From + " WHERE  Zajavki.status_vipolnenia='false'  ";
                    NeKontrol = "SELECT Count(*)  " + From + " where  Zajavki.obratnij_dozvon='false' ";

                }


                //       #region вывод подсчетов

                label40.Text = sr.id_kol(Vsego).ToString();
                label8.Text = sr.id_kol(Vip).ToString();
                label41.Text = sr.id_kol(VipNarushSroka).ToString();
                label36.Text = sr.id_kol(Kontrol).ToString();
                label11.Text = sr.id_kol(NeVip).ToString();
                label35.Text = sr.id_kol(NeKontrol).ToString();

                //    #endregion
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zaprosi1();
        }

      

      

    
    }
}
