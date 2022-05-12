﻿using Kurs1125.DTO;
using Kurs1125.pages;
using Kurs1125.Tools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs1125.Model
{
    class SqlModel
    {
        private SqlModel() { }
        static SqlModel sqlModel;
        public static SqlModel GetInstance()
        {
            if (sqlModel == null)
                sqlModel = new SqlModel();
            return sqlModel;
        }
        internal List<Zakazi> Zakazi()
        {
            List<Zakazi> zakazi = new List<Zakazi>();
            var groups = new List<Zakazi>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT dtincome, dtdestination, place of departure, destination, price FROM `zakazi`";

            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.conn))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        groups.Add(new Zakazi
                        {

                            Dtincome = dr.GetDateTime("dtincome"),
                            Dtdestination = dr.GetDateTime("dtdestination"),
                            Pod = dr.GetString("place of departure"),
                            Destination = dr.GetString("destination"),
                            Price = dr.GetString("price"),
                            AB1 = dr.GetInt32("Abonent_id"),
                            ND = dr.GetInt32("number_dispatchs"),
                            Vid = dr.GetInt32("Voditel_id"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return groups;
        }
        internal List<Voditel> Voditel()
        {
            List<Voditel> voditel = new List<Voditel>();
            var voditels = new List<Voditel>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT fname, lname, mcar, ncar, color FROM `voditel`";

            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.conn))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        voditels.Add(new Voditel
                        {
                            ID = dr.GetInt32("id"),
                            Fname = dr.GetString("dtincome"),
                            Lname = dr.GetString("dtdestination"),
                            Mcar = dr.GetString("place of departure"),
                            Ncar = dr.GetString("destination"),
                            Color = dr.GetString("price")

                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return voditels;
        }

       
        internal List<Zakazi> SelectZakazisByList()
        {

            var zakazis = new List<Zakazi>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `zakazi`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.conn))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        zakazis.Add(new Zakazi
                        {
                            Dtincome = dr.GetDateTime("dtincome"),
                            Dtdestination = dr.GetDateTime("dtdestination"),
                            Pod = dr.GetString("place of departure"),
                            Destination = dr.GetString("destination"),
                            Price = dr.GetString("price"),
                            AB1 = dr.GetInt32("Abonent_id"),
                            ND = dr.GetInt32("number_dispatchs"),
                            Vid = dr.GetInt32("Voditel_id")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return zakazis;
        }

        public int Insert<T>(T value)
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateInsertQuery(table, values);
            var db = MySqlDB.GetDB();
            int id = db.GetNextID(table);
            db.ExecuteNonQuery(query.Item1, query.Item2);
            return id;
        }

        public void Update<T>(T value) where T : BaseDTO
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateUpdateQuery(table, values, value.ID);
            var db = MySqlDB.GetDB();
            db.ExecuteNonQuery(query.Item1, query.Item2);
        }

        public void Delete<T>(T value) where T : BaseDTO
        {
            var type = value.GetType();
            string table = GetTableName(type);
            var db = MySqlDB.GetDB();
            string query = $"delete from `{table}` where id = {value.ID}";
            db.ExecuteNonQuery(query);
        }

        public int GetNumRows(Type type)
        {
            string table = GetTableName(type);
            return MySqlDB.GetDB().GetRowsCount(table);
        }

        private static string GetTableName(Type type)
        {
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            return ((TableAttribute)tableAtrributes.First()).Table;
        }

        private static (string, MySqlParameter[]) CreateInsertQuery(string table, List<(string, object)> values)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"INSERT INTO `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static (string, MySqlParameter[]) CreateUpdateQuery(string table, List<(string, object)> values, int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"UPDATE `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            stringBuilder.Append($" WHERE id = {id}");
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static List<MySqlParameter> InitParameters(List<(string, object)> values, StringBuilder stringBuilder)
        {
            var parameters = new List<MySqlParameter>();
            int count = 1;
            var rows = values.Select(s =>
            {
                parameters.Add(new MySqlParameter($"p{count}", s.Item2));
                return $"{s.Item1} = @p{count++}";
            });
            stringBuilder.Append(string.Join(',', rows));
            return parameters;
        }

        private static void GetMetaData<T>(T value, out string table, out List<(string, object)> values)
        {
            var type = value.GetType();
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            table = ((TableAttribute)tableAtrributes.First()).Table;
            values = new List<(string, object)>();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                var columnAttributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (columnAttributes.Length > 0)
                {
                    string column = ((ColumnAttribute)columnAttributes.First()).Column;
                    values.Add(new(column, prop.GetValue(value)));
                }
            }
        }
    }
}
