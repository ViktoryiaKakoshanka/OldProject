using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Data.SqlClient;

namespace organization
{
    public partial class sroki : Form
    {
        public sroki()
        {
            InitializeComponent();
        }


        private void sroki_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menu frm = new menu();
                frm.Show();
                this.Dispose();
            }
            catch { }
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
        public static bool v = false;
        private void sroki_Load(object sender, EventArgs e)
        {
            try
            {
                v = true;
                


                try
                {

                    z = "SELECT count(*) FROM Zajavki where Zajavki.status_vipolnenia='False' and id_master is not null";
                    reader = sr.ReadSQLExec(z);
                    while (reader.Read())
                    {
                        label8.Text = reader[0].ToString();
                    }
                    sr.cn.Close();
                }
                catch { }

                try
                {
                    DateTime dat = DateTime.Now;

                    z = "SELECT Count(*) FROM Zajavki WHERE Zajavki.status_vipolnenia='False' AND Zajavki.data_okonch_sroka >='" + dat.ToShortDateString() + "' and id_master is not null";

                    reader = sr.ReadSQLExec(z);
                    while (reader.Read())//проходим по строкам таблицы результирующего запроса
                    {
                        label9.Text = reader[0].ToString();
                    }
                    sr.cn.Close();
                }
                catch { }

                try
                {
                    DateTime dat = DateTime.Now;
                    z = "SELECT Count(*)  FROM Zajavki WHERE Zajavki.status_vipolnenia='False' AND Zajavki.data_okonch_sroka<'" + dat.ToShortDateString() + "' and id_master is not null";

                    reader = sr.ReadSQLExec(z);

                    while (reader.Read())//проходим по строкам таблицы результирующего запроса
                    {
                        label10.Text = reader[0].ToString();
                    }
                    sr.cn.Close();
                }
                catch { }

                v = false;

                string q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL";
                con(q);
            }
            catch {  }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns[0].Width = 130;// фамилия
                dataGridView1.Columns[1].Width = 30;//имя
                dataGridView1.Columns[2].Width = 30;//отчество

                dataGridView1.Columns[9].Width = 30;// фамилия
                dataGridView1.Columns[10].Width = 100;//имя
                dataGridView1.Columns[11].Width = 40;//отчество
                dataGridView1.Columns[12].Width = 100;// фамилия
                dataGridView1.Columns[13].Width = 40;//имя
                dataGridView1.Columns[14].Width = 40;//отчество

                dataGridView1.Columns[3].Visible = false; //станд пробл
                dataGridView1.Columns[4].Visible = false;//нест пробл
                dataGridView1.Columns[5].Visible = false;//дата и врем заявки
                dataGridView1.Columns[6].Visible = false;//тел1
                dataGridView1.Columns[7].Visible = false;//тел2
                dataGridView1.Columns[8].Visible = false;//тел3
               /* dataGridView1.Columns[9].Visible = false;//тип города
                dataGridView1.Columns[10].Visible = false;//город
                dataGridView1.Columns[11].Visible = false;//тип улицы
                dataGridView1.Columns[12].Visible = false;//улица
                dataGridView1.Columns[13].Visible = false;//дом
                dataGridView1.Columns[14].Visible = false;//кв*/
                dataGridView1.Columns[15].Width = 130;//мастер
                dataGridView1.Columns[16].Visible = false;//статус вып-я
                dataGridView1.Columns[17].Visible = false;//дата вып-я*/
                dataGridView1.Columns[18].Visible = false;//статус дозвона
                dataGridView1.Columns[19].Visible = false;//дата дозвона*/
                dataGridView1.Columns[20].Visible = false;//Zajavki.id_zajzvki
               label29.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();//тел1
                label26.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();//тел2
                label24.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();//тел3
                //adres
                if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "")
                {
                    label32.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();//станд пробл
                }
                else
                {
                    label32.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();//нест пробл
                }


                label20.Text = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value).ToShortDateString();//дата и врем заявки
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[16].Value) == true)
                    label28.Text = "Выполнено";//статус вып-я
                else label28.Text = "Не выполнено";

                label25.Text = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[17].Value).ToShortDateString();//дата вып-я

                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[18].Value) == true)
                    label3.Text = "Выполнено";//статус вып-я
                else label3.Text = "Не выполнено";

                label2.Text = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[19].Value).ToShortDateString();//дата вып-я
            }
            catch {}
        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE (((Zajavki.status_vipolnenia)='False'))";
                con(q);
            }
            catch { }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dat = DateTime.Now;
                string q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE (((Zajavki.status_vipolnenia)='False')) AND Zajavki.data_okonch_sroka>='" + dat.ToShortDateString() + "'";
                con(q);
            }
            catch { }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dat = DateTime.Now;
                string q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE (((Zajavki.status_vipolnenia)='False')) AND Zajavki.data_okonch_sroka<'" + dat.ToShortDateString() + "'";
                con(q);
            }
            catch {}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                string str = "Наряды(txt)/";
                string s = "Просроченые заявки " + now.ToShortDateString() + ".txt";

                System.IO.StreamWriter textFile = new System.IO.StreamWriter(str + s);

                textFile.WriteLine("            Список просроченых заявок     от " + now.ToShortDateString());
                textFile.WriteLine();
                textFile.WriteLine();

                //#region baza

               

                z = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki, Zajavki.data_okonch_sroka FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (SPR_AB INNER JOIN (MASTER INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON MASTER.id_master = Zajavki.id_master) ON SPR_AB.NDOG = Zajavki.NDOG) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL WHERE (((Zajavki.status_vipolnenia)='False')) AND Zajavki.data_okonch_sroka<'" + now.ToShortDateString() + "'";
 
                reader = sr.ReadSQLExec(z);

                string fio = "", dataz = "", adres = "", prob = "";

                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    fio = reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString();
                    dataz = reader[5].ToString();
                    adres = reader[9].ToString() + " " + reader[10].ToString() + " " + reader[11].ToString() + " " + reader[12].ToString() + " дом " + reader[13].ToString() + " кв " + reader[14].ToString();

                    if (reader[3].ToString() == "")
                    {
                        prob = reader[4].ToString();//нестанд пробл
                    }
                    else
                    {
                        prob = reader[3].ToString();//ст пробл
                    }


                    textFile.WriteLine("Дата заявки:  " + dataz.ToString());
                    textFile.WriteLine("Абонент:      " + fio.ToString());
                    textFile.WriteLine("Адрес:        " + adres.ToString());
                    textFile.WriteLine("Проблема:     " + prob.ToString());
                    textFile.WriteLine();
                    textFile.WriteLine("----------------------------------------дата/время------подпись абонента ");
                    textFile.WriteLine();
                }
                sr.cn.Close();
                System.Diagnostics.Process.Start("Наряды(txt)\\" + s);
                textFile.Close();
            }
            catch {  }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "SELECT SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки], SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв, MASTER.FIO as [Мастер], Zajavki.status_vipolnenia, Zajavki.data_vipolnenia, Zajavki.obratnij_dozvon, Zajavki.data_dozvona, Zajavki.id_zajzvki FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN (MASTER INNER JOIN (SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG) ON MASTER.id_master = Zajavki.id_master) ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL";
                con(q);
            }
            catch { }
        }

 

      
    }
}
