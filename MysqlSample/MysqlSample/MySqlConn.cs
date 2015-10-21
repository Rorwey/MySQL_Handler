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
        // MySQL DB 설정 및 세팅
        private string strServer;
        private string strDB;
        private string strUID;
        private string strPWD;

        // MySQL 접속 샘플 스트링
        //string strConn = "SERVER=localhost; DATABASE=test; UID=root; PWD=admin; CHARSET=utf8;";

        //MySqlConnection con = new MySqlConnection();
        private MySqlConnection con;

        // 서버 주소 설정
        public string Server
        {
            get
            {
                return strServer;
            }
            set
            {
                strServer = value;
            }
        }

        // DB 설정
        public string DB
        {
            get
            {
                return strDB;
            }
            set
            {
                strDB = value;
            }
        }

        // DB 접속 아이디 설정
        public string UID
        {
            get
            {
                return strUID;
            }
            set
            {
                strUID = value;
            }
        }

        // DB 접속 패스워드 설정
        public string PWD
        {
            get
            {
                return strPWD;
            }
            set
            {
                strPWD = value;
            }
        }

        // MySqlConnection 설정
        public MySqlConnection Conn
        {
            get
            {
                return con;
            }
            set
            {
                con = value;
            }
        }

        // DB 접속 함수
        public int Connect()
        {
            string _strConn = "SERVER = " + strServer + "; DATABASE = " + strDB + "; UID = " + strUID + "; PWD = " + strPWD + "; CHARSET = utf8;";

            try
            {
                con.ConnectionString = _strConn;
                con.Open();
                return 0;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            
        }

        // DB 접속 끊는 함수
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

        // DB 쿼리 실행 함수
        public void Execute(string query)
        {
            string _query;
            // 쿼리의 공백 ' ' 추출
            char c = ' ';

            _query = query;
            string[] _type = _query.Split(c);

            // SELECT 함수가 아닌 경우
            if (_type[0] != "SELECT")
            {
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
            /*
            // SELECT 함수일 경우
            else
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(_query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //Console.WriteLine(string.Format("일련번호 : {0} \n수리번호 : {1}\n", row["idx"], row["fix_idx"]));
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            */
        }
   
    }
}
