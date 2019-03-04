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
    public partial class parol : Form
    {
        public parol()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectToDB sr = new ConnectToDB();
                string z = "SELECT login, pass FROM Роли";
                SqlDataReader reader;
                
                string[] mas = new string[8];
                reader = sr.ReadSQLExec(z);
                int k = 0;
                while (reader.Read())//проходим по строкам таблицы результирующего запроса
                {
                    for (int i = 0; i < reader.FieldCount; i++)//здесь tt.FieldCount - это число столбцов в результате запроса
                    {
                        mas[k] = Convert.ToString(reader[i]);
                        k++;
                    }
                }
                sr.cn.Close();




                if ((mas[0] == label1.Text && mas[1] == textBox1.Text) || (mas[2] == label1.Text && mas[3] == textBox1.Text) || (mas[4] == label1.Text && mas[5] == textBox1.Text) || (mas[6] == label1.Text && mas[7] == textBox1.Text))//если пользователь - админ и логин и пароль корректны
                {
                    #region
                    if (textBox2.Text == textBox3.Text)
                    {
                        sr.query = "UPDATE Роли SET  pass='" + textBox3.Text + "' WHERE login='" + label1.Text + "'";
                        sr.ExecSQL(sr.query);

                        admin frm2 = new admin();
                        frm2.Show();//открываем форму для админа                   
                        this.Dispose();//скрываем форму входа*/
                        sr.query = "UPDATE Роли SET  vhod='false' WHERE login='" + admin.dis + "'";
                        sr.ExecSQL(sr.query);
                        if (sr.cn.State == ConnectionState.Open) sr.cn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Некорректный  пароль");//отображаем сообщение, о некорректном логине или пароле
                        textBox3.BackColor = Color.FromArgb(230, 54, 80);
                    }


                    #endregion
                }
                
                            else
                            {
                                MessageBox.Show("Некорректный пароль");//отображаем сообщение, о некорректном логине или пароле
                                textBox1.BackColor = Color.FromArgb(230, 54, 80);
                            }
                        
            }
            catch { }
        }

        private void parol_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menu frm3 = new menu();
                frm3.Show();//открываем форму для обычного пользователя
                this.Dispose();//скрываем форму входа
            }
            catch { }
        }

        private void parol_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Text = admin.dis;
            }
            catch { }
        }
    }
}
