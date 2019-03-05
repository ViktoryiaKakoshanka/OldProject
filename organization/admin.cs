using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace organization
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        ConnectToDB sr = new ConnectToDB();
        
        public static string dis = "",ad="", strConn="";
        public static int vhod = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                string[] mas = new string[8];
                int k = 0;
                string z = "SELECT login,pass FROM Роли";
                SqlDataReader reader = sr.ReadSQLExec(z);

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)//здесь tt.FieldCount - это число столбцов в результате запроса
                    {
                        mas[k] = Convert.ToString(reader[i]);
                        k++;
                    }
                }

                z="SELECT vhod FROM Роли where login='"+comboBox1.Text+"'";
                 reader = sr.ReadSQLExec(z);
                while (reader.Read()){
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        vhod = Convert.ToInt32(reader[i]);
                    }
                }


                if (vhod == 0)
                {
                    if ((mas[0] == comboBox1.Text && mas[1] == textBox2.Text) || (mas[2] == comboBox1.Text && mas[3] == textBox2.Text) || (mas[4] == comboBox1.Text && mas[5] == textBox2.Text))//если пользователь - админ и логин и пароль корректны
                    {
                        ad = "";
                        dis = comboBox1.Text;
                        menu frm2 = new menu();
                        frm2.Show();//открываем форму для админа                   
                        this.Hide();//скрываем форму входа*/
                        sr.query = "UPDATE Роли SET  vhod='true' WHERE login='" + dis + "'";
                        sr.ExecSQL(sr.query);
                    }
                    else if (mas[6] == comboBox1.Text && mas[7] == textBox2.Text)//если пользователь - user и логин и пароль корректны
                    {
                        ad = comboBox1.Text;
                        dis = comboBox1.Text;
                        menu frm3 = new menu();
                        frm3.Show();//открываем форму для обычного пользователя
                        this.Hide();//скрываем форму входа
                        sr.query = "UPDATE Роли SET  vhod='true' WHERE login='" + dis + "'";
                        sr.ExecSQL(sr.query);
                    }
                    else
                    {
                        //если пользователь ввел некорректный логин или пароль
                        MessageBox.Show("Некорректный логин или пароль");//отображаем сообщение, о некорректном логине или пароле
                        //   comboBox1.BackColor = Color.FromArgb(230, 54, 80);//фон textbox1 делаем красным
                        textBox2.BackColor = Color.FromArgb(230, 54, 80);//фон textbox1 делаем красным
                    }
                }
                else MessageBox.Show("Извините. Но эот пользователь уже в сети");
            }
            catch { }
        }

        

        private void admin_Load(object sender, EventArgs e)
        {

            //Server=tcp:EPBYVITW0217,49172;Integrated Security=false; User ID=orgUs;Initial Catalog=org; pooling=true; Password=11;
            String line = "";
                using (StreamReader srq = new StreamReader("ConnectedString.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = srq.ReadToEnd();
                }
                strConn = line;


                sr.cmd.Connection = sr.cn;

                comboBox1.Items.Clear();
                string z = "SELECT * FROM Роли";
                SqlDataReader reader = sr.ReadSQLExec(z);
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
                sr.cn.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {//★ ☆ ●
            if (textBox2.PasswordChar == '\0') textBox2.PasswordChar = '●'; else textBox2.PasswordChar = '\0';
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        protected void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try{
            sr.query = "UPDATE Роли SET  vhod='false' WHERE login='" + dis + "'";
            sr.ExecSQL(sr.query);
            int i = 0;
            if (adminKA.arhiv == true)
            {
                i++;
                if (i == 1) System.Diagnostics.Process.Start(@""+Environment.CurrentDirectory+@"\connect.exe");
                adminKA.arhiv = false;
            }
            Application.Exit();
            }
            catch { }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox1, "Настройки");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try{
            Form2 frm3 = new Form2();
            frm3.Show();//открываем форму для обычного пользователя
            this.Hide();
            }
            catch { }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"" + Environment.CurrentDirectory + @"\organization.exe");
                Application.Exit();
            }
            catch { }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox2, "Перезагрузка");
        }

       

      
    }
}
