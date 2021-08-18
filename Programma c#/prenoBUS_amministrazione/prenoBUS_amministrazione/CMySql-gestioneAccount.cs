using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace prenoBUS_amministrazione
{
    public class CMySql_gestioneAccount
    {
        static MySqlConnection conn;
        string connString;
        public CMySql_gestioneAccount()
        {
            conn = null;
            connString = "";
        }
        public bool connettiDatabase()
        {
            connString = "server=remotemysql.com;user=UZ4rJQ4qBZ;password=xzZFVqol3S;database=UZ4rJQ4qBZ;charset=utf8";
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
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
        public bool controllaCredenziali(string username)
        {
            string query = $"SELECT * FROM login WHERE username='{username}';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
            }
            catch (Exception)
            { }
            return false;
        }
        public bool creaUtente(string username, string password)
        {
            if (!controllaCredenziali(username))
            {
                disconnettiDatabase();
                connettiDatabase();
                string query = $"INSERT INTO login VALUES ('" + username + "', '" + password + "')";

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
                return false;
            
        }

        public bool eliminaUtente(string username, string password)
        {
            if (controllaCredenziali(username))
            {
                disconnettiDatabase();
                connettiDatabase();
                string query = $"DELETE FROM login WHERE username='{username}'";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}
