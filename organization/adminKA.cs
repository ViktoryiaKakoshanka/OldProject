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
using System.IO;
using System.Diagnostics;

namespace organization
{
    public partial class adminKA : Form
    {
        public adminKA()
        {
            InitializeComponent();
        }

        public static bool arhiv = false;

        public int t1 = 0;
        string sql = "";

        
        protected Timer time1, time2, time3, time4;
        protected CheckBox ch1;
        protected PictureBox p;
        protected DataGridView dgv1, dgv2, dgv3;
        protected DateTimePicker dtp1;
        protected Label l1, l2, l3, l4, l5, l6, l7, l8, l9, l10;
        protected TextBox tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9;
        protected Button b1, b2, b3, b4, b5, b6, b7;
        protected ComboBox cb1, cb2;
        protected GroupBox gb1, gb2, gb3, gb4;
        protected ListBox list1, list2;
        protected int prosmotr = 0;

        static string pc = "pc50", user = "orgUs";

        protected SqlConnection cn = new SqlConnection(@"Server=tcp:" + pc + ",49172;  Integrated Security=false; User ID="+user+";Password=11;");

        protected SqlCommand cmd = new SqlCommand();


        ConnectToDB sr = new ConnectToDB();
        string z = "";
        SqlDataReader reader;

       /* void attach(string db)
        {
            SqlConnection cn = new SqlConnection(@"Server=tcp:vika-pc,49172; Initial Catalog=" + db + "; Integrated Security=false; User ID=us;Password=11;");
            SqlCommand cmd = new SqlCommand();

        }*/

        void soed()
        {
            try
            {
                if (pc != Environment.MachineName.ToLower()) MessageBox.Show("Не на этом подключена БД, поэтому дальнейшие действия будут некорректны!");
                DialogResult result = MessageBox.Show("Для этого необходимо закрыть это приложение и другие по сети.", "Прервать работу?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) //Если нажал Да
                {
                    arhiv = true;
                    sr.query = "UPDATE Роли SET  vhod='false' WHERE login='" + admin.dis + "'";
                    sr.ExecSQL(sr.query);
                    if (sr.cn.State == ConnectionState.Open) sr.cn.Close();
                    this.Dispose();
                    admin aaa = new admin();

                    aaa.Show(); 

                    string s = "conn.txt";
                    System.IO.StreamWriter textFile = new System.IO.StreamWriter(s);

                    textFile.Write("Архив");
                  
                    textFile.Close();
                }
            }
            catch
            {
                //Process.Start(@"D:\ЦТО ООО Веста ТВ\connect\connect\bin\Debug\connect.exe");
               // sr.query = "UPDATE Роли SET  vhod='false' WHERE login='" + admin.dis + "'";
                //sr.ExecSQL(sr.query);
               // Environment.Exit(0);
            }
        }

        #region подключение con и вывод данных в табл
        public void con(string sql, int t)
        {
            try
            {
                sr.cn.Open();
                if (t==1)
                dgv1.DataSource = sr.GetUsersTable(sql).Tables[0];
                else
                    if (t==2)
                    dgv2.DataSource = sr.GetUsersTable(sql).Tables[0];
                else
                        dgv3.DataSource = sr.GetUsersTable(sql).Tables[0];
                sr.cn.Close();
            }
            catch { }

        }
        #endregion

        public int k = 0, dob = 0, red = 0, del = 0;


        
        private void adminKA_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menu frm = new menu();
                frm.Show();
                this.Dispose();
            }
            catch { }
        }
        //Сохранить

        private void adminKA_Load(object sender, EventArgs e)
        {
            try
            {
                p = new PictureBox() { Location = new Point(850, 5), Size = new Size(75, 30), BackColor= Color.Transparent };
                p.Image = Image.FromFile(@""+Environment.CurrentDirectory + @"\img\on.png");
                p.Tag = @"" + Environment.CurrentDirectory + @"\img\on.png";
                p.Click += p_Click;
                p.Visible = false;

                this.Controls.Add(p);


                // dispose(prosmotr);
                prosmotr = 0;
                timerr();


                if (admin.ad == "Админ")
                {
                    просмотрToolStripMenuItem.Visible = true;
                    настройкиToolStripMenuItem.Visible = true;
                }
                else
                {
                    просмотрToolStripMenuItem.Visible = false;
                    настройкиToolStripMenuItem.Visible = false;
                }
            }
            catch { }
        }

        private void p_Click(object sender, EventArgs e)
        {
            if (p.Tag.ToString() == (string)@"" + Environment.CurrentDirectory + @"\img\on.png")
            {
                p.Image = Image.FromFile(@"" + Environment.CurrentDirectory + @"\img\off.png");
                p.Tag = @"" + Environment.CurrentDirectory + @"\img\off.png";

               // if (prosmotr == 21) dgv1.Visible = false;
                if (prosmotr == 11 || prosmotr == 12)
                {
                    //timerr

                    tb1.Visible = false;
                    dgv1.Visible = false;
                    l1.Visible = false;
                    b1.Visible = false;
                    b2.Visible = false;
                    b3.Visible = false;
                }
                else
                    if (prosmotr == 31)
                    {
                        dgv1.Visible = false;
                        gb1.Visible = false;
                        gb2.Visible = false;
                        gb3.Visible = false;
                        gb4.Visible = false;
                    }
                    else
                        if (prosmotr == 13)
                        {
                            cb1.Visible = false;
                            dgv2.Visible = false;
                            b4.Visible = false;
                            b5.Visible = false;
                            b6.Visible = false;

                            tb1.Visible = false;
                            tb8.Visible = false;
                            tb2.Visible = false;
                            tb3.Visible = false;
                            tb4.Visible = false;
                            tb5.Visible = false;
                            tb6.Visible = false;
                            tb7.Visible = false;
                            dgv1.Visible = false;
                            l1.Visible = false;
                            l2.Visible = false;
                            l3.Visible = false;
                            l4.Visible = false;
                            l5.Visible = false;
                            l6.Visible = false;
                            l7.Visible = false;
                            l8.Visible = false;
                            l9.Visible = false;
                            b1.Visible = false;
                            b2.Visible = false;
                            b3.Visible = false;
                            gb1.Visible = false;
                            ch1.Visible = false;
                        }
                        else
                            if (prosmotr == 21)
                            {
                                dgv1.Visible = false;
                            }
                            else
                                    if (prosmotr == 14)
                                    {
                                        cb1.Visible = false;
                                        dgv2.Visible = false;
                                        dgv1.Visible = false;
                                        dgv3.Visible = false;
                                        b4.Visible = false;
                                        b5.Visible = false;
                                        b6.Visible = false;

                                        tb1.Visible = false;

                                        tb2.Visible = false;
                                        tb3.Visible = false;


                                        l1.Visible = false;
                                        l2.Visible = false;
                                        l3.Visible = false;

                                        l9.Visible = false;
                                        b1.Visible = false;
                                        b2.Visible = false;
                                        b3.Visible = false;
                                        b7.Visible = false;
                                        gb1.Visible = false;
                                        gb2.Visible = false;
                                    }
            }
            else
            {
                p.Image = Image.FromFile(@"" + Environment.CurrentDirectory + @"\img\on.png");
                p.Tag = @"" + Environment.CurrentDirectory + @"\img\on.png";
              //  if (prosmotr == 21) dgv1.Visible = true;
                if (prosmotr == 11 || prosmotr == 12)
                {
                    tb1.Visible = true;
                    dgv1.Visible = true;
                    l1.Visible = true;
                    b1.Visible = true;
                    b2.Visible = true;
                    b3.Visible = true;
                }
                else
                    if (prosmotr == 31)
                    {
                        dgv1.Visible = true;
                        gb1.Visible = true;
                        gb2.Visible = true;
                        gb3.Visible = true;
                        gb4.Visible = true;
                    }
                    else
                        if (prosmotr == 13)
                        {
                            cb1.Visible = true;
                            dgv2.Visible = true;
                            b4.Visible = true;
                            b5.Visible = true;
                            b6.Visible = true;

                            tb1.Visible = true;
                            tb8.Visible = true;
                            tb2.Visible = true;
                            tb3.Visible = true;
                            tb4.Visible = true;
                            tb5.Visible = true;
                            tb6.Visible = true;
                            tb7.Visible = true;
                            dgv1.Visible = true;
                            l1.Visible = true;
                            l2.Visible = true;
                            l3.Visible = true;
                            l4.Visible = true;
                            l5.Visible = true;
                            l6.Visible = true;
                            l7.Visible = true;
                            l8.Visible = true;
                            l9.Visible = true;
                            b1.Visible = true;
                            b2.Visible = true;
                            b3.Visible = true;
                            gb1.Visible = true;
                            ch1.Visible = true;
                        }
                        else
                            if (prosmotr == 21)
                            {
                                dgv1.Visible = true;
                            }
                            else
                                if (prosmotr == 14)
                                {
                                    cb1.Visible = true;
                                    dgv2.Visible = true;
                                    dgv1.Visible = true;
                                    dgv3.Visible = true;
                                    b4.Visible = true;
                                    b5.Visible = true;
                                    b6.Visible = true;

                                    tb1.Visible = true;

                                    tb2.Visible = true;
                                    tb3.Visible = true;


                                    l1.Visible = true;
                                    l2.Visible = true;
                                    l3.Visible = true;

                                    l9.Visible = true;
                                    b1.Visible = true;
                                    b2.Visible = true;
                                    b3.Visible = true;
                                    b7.Visible = true;
                                    gb1.Visible = true;
                                    gb2.Visible = true;
                                }
            }
        }


        private void историяРаботыДиспетчеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                p.Visible = true;
                dispose(prosmotr);
                prosmotr = 21;

                timerr();

                //p.Visible = true;

                dgv1 = new DataGridView() { Location = new Point(30, 55), Size = new Size(400, 300), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top, RowHeadersVisible = false, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
                this.Controls.Add(dgv1);

                string q = "SELECT zap_dejstvij_disp.deistvie as [Действие], zap_dejstvij_disp.dispetcher as [Диспетчер], zap_dejstvij_disp.data as [Дата] FROM zap_dejstvij_disp ORDER BY zap_dejstvij_disp.data";
                con(q, 1);
            }
            catch { }
        }

        void timerr()
        {
            try
            {
                #region pustoe mesto
                l2 = new Label() { Location = new Point(500, 100), BackColor = Color.Transparent, AutoSize = true, Font = new Font("Monotype Corsiva", 100.0F, FontStyle.Italic) };
                l3 = new Label() { Location = new Point(750, 100), BackColor = Color.Transparent, AutoSize = true, Font = new Font("Monotype Corsiva", 100.0F, FontStyle.Italic) };
                l5 = new Label() { Text = ":", Location = new Point(670, 100), BackColor = Color.Transparent, AutoSize = true, Font = new Font("Monotype Corsiva", 100.0F, FontStyle.Italic) };

                l4 = new Label() { Location = new Point(500, 250), BackColor = Color.Transparent, AutoSize = true, Font = new Font("Monotype Corsiva", 40.0F, FontStyle.Italic) };


                l2.Text = DateTime.Now.ToString("HH");
                l3.Text = DateTime.Now.ToString("mm");

                time1 = new Timer() { Interval = 450 }; time1.Tick += time1Tick;
                time2 = new Timer() { Interval = 10 }; time2.Tick += time2Tick;
                time4 = new Timer() { Interval = 100 };
                //запускаем таймер
                time1.Enabled = true;
                time2.Enabled = true;
                time4.Enabled = true;

                l4.Text = DateTime.Now.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));

                this.Controls.Add(l2);
                this.Controls.Add(l3);
                this.Controls.Add(l4);
                this.Controls.Add(l5);
                #endregion
            }
            catch { }
        }

        private void типОтношенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                p.Visible = true;
                dispose(prosmotr);
                 prosmotr = 11;

                 timerr();

                //p.Visible = true;

                dgv1 = new DataGridView() { Location = new Point(30, 55), Size = new Size(273, 300), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top, RowHeadersVisible=false, AllowUserToAddRows=false, AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill};
                this.Controls.Add(dgv1);

                l1 = new Label() { Text = "Тип отношений", AutoSize = true, Location = new Point(30, 375), Anchor = AnchorStyles.Bottom, ForeColor=Color.White, BackColor=Color.Transparent };
                tb1 = new TextBox() { Text = "", Size = new Size(180, 20), Location = new Point(120, 370), Anchor = AnchorStyles.Bottom };

                this.Controls.Add(l1);
                this.Controls.Add(tb1);

                b1 = new Button() { Text = "Добавить", AutoSize = true, Location = new Point(40, 400), Anchor = AnchorStyles.Bottom };
                b2 = new Button() { Text = "Редактировать", AutoSize = true, Location = new Point(120, 400), Anchor = AnchorStyles.Bottom };
                b3 = new Button() { Text = "Удалить", AutoSize = true, Location = new Point(220, 400), Anchor = AnchorStyles.Bottom };

                this.Controls.Add(b1);
                this.Controls.Add(b2);
                this.Controls.Add(b3);


                b1.Click += b1Click;//доб
                b2.Click += b2Click;//red
                b3.Click += b3Click;


                con("SELECT SPR_OTN.NOTN as [Отношение] FROM SPR_OTN", 1);
            }
            catch { }
        }

        void time1Tick(object sender, EventArgs e)
        {
            try
            {
                if (l5.Visible == true) l5.Visible = false; else l5.Visible = true;
            }
            catch { }
        }

        void time2Tick(object sender, EventArgs e)
        {
            try
            {
                l2.Text = DateTime.Now.ToString("HH");
                l3.Text = DateTime.Now.ToString("mm");
            }
            catch { }
        }

        private void b1Click(object sender, EventArgs e)
        {
            try{
            if (prosmotr == 11)//dob
            {
                #region
                z = "SELECT max(totn) FROM dbo.SPR_OTN ";

                int idTipOtn = sr.id_kol(z); idTipOtn++;
                sr.query = "INSERT INTO  SPR_OTN values (" + idTipOtn + ",'" + tb1.Text + "')";
                sr.ExecSQL(sr.query);
                con("SELECT SPR_OTN.NOTN FROM SPR_OTN",1);
                tb1.Text = "";
                sr.cn.Close();
                #endregion
            }
            else
                if (prosmotr == 12)
                {
                    #region
                    z = "SELECT max(id_problem) FROM dbo.problem_po_remontu_kabTV ";

                    int id_problem = sr.id_kol(z); id_problem++;
                    sr.query = "INSERT INTO problem_po_remontu_kabTV  values ('" + tb1.Text + "')";
                    sr.ExecSQL(sr.query);
                    con("SELECT problem_po_remontu_kabTV.problema FROM problem_po_remontu_kabTV",1);
                    tb1.Text = "";
                    sr.cn.Close();
                    #endregion
                }
            else
                    if (prosmotr == 31)
                    {
                        try
                        {
                            DateTime now = DateTime.Now;
                            string put = Environment.CurrentDirectory + @"\Архив\";


                            sr.query = "backup database org to disk ='" + put + "Резервная_копия" + now.Day.ToString() + "_" + now.Month.ToString() + "_" + now.Year.ToString() + ".bak'";
                            sr.ExecSQL(sr.query);
                            /*    sr.query = "backup log org to disk ='" + put + tb1.Text + "_log.ldf'";
                                sr.ExecSQL(sr.query);*/

                            // coed-e

                            MessageBox.Show("Сохранено");
                            архивацияToolStripMenuItem.PerformClick();
                        }
                        catch { }
                    }
            else
                        if (prosmotr == 13)
                        {
                            #region
                            z = "SELECT max(id_master) FROM  dbo.MASTER";

                            int id_master = sr.id_kol(z); id_master++;
                            sr.query = "INSERT INTO MASTER  values ('" + tb1.Text + "','" + tb2.Text + "','" + tb3.Text + "','" + tb4.Text + "','" + tb5.Text + "','" + tb6.Text + "','" + tb7.Text + "','" + tb8.Text + "','"+Convert.ToBoolean(ch1.Checked)+"')";
                            sr.ExecSQL(sr.query);
                            con("SELECT MASTER.FIO, MASTER.tel_rab, MASTER.tel_rab1, MASTER.tel_dom, MASTER.tel_dom1, MASTER.tel_mob, MASTER.tel_mob1, MASTER.[e-mail], brigada FROM MASTER",1);

                            dgv1.Columns[2].Visible = false;
                            dgv1.Columns[4].Visible = false;
                            dgv1.Columns[6].Visible = false;
                            dgv1.Columns[7].Visible = false;
                            dgv1.Columns[8].Visible = false;
                            tb1.Text = tb2.Text = tb3.Text = tb4.Text = tb5.Text = tb6.Text = tb7.Text = tb8.Text = "";
                            sr.cn.Close();
                            #endregion
                        }
            else
                            if (prosmotr == 14)
                            {
                                try{
                                #region
                                z = "SELECT max(NGOR) FROM  dbo.SPR_GOR";

                                int NGOR = sr.id_kol(z); NGOR++;
                                sr.query = "INSERT INTO  dbo.SPR_GOR values (" + NGOR + ",'" + tb1.Text + "','" + tb2.Text + "')";
                                sr.ExecSQL(sr.query);
                                con("select NGOR,SOATO as [сокр],NAMEGOR as [название] from dbo.SPR_GOR", 1);

                                dgv1.Columns[0].Visible = false;
                                tb1.Text = tb2.Text = "";
                                sr.cn.Close();
                                #endregion
                                }
                                catch
                                {
                                    MessageBox.Show("Правильно ли Вы заполнили поля?");
                                }
                            }
        } catch
            {
                MessageBox.Show("Извините, это выполнить невозможно.");
            }
        }
        private void b2Click(object sender, EventArgs e)
        {
            try
            {
                #region
                if (b2.Text == "Редактировать")
                {
                    tb1.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
                    b2.Text = "Сохранить";
                    b1.Visible = b3.Visible = false;
                    if (prosmotr == 13)
                    {
                        tb2.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                        tb3.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
                        tb4.Text = dgv1.CurrentRow.Cells[3].Value.ToString();
                        tb5.Text = dgv1.CurrentRow.Cells[4].Value.ToString();
                        tb6.Text = dgv1.CurrentRow.Cells[5].Value.ToString();
                        tb7.Text = dgv1.CurrentRow.Cells[6].Value.ToString();
                        tb8.Text = dgv1.CurrentRow.Cells[7].Value.ToString();
                        ch1.Checked = Convert.ToBoolean(dgv1.CurrentRow.Cells[8].Value);
                    }
                    else
                        if (prosmotr == 14)
                        {
                            tb1.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                            tb2.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
                        }
                }
                else
                    if (prosmotr == 11)//red
                    {
                        #region
                        z = "SELECT totn FROM dbo.SPR_OTN where notn='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'";
                        int idTipOtn = sr.id_kol(z);
                        sr.query = "UPDATE SPR_OTN SET notn = '" + tb1.Text + "'  WHERE totn=" + idTipOtn;// .Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))
                        sr.ExecSQL(sr.query);
                        b2.Text = "Редактировать";
                        b1.Visible = b3.Visible = true;
                        con("SELECT SPR_OTN.NOTN FROM SPR_OTN", 1);
                        tb1.Text = "";
                        sr.cn.Close();
                        #endregion
                    }
                    else
                        if (prosmotr == 12)
                        {
                            #region
                            z = "SELECT id_problem FROM dbo.problem_po_remontu_kabTV where problema='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'";
                            int id = sr.id_kol(z);
                            sr.query = "UPDATE problem_po_remontu_kabTV SET problema = '" + tb1.Text + "'  WHERE id_problem=" + id;// .Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))
                            sr.ExecSQL(sr.query);
                            b2.Text = "Редактировать";
                            b1.Visible = b3.Visible = true;
                            con("SELECT problem_po_remontu_kabTV.problema FROM problem_po_remontu_kabTV", 1);
                            tb1.Text = "";
                            sr.cn.Close();
                            #endregion
                        }
                        else
                            if (prosmotr == 13)
                            {
                                #region
                                z = "SELECT id_master FROM dbo.master where fio='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'";
                                int id = sr.id_kol(z);
                                sr.query = "UPDATE master SET FIO = '" + tb1.Text + "', tel_rab= '" + tb2.Text + "', tel_rab1= '" + tb3.Text + "', tel_dom= '" + tb4.Text + "', tel_dom1= '" + tb5.Text + "', tel_mob= '" + tb6.Text + "', tel_mob1= '" + tb7.Text + "', [e-mail]= '" + tb8.Text + "', brigada= '" + (bool)ch1.Checked + "'  WHERE id_master=" + id;// .Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))
                                sr.ExecSQL(sr.query);
                                b2.Text = "Редактировать";
                                b1.Visible = b3.Visible = true;
                                con("SELECT MASTER.FIO, MASTER.tel_rab, MASTER.tel_rab1, MASTER.tel_dom, MASTER.tel_dom1, MASTER.tel_mob, MASTER.tel_mob1, MASTER.[e-mail], brigada FROM MASTER", 1);

                                dgv1.Columns[2].Visible = false;
                                dgv1.Columns[4].Visible = false;
                                dgv1.Columns[6].Visible = false;
                                dgv1.Columns[7].Visible = false;
                                dgv1.Columns[8].Visible = false;
                                tb1.Text = tb2.Text = tb3.Text = tb4.Text = tb5.Text = tb6.Text = tb7.Text = tb8.Text = "";
                                sr.cn.Close();
                                #endregion
                            }
                            else
                                if (prosmotr == 31)
                                {
                                    soed();
                                }
                                else
                                    if (prosmotr == 14)
                                    {
                                        #region
                                        sr.query = "UPDATE dbo.SPR_GOR SET SOATO= '" + tb1.Text + "', NAMEGOR= '" + tb2.Text + "' WHERE NGOR=" + dgv1.CurrentRow.Cells[0].Value.ToString();// .Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))
                                        sr.ExecSQL(sr.query);
                                        b2.Text = "Редактировать";
                                        b1.Visible = b3.Visible = true;
                                        con("select NGOR,SOATO as [сокр],NAMEGOR as [название] from dbo.SPR_GOR", 1);

                                        dgv1.Columns[0].Visible = false;
                                        tb1.Text = tb2.Text = "";
                                        sr.cn.Close();
                                        #endregion
                                    }
                #endregion
            }
            catch { }
        }
        private void b3Click(object sender, EventArgs e)
        {
            try
            {
                if (prosmotr != 31)
                {
                    DialogResult result = MessageBox.Show("Желаете удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) //Если нажал Да
                    {
                        if (prosmotr == 11)
                        {
                            sr.query = "DELETE FROM SPR_OTN where SPR_OTN.NOTN='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'";
                            sr.ExecSQL(sr.query);
                            con("SELECT SPR_OTN.NOTN FROM SPR_OTN", 1);
                            sr.cn.Close();
                        }
                        else
                            if (prosmotr == 12)
                            {
                                sr.query = "DELETE FROM problem_po_remontu_kabTV where problema='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'";
                                sr.ExecSQL(sr.query);
                                con("SELECT problem_po_remontu_kabTV.problema FROM problem_po_remontu_kabTV", 1);
                                sr.cn.Close();
                            }
                            else
                                if (prosmotr == 13)
                                {
                                    sr.query = "DELETE FROM master where fio='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'";
                                    sr.ExecSQL(sr.query);
                                    con("SELECT MASTER.FIO, MASTER.tel_rab, MASTER.tel_rab1, MASTER.tel_dom, MASTER.tel_dom1, MASTER.tel_mob, MASTER.tel_mob1, MASTER.[e-mail], brigada FROM MASTER", 1);

                                    dgv1.Columns[2].Visible = false;
                                    dgv1.Columns[4].Visible = false;
                                    dgv1.Columns[6].Visible = false;
                                    dgv1.Columns[7].Visible = false;
                                    dgv1.Columns[8].Visible = false;
                                    sr.cn.Close();
                                }
                                else
                                    if (prosmotr == 14)
                                    {
                                        sr.query = "DELETE FROM SPR_GOR where NGOR='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'";
                                        sr.ExecSQL(sr.query);

                                        con("select NGOR,SOATO as [сокр],NAMEGOR as [название] from dbo.SPR_GOR", 1);
                                        dgv1.Columns[0].Visible = false;

                                        sr.cn.Close();
                                    }

                    }
                }
                else
                    if (prosmotr == 31)
                    {
                        sr.query = "DELETE FROM dbo.Zajavki where data<='" + dtp1.Value.Date.ToShortDateString() + "'";
                        sr.ExecSQL(sr.query);
                        sr.query = "DELETE FROM dbo.zap_dejstvij_disp where data<='" + dtp1.Value.Date.ToShortDateString() + "  23:59:59' ";
                        sr.ExecSQL(sr.query);
                        sr.query = "DELETE FROM dbo.RUR where data<='" + dtp1.Value.Date.ToShortDateString() + "'";
                        sr.ExecSQL(sr.query);
                        MessageBox.Show("Выполнено успешно");
                        sr.cn.Close();

                    }
            }
            catch { }
        }
       
        private void b4Click(object sender, EventArgs e)
        {
            try
            {
                if (prosmotr == 13)//dob
                {
                    z = "SELECT NGOR FROM dbo.SPR_GOR where NAMEGOR='" + cb1.Text + "'";
                    int idgor = sr.id_kol(z);
                    z = "SELECT id_master FROM  dbo.MASTER where FIO='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'";
                    int idmeh = sr.id_kol(z);
                    sr.query = "INSERT INTO  dbo.GOR_MASTER values (" + idgor + "," + idmeh + ")";
                    sr.ExecSQL(sr.query);
                    con("SELECT GOR_MASTER.NGOR, GOR_MASTER.id_master, SPR_GOR.NAMEGOR, MASTER.FIO FROM SPR_GOR INNER JOIN (MASTER INNER JOIN GOR_MASTER ON MASTER.id_master = GOR_MASTER.id_master) ON SPR_GOR.NGOR = GOR_MASTER.NGOR WHERE (((MASTER.FIO)='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'))", 2);
                    dgv2.Columns[0].Visible = false;
                    dgv2.Columns[1].Visible = false;
                    tb1.Text = "";
                    sr.cn.Close();
                }
                else
                    if (prosmotr == 14)
                    {
                        #region
                        z = "SELECT max(nul) FROM  SPR_UL1";

                        int NGOR = sr.id_kol(z); NGOR++;
                        sr.query = "INSERT INTO  dbo.SPR_UL1 values (" + NGOR + ",'" + cb1.Text + "','" + tb3.Text + "')";

                        sr.ExecSQL(sr.query);

                        con(" SELECT nul,tip, UL  FROM SPR_UL1", 3);
                        dgv3.Columns[0].Visible = false;

                        cb1.Text = tb3.Text = "";
                        sr.cn.Close();
                        #endregion
                    }
                    else
                        if (prosmotr == 31) // подсоед-е
                        {

                            string org_mdf1 = @"" + Environment.CurrentDirectory + @"\Архив\" + list1.SelectedItem.ToString() + ".mdf";
                            string org_log1 = @"" + Environment.CurrentDirectory + @"\Архив\" + list1.SelectedItem.ToString() + ".ldf";

                            string query = "CREATE DATABASE    " + list1.SelectedItem.ToString() + "     ON (FILENAME = '" + org_mdf1 + "'),       (FILENAME = '" + org_log1 + "')    FOR ATTACH; ";
                            cmd.Connection = cn;
                            if (cn.State == ConnectionState.Open) cn.Close();
                            cn.Open();
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();

                            cn.Close();
                            cn = new SqlConnection(@"Server=tcp:" + pc + ",49172; Initial Catalog=" + list1.SelectedItem.ToString() + "; Integrated Security=false; User ID=" + user + ";Password=11;");

                            if (cn.State == ConnectionState.Open) cn.Close();
                            cmd.Connection = cn;
                            cn.Open();

                            query = "select * from INFORMATION_SCHEMA.tables";
                            cmd.CommandText = query;
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())//проходим по строкам таблицы результирующего запроса
                            {
                                cb2.Items.Add(reader[2]);
                            }
                            cn.Close();
                            reader.Dispose();
                            cmd.CommandText = "";
                            cn.Open();
                            cn.ChangeDatabase("org");
                            cn.Close();
                            cn.ConnectionString = @"Server=tcp:" + pc + ",49172;  Integrated Security=false; User ID=" + user + ";Password=11;";
                            //MessageBox.Show(cn.ConnectionString.ToString());
                            //cn.Close();
                            MessageBox.Show("Присоединено");
                        }
            }
            catch { }
        }
        private void b5Click(object sender, EventArgs e)
        {
            try
            {
                if (b5.Text == "Редактировать")
                {

                    b5.Text = "Сохранить";
                    b4.Visible = b6.Visible = false;
                    if (prosmotr == 13)
                    {
                        cb1.Text = dgv2.CurrentRow.Cells[2].Value.ToString();
                    }
                    else
                        if (prosmotr == 14)
                        {
                            tb3.Text = dgv3.CurrentRow.Cells[2].Value.ToString();
                            cb1.Text = dgv3.CurrentRow.Cells[1].Value.ToString();
                        }
                }
                else
                    if (prosmotr == 13)//red
                    {
                        #region
                        z = "SELECT NGOR FROM dbo.SPR_GOR where NAMEGOR='" + cb1.Text + "'";
                        int idGor = sr.id_kol(z);
                        sr.query = "UPDATE dbo.GOR_MASTER SET  NGOR= " + idGor + "  WHERE id_master=" + dgv2.CurrentRow.Cells[1].Value.ToString();// .Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))
                        sr.ExecSQL(sr.query);
                        b5.Text = "Редактировать";
                        b4.Visible = b6.Visible = true;
                        con("SELECT GOR_MASTER.NGOR, GOR_MASTER.id_master, SPR_GOR.NAMEGOR, MASTER.FIO FROM SPR_GOR INNER JOIN (MASTER INNER JOIN GOR_MASTER ON MASTER.id_master = GOR_MASTER.id_master) ON SPR_GOR.NGOR = GOR_MASTER.NGOR WHERE (((MASTER.FIO)='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'))", 2);
                        dgv2.Columns[0].Visible = false;
                        dgv2.Columns[1].Visible = false;
                        cb1.Text = "";
                        sr.cn.Close();
                        #endregion
                    }
                    else
                        if (prosmotr == 31)
                        {
                            if (pc != Environment.MachineName.ToLower()) MessageBox.Show("Не на этом подключена БД, поэтому дальнейшие действия будут некорректны!");
                            DialogResult result = MessageBox.Show("Для этого необходимо закрыть это приложение и другие по сети.", "Прервать работу?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes) //Если нажал Да
                            {
                                arhiv = true; 
                                sr.query = "UPDATE Роли SET  vhod='false' WHERE login='" + admin.dis + "'";
                                sr.ExecSQL(sr.query);
                                if (sr.cn.State == ConnectionState.Open) sr.cn.Close();
                                this.Dispose();
                                admin aaa = new admin();

                                aaa.Show();

                                string s = "conn.txt";
                                System.IO.StreamWriter textFile = new System.IO.StreamWriter(s);

                                textFile.Write("Восстановление");

                                textFile.Close();
                            }

                        }
                        else
                            if (prosmotr == 14)
                            {
                                sr.query = "UPDATE dbo.SPR_UL1 SET  tip= '" + cb1.Text + "', ul='" + tb3.Text + "'  WHERE nul=" + dgv3.CurrentRow.Cells[0].Value.ToString();// .Value.Date.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))
                                sr.ExecSQL(sr.query);
                                b5.Text = "Редактировать";
                                b4.Visible = b6.Visible = true;
                                con(" SELECT nul,tip, UL  FROM SPR_UL1", 3);
                                dgv3.Columns[0].Visible = false;
                                cb1.Text = tb3.Text = "";
                                sr.cn.Close();
                            }
            }
            catch { }
        }
        private void b6Click(object sender, EventArgs e)
        {  try
                {
                    if (prosmotr != 31)
                    {
                        DialogResult result = MessageBox.Show("Желаете удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes) //Если нажал Да
                        {
                            if (prosmotr == 13)
                            {
                                sr.query = "DELETE  FROM dbo.GOR_MASTER where NGOR=" + dgv2.CurrentRow.Cells[0].Value.ToString() + " and id_master=" + dgv2.CurrentRow.Cells[1].Value.ToString();
                                sr.ExecSQL(sr.query);
                                con("SELECT GOR_MASTER.NGOR, GOR_MASTER.id_master, SPR_GOR.NAMEGOR, MASTER.FIO FROM SPR_GOR INNER JOIN (MASTER INNER JOIN GOR_MASTER ON MASTER.id_master = GOR_MASTER.id_master) ON SPR_GOR.NGOR = GOR_MASTER.NGOR WHERE (((MASTER.FIO)='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'))", 2);
                                dgv2.Columns[0].Visible = false;
                                dgv2.Columns[1].Visible = false;
                                sr.cn.Close();
                            }
                            else
                                if (prosmotr == 14)
                                {
                                    sr.query = "DELETE  FROM dbo.SPR_UL1 where nul=" + dgv3.CurrentRow.Cells[0].Value.ToString();
                                    sr.ExecSQL(sr.query);
                                    con(" SELECT nul,tip, UL  FROM SPR_UL1", 3);
                                    dgv3.Columns[0].Visible = false;
                                    sr.cn.Close();
                                }

                        }
                    }
                    else
                        if (prosmotr == 31)
                        {
                            try
                            {
                                cn.ConnectionString = @"Server=tcp:" + pc + ",49172; Integrated Security=false; User ID=" + user + ";Password=11;";
                                if (dgv1.Rows.Count != 0)
                                    dgv1.Rows.Clear();
                                if (cb2.Items.Count != 0)
                                    cb2.Items.Clear();

                                //    MessageBox.Show(cn.ConnectionString.ToString());
                                if (cn.State == ConnectionState.Open) cn.Close();
                                cmd.Connection = cn;
                                cn.Open();

                                string query = "   EXEC sp_detach_db '" + list1.SelectedItem.ToString() + "' , 'true';";
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Отсоединено");
                            }
                            catch (Exception q)
                            { MessageBox.Show(q.ToString()); }
                        }

                }
                catch
                {
                    MessageBox.Show("Извините, эта запись связана с другой таблицей.");
                }
        }
        #region
        private void проблемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                p.Visible = true;
                dispose(prosmotr);
                prosmotr = 12;
                timerr();

                dgv1 = new DataGridView() { Location = new Point(30, 55), Size = new Size(417, 300), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top, RowHeadersVisible = false, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
                this.Controls.Add(dgv1);

                l1 = new Label() { Text = "Проблема", AutoSize = true, Location = new Point(30, 375), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb1 = new TextBox() { Text = "", Size = new Size(325, 20), Location = new Point(120, 370), Anchor = AnchorStyles.Bottom };

                this.Controls.Add(l1);
                this.Controls.Add(tb1);

                b1 = new Button() { Text = "Добавить", AutoSize = true, Location = new Point(40, 400), Anchor = AnchorStyles.Bottom };
                b2 = new Button() { Text = "Редактировать", AutoSize = true, Location = new Point(120, 400), Anchor = AnchorStyles.Bottom };
                b3 = new Button() { Text = "Удалить", AutoSize = true, Location = new Point(220, 400), Anchor = AnchorStyles.Bottom };

                this.Controls.Add(b1);
                this.Controls.Add(b2);
                this.Controls.Add(b3);


                b1.Click += b1Click;//доб
                b2.Click += b2Click;//red
                b3.Click += b3Click;


                con("SELECT problem_po_remontu_kabTV.problema as [Проблема] FROM problem_po_remontu_kabTV", 1);
            }
            catch { }
        }

        private void мастераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                p.Visible = true;
                dispose(prosmotr);
                prosmotr = 13;

                dgv1 = new DataGridView() { Location = new Point(30, 55), Size = new Size(500, 250), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top, RowHeadersVisible = false, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
                this.Controls.Add(dgv1);

                gb1 = new GroupBox() { Location = new Point(30, 305), Size = new Size(500, 160), BackColor = Color.Transparent };
                this.Controls.Add(gb1);

                l1 = new Label() { Text = "ФИО", AutoSize = true, Location = new Point(2, 27), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb1 = new TextBox() { Text = "", Size = new Size(150, 20), Location = new Point(60, 24), Anchor = AnchorStyles.Bottom };

                l2 = new Label() { Text = "тел. раб.", AutoSize = true, Location = new Point(2, 53), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb2 = new TextBox() { Text = "", Size = new Size(150, 20), Location = new Point(60, 50), Anchor = AnchorStyles.Bottom };
                l3 = new Label() { Text = "тел. раб.", AutoSize = true, Location = new Point(220, 53), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb3 = new TextBox() { Text = "", Size = new Size(150, 20), Location = new Point(280, 50), Anchor = AnchorStyles.Bottom };

                l4 = new Label() { Text = "тел. дом.", AutoSize = true, Location = new Point(2, 82), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb4 = new TextBox() { Text = "", Size = new Size(150, 20), Location = new Point(60, 79), Anchor = AnchorStyles.Bottom };
                l5 = new Label() { Text = "тел. дом.", AutoSize = true, Location = new Point(220, 82), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb5 = new TextBox() { Text = "", Size = new Size(150, 20), Location = new Point(280, 79), Anchor = AnchorStyles.Bottom };

                l6 = new Label() { Text = "тел. моб.", AutoSize = true, Location = new Point(2, 112), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb6 = new TextBox() { Text = "", Size = new Size(150, 20), Location = new Point(60, 108), Anchor = AnchorStyles.Bottom };
                l7 = new Label() { Text = "тел. моб.", AutoSize = true, Location = new Point(220, 108), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb7 = new TextBox() { Text = "", Size = new Size(150, 20), Location = new Point(280, 112), Anchor = AnchorStyles.Bottom };

                l8 = new Label() { Text = "E-mail", AutoSize = true, Location = new Point(220, 27), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb8 = new TextBox() { Text = "", Size = new Size(150, 20), Location = new Point(280, 24), Anchor = AnchorStyles.Bottom };
                ch1 = new CheckBox() { Text = "Бригада", Location = new Point(60, 135), Anchor = AnchorStyles.Bottom };

                this.gb1.Controls.Add(l1);
                this.gb1.Controls.Add(l2);
                this.gb1.Controls.Add(l3);
                this.gb1.Controls.Add(l4);
                this.gb1.Controls.Add(l5);
                this.gb1.Controls.Add(l6);
                this.gb1.Controls.Add(l7);
                this.gb1.Controls.Add(l8);
                this.gb1.Controls.Add(tb1);
                this.gb1.Controls.Add(tb2);
                this.gb1.Controls.Add(tb4);
                this.gb1.Controls.Add(tb5);
                this.gb1.Controls.Add(tb6);
                this.gb1.Controls.Add(tb7);
                this.gb1.Controls.Add(tb8);
                this.gb1.Controls.Add(tb3);
                this.gb1.Controls.Add(ch1);

                b1 = new Button() { Text = "Добавить", AutoSize = true, Location = new Point(40, 480), Anchor = AnchorStyles.Bottom };
                b2 = new Button() { Text = "Редактировать", AutoSize = true, Location = new Point(120, 480), Anchor = AnchorStyles.Bottom };
                b3 = new Button() { Text = "Удалить", AutoSize = true, Location = new Point(220, 480), Anchor = AnchorStyles.Bottom };

                this.Controls.Add(b1);
                this.Controls.Add(b2);
                this.Controls.Add(b3);

                b1.Click += b1Click;//доб
                b2.Click += b2Click;//red
                b3.Click += b3Click;

                con("SELECT MASTER.FIO as [ФИО], MASTER.tel_rab as [Рабочий тел], MASTER.tel_rab1, MASTER.tel_dom as [Домашний тел], MASTER.tel_dom1, MASTER.tel_mob as [Мобильный тел], MASTER.tel_mob1, MASTER.[e-mail] as [E-mail], brigada FROM MASTER", 1);

                dgv1.Columns[2].Visible = false;
                dgv1.Columns[4].Visible = false;
                dgv1.Columns[6].Visible = false;
                dgv1.Columns[7].Visible = false;
                dgv1.Columns[8].Visible = false;

                dgv1.SelectionChanged += dgv1SelectionChanged;


                dgv2 = new DataGridView() { Location = new Point(550, 55), Size = new Size(400, 200), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top, RowHeadersVisible = false, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
                this.Controls.Add(dgv2);


                l9 = new Label() { Text = "Город", AutoSize = true, Location = new Point(550, 280), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                cb1 = new ComboBox() { Text = "", Size = new Size(150, 20), Location = new Point(600, 277), Anchor = AnchorStyles.Bottom };

                this.Controls.Add(l9);
                this.Controls.Add(cb1);

                //созд comboBox3 gorod
                cb1.Items.Clear();
                z = "SELECT  NAMEGOR FROM SPR_GOR";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    cb1.Items.Add(reader[0]);
                }
                sr.cn.Close();//закрываем соединение с БД

                b4 = new Button() { Text = "Добавить", AutoSize = true, Location = new Point(600, 320), Anchor = AnchorStyles.Bottom };
                b5 = new Button() { Text = "Редактировать", AutoSize = true, Location = new Point(680, 320), Anchor = AnchorStyles.Bottom };
                b6 = new Button() { Text = "Удалить", AutoSize = true, Location = new Point(780, 320), Anchor = AnchorStyles.Bottom };

                this.Controls.Add(b6);
                this.Controls.Add(b5);
                this.Controls.Add(b4);

                b4.Click += b4Click;//доб
                b5.Click += b5Click;//red
                b6.Click += b6Click;

                con("SELECT GOR_MASTER.NGOR, GOR_MASTER.id_master, SPR_GOR.NAMEGOR as [Город], MASTER.FIO as [Мастер] FROM SPR_GOR INNER JOIN (MASTER INNER JOIN GOR_MASTER ON MASTER.id_master = GOR_MASTER.id_master) ON SPR_GOR.NGOR = GOR_MASTER.NGOR WHERE (((MASTER.FIO)='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'))", 2);

                dgv2.Columns[0].Visible = false;
                dgv2.Columns[1].Visible = false;
            }
            catch { }

        }

        void dgv1SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (prosmotr == 13)
                {
                    con("SELECT GOR_MASTER.NGOR, GOR_MASTER.id_master, SPR_GOR.NAMEGOR as [Город], MASTER.FIO as [Мастер] FROM SPR_GOR INNER JOIN (MASTER INNER JOIN GOR_MASTER ON MASTER.id_master = GOR_MASTER.id_master) ON SPR_GOR.NGOR = GOR_MASTER.NGOR WHERE (((MASTER.FIO)='" + dgv1.CurrentRow.Cells[0].Value.ToString() + "'))", 2);
                    dgv2.Columns[0].Visible = false;
                    dgv2.Columns[1].Visible = false;
                }
                else
                    if (prosmotr == 14)
                    {
                        con("SELECT SPR_UL1.UL as [Улица], SPR_GOR.NAMEGOR as [Город], [GOR-UL].NGOR, [GOR-UL].NUL FROM SPR_GOR INNER JOIN (SPR_UL1 INNER JOIN [GOR-UL] ON SPR_UL1.NUL = [GOR-UL].NUL) ON SPR_GOR.NGOR = [GOR-UL].NGOR where SPR_GOR.NAMEGOR= '" + dgv1.CurrentRow.Cells[2].Value.ToString() + "'", 2);
                        dgv2.Columns[3].Visible = false;
                        dgv2.Columns[2].Visible = false;
                        dgv2.Columns[1].Visible = false;
                    }
            }
            catch { }
        }

        public static bool u = false;

        private void b7Click(object sender, EventArgs e)
        {
            try
            {
                #region

                sr.query = "INSERT INTO  dbo.[GOR-UL] values (" + dgv1.CurrentRow.Cells[0].Value.ToString() + "," + dgv3.CurrentRow.Cells[0].Value.ToString() + ")";
                MessageBox.Show(sr.query);
                sr.ExecSQL(sr.query);
                con("SELECT SPR_UL1.UL as [Улица], SPR_GOR.NAMEGOR as [Город], [GOR-UL].NGOR, [GOR-UL].NUL FROM SPR_GOR INNER JOIN (SPR_UL1 INNER JOIN [GOR-UL] ON SPR_UL1.NUL = [GOR-UL].NUL) ON SPR_GOR.NGOR = [GOR-UL].NGOR where SPR_GOR.NAMEGOR= '" + dgv1.CurrentRow.Cells[2].Value.ToString() + "'", 2);
                dgv2.Columns[3].Visible = false;
                dgv2.Columns[2].Visible = false;
                dgv2.Columns[1].Visible = false;
                sr.cn.Close();
                #endregion
            }
            catch { }

        }

        private void улицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                p.Visible = true;
                dispose(prosmotr);
                prosmotr = 14;

                dgv1 = new DataGridView() { Location = new Point(30, 55), Size = new Size(300, 250), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top, RowHeadersVisible = false, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
                this.Controls.Add(dgv1);

                gb1 = new GroupBox() { Location = new Point(30, 305), Size = new Size(300, 90), BackColor = Color.Transparent };
                this.Controls.Add(gb1);

                l1 = new Label() { Text = "Сокращение", AutoSize = true, Location = new Point(2, 27), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb1 = new TextBox() { Text = "", Size = new Size(210, 20), Location = new Point(80, 24), Anchor = AnchorStyles.Bottom };

                l2 = new Label() { Text = "Название города", AutoSize = true, Location = new Point(2, 57), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
                tb2 = new TextBox() { Text = "", Size = new Size(190, 20), Location = new Point(100, 54), Anchor = AnchorStyles.Bottom };
                
                
                this.gb1.Controls.Add(l1);
                this.gb1.Controls.Add(l2);
              
                this.gb1.Controls.Add(tb1);
                this.gb1.Controls.Add(tb2);
                

                b1 = new Button() { Text = "Добавить", AutoSize = true, Location = new Point(40, 400), Anchor = AnchorStyles.Bottom };
                b2 = new Button() { Text = "Редактировать", AutoSize = true, Location = new Point(120, 400), Anchor = AnchorStyles.Bottom };
                b3 = new Button() { Text = "Удалить", AutoSize = true, Location = new Point(220, 400), Anchor = AnchorStyles.Bottom };

                this.Controls.Add(b1);
                this.Controls.Add(b2);
                this.Controls.Add(b3);

                b1.Click += b1Click;//доб
                b2.Click += b2Click;//red
                b3.Click += b3Click;

                con("select NGOR,SOATO as [сокр],NAMEGOR as [название] from dbo.SPR_GOR", 1);

                dgv1.Columns[0].Visible = false;
               
                dgv1.SelectionChanged += dgv1SelectionChanged;


                dgv2 = new DataGridView() { Location = new Point(365, 55), Size = new Size(200, 250), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top, RowHeadersVisible = false, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
                this.Controls.Add(dgv2);

                b7 = new Button() { Text = "Добавить", AutoSize = true, Location = new Point(500, 400), Anchor = AnchorStyles.Bottom };
                this.Controls.Add(b7);
                b7.Click += b7Click;//доб

                dgv3 = new DataGridView() { Location = new Point(600, 55), Size = new Size(300, 250), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top, RowHeadersVisible = false, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
                this.Controls.Add(dgv3);

               con(" SELECT nul,tip as [Тип], UL as [Улица]  FROM SPR_UL1", 3);
               dgv3.Columns[0].Visible = false;

               gb2 = new GroupBox() { Location = new Point(600, 305), Size = new Size(300, 90), BackColor = Color.Transparent };
               this.Controls.Add(gb2);

               l9 = new Label() { Text = "Тип улицы", AutoSize = true, Location = new Point(2, 27), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
               cb1 = new ComboBox() { Text = "", Size = new Size(202, 20), Location = new Point(80, 24), Anchor = AnchorStyles.Bottom };

               l3 = new Label() { Text = "Название города", AutoSize = true, Location = new Point(2, 57), Anchor = AnchorStyles.Bottom, BackColor = Color.Transparent };
               tb3 = new TextBox() { Text = "", Size = new Size(180, 20), Location = new Point(100, 54), Anchor = AnchorStyles.Bottom };


               this.gb2.Controls.Add(l9);
               this.gb2.Controls.Add(l3);

               this.gb2.Controls.Add(cb1);
               this.gb2.Controls.Add(tb3);

                //созд comboBox3 tip ul
                cb1.Items.Clear();
                z = "SELECT NAIM FROM dbo.SPR_T_UL";
                reader = sr.ReadSQLExec(z);
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    cb1.Items.Add(reader[0]);
                }
                sr.cn.Close();//закрываем соединение с БД

                b4 = new Button() { Text = "Добавить", AutoSize = true, Location = new Point(600, 400), Anchor = AnchorStyles.Bottom };
                b5 = new Button() { Text = "Редактировать", AutoSize = true, Location = new Point(680, 400), Anchor = AnchorStyles.Bottom };
                b6 = new Button() { Text = "Удалить", AutoSize = true, Location = new Point(780, 400), Anchor = AnchorStyles.Bottom };

                this.Controls.Add(b6);
                this.Controls.Add(b5);
                this.Controls.Add(b4);

                b4.Click += b4Click;//доб
                b5.Click += b5Click;//red
                b6.Click += b6Click;



         /*       con("SELECT SPR_UL1.UL, SPR_GOR.NAMEGOR, [GOR-UL].NGOR, [GOR-UL].NUL FROM SPR_GOR INNER JOIN (SPR_UL1 INNER JOIN [GOR-UL] ON SPR_UL1.NUL = [GOR-UL].NUL) ON SPR_GOR.NGOR = [GOR-UL].NGOR where SPR_GOR.NAMEGOR= ='" + dgv1.CurrentRow.Cells[2].Value.ToString() + "'", 2);

                dgv2.Columns[0].Visible = false;
                */

            }
            catch { }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {/*
                if (checkBox1.Checked == true)
                {

                    string q = "SELECT SPR_UL1.UL, SPR_GOR.NAMEGOR, [GOR-UL].NGOR, [GOR-UL].NUL FROM SPR_GOR INNER JOIN (SPR_UL1 INNER JOIN [GOR-UL] ON SPR_UL1.NUL = [GOR-UL].NUL) ON SPR_GOR.NGOR = [GOR-UL].NGOR where SPR_UL1.NUL=" + Convert.ToInt32(comboBox1.SelectedValue);
                        con(q);
                    
                }*/
            }
            catch { }
        }

#endregion

        void dispose(int prosmotr)
        {
            try
            {
                if (prosmotr == 11 || prosmotr == 12)
                {
                    //timerr
                    l2.Dispose();
                    l3.Dispose();
                    l5.Dispose();
                    l4.Dispose();
                    time1.Dispose();
                    time2.Dispose();
                    time4.Dispose();

                    tb1.Dispose();
                    dgv1.Dispose();
                    l1.Dispose();
                    b1.Dispose();
                    b2.Dispose();
                    b3.Dispose();
                }
                else
                    if (prosmotr == 31)
                    {
                        dgv1.Dispose();
                        l1.Dispose();
                        b1.Dispose();
                        b2.Dispose();
                        b3.Dispose();
                        b4.Dispose();
                        b5.Dispose();
                        b6.Dispose();
                        gb1.Dispose();
                        gb2.Dispose();
                        gb3.Dispose();
                        gb4.Dispose();
                        list1.Dispose();
                        list2.Dispose();
                        dtp1.Dispose();
                        cb2.Dispose();
                    }
                    else
                        if (prosmotr == 13)
                        {
                            cb1.Dispose();
                            dgv2.Dispose();
                            b4.Dispose();
                            b5.Dispose();
                            b6.Dispose();

                            tb1.Dispose();
                            tb8.Dispose();
                            tb2.Dispose();
                            tb3.Dispose();
                            tb4.Dispose();
                            tb5.Dispose();
                            tb6.Dispose();
                            tb7.Dispose();
                            dgv1.Dispose();
                            l1.Dispose();
                            l2.Dispose();
                            l3.Dispose();
                            l4.Dispose();
                            l5.Dispose();
                            l6.Dispose();
                            l7.Dispose();
                            l8.Dispose();
                            l9.Dispose();
                            b1.Dispose();
                            b2.Dispose();
                            b3.Dispose();
                            gb1.Dispose();
                            ch1.Dispose();
                        }
                        else
                            if (prosmotr == 21)
                            {
                                //timerr
                                l2.Dispose();
                                l3.Dispose();
                                l5.Dispose();
                                l4.Dispose();
                                time1.Dispose();
                                time2.Dispose();
                                time4.Dispose();

                                dgv1.Dispose();
                            }
                            else
                                if (prosmotr == 0)
                                {
                                    //timerr
                                    l2.Dispose();
                                    l3.Dispose();
                                    l5.Dispose();
                                    l4.Dispose();
                                    time1.Dispose();
                                    time2.Dispose();
                                    time4.Dispose();
                                }
                                else
                                    if (prosmotr == 14)
                                    {
                                        cb1.Dispose();
                                        dgv2.Dispose();
                                        dgv1.Dispose();
                                        dgv3.Dispose();
                                        b4.Dispose();
                                        b5.Dispose();
                                        b6.Dispose();

                                        tb1.Dispose();

                                        tb2.Dispose();
                                        tb3.Dispose();


                                        l1.Dispose();
                                        l2.Dispose();
                                        l3.Dispose();

                                        l9.Dispose();
                                        b1.Dispose();
                                        b2.Dispose();
                                        b3.Dispose();
                                        b7.Dispose();
                                        gb1.Dispose();
                                        gb2.Dispose();
                                    }
            }
            catch { }
        }

        private void архивацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                p.Visible = true;
                dispose(prosmotr);
                prosmotr = 31;


                //p.Visible = true;

                #region 1

                gb1 = new GroupBox() { Text = "Список архивных БД", BackColor = Color.Transparent, Location = new Point(30, 40), Size = new Size(350, 210), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top };
                this.Controls.Add(gb1);

                list1 = new ListBox() { Location = new Point(5, 20), Size = new Size(150, 188), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top };
                this.gb1.Controls.Add(list1);

                b2 = new Button() { Text = "Создать Архив", AutoSize = true, Location = new Point(180, 140), Anchor = AnchorStyles.Bottom, Size = new Size(147, 20) };
                this.gb1.Controls.Add(b2); b2.Click += b2Click;

                gb2 = new GroupBox() { Text = "Удаление данных", BackColor = Color.Transparent, Location = new Point(160, 40), Size = new Size(180, 85), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top };
                this.gb1.Controls.Add(gb2);

                l1 = new Label() { Text = "до", AutoSize = true, Location = new Point(20, 25), Anchor = AnchorStyles.Bottom, ForeColor = Color.Black, BackColor = Color.Transparent };
                this.gb2.Controls.Add(l1);

                dtp1 = new DateTimePicker() { Location = new Point(40, 20), Anchor = AnchorStyles.Bottom, Size = new Size(120, 20) };
                this.gb2.Controls.Add(dtp1);

                b3 = new Button() { Text = "Удаление из текущей БД", AutoSize = true, Location = new Point(20, 50), Anchor = AnchorStyles.Bottom };
                this.gb2.Controls.Add(b3); b3.Click += b3Click;//доб

                #region заполнение списка архивных данных
                var patch = Environment.CurrentDirectory + "/Архив";
                var dir = new DirectoryInfo(patch); // папка с файлами 
                var files = new List<string>(); // список для имен файлов 
                //Directory.GetFiles(@"C:\folder", "*.mdf");
                int i = 0;
                // dgv1.ColumnCount = 1;
                i = 0;
                foreach (FileInfo file in dir.GetFiles("*.mdf")) // извлекаем все файлы и кидаем их в список 
                {
                    list1.Items.Add((string)Path.GetFileNameWithoutExtension(file.FullName));
                    //dgv1.Rows.Add((string)Path.GetFileNameWithoutExtension(file.FullName)); i++;
                }
                #endregion
                #endregion

                #region 2

                gb3 = new GroupBox() { Text = "Список резервных копий БД", BackColor = Color.Transparent, Location = new Point(30, 270), Size = new Size(350, 210), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top };
                this.Controls.Add(gb3);

                list2 = new ListBox() { Location = new Point(5, 20), Size = new Size(160, 188), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top };
                this.gb3.Controls.Add(list2);

                b1 = new Button() { Text = "Создать резервную копию", AutoSize = true, Location = new Point(180, 60), Anchor = AnchorStyles.Bottom, Size = new Size(147, 20) };
                this.gb3.Controls.Add(b1); b1.Click += b1Click;

                b5 = new Button() { Text = "Восстановить текущую БД из последней резервной копии", Size = new Size(147, 60), Location = new Point(180, 100), Anchor = AnchorStyles.Bottom };
                this.gb3.Controls.Add(b5); b5.Click += b5Click;

                #region заполнение списка архивных данных
                i = 0;
                // dgv1.ColumnCount = 1;
                i = 0;
                foreach (FileInfo file in dir.GetFiles("*.bak")) // извлекаем все файлы и кидаем их в список 
                {
                    list2.Items.Add((string)Path.GetFileNameWithoutExtension(file.FullName));
                    //dgv1.Rows.Add((string)Path.GetFileNameWithoutExtension(file.FullName)); i++;
                }
                #endregion

                #endregion

                #region 3

                gb4 = new GroupBox() { Text = "Просмотр архивных данных БД", BackColor = Color.Transparent, Location = new Point(400, 40), Size = new Size(560, 440), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top };
                this.Controls.Add(gb4);

                b4 = new Button() { Text = "Подключить выбранный архив БД", Size = new Size(200, 25), Location = new Point(170, 20), Anchor = AnchorStyles.Bottom };
                this.gb4.Controls.Add(b4); b4.Click += b4Click;

                cb2 = new ComboBox() { Text = "", Size = new Size(200, 25), Location = new Point(170, 60), Anchor = AnchorStyles.Bottom };
                this.gb4.Controls.Add(cb2);

                cb2.SelectedValueChanged += cb2SelectedValueChanged;

                dgv1 = new DataGridView() { Location = new Point(20, 90), Size = new Size(520, 280), Visible = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Top, RowHeadersVisible = false, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
                this.gb4.Controls.Add(dgv1);

                b6 = new Button() { Text = "Отключить выбранный архив БД", Size = new Size(200, 25), Location = new Point(200, 400), Anchor = AnchorStyles.Bottom };
                this.gb4.Controls.Add(b6); b6.Click += b6Click;
                #endregion
            }
            catch { }
        }

        void cb2SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cn.ConnectionString = @"Server=tcp:" + pc + ",49172; Initial Catalog=" + list1.SelectedItem.ToString() + "; Integrated Security=false; User ID=" + user + ";Password=11;";
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Open();
                cmd.Connection = cn;

                dgv1.Rows.Clear();

                string query = "select * from [" + cb2.Text + "]";
                cmd.CommandText = query;
                SqlDataReader reader = cmd.ExecuteReader();
                int col = reader.FieldCount;
                dgv1.ColumnCount = col;
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    int rowNum = dgv1.Rows.Add();
                    dgv1.Rows[rowNum].Cells[0].Value = reader[0].ToString();//ячейку можно указывать номером столбца
                    dgv1.Rows[rowNum].Cells[1].Value = reader[1].ToString();//... или его именем
                }
                cn.Close();
                reader.Dispose();
                cmd.CommandText = "";
                cn.ConnectionString = @"Server=tcp:" + pc + ",49172; Integrated Security=false; User ID=" + user + ";Password=11;";

            //    MessageBox.Show(cn.ConnectionString.ToString());
                MessageBox.Show("Присоединено");
            }
            catch { }
        }

        private void справкаПоАрхивацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, "help.chm");
            }
            catch { }
        }

       







    }
}
