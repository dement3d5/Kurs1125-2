using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs1125.Model
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

        internal MySqlConnection sqlConnection = null;

        internal void InitConnection()
        {
  
        }

        internal void InitConnection(string server, string user, string db, string password)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.UserID = user;
            builder.Password = password;
            builder.Database = db;
            builder.Server = server;
            builder.CharacterSet = "utf8";
            builder.ConnectionTimeout = 5;

            sqlConnection = new MySqlConnection(builder.GetConnectionString(true));
        }

        internal bool OpenConnection()
        {
            try
            {
                if (sqlConnection == null)
                    InitConnection();
                sqlConnection.Open();
                return true;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return false;
        }

        internal void CloseConnection()
        {
            try
            {
                sqlConnection.Close(); // закрытие соединения
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal void ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            if (OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, sqlConnection))
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

        private int GetTableInfo(string table, string column)
        {
            int result = 0;
            //SHOW TABLE STATUS WHERE `Name` = 'group'
            if (OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand($"SHOW TABLE STATUS WHERE `Name` = '{table}'", sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    dr.Read();
                    result = dr.GetInt32(column);
                }
                CloseConnection();
            }
            return result;
        }
    }
}
