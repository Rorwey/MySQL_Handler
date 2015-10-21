using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MySql.Data.MySqlClient;
using System.Data;

namespace MysqlSample
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MySqlConn db = new MySqlConn();
            MySqlConnection con = new MySqlConnection();
            string query;

            db.Conn = con;
            db.Server = "localhost";
            db.DB = "test";
            db.UID = "root";
            db.PWD = "admin";

            db.Connect();

            query = "SELECT * FROM fix_register";
            //query = "DESC fix_register";
            db.Execute(query);

            MySqlDataAdapter da = new MySqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(string.Format("일련번호 : {0} \n수리번호 : {1}\n", row["idx"], row["fix_idx"]));
                }
            }

            db.DisConnect();
        }
    }
}
