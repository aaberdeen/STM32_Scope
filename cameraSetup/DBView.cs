using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComPort;
using MySql.Data.MySqlClient;

namespace STM32scope
{
    public partial class DBView : Form
    {
        public DBView()
        {
            InitializeComponent();
            DBConnect dbConnect;
            dbConnect = new DBConnect(Properties.Settings.Default.Server, Properties.Settings.Default.Port, Properties.Settings.Default.Database, Properties.Settings.Default.UID, Properties.Settings.Default.Password); //initialises new db connection
            if (dbConnect.OpenConnection() == true)
            {
                DataTable table = new DataTable();
                table.Columns.Add("HEX MAC");
                string sql = string.Format("select * from mac_table");
                MySqlCommand command = new MySqlCommand(sql, dbConnect.connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                table.Load(dataReader, LoadOption.OverwriteChanges);
                dbConnect.CloseConnection();

                foreach (DataRow r in table.Rows)
                {
                    r["HEX MAC"] =  string.Format("{0:x}", r["MAC"]);
                }
                

                dataGridView1.DataSource = table;
                //MySqlDataReader dataReader = command.ExecuteReader();
                // table.Load(command.ExecuteReader(), LoadOption.OverwriteChanges);
                // table.Load(dataReader, LoadOption.OverwriteChanges);



            }
            else // datbase connection not open
            {
                MessageBox.Show("Error , no database connection!");

            }

        }

        private void DBView_Load(object sender, EventArgs e)
        {

        }
    }
}
