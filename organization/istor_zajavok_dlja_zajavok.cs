using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace organization
{
    public partial class istor_zajavok_dlja_zajavok : Form
    {
        public istor_zajavok_dlja_zajavok()
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


        private void istor_zajavok_dlja_zajavok_Load(object sender, EventArgs e)
        {
            try
            {
                base.Text = "История заявок " + Zajavki.name;
                string q11 = " SELECT SPR_AB.NDOG as [№ дог], problem_po_remontu_kabTV.problema as [Станд проблема], problem as [Нестанд продлема],Zajavki.data as [Дата заявки],data_okonch_sroka as [Окончание срока], status_vipolnenia as [Выпол- нение] FROM  SPR_AB INNER JOIN (Zajavki LEFT JOIN problem_po_remontu_kabTV ON Zajavki.id_problem = problem_po_remontu_kabTV.id_problem) ON SPR_AB.NDOG = Zajavki.NDOG WHERE Zajavki.NDOG=" + Zajavki.NDOG;
                con(q11);
            }
            catch { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].Width = 45;
            }
            catch { }
        }
    }
}
