using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace organization
{
    class ConnectToDB
    {
        static string pc = "EPBYVITW0217.minsk.epam.com", user = "orgUs";

        //public SqlConnection cn = new SqlConnection(@"Server=tcp:" + pc + ",49172; Initial Catalog=org;  Integrated Security=false; User ID=" + user + ";Password=11; pooling=true;");

          //public SqlConnection cn = new SqlConnection(@"Server=tcp:" + Environment.MachineName + ",49172;Initial Catalog=org; Integrated Security=false; User ID=us;Password=11; pooling=true;");
          public SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=true; Initial Catalog=org;");
        public SqlCommand cmd = new SqlCommand();
        public string query = "";
  

        public string GetConnectionString()
        {
            return "Server=tcp:vika-pc,49172;Initial Catalog=org;"
                + "Integrated Security=false; User ID=us;Password=11; pooling=true;";
        }

        public DataSet GetUsersTable(string str_select)
        {
            DataSet ds = new DataSet();
             SqlDataAdapter da = new SqlDataAdapter(str_select, cn);
                da.Fill(ds);
            return ds;
        }

        

        public void ExecSQL(string query)
        {
            //try
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //catch
            {
                MessageBox.Show("Извините, но это выполнить невозможно.");
            }
        }

        public SqlDataReader ReadSQLExec(string sqlEx)
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }

            cn.Open();
            SqlCommand command = new SqlCommand(sqlEx, cn);
            SqlDataReader reader = command.ExecuteReader();
            
            
        return reader;
            cn.Close();
        }

        public int id_kol(string kol)
        {
            
            int id_kol = 0;
            SqlDataReader reader = ReadSQLExec(kol);
            while (reader.Read())
            {
                id_kol = Convert.ToInt32(reader[0]);
            }
            cn.Close(); 
            return id_kol;
            
        }


    }
}
