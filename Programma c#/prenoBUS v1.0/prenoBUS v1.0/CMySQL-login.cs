using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace prenoBUS_v1._0
{
    class CMySQL_login
    {
        static MySqlConnection conn;
        string connString;
        public CMySQL_login()
        {
            conn = null;
            connString = "";
        }
        public bool connettiDatabase()
        {
            connString = "server=remotemysql.com;user=UZ4rJQ4qBZ;password=xzZFVqol3S;database=UZ4rJQ4qBZ;charset=utf8";
            //try
            //{
                conn = new MySqlConnection(connString);
                //conn.ConnectionString = connString;
                conn.Open();
                return true;
            /*}
            catch(Exception)
            {
                return false;
            }    */
        }
        public bool disconnettiDatabase()
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
                return true;
            }
            else
                return false;
        }
        public bool controllaCredenziali(string username, string password)
        {
            string query = $"SELECT * FROM login WHERE username='{username}' AND password='{password}';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    return true;
                }
            }
            catch(Exception)
            { }
            return false;
        }
    }
}
