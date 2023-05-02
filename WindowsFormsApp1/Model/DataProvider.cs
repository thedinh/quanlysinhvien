using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class DataProvider
    {
        protected static string _connectionString;
        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
        public void Connect()
        {
            connection = new SqlConnection(_connectionString);
            connection.Open();
        }

        public void Disconnect()
        {
            connection.Close();
        }
        public DataTable executeQuery(string strStore)
        {
            command = new SqlCommand(strStore, connection);
            command.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable GetDataTable(string strStotre, string table)
        {
            command = new SqlCommand(strStotre, connection);
            command.Parameters.Add("@tenbang", SqlDbType.NVarChar).Value = table;
            command.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public void executeNonQuery(string strStore)
        {
            command = new SqlCommand(strStore, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }
        // Insert students
        public void ENQInsert_HS(string strStore, string mahs, string tenhs, DateTime ngaysinh, string diachi, string diemtrungbinh, string malop)
        {
            command = new SqlCommand(strStore, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@mahs", SqlDbType.NChar).Value = mahs;
            command.Parameters.Add("@tenhs", SqlDbType.NVarChar).Value = tenhs;
            command.Parameters.Add("@ngaysinh", SqlDbType.DateTime2).Value = ngaysinh;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = diachi;
            command.Parameters.Add("@diemtrungbinh", SqlDbType.NVarChar).Value = diemtrungbinh;
            command.Parameters.Add("@malop", SqlDbType.NChar).Value = malop;
            command.ExecuteNonQuery();
            
        }
        // Delete students
        public void ENQDelete_HS(string strStore, string table, string dk)
        {
            command = new SqlCommand(strStore, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@tenbang", SqlDbType.NVarChar).Value = table;
            command.Parameters.Add("@dieukien", SqlDbType.NVarChar).Value = dk;
            command.ExecuteNonQuery();
        }
        // update students
        public void ENQUpdateHS(string strStore,string mahs, string tenhs, DateTime ngaysinh, string diachi, string diemtrungbinh, string malop)
        {
            command = new SqlCommand(strStore, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@mahs", SqlDbType.NChar).Value = mahs;
            command.Parameters.Add("@tenhs", SqlDbType.NVarChar).Value = tenhs;
            command.Parameters.Add("@ngaysinh", SqlDbType.DateTime2).Value = ngaysinh;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = diachi;
            command.Parameters.Add("@diemtrungbinh", SqlDbType.NVarChar).Value = diemtrungbinh;
            command.Parameters.Add("@malop", SqlDbType.NChar).Value = malop;
            command.ExecuteNonQuery();
        }
        public object executeScalar(string strStore)
        {
            command = new SqlCommand(strStore, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteScalar();
        }
    }
}
