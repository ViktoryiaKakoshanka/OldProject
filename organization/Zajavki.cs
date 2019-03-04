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
    public partial class Zajavki : Form
    {
        public Zajavki()
        {
            InitializeComponent();
            this.KeyPreview = true;
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
                if (qwe == 1) dataGridView2.DataSource = sr.GetUsersTable(sql).Tables[0];
                //
                if (qwe == 2) dataGridView1.DataSource = sr.GetUsersTable(sql).Tables[0];
                sr.cn.Close();
            }
            catch {  }

        }
        #endregion

        static public int w = 0, NDOG=0;
        static public string name = "";
        public int qwe = 0,idProblem=0, m, r=0;
        public string vstavka = "";

        private void Zajavki_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menu frm = new menu();
                frm.Show();
               // Hide();
                this.Dispose();
            }
            catch { }
        }
        
        private void Zajavki_Load(object sender, EventArgs e)
        {
           // sr.cmd.Connection = sr.cn;
            
            try
            {
                //AB

                dateTimePicker1.Visible = false;

                qwe = 1;
                string q = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL";
                con(q);

                //ZAJAVKI
                qwe = 2;
                string q123 = "SELECT [individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG as [№Дог], SPR_AB.FAM AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки],data_okonch_sroka AS [Конец срока],mesto_nahogdenia AS [Примечание],  Zajavki.id_zajzvki,Zajavki.тел FROM SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG WHERE  (((Zajavki.id_master) Is Null))  ORDER BY data desc";
                con(q123);

//созд comboBox1-problem
                comboBox1.Items.Clear();
                 z = "SELECT problem_po_remontu_kabTV.problema FROM problem_po_remontu_kabTV ORDER BY problem_po_remontu_kabTV.problema ";
                 reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
                sr.cn.Close();
//город
                comboBox3.Items.Clear();
                z = " SELECT NAMEGOR FROM dbo.SPR_GOR";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader[0]);
                }
                comboBox3.Text = comboBox3.Items[0].ToString();
                sr.cn.Close();

        /*        string str_select = "SELECT * FROM dbo.SPR_GOR";
                comboBox3.DataSource = sr.GetUsersTable(str_select).Tables[0];
                comboBox3.ValueMember = "NGOR";
                comboBox3.DisplayMember = "NAMEGOR";*/
                

                label13.Location = new Point(250, 246);
                dataGridView1.Location = new Point(10, 272);
                dataGridView1.Size = new Size(1010, 250);

                checkBox1.Visible = false;
            }
            catch { }
        }

        #region fufu
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                qwe = 1;
                string q = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL   WHERE SPR_AB.FAM LIKE '%" + textBox2.Text + "%'";
                con(q);

            }
            catch {}
        }
 
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //поиск в базе по городу
                qwe = 1;
                string q = "SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL  where SPR_GOR.NAMEGOR = '" + comboBox3.Text+"'";
                con(q);


                //созд comboBox4-улицы
                comboBox4.Items.Clear();
                 z = "SELECT  SPR_UL1.UL FROM SPR_GOR, SPR_UL1, [GOR-UL] WHERE  SPR_UL1.NUL = [GOR-UL].NUL and SPR_GOR.NGOR = [GOR-UL].NGOR and SPR_GOR.NAMEGOR= '" + comboBox3.Text+"'";
                 reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox4.Items.Add(reader[0]);
                }
                comboBox4.Text = comboBox4.Items[0].ToString();
                sr.cn.Close();
            }
            catch {  }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.Text != null)
                {
                    qwe = 1;
                    string q = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where SPR_UL1.UL='" + comboBox4.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox3.Text+"'";
                    con(q);

                    if (comboBox4.Text == "нет улицы")
                    {
                        comboBox5.SelectedValue = 20;
                    }
                    else
                    {
                        if (comboBox4.Text == "улица")
                        {
                            comboBox5.SelectedValue = 1;
                        }
                    }
                }

            }
            catch {  }
        }
        //dom
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == false)
                {
                    if (comboBox4.Text != "")
                    {
                        qwe = 1;
                        string q = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where SPR_UL1.UL='" + comboBox4.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox3.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "%' ORDER BY SPR_AB.NKV";
                        con(q);
                    }
                    else
                    {
                        qwe = 1;
                        string q = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where  SPR_AB.NDOM = '" + textBox3.Text + "' and SPR_GOR.NAMEGOR = '" + comboBox3.Text + "' ORDER BY SPR_AB.NKV";
                        con(q);
                    }
                }
                else
                {
                    if (comboBox4.Text != "")
                    {
                        qwe = 1;
                        string q = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where SPR_UL1.UL='" + comboBox4.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox3.Text + "' and SPR_AB.NDOM like'" + textBox3.Text + "'  ORDER BY SPR_AB.NKV";
                        con(q);
                    }
                    else
                    {
                        qwe = 1;
                        string q = "SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where SPR_GOR.NAMEGOR  = '" + comboBox3.Text + "' and SPR_AB.NDOM like'" + textBox3.Text + "'  ORDER BY SPR_AB.NKV";
                        con(q);
                    }
                }

            }
            catch { }
        }
        //kv
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == false)
                {
                    if (comboBox4.Text != "")
                    {
                        qwe = 1;
                        string q = "SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where SPR_UL1.UL='" + comboBox4.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox3.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "%' and  SPR_AB.NKV like '" + textBox4.Text + "'";
                        con(q);
                    }
                    else
                    {
                        qwe = 1;
                        string q = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where SPR_GOR.NAMEGOR = '" + comboBox3.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "%' and  SPR_AB.NKV like '" + textBox4.Text + "'";
                        con(q);
                    }
                }
                else
                {
                    if (comboBox4.Text != "")
                    {
                        qwe = 1;
                        string q = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where SPR_UL1.UL='" + comboBox4.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox3.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "' and  SPR_AB.NKV like '" + textBox4.Text + "'";
                        con(q);
                    }
                    else
                    {
                        qwe = 1;
                        string q = "SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where SPR_GOR.NAMEGOR = '" + comboBox3.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "' and  SPR_AB.NKV like '" + textBox4.Text + "'";
                        con(q);
                    }
                }
                
            }
            catch {  }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox3.Text = comboBox3.Items[0].ToString();
                comboBox4.Text = comboBox4.Items[0].ToString();
                qwe = 1;
                string q = "SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL";
                con(q);
            }
            catch { }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region ШИРИНА СТОЛБЦОВ
                dataGridView2.Columns[0].Width = 40;
                dataGridView2.Columns[1].Width = 30;
                dataGridView2.Columns[2].Width = 130;
                dataGridView2.Columns[3].Width = 20;
                dataGridView2.Columns[4].Width = 20;
                dataGridView2.Columns[5].Width = 80;
                dataGridView2.Columns[6].Width = 30;
                dataGridView2.Columns[7].Width = 110;
                dataGridView2.Columns[8].Width = 50;
                dataGridView2.Columns[9].Width = 40;
                #endregion
            }
            catch {  }
        }

    
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].Width = 40;
                dataGridView1.Columns[2].Width = 130;
                dataGridView1.Columns[3].Width = 20;
                dataGridView1.Columns[4].Width = 20;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[7].Width = 95;
                dataGridView1.Columns[8].Width = 65;
                dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            }
            catch {  }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    richTextBox1.Visible = true;

                    comboBox1.Visible = false;
                    checkBox1.Visible = false;
                    button1.Focus();
                }
                if (checkBox1.Checked == false)
                {
                    richTextBox1.Visible = false;
                    comboBox1.Visible = true;
                }
            }
            catch {}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                #region BAZA
                if (textBox2.Text != string.Empty)
                {
                    int ul = 0;
                    z = "SELECT NUL FROM SPR_UL1 WHERE UL='" + comboBox4.Text + "'";
                    reader = sr.ReadSQLExec(z);
                    while (reader.Read())
                    {
                        ul = Convert.ToInt32(reader[0]);
                    }
                    sr.cn.Close();

                    int dog = 0;
                    z = "SELECT NDOG FROM SPR_AB where NDOG<1000 ORDER BY NDOG";
                    reader = sr.ReadSQLExec(z);
                    while (reader.Read())
                    {
                        dog = Convert.ToInt32(reader[0]);
                    }
                    dog = dog + 1;
                    sr.cn.Close();

                    int cb3 = 0;
                    z = "SELECT NGOR FROM dbo.SPR_GOR where NAMEGOR='" + comboBox3.Text + "'";
                    reader = sr.ReadSQLExec(z);
                    while (reader.Read())
                    {
                        cb3 = Convert.ToInt32(reader[0]);
                    }
                    sr.cn.Close();
                    //------------------------------------------------------------------------------------------------------------------------


                #endregion
                    label9.Text = "Поиск по фамилии:";
                    button2.Visible = true;
                    button4.Visible = true;
                    button5.Visible = false;
                    button6.Visible = false;
                    w = 1;
                    //-----------------------------------------------------------------------------------------
                    //if (txtName.Text != "")
                    {
                        sr.query = "INSERT INTO SPR_AB  values (" + dog + ",null,'" + Convert.ToString(textBox2.Text) + "',null,null,   '" + Convert.ToString(textBox7.Text) + "','" + Convert.ToString(textBox6.Text) + "','" + Convert.ToString(textBox5.Text) + "'," + comboBox2.SelectedValue + ",null," + cb3 + "," + comboBox5.SelectedValue + "," + ul + ",'" + Convert.ToString(textBox3.Text) + "','" + Convert.ToString(textBox4.Text) + "')";
                        sr.ExecSQL(sr.query);
                    }



                    label12.Visible = true;
                    label24.Visible = true;
                    textBox9.Visible = true;
                    groupBox1.Size = new Size(202, 201);
                    w = 0;


                    string q5 = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL where SPR_UL1.UL='" + comboBox4.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox3.Text + "' and SPR_AB.NDOM like '" + textBox3.Text + "' and  SPR_AB.NKV like '" + textBox4.Text + "' and SPR_AB.NDOG=" + dog;
                    con(q5);

                    #region BAZA

                    DateTime now1 = DateTime.Now;

                    w = 1;
                    //


                    int master = Convert.ToInt32(comboBox2.SelectedValue);
                    sr.query = "INSERT INTO Zajavki  values (" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + ",'" + master + "','', null ,'" + now1.ToString() + "','false',null,'false',null,'" + now1.AddDays(3).ToShortDateString() + "',' ','false',null,' ' )";
                    sr.ExecSQL(sr.query);
                    w = 0;
                    textBox1.Text = "";


                    qwe = 2;
                    string q123 = "SELECT [individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG,SPR_AB.FAM AS Фамилия, SPR_AB.IM AS Имя, SPR_AB.OT AS Отчество, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки],data_okonch_sroka AS [Конец срока],mesto_nahogdenia AS [Примечание], Zajavki.id_zajzvki,Zajavki.тел FROM SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG WHERE  (((Zajavki.id_master) Is Null))  ORDER BY data desc";
                    con(q123);
                    #endregion

                    DateTime now = DateTime.Now;
                    v = true;


                    sr.query = "INSERT INTO zap_dejstvij_disp  values ('Заявку принял','" + admin.dis + "','" + now.ToString() + "')";
                    sr.ExecSQL(sr.query);
                    v = false;


                    textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else MessageBox.Show("Заполните ФИО");

            }
            catch { }
        }
        #endregion

        //Добавить заявку
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Visible = false;// ПОИСК И ДОБ-Е АБОНЕНТА
                groupBox2.Visible = true;// ЗАЯВКА
                groupBox2.Size = new Size(405, 220);
                groupBox2.Location = new Point(600, 12);

                textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                button2.Visible = false;
                button4.Visible = false;

                checkBox1.Visible = true;

                textBox1.Focus();

                DateTime now = DateTime.Now;
                label7.Text = now.ToString();
            }
            catch { }
        }

        public static bool v = false;
        
        //Принять заявку
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    r = 0;

                    groupBox2.Visible = false;// ЗАЯВКА
                    groupBox1.Visible = true;// ПОИСК И ДОБ-Е АБОНЕНТА
                    #region BAZA

                    DateTime dat = new DateTime();
                    dat = Convert.ToDateTime(label7.Text);


                  
                    w = 1;


                    int master = 0;
                    z = "SELECT id_problem FROM problem_po_remontu_kabTV WHERE problema='" + comboBox1.Text + "'";
                    reader = sr.ReadSQLExec(z);
                    while (reader.Read())
                    {
                        master = Convert.ToInt32(reader[0]);
                    }
                    sr.cn.Close();
     
                    if (checkBox1.Checked == true)
                    {
                        if (checkBox4.Checked == false)
                        {
                            sr.query = "INSERT INTO Zajavki values (" + Convert.ToInt32(textBox1.Text) + ",null,'" + richTextBox1.Text + "', null ,'" + label7.Text + "' ,'false',null,'false',null,'" + dat.AddDays(3).ToShortDateString() + "','" + textBox8.Text + "','false',null,'" + textBox10.Text + "')";
                        }
                        else
                        {
                            sr.query = "INSERT INTO Zajavki  values (" + Convert.ToInt32(textBox1.Text) + ",null,'" + richTextBox1.Text + "', null ,'" + label7.Text + "' ,'false',null,'false',null,'" + dat.AddDays(3).ToShortDateString() + "','" + textBox8.Text + "','true',null,'" + textBox10.Text + "')";
                        }
                    }
                    else 
                    {
                        if (checkBox4.Checked == false)
                        {
                            sr.query = "INSERT INTO Zajavki  values (" + Convert.ToInt32(textBox1.Text) + ",'" + master + "',null, null ,'" + label7.Text + "','false',null,'false',null,'" + dat.AddDays(3).ToShortDateString() + "','" + textBox8.Text + "','false',null,'" + textBox10.Text + "' )";
                            
                        }
                        else
                        {
                            sr.query = "INSERT INTO Zajavki  values (" + Convert.ToInt32(textBox1.Text) + ",'" + master + "','', null ,'" + label7.Text + "','false',null,'false',null,'" + dat.AddDays(3).ToShortDateString() + "','" + textBox8.Text + "','true',null,'" + textBox10.Text + "' )";
                        }
                    }
                    
                    sr.ExecSQL(sr.query);
                    w = 0;
                    textBox1.Text = "";


                    qwe = 2;
                    string q123 = "SELECT [individ/kollectiv] AS [инд/ кол], SPR_AB.NDOG  as [№Дог],SPR_AB.FAM AS Фамилия, SPR_AB.IM AS Имя, SPR_AB.OT AS Отчество, problem_po_remontu_kabTV.problema AS [Стандартная проблема], Zajavki.problem AS [Нестандартные проблемы], Zajavki.data AS [Дата и время заявки],data_okonch_sroka AS [Конец срока],mesto_nahogdenia AS [Примечание], Zajavki.id_zajzvki,Zajavki.тел FROM SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG WHERE  (((Zajavki.id_master) Is Null))  ORDER BY data desc";
                    con(q123);
                    #endregion

                    label7.Text = "";
                    button2.Visible = true;
                    button4.Visible = true;


                    checkBox1.Visible = false;
                    checkBox1.Checked = false;
                    richTextBox1.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                    DateTime now = DateTime.Now;
                    v = true;


                    sr.query = "INSERT INTO zap_dejstvij_disp  values ('Заявку принял','" + admin.dis + "','" + now.ToString() + "')";
                    sr.ExecSQL(sr.query);
                    v = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    dataGridView2.Focus();

                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox10.Text = "";
                    qwe = 1;
                    string q = "SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город,  SPR_T_UL.S_NAIM as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL";
                    con(q);
                }
            }
            catch { }
        }

        //Отмена
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                r = 0;

                groupBox2.Visible = false;// ЗАЯВКА
                groupBox1.Visible = true;// ПОИСК И ДОБ-Е АБОНЕНТА

                textBox1.Text = "";

                label7.Text = "";
                button2.Visible = true;
                button4.Visible = true;
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
            catch { }
        }

        //Доб абонента
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                label24.Visible = false;
                textBox9.Visible = false;
                label9.Text = "            Ф.И.О.";
                button2.Visible = false;
                button4.Visible = false;
                button5.Visible = true;
                label12.Visible = false;
                button6.Visible = true;
                textBox5.Text = textBox6.Text = textBox7.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
               // label13.Location = new Point(150, 246);
                dataGridView1.Location = new Point(10, 272);
                groupBox1.Size = new Size(398, 192);
//-----------------------------------------------------------------------
                string str_select = "SELECT * FROM dbo.SPR_OTN";
                comboBox2.DataSource = sr.GetUsersTable(str_select).Tables[0];
                comboBox2.ValueMember = "TOTN";
                comboBox2.DisplayMember = "NOTN";


                 str_select = "SELECT * FROM dbo.SPR_T_UL";
                comboBox5.DataSource = sr.GetUsersTable(str_select).Tables[0];
                comboBox5.ValueMember = "TUL";
                comboBox5.DisplayMember = "NAIM";


            }
            catch {}
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked == true)
                {
                    dateTimePicker1.Visible = true;
                    label7.Text = dateTimePicker1.Value.ToString("g", CultureInfo.CreateSpecificCulture("es-ES"));
                }
                else
                {
                    dateTimePicker1.Visible = false;
                }
            }
            catch { }
        }

        private void dataGridView2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && e.Shift)
                {


                    groupBox1.Visible = false;// ПОИСК И ДОБ-Е АБОНЕНТА
                    groupBox2.Visible = true;// ЗАЯВКА
                    groupBox2.Size = new Size(405, 220);
                    groupBox2.Location = new Point(600, 12);

                    textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    button2.Visible = false;
                    button4.Visible = false;

                    checkBox1.Visible = true;

                    textBox1.Focus();

                    DateTime now = DateTime.Now;
                    label7.Text = now.ToString();
                }
                if (e.KeyCode == Keys.P)
                {
                    comboBox3.Focus();
                }
            }
            catch { }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            comboBox1.DroppedDown = true; 
            //SendKeys.Send("{F4}");
            r = 1;
        }
        
        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                    if (e.KeyCode == Keys.Enter && e.Shift)
                    {
                        button1.Click += new System.EventHandler(button1_Click);
                }
            }
            catch { }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                label7.Text = dateTimePicker1.Value.ToString("g", CultureInfo.CreateSpecificCulture("es-ES"));
            }
            catch { }
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void richTextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            textBox8.Focus();
        }

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { textBox10.Focus(); }
            else
            {
                textBox8.Focus();
            }
        }

        private void dateTimePicker1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                label9.Text = "Поиск по фамилии:";
                button2.Visible = true;
                button4.Visible = true;
                button5.Visible = false;
                button6.Visible = false;
                label12.Visible = true;
                label24.Visible = true;
                textBox9.Visible = true;
                groupBox1.Size = new Size(202, 201);
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Narjad frm = new Narjad();
                frm.Show();
                this.Dispose();
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(dataGridView1.CurrentRow.Cells[10].Value.ToString());
                sr.query = "UPDATE Zajavki SET  Zajavki.mesto_nahogdenia='" + dataGridView1.CurrentRow.Cells[9].Value.ToString() + "' , Zajavki.data_okonch_sroka = '" + Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value).ToShortDateString() + "' WHERE Zajavki.id_zajzvki=" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[10].Value.ToString());// .Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))
                sr.ExecSQL(sr.query);
                // dataGridView1.ReadOnly = true;
            }
            catch { }
        }

        private void просмотретьИсториюЗаявокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NDOG = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                name = dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[3].Value.ToString();
                istor_zajavok_dlja_zajavok frm = new istor_zajavok_dlja_zajavok();
                frm.Show();
            }
            catch { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
          //  dataGridView1.ReadOnly = false;
        }

        private void comboBox4_TextUpdate(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView2.Focus();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                qwe = 1;
                string q = " SELECT  SPR_AB.NDOG as [№Дог],SPR_AB.TOTN as от, SPR_AB.FAM  AS Фамилия, SPR_AB.IM AS И, SPR_AB.OT AS О,SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as тип, SPR_UL1.UL as улица, SPR_AB.NDOM as дом, SPR_AB.NKV as кв FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_UL1.NUL = SPR_AB.NUL   WHERE SPR_AB.NDOG LIKE '%" + textBox9.Text + "%'";
                con(q);
            }
            catch { }
        }

        private void comboBox3_TextUpdate(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView2.Focus();
            }
        }

        private void textBox9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView2.Focus();
            }
        }

        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button8.Click += new System.EventHandler(button8_Click);
            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void textBox10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            { button1.Focus(); }
            else
            {
                textBox10.Focus();
            }
        }

        private void comboBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // button8.Click += new System.EventHandler(button8_Click);
                    comboBox3.SelectedIndexChanged += new System.EventHandler(comboBox3_SelectedIndexChanged);
                }
            }
            catch { }
        }

        private void comboBox5_TextUpdate(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

    }
}
