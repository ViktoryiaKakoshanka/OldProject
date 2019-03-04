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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static public int w = 0; static public int b = 0;
       static public bool ist;
       public DataGrid istorGrid;


       ConnectToDB sr = new ConnectToDB();
       string z = "";
       SqlDataReader reader;

       #region подключение con и вывод данных в табл
       public void con(string sql)
       {
           try
           {
               sr.cn.Open();
               if (b == 3) dataGridView3.DataSource = sr.GetUsersTable(sql).Tables[0];
               else
               {
                   if (b == 2) dataGridView2.DataSource = sr.GetUsersTable(sql).Tables[0];
                   else { dataGridView1.DataSource = sr.GetUsersTable(sql).Tables[0]; }
               }
               sr.cn.Close();
           }
           catch { }

       }
       #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
           try
            {
                #region     //город
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                z = " SELECT NAMEGOR FROM dbo.SPR_GOR";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                    comboBox5.Items.Add(reader[0]);
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
                sr.cn.Close();
                #endregion
               
                
                #region      //тип отношений
                comboBox2.Items.Clear();
                comboBox7.Items.Clear();
                z = "SELECT NOTN FROM dbo.SPR_OTN";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0]);
                    comboBox7.Items.Add(reader[0]);
                }
                comboBox2.Text = comboBox2.Items[0].ToString();
                sr.cn.Close();
                #endregion
                textBox9.BackColor = Color.Silver;
         
            ist = false;
            b = 0;
            string q = "SELECT SPR_AB.NDOG , SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_T_UL.NAIM, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL ORDER BY SPR_AB.NDOG desc";
            con(q);

            tabPage2.Controls.Add(dataGridView1);//список абонентов


            textBox2.Text = "";
            textBox3.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";

         /*   dataGridView3.Columns[0].Width = 300;
            dataGridView3.Columns[1].Width = 100;*/

            textBox9.BackColor = Color.Silver;
            }
            catch {  }
        }

        #region
        //ГОРОД
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                #region созд comboBox4-улицы
                comboBox3.Items.Clear();
                z = "SELECT  SPR_UL1.UL FROM SPR_GOR, SPR_UL1, [GOR-UL] WHERE  SPR_UL1.NUL = [GOR-UL].NUL and SPR_GOR.NGOR = [GOR-UL].NGOR and SPR_GOR.NAMEGOR= '" + comboBox1.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader[0]);
                }
                comboBox3.Text = comboBox3.Items[0].ToString();
                sr.cn.Close();
                #endregion

                string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR, SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL  where SPR_GOR.NAMEGOR = '" + comboBox1.Text + "' ORDER BY SPR_AB.NDOG desc";               
                con(q);
            }
            catch {}
        }

        //ТИП ОТНОШЕНИЙ
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL where SPR_OTN.NOTN ='" + comboBox2.Text + "' ORDER BY SPR_AB.NDOG desc";
                con(q);
            }
            catch {  }
        }

        //УЛИЦА
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL where SPR_UL1.UL='" + comboBox3.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox1.Text + "' ORDER BY SPR_AB.NDOG desc";
                con(q);
            }
            catch {  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL where    SPR_AB.DDOG  BETWEEN '" + dateTimePicker1.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker2.Value.Date.ToShortDateString() + "' ORDER BY SPR_AB.NDOG desc";
                con(q);
            }
            catch { }
        }
     
        private void button2_Click(object sender, EventArgs e)//Доб-е
        {
            try
            {
                w = 1;

                textBox9.ReadOnly = false;
                textBox9.Text = "";
                textBox8.ReadOnly = false;
                textBox8.Text = "";
                textBox7.ReadOnly = false;
                textBox7.Text = "";
                textBox6.ReadOnly = false;
                textBox6.Text = "";
                textBox1.ReadOnly = false;
                textBox1.Text = "";
                textBox4.ReadOnly = false;
                textBox4.Text = "";
                textBox5.ReadOnly = false;
                textBox5.Text = "";
                textBox11.ReadOnly = false;
                textBox11.Text = "";
                textBox10.ReadOnly = false;
                textBox10.Text = "";

                textBox14.Visible = false;
                textBox13.Visible = false;
                textBox12.Visible = false;
                textBox16.Visible = false;
                textBox15.Visible = false;
                textBox17.Visible = false;

                button6.Visible = true;
                button7.Visible = true;

                dateTimePicker3.Visible = true;
                dateTimePicker3.Value = DateTime.Now;
                dateTimePicker4.Visible = true;
                dateTimePicker4.Value = DateTime.Now;

                comboBox7.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox4.Visible = true;

                comboBox5.Focus();
                comboBox5.DroppedDown = true; 

            }
            catch {  }

            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try{
            menu frm = new menu();
            frm.Show();
            this.Dispose();
            }
            catch { }
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL where SPR_AB.FAM like '%" + textBox2.Text + "%' ORDER BY SPR_AB.NDOG desc";
                con(q);
            }
            catch {  }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Желаете удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) //Если нажал Да
            {
                try
                {
                    sr.query = "DELETE FROM Istoria_OTN where  Istoria_OTN.NDOG = " + Convert.ToInt32(textBox9.Text);
                    sr.ExecSQL(sr.query);

                    sr.query = "DELETE FROM Zajavki where  Zajavki.NDOG = " + Convert.ToInt32(textBox9.Text);
                    sr.ExecSQL(sr.query);

                    sr.query = "DELETE FROM SPR_AB where  SPR_AB.NDOG = " + Convert.ToInt32(textBox9.Text);
                    sr.ExecSQL(sr.query);
                }
                catch {  }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL where SPR_AB.NDOG like '%" + textBox3.Text + "%' ORDER BY SPR_AB.NDOG desc";
                con(q);
            }
            catch { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            #region ШИРИНА И ВИДИМОСТЬ СТОЛБЦОВ
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].Width = 30;
            dataGridView1.Columns[4].Width = 30;
            dataGridView1.Columns[8].Width = 150;
            dataGridView1.Columns[9].Width = 70;
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].Width = 70;
            dataGridView1.Columns[13].Width = 40;
            dataGridView1.Columns[14].Width = 40;
            #endregion
           #region данные
             try
            {
                //if (dataGridView1.Rows.Count != null)
                { textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString(); //номер договора

                    dateTimePicker3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();//дата дог
                    textBox14.Text = dateTimePicker3.Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));//дата дог

                    textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); //фамилия
                    textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();//имя
                    textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();//отчество
                    textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();//тел1
                    textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();//тел2
                    textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();//тел3

                    comboBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString(); //номер договора
                    textBox13.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

                    dateTimePicker4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();//дата дог
                    textBox12.Text = dateTimePicker4.Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));

                    comboBox5.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString(); //фамилия
                    textBox16.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();

                    comboBox6.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();//имя
                    textBox15.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

                    comboBox4.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();//отчество
                    textBox17.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

                    textBox11.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();//тел1
                    textBox10.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();//тел2
                }
            }
            catch { }
            #endregion

             try
             {
                 b = 2;
                 string q = "SELECT Istoria_OTN.NDOG, Istoria_OTN.DATA, SPR_OTN.NOTN FROM SPR_OTN INNER JOIN Istoria_OTN ON SPR_OTN.TOTN = Istoria_OTN.TOTN where Istoria_OTN.NDOG=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + " ORDER BY Istoria_OTN.DATA";
                 con(q);
                 b = 0;
             }
             catch { }
             try
             {
                 b = 3;
                 string q11 = "  SELECT Zajavki.data, problem_po_remontu_kabTV.problema FROM problem_po_remontu_kabTV  INNER JOIN Zajavki ON problem_po_remontu_kabTV.id_problem = Zajavki.id_problem WHERE Zajavki.NDOG=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                 con(q11);
                 b = 0;
             }
             catch { }
            }
            catch { }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
            }
            catch { }
        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                #region улицы
                z = "SELECT SPR_UL1.NUL FROM SPR_UL1 WHERE SPR_UL1.UL='" + comboBox4.Text + "'";
                reader = sr.ReadSQLExec(z);
                int ul = 0;
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    ul = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();//закрываем соединение с БД
                #endregion

                #region город
                z = "SELECT NGOR FROM dbo.SPR_GOR WHERE NAMEGOR='" + comboBox5.Text + "'";
                reader = sr.ReadSQLExec(z);
                int gor = 0;
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    gor = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();//закрываем соединение с БД
                #endregion

                #region тип отношений
                z = "SELECT TOTN FROM dbo.SPR_OTN WHERE NOTN='" + comboBox7.Text + "'";
                reader = sr.ReadSQLExec(z);
                int totn = 0;
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    totn = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();//закрываем соединение с БД
                #endregion

                #region тип отношений
                z = "SELECT TUL FROM dbo.SPR_T_UL WHERE NAIM='" + comboBox6.Text + "'";
                reader = sr.ReadSQLExec(z);
                int tul = 0;
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    tul = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();//закрываем соединение с БД
                #endregion

                if (w == 1)
                {
                    #region if
                    z = "SELECT NDOG FROM SPR_AB";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    if (Convert.ToInt32(reader[0]) == Convert.ToInt32(textBox9.Text))
                    {
                        MessageBox.Show("Договор с таким номером существует");//отображаем сообщение, о некорректном логине или пароле
                        textBox9.BackColor = Color.FromArgb(230, 54, 80);//фон textbox1 делаем красным
                    }
                }
                sr.cn.Close();//закрываем соединение с БД

                if (textBox9.BackColor != Color.FromArgb(230, 54, 80))
                {
                    sr.query = "INSERT INTO SPR_AB  values (" + Convert.ToInt32(textBox9.Text) + ",'" + dateTimePicker3.Value.Date.ToShortDateString() + "','" + Convert.ToString(textBox8.Text) + "','" + Convert.ToString(textBox7.Text) + "','" + Convert.ToString(textBox6.Text) + "','" + Convert.ToString(textBox1.Text) + "','" + Convert.ToString(textBox4.Text) + "','" + Convert.ToString(textBox5.Text) + "'," + totn + ",'" + dateTimePicker4.Value.Date.ToShortDateString() + "'," + gor + "," + tul + "," + ul + ",'" + Convert.ToString(textBox11.Text) + "','" + Convert.ToString(textBox10.Text) + "')";
                    sr.ExecSQL(sr.query);

                    sr.query = "INSERT INTO Istoria_OTN  values (" + Convert.ToInt32(textBox9.Text) + ",'" + dateTimePicker4.Value.Date.ToShortDateString() + "'," + totn + ")";
                    sr.ExecSQL(sr.query);

                    textBox9.ReadOnly = true;
                    textBox8.ReadOnly = true;
                    textBox7.ReadOnly = true;
                    textBox6.ReadOnly = true;
                    textBox1.ReadOnly = true;
                    textBox4.ReadOnly = true;
                    textBox5.ReadOnly = true;
                    textBox11.ReadOnly = true;
                    textBox10.ReadOnly = true;
                    textBox9.BackColor = Color.Silver;

                    textBox14.Visible = true;
                    textBox13.Visible = true;
                    textBox12.Visible = true;
                    textBox16.Visible = true;
                    textBox15.Visible = true;
                    textBox17.Visible = true;

                    button6.Visible = false;
                    button7.Visible = false;

                    dateTimePicker3.Visible = false;
                    dateTimePicker4.Visible = false;

                    comboBox7.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox4.Visible = false;
                }
                
                w = 0;
                    #endregion
                }
            else
                {
                    #region else
                    if (textBox9.BackColor == Color.Silver)
                    {
                        sr.query = "update SPR_AB set  DDOG= '" + dateTimePicker3.Value.Date.ToShortDateString() + "', FAM='" + Convert.ToString(textBox8.Text) + "', IM='" + Convert.ToString(textBox7.Text) + "', OT='" + Convert.ToString(textBox6.Text) + "', MTEL1='" + Convert.ToString(textBox1.Text) + "', MTEL2='" + Convert.ToString(textBox4.Text) + "', TEL='" + Convert.ToString(textBox5.Text) + "', TOTN=" + totn + ", DOTN='" + dateTimePicker4.Value.Date.ToShortDateString() + "', NGOR=" + gor + ", TUL=" + tul + ", NUL=" + ul + ", NDOM='" + Convert.ToString(textBox11.Text) + "', NKV='" + Convert.ToString(textBox10.Text) + "' where NDOG= " + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        sr.ExecSQL(sr.query);
                    }
                    else
                    {
                        sr.query = "update SPR_AB set NDOG= " + Convert.ToInt32(textBox9.Text) + ", DDOG= '" + dateTimePicker3.Value.Date.ToShortDateString() + "', FAM='" + Convert.ToString(textBox8.Text) + "', IM='" + Convert.ToString(textBox7.Text) + "', OT='" + Convert.ToString(textBox6.Text) + "', MTEL1='" + Convert.ToString(textBox1.Text) + "', MTEL2='" + Convert.ToString(textBox4.Text) + "', TEL='" + Convert.ToString(textBox5.Text) + "', TOTN=" + totn + ", DOTN='" + dateTimePicker4.Value.Date.ToShortDateString() + "', NGOR=" + gor + ", TUL=" + tul + ", NUL=" + ul + ", NDOM='" + Convert.ToString(textBox11.Text) + "', NKV='" + Convert.ToString(textBox10.Text) + "' where NDOG= " + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        sr.ExecSQL(sr.query);
                    }
                w = 0;
           
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == textBox9.Text && ist == true && textBox13.Text != comboBox7.Text && textBox12.Text != dateTimePicker4.Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")))
            {
               // MessageBox.Show("hggugu");
                sr.query = "INSERT INTO Istoria_OTN  values (" + Convert.ToInt32(textBox9.Text) + ",'" + dateTimePicker4.Value.Date.ToShortDateString() + "'," + totn + ")";
                sr.ExecSQL(sr.query);
            }
            textBox9.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox10.ReadOnly = true;

            textBox14.Visible = true;
            textBox13.Visible = true;
            textBox12.Visible = true;
            textBox16.Visible = true;
            textBox15.Visible = true;
            textBox17.Visible = true;

            button6.Visible = false;
            button7.Visible = false;

            dateTimePicker3.Visible = false;
            dateTimePicker4.Visible = false;

            comboBox7.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox4.Visible = false;
                    #endregion
                }
            }
            catch {  }
        }

        private void button5_Click(object sender, EventArgs e)//изм-е
        {
            try{
            w = 2;

            ist = true;
            
            textBox9.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox1.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox10.ReadOnly = false;

            textBox14.Visible = false;
            textBox13.Visible = false;
            textBox12.Visible = false;
            textBox16.Visible = false;
            textBox15.Visible = false;
            textBox17.Visible = false;

            button6.Visible = true;
            button7.Visible = true;

            dateTimePicker3.Visible = true;
            dateTimePicker4.Visible = true;

            comboBox7.Visible = true;
            comboBox5.Visible = true;
            comboBox6.Visible = true;
            comboBox4.Visible = true;

            }
            catch {  }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                textBox9.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox1.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox11.ReadOnly = true;
                textBox10.ReadOnly = true;

                textBox14.Visible = true;
                textBox13.Visible = true;
                textBox12.Visible = true;
                textBox16.Visible = true;
                textBox15.Visible = true;
                textBox17.Visible = true;

                button6.Visible = false;
                button7.Visible = false;

                dateTimePicker3.Visible = false;
                dateTimePicker4.Visible = false;

                comboBox7.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox4.Visible = false;
            }
            catch {  }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == false)
                {
                    string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL where SPR_UL1.UL='" + comboBox3.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox1.Text + "' and SPR_AB.NDOM like '" + textBox18.Text + "%' ORDER BY SPR_AB.NDOG desc";
                    con(q);
                }
                else
                {
                    string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL where SPR_UL1.UL='" + comboBox3.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox1.Text + "' and SPR_AB.NDOM like '" + textBox18.Text + "' ORDER BY SPR_AB.NDOG desc";
                    con(q);
                }
            }
            catch {}
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == false)
                {
                string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL where SPR_UL1.UL='" + comboBox3.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox1.Text + "' and SPR_AB.NDOM like '" + textBox18.Text + "%' and  SPR_AB.NKV like '" + textBox19.Text + "' ORDER BY SPR_AB.NDOG desc";
                con(q);
                }
                else
                {
                    string q = "SELECT  SPR_AB.NDOG, SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_UL1.TIP, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL where SPR_UL1.UL='" + comboBox3.Text + "'  and SPR_GOR.NAMEGOR = '" + comboBox1.Text + "' and SPR_AB.NDOM like '" + textBox18.Text + "' and  SPR_AB.NKV like '" + textBox19.Text + "' ORDER BY SPR_AB.NDOG desc";
                    con(q);
                }
            }
            catch { }
        }

        #endregion


        private void comboBox6_TextUpdate(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void comboBox4_TextUpdate(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void comboBox7_TextUpdate(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Visible == true)
            {
                textBox9.BackColor = Color.White;
                w = 1;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.BackColor = Color.Silver;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                #region созд comboBox4-улицы
                comboBox4.Items.Clear();
                z = "SELECT  SPR_UL1.UL FROM SPR_GOR, SPR_UL1, [GOR-UL] WHERE  SPR_UL1.NUL = [GOR-UL].NUL and SPR_GOR.NGOR = [GOR-UL].NGOR and SPR_GOR.NAMEGOR= '" + comboBox5.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox4.Items.Add(reader[0]);
                }
                comboBox4.Text = comboBox4.Items[0].ToString();
                sr.cn.Close();
                #endregion
            }
            catch { }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView2.Columns[0].Width = 45;
                dataGridView2.Columns[1].Width = 75;
                dataGridView2.Columns[2].Width = 300;
            }
            catch { }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView3.Columns[1].Width = 300;
                dataGridView3.Columns[0].Width = 100;
            }
            catch { }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
                b = 0;
                string q = "SELECT SPR_AB.NDOG , SPR_AB.DDOG, SPR_AB.FAM, SPR_AB.IM, SPR_AB.OT, SPR_AB.MTEL1, SPR_AB.MTEL2, SPR_AB.TEL, SPR_OTN.NOTN, SPR_AB.DOTN, SPR_GOR.NAMEGOR,  SPR_T_UL.NAIM, SPR_UL1.UL, SPR_AB.NDOM, SPR_AB.NKV FROM SPR_T_UL INNER JOIN (SPR_UL1 INNER JOIN (SPR_OTN INNER JOIN (SPR_GOR INNER JOIN SPR_AB ON SPR_GOR.NGOR = SPR_AB.NGOR) ON SPR_OTN.TOTN = SPR_AB.TOTN) ON SPR_UL1.NUL = SPR_AB.NUL) ON SPR_T_UL.TUL = SPR_AB.TUL ORDER BY SPR_AB.NDOG desc";
                con(q);
            }
            catch { }
        }


  

       

      
      


        



       

     



     
      
    }
}
