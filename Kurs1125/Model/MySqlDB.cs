using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs1125
{
    public class MySqlDB
    {
        private MySqlDB() { }
        static MySqlDB db;
        public static MySqlDB GetDB()
        {
            if (db == null)
                db = new MySqlDB();
            return db;
        }
        public MySqlConnection
               GetConnection()
        {
            if(conn == null)
                InitConnection();

            return conn;
        }


        public bool OpenConnection()
        {
            try
            {
                if (conn == null)
                    InitConnection();
                conn.Open();
                return true;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return false;
        }

        public void CloseConnection()
        {
            try
            {
                conn.Close(); // закрытие соединения
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        internal MySqlConnection conn = null;
        internal void InitConnection()
        {
            InitConnection(Properties.Settings.Default.host, Properties.Settings.Default.username, Properties.Settings.Default.password, Properties.Settings.Default.db);
        }
        internal void InitConnection(string server, string user, string pass, string db)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.UserID = user;
            builder.Password = pass;
            builder.Database = db;
            builder.Server = server;
            builder.CharacterSet = "utf8";
            builder.ConnectionTimeout = 5;

            conn = new MySqlConnection(builder.GetConnectionString(true));
        }


        private int GetTableInfo(string table, string column)
        {
            int result = 0;
            //SHOW TABLE STATUS WHERE `Name` = 'group'
            if (OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand($"SHOW TABLE STATUS WHERE `Name` = '{table}'", conn))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    dr.Read();
                    result = dr.GetInt32(column);
                }
                CloseConnection();
            }
            return result;
        }
        internal void ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            if (OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                        mc.Parameters.AddRange(parameters);
                    mc.ExecuteNonQuery();
                }
                CloseConnection();
            }
        }
       

        internal int GetNextID(string table)
        {
            string column = "Auto_increment";
            return GetTableInfo(table, column);
        }
        internal int GetRowsCount(string table)
        {
            string column = "Rows";
            return GetTableInfo(table, column);
        }
    }
}
