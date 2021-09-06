using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace prenoBUS_v1._0
{
    public class CMySQL_login
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
            connString = "server=bb4guwdx6vaaqx95ix7h-mysql.services.clever-cloud.com;user=uzdvzunx5mjtnyad;password=2pR6rqfLqYbMfLa1XqwF;database=bb4guwdx6vaaqx95ix7h;charset=utf8";
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                return true;
            }
            catch(MySqlException)
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
        public bool controllaCredenziali(string username, string password)
        {
            string query = $"SELECT * FROM login WHERE username='{username}' AND password='{password}';";
            disconnettiDatabase();
            connettiDatabase();
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
        public CData controllaBiglietto(string qr)
        {
            CData dati;
            string query = $"SELECT linea, inizioAbbonamento, fineAbbonamento from biglietti where codiceqr='{qr}'";
            disconnettiDatabase();
            connettiDatabase();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dati = new CData(qr,reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    return dati;
                }
            }
            catch (Exception)
            { }
            return null;
        }
        public bool eliminaBiglietto(string qr)
        {
            disconnettiDatabase();
            connettiDatabase();
            string query = $"DELETE FROM biglietti WHERE codiceqr='{qr}'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
