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
    public partial class RUR : Form
    {
        public RUR()
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

        private void RUR_Load(object sender, EventArgs e)
        {
            try
            {
                //gorod
                comboBox5.Items.Clear();
                z = "SELECT NAMEGOR FROM dbo.SPR_GOR";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox5.Items.Add(reader[0]);
                }
                comboBox5.Text = comboBox5.Items[0].ToString();
                sr.cn.Close();

                //ответственный и исполняющий
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                z = "SELECT MASTER.FIO FROM MASTER WHERE MASTER.brigada='True'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0]);
                    comboBox3.Items.Add(reader[0]);
                }
                comboBox2.Text = comboBox2.Items[0].ToString();
                comboBox3.Text = comboBox3.Items[0].ToString();
                sr.cn.Close();

               

                if (admin.ad == "")
                {
                    label6.Text = admin.dis;
                }
                else { label6.Text = admin.ad; }

                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата, srok as срок, RUR.primechanie as Примечание, RUR.id_rur,  status_vipolnenia as вып, data_vipolnenia as _дата, obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL WHERE status_vipolnenia= 'false'";
                con(q123);
            }
            catch { }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //созд comboBox4-улицы
                comboBox4.Items.Clear();
                z = "SELECT  SPR_UL1.UL FROM SPR_GOR, SPR_UL1, [GOR-UL] WHERE  SPR_UL1.NUL = [GOR-UL].NUL and SPR_GOR.NGOR = [GOR-UL].NGOR and SPR_GOR.NAMEGOR= '" + comboBox5.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox4.Items.Add(reader[0]);
                }
                comboBox4.Text = comboBox4.Items[0].ToString();
                sr.cn.Close();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {/*
                ConnectToDB k = new ConnectToDB();
                string l = "SELECT id_rur FROM RUR ORDER BY id_rur";
                OleDbDataReader tt;
                tt = k.ConnectDB(l);
                int m = 0;
                while (tt.Read())//проходим по строкам таблицы результирующего запроса
                {
                    m = Convert.ToInt32(tt[0]);// MessageBox.Show(m.ToString());
                }
                m = m + 1;
                k.CloseConnectDB();//закрываем соединение с БД*/

                int gor = 0;
                z = "SELECT NGOR FROM dbo.SPR_GOR where NAMEGOR='" + comboBox5.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    gor = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();

                int ul = 0;
                z = "SELECT NUL FROM SPR_UL1 WHERE UL='" + comboBox4.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    ul = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();

                if (comboBox4.Text != "")
                {

                    sr.query = "INSERT INTO RUR  values ('" + label6.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "'," + gor + "," + ul + ",   '" + textBox3.Text + "','" + textBox4.Text + "','" + richTextBox1.Text + "',   '" + dateTimePicker1.Value.Date.ToShortDateString() + "','" + richTextBox2.Text + "',null,'false', null , 'false', '" + dateTimePicker4.Value.Date.ToShortDateString() + "')";
                    sr.ExecSQL(sr.query);
                   
                }
                else
                {
                    sr.query = "INSERT INTO RUR  values ('" + label6.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "'," + gor + "," + 43 + ",   '" + textBox3.Text + "','" + textBox4.Text + "','" + richTextBox1.Text + "',   '" + dateTimePicker1.Value.Date.ToShortDateString() + "','" + richTextBox2.Text + "',null,'false', null , 'false', '" + dateTimePicker4.Value.Date.ToShortDateString() + "')";
                    sr.ExecSQL(sr.query);
                }


                button1.Visible = false;

                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата, srok as срок,  RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL";
                con(q123);

                richTextBox1.Text = "";
                richTextBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                dataGridView1.Focus();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{
           // MessageBox.Show(dataGridView1.CurrentRow.Cells[12].Value.ToString());

                sr.query = "UPDATE RUR SET  data_vipolnenia='" + dateTimePicker2.Value.Date.ToShortDateString() + "',status_vipolnenia= 'true' WHERE RUR.id_rur=" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value);
                sr.ExecSQL(sr.query);

            string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата, srok as срок,  RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL";
            con(q123);
            }
        catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата, srok as срок,  RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL";
                con(q123);
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата,  srok as срок, RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL WHERE status_vipolnenia= 'true' and obratnij_dozvon='false'";
                con(q123);
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата,  srok as срок, RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL WHERE status_vipolnenia= 'false'";
                con(q123);
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата,  srok as срок, RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL WHERE status_vipolnenia= 'true' and obratnij_dozvon='true'";
                con(q123);
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                sr.query = "UPDATE RUR SET  data_dozvona='" + dateTimePicker3.Value.Date.ToShortDateString() + "',obratnij_dozvon= 'true' WHERE RUR.id_rur=" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value);
                sr.ExecSQL(sr.query);

                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата, srok as срок,  RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL";
                con(q123);
            }
            catch { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns[13].Visible = false;

                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[14].Value) == true)
                {
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dateTimePicker3.Visible = true;
                    button4.Visible = true;
                    dateTimePicker2.Visible = false;
                    button3.Visible = false;
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[14].Value) == false)
                {
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightCoral;
                    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dateTimePicker3.Visible = false;
                    button4.Visible = false;
                    dateTimePicker2.Visible = true;
                    button3.Visible = true;
                }
            }
            catch { }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker4.Text = dateTimePicker1.Value.Date.AddDays(3).ToShortDateString();
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                button1.Visible = true;

                comboBox2.Focus();
                SendKeys.Send("{F4}");
            }
            catch { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                button11.Visible = true;
                comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                richTextBox1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                richTextBox2.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            }
            catch { }
            
        }

        private void RUR_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menu frm2 = new menu();
                frm2.Show();//открываем форму для админа                   
                this.Dispose();//скрываем форму входа
            }
            catch { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int gor = 0;
                z = "SELECT NGOR FROM dbo.SPR_GOR where NAMEGOR='" + comboBox5.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    gor = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();

                int ul = 0;
                z = "SELECT NUL FROM SPR_UL1 WHERE UL='" + comboBox4.Text + "'";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    ul = Convert.ToInt32(reader[0]);
                }
                sr.cn.Close();

                sr.query = "UPDATE RUR SET  otvetstvennij='" + comboBox2.Text + "', ispolnitel= '" + comboBox3.Text + "', NGOR=" + gor + ",  NUL=" + ul + ",  ndom='" + textBox3.Text + "',  nkv='" + textBox4.Text + "',  problem='" + richTextBox1.Text + "',  data='" + dateTimePicker3.Value.Date.ToShortDateString() + "',  primechanie='" + richTextBox2.Text + "', srok='" + dateTimePicker4.Value.Date.ToShortDateString() + "'  WHERE RUR.id_rur=" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value);
                sr.ExecSQL(sr.query);

                button11.Visible = false;

                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата, srok as срок,  RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL";
                con(q123);
            }
            catch { }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dat = DateTime.Now;
                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Отвеиственный, RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата,  srok as срок, RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL WHERE status_vipolnenia='False' AND srok>='" + dat.ToShortDateString() + "'";
                con(q123);
            }
            catch { }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dat = DateTime.Now;
                string q123 = "SELECT RUR.dispetcher as Диспетчер, RUR.otvetstvennij as Ответственный, srok as срок,  RUR.ispolnitel as Исполнитель, SPR_GOR.SOATO as г, SPR_GOR.NAMEGOR as Город, SPR_UL1.TIP as ул, SPR_UL1.UL as улица, RUR.ndom as Дом, RUR.nkv as Кв, RUR.problem as Проблема, RUR.data as Дата, RUR.primechanie as Примечание, RUR.id_rur,status_vipolnenia as вып, data_vipolnenia as _дата,obratnij_dozvon as контр, data_dozvona as дата_ FROM SPR_UL1 INNER JOIN (SPR_GOR INNER JOIN RUR ON SPR_GOR.NGOR = RUR.NGOR) ON SPR_UL1.NUL = RUR.NUL WHERE status_vipolnenia='False' AND srok<'" + dat.ToShortDateString() + "'";
                con(q123);
            }
            catch { }
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {

            SendKeys.Send("{F4}");
        }

        private void comboBox3_TextUpdate(object sender, EventArgs e)
        {

            SendKeys.Send("{F4}");
        }

        private void comboBox5_TextUpdate(object sender, EventArgs e)
        {

            SendKeys.Send("{F4}");
        }

        private void comboBox4_TextUpdate(object sender, EventArgs e)
        {

            SendKeys.Send("{F4}");
        }

        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[14].Value) == true)
                {

                    if (e.KeyCode == Keys.P)
                    {
                        button3.Focus();
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.P)
                    {
                        button4.Focus();
                    }
                }
            }
            catch { }

        }
    }
}
