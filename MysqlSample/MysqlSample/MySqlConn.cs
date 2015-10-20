using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace MysqlSample
{
    class MySqlConn
    {
        // MySql DB 설정 및 세팅
        string strConn = "SERVER=localhost; DATABASE=test; UID=root; PWD=admin; CHARSET=utf8;";
        MySqlConnection con = new MySqlConnection();

        public int Connect()
        {
            try
            {
                con.ConnectionString = strConn;
                con.Open();
                return 0;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            
        }

        public void DisConnect()
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                    con = null;
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void Insert(string query)
        {
            string _query;
            // 샘플 쿼리
            //_query = "INSERT ...";
            _query = query;

            MySqlCommand cmd = new MySqlCommand(_query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            

        }

        public void Execute(string query)
        {
            string _query;
            // 샘플 쿼리
            //query = "SELECT * FROM fix_register";
            _query = query;

            MySqlCommand cmd = new MySqlCommand(_query, con);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine(reader.GetString(0));
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
   
    }

   
}
