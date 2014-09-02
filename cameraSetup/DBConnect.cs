using System;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data;
//Add MySql Library
using MySql.Data.MySqlClient;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;


namespace ComPort
{
    public class DBConnect
    {
        public MySqlConnection connection;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;

        

        //Constructor
        public DBConnect(string server,string port, string database, string uid, string password)
        {
            Initialize(server,port, database, uid, password);
        }

        //Initialize values
        private void Initialize(string serverVal,string portVal, string databaseVal, string uidVal, string passwordVal)
        {
            //server = "localhost";
            server = serverVal; // "10.1.0.16";
            database = databaseVal; // "wpandb";
            port = portVal;
            uid = uidVal; // "root";
            password = passwordVal; // null;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "Port=" + port +";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public void createDB()
        {
          
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
            catch(Exception e)
            {
               // MessageBox.Show("other exeption");
                return false;
            }

        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                
                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select()
        {
            
            string query = "SELECT * FROM locationdb";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //list[0].Add(dataReader["id"] + "");
                    //list[1].Add(dataReader["name"] + "");
                    //list[2].Add(dataReader["age"] + "");
                    Debug.WriteLine("TAGid " + dataReader["TagID"] + "\tPktLqi: " + dataReader["PktLqi"]);


                }

            

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public DataTable searchDB(string sql)
        {
            DataTable table = new DataTable();

            if (this.OpenConnection() == true)
            {
                // Creates a SQL command
                using (var command = new MySqlCommand(sql, connection))
                {
                    // Loads the query results into the table
                    table.Load(command.ExecuteReader());
                    this.CloseConnection();
                    return table;
                }

            }
            else
            {
                this.CloseConnection();
                return null;
            }




        }


        //public void trackingDBaseUpDate(Tag WorkingTag) //(string TagAdd, string ReaderAdd)
        //{
                
        //        DataTable table = new DataTable(); // to store results
        //        // System.Data.SqlClient.SqlCommandBuilder trackingCB;                     //needed to add new records on clossed DB 
        //        // trackingCB = new System.Data.SqlClient.SqlCommandBuilder(trackingDA);           //
                

        //        //Open connection
        //        if (this.OpenConnection() == true)
        //        {
        //            //Remove all TOFdistance entrys for this tag
        //            //------------------------------------------------------------------------------------------------------------
        //            string sql = string.Format("UPDATE LocationDB SET TOFdistance = 0 WHERE TagAdd like '{0}%'", WorkingTag.TagAdd); // TagAdd);

        //            //Create Command
        //            MySqlCommand command = new MySqlCommand(sql, connection);
        //            //Create a data reader and Execute the command

        //            //command.ExecuteNonQuery();  //Will change to this after testing

        //            //----------------------------------------------------------------------------------------------------------------
        //            //check if tag reader pair are in DB
        //            //------------------------------------------------------------------------------------------------------------------

        //            sql = string.Format("SELECT * FROM LocationDB WHERE TagAdd like '{0}%' and ReaderAdd like '{1}%' LIMIT 1", WorkingTag.TagAdd, WorkingTag.ReaderAdd); //TagAdd,ReaderAdd);

        //            //sql = string.Format("SELECT * FROM LocationDb");
        //            command = new MySqlCommand(sql, connection);
        //            try
        //            {
        //                MySqlDataReader dataReader = command.ExecuteReader();
        //                // table.Load(command.ExecuteReader(), LoadOption.OverwriteChanges);
        //                table.Load(dataReader, LoadOption.OverwriteChanges);


        //                if (table.Rows.Count > 0)
        //                {// We have one in the table so needs updating
        //                    // trackingCon.Open();
        //                    string sqlChange = string.Format("UPDATE LocationDB SET PktLqi = '{0}', TOFdistance ='{1}', TOFmac= '{2}', TimeStamp = (@value), TOF_MAC_LQI_LIFETIME = '{3}', RxLQI = '{4}', sequence = '{7}', CH4 = '{8}', CO = '{9}', O2 = '{10}', CO2 = '{11}', Name = '{12}', endPointType ='{13}' WHERE TagAdd like '{5}%' and ReaderAdd like '{6}%'  ", WorkingTag.PktLqi, WorkingTag.TOFdistance, WorkingTag.TOFmac, 6, WorkingTag.RxLQI, WorkingTag.TagAdd, WorkingTag.ReaderAdd, WorkingTag.PktSequence, WorkingTag.CH4gas, WorkingTag.COgas, WorkingTag.O2gas, WorkingTag.CO2gas, WorkingTag.Name, WorkingTag.endPointType);

        //                    // Creates a SQL command
        //                    command = new MySqlCommand(sqlChange, connection);
        //                    command.Parameters.AddWithValue("@value", DateTime.Now);
        //                    command.ExecuteNonQuery();


        //                }
        //                else
        //                {// Not in the table so needs adding 
        //                    trackingDataBaseAddNew(WorkingTag);           //add new data to tracking DB
        //                }

        //                this.CloseConnection();
        //            }
        //            catch
        //            { }


        //        }
        //        else // datbase connection not open
        //        {
        //            MessageBox.Show("Error , no database connection!"); 
        //        }

        //     }

//        private void trackingDataBaseAddNew(Tag WorkingTag)
//        {
            
//            MySqlCommand cmd = new MySqlCommand();
//            cmd.CommandText = "INSERT INTO LocationDB (TagAdd, ReaderAdd, PktLqi, TOFdistance, TOFmac, TimeStamp, TOF_MAC_LQI_LIFETIME, RxLQI,sequence , CH4, CO, O2, CO2, Name, endPointType) VALUES(@TagAdd,@ReaderAdd,@PktLqi,@TOFdistance,@TOFmac,@TimeStamp,@TOF_MAC_LQI_LIFETIME,@RxLQI,@sequence,@CH4,@CO,@O2,@CO2,@Name,@endPointType)";
//            cmd.Parameters.AddWithValue("TagAdd", WorkingTag.TagAdd);
//            cmd.Parameters.AddWithValue("ReaderAdd", WorkingTag.ReaderAdd);
//            cmd.Parameters.AddWithValue("PktLqi", WorkingTag.PktLqi);
//            cmd.Parameters.AddWithValue("TOFdistance", WorkingTag.TOFdistance);
//            cmd.Parameters.AddWithValue("TOFmac", WorkingTag.TOFmac);
//            cmd.Parameters.AddWithValue("TimeStamp", DateTime.Now);
//            cmd.Parameters.AddWithValue("TOF_MAC_LQI_LIFETIME", 6);
//            cmd.Parameters.AddWithValue("RxLQI", WorkingTag.RxLQI);
//            cmd.Parameters.AddWithValue("sequence", WorkingTag.PktSequence);
//            cmd.Parameters.AddWithValue("CH4", WorkingTag.CH4gas);
//            cmd.Parameters.AddWithValue("CO", WorkingTag.COgas);
//            cmd.Parameters.AddWithValue("O2", WorkingTag.O2gas);
//            cmd.Parameters.AddWithValue("CO2", WorkingTag.CO2gas);
//            cmd.Parameters.AddWithValue("Name", WorkingTag.Name);
//            cmd.Parameters.AddWithValue("endPointType", WorkingTag.endPointType);
//            cmd.Connection = connection;
//            cmd.ExecuteNonQuery();

            
//        }

//        public void historyDataBaseAddNew(Tag WorkingTag)
//        {
//            //Open connection
//            if (this.OpenConnection() == true)
//            {
//                MySqlCommand cmd = new MySqlCommand();
//                cmd.CommandText = @"INSERT INTO Historydb ( PktLength, ReaderAdd, TagAdd, Volt, PktSequence, PktEvent, PktLqi, TOFping, TOFtimeout, TOFrefuse, TOFsuccess, TOFdistance, RSSIdistance, TOFerror, TOFmac, PktTemp, BrSequ, BrCmd) 
//                                                    VALUES(@PktLength,@ReaderAdd,@TagAdd,@Volt,@PktSequence,@PktEvent,@PktLqi,@TOFping,@TOFtimeout,@TOFrefuse,@TOFsuccess,@TOFdistance,@RSSIdistance,@TOFerror,@TOFmac,@PktTemp,@BrSequ,@BrCmd)";

//                cmd.Parameters.AddWithValue("PktLength", WorkingTag.PktLength);
//                cmd.Parameters.AddWithValue("ReaderAdd", WorkingTag.ReaderAdd);
//                cmd.Parameters.AddWithValue("TagAdd", WorkingTag.TagAdd);
//                cmd.Parameters.AddWithValue("Volt", WorkingTag.Volt);
//                cmd.Parameters.AddWithValue("PktSequence", WorkingTag.PktSequence);
//                cmd.Parameters.AddWithValue("PktEvent", WorkingTag.PktEvent);
//                cmd.Parameters.AddWithValue("PktLqi", WorkingTag.PktLqi);
//                cmd.Parameters.AddWithValue("TOFping", WorkingTag.TOFping);
//                cmd.Parameters.AddWithValue("TOFtimeout", WorkingTag.TOFtimeout);
//                cmd.Parameters.AddWithValue("TOFrefuse", WorkingTag.TOFrefuse);
//                cmd.Parameters.AddWithValue("TOFsuccess", WorkingTag.TOFsuccess);
//                cmd.Parameters.AddWithValue("TOFdistance", WorkingTag.TOFdistance);
//                cmd.Parameters.AddWithValue("RSSIdistance", WorkingTag.RSSIdistance);
//                cmd.Parameters.AddWithValue("TOFerror", WorkingTag.TOFerror);
//                cmd.Parameters.AddWithValue("TOFmac", WorkingTag.TOFmac);
//                cmd.Parameters.AddWithValue("PktTemp", WorkingTag.PktTemp);
//                cmd.Parameters.AddWithValue("BrSequ", WorkingTag.BrSequ);
//                cmd.Parameters.AddWithValue("BrCmd", WorkingTag.BrCmd);
//                cmd.Connection = connection;
//                cmd.ExecuteNonQuery();

//                this.CloseConnection();

//            }
   

//        }

        public void LQIdecay()
        {
            if (this.OpenConnection() == true)
            {
                string sql = string.Format("UPDATE LocationDB SET PktLqi = PktLqi/(POWER(0.75,(TOF_MAC_LQI_LIFETIME - 6))), TOF_MAC_LQI_LIFETIME = (TOF_MAC_LQI_LIFETIME -1)  WHERE PktLqi > 0 and TOF_MAC_LQI_LIFETIME > 0 ");   //TagAdd, ReaderAdd, PktLqi, TimeStamp, TOF_MAC_LQI_LIFETIME

                //Create Command
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();

                this.CloseConnection();

            }
            this.CloseConnection();                
            
        }




        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar()+"");
                
                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);

                
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                
                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!");
            }
        }

        public void exicuteScript(string fileName)
        {
            MySqlScript script = new MySqlScript(this.connection, File.ReadAllText(fileName));
            script.Delimiter = "$$";
            try
            {
                script.Execute();
                MessageBox.Show("DB Created");
            }
            catch
            {
                MessageBox.Show("Error, Server connection");
            }
        }


        //public class Tag
        //{

 
        //    public string TagAdd { get; set; }
        //    public int TTL { get; set; }           // tag time to live

        //    public int PktLength;
        //    public int PktSequence;
        //    public int PktEvent;
        //    public int PktTemp;
        //    public int Volt;
        //    public int PktLqi;
        //    public int BrSequ;
        //    public int BrCmd;
        //    public int TOFping;
        //    public int TOFtimeout;
        //    public int TOFrefuse;
        //    public int TOFsuccess;
        //    public int TOFdistance;
        //    public int RSSIdistance;
        //    public int TOFerror;
        //    public string TOFmac;
        //    public string ReaderAdd;
        //    public int RxLQI;
        //    public float CH4gas;
        //    public int COgas;
        //    public float O2gas;
        //    public float CO2gas;

        //    public void formatDataOld(ref int[] rxArray)
        //    {
        //        this.PktLength = rxArray[2];
        //        this.PktSequence = rxArray[3];
        //        //4
        //        //5
        //        //6
        //        //7
        //        //8
        //        //9
        //        //10
        //        this.PktEvent = rxArray[11];
        //        this.PktTemp = rxArray[12];
        //        this.Volt = (rxArray[14] << 8) + rxArray[13];
        //        //15
        //        //16
        //        //17
        //        //18
        //        //19
        //        //20
        //        this.TagAdd = string.Format("{0:X}{1:X}{2:X}{3:X}{4:X}{5:X}{6:X}{7:X}",
        //                                    rxArray[28].ToString("X2"), rxArray[27].ToString("X2"), rxArray[26].ToString("X2"), rxArray[25].ToString("X2"),
        //                                    rxArray[24].ToString("X2"), rxArray[23].ToString("X2"), rxArray[22].ToString("X2"), rxArray[21].ToString("X2")
        //                                    );
        //        //WorkingTag.PktLength = (PortArray[2] << 8) + PortArray[1]; //Then use it to index allTag List

        //        this.ReaderAdd = string.Format("{0:X}{1:X}{2:X}{3:X}{4:X}{5:X}{6:X}{7:X}",
        //                                      rxArray[36].ToString("X2"), rxArray[35].ToString("X2"), rxArray[34].ToString("X2"), rxArray[33].ToString("X2"),
        //                                      rxArray[32].ToString("X2"), rxArray[31].ToString("X2"), rxArray[30].ToString("X2"), rxArray[29].ToString("X2")
        //                                      );
        //        this.PktLqi = rxArray[37];
        //        //Broadcast
        //        this.BrSequ = rxArray[38];
        //        this.BrCmd = rxArray[39];
        //        //TOF
        //        this.TOFping = rxArray[40];
        //        this.TOFtimeout = (rxArray[42] << 8) + rxArray[41];
        //        this.TOFrefuse = rxArray[43];
        //        this.TOFsuccess = rxArray[44];
        //        this.TOFdistance = ((rxArray[48] << 24) + (rxArray[47] << 16) + (rxArray[46] << 8) + (rxArray[45]));
        //        this.RSSIdistance = ((rxArray[52] << 24) + (rxArray[51] << 16) + (rxArray[50] << 8) + (rxArray[49]));
        //        this.TOFerror = rxArray[53];
        //        this.TOFmac = string.Format("{0:X}{1:X}{2:X}{3:X}{4:X}{5:X}{6:X}{7:X}",
        //                                         rxArray[61].ToString("X2"), rxArray[60].ToString("X2"), rxArray[59].ToString("X2"), rxArray[58].ToString("X2"),
        //                                         rxArray[57].ToString("X2"), rxArray[56].ToString("X2"), rxArray[55].ToString("X2"), rxArray[54].ToString("X2"));

        //        this.RxLQI = rxArray[62];

        //        //Gas Sensors
        //        this.CH4gas = (float)((rxArray[63] << 8) + (rxArray[64])) / 100;  // %
        //        this.COgas = (rxArray[65] << 8) + rxArray[66];                    //ppm
        //        this.O2gas = (float)((rxArray[67] << 8) + rxArray[68]) / 10;      // %

        //    }

        //    public void formatData(ref int[] rxArray)
        //    {
        //        UInt16 u16data = 2;

        //        this.PktLength = rxArray[u16data++]; //2
        //        this.PktSequence = rxArray[u16data++]; //3
        //        u16data++;//4 Type               
        //        u16data++;//5 Sleep time
        //        u16data++;//6 Sleep time
        //        u16data++;//7 Sleep time
        //        u16data++;//8 Sleep time
        //        this.PktEvent = (rxArray[10] << 8) + rxArray[9];
        //        //11 buttons
        //        this.PktTemp = rxArray[12];
        //        this.Volt = (rxArray[14] << 8) + rxArray[13];
        //        //15 tag ping sequ count
        //        //16 tag ping sequ count
        //        //17 tag ping sequ count
        //        //18 tag ping sequ count
                         
                               
        //        this.TagAdd = string.Format("{0:X}{1:X}{2:X}{3:X}{4:X}{5:X}{6:X}{7:X}",
        //                                    rxArray[26].ToString("X2"), rxArray[25].ToString("X2"), rxArray[24].ToString("X2"), rxArray[23].ToString("X2"),
        //                                    rxArray[22].ToString("X2"), rxArray[21].ToString("X2"), rxArray[20].ToString("X2"), rxArray[19].ToString("X2")
        //                                    );
        //        //WorkingTag.PktLength = (PortArray[2] << 8) + PortArray[1]; //Then use it to index allTag List

        //        this.ReaderAdd = string.Format("{0:X}{1:X}{2:X}{3:X}{4:X}{5:X}{6:X}{7:X}",
        //                                      rxArray[34].ToString("X2"), rxArray[33].ToString("X2"), rxArray[32].ToString("X2"), rxArray[31].ToString("X2"),
        //                                      rxArray[30].ToString("X2"), rxArray[29].ToString("X2"), rxArray[28].ToString("X2"), rxArray[27].ToString("X2")
        //                                      );
        //        this.PktLqi = rxArray[35];
        //        //Broadcast
        //        this.BrSequ = rxArray[36];
        //        this.BrCmd = rxArray[37];
        //        //TOF
        //        this.TOFping = (rxArray[39] << 8) + rxArray[38];
        //        this.TOFtimeout = rxArray[40];
        //        this.TOFrefuse = rxArray[41];
        //        this.TOFsuccess = rxArray[42];
        //        this.TOFdistance = ((rxArray[46] << 24) + (rxArray[45] << 16) + (rxArray[44] << 8) + (rxArray[43]));
               
        //        this.TOFerror = rxArray[47];
        //        this.TOFmac = string.Format("{0:X}{1:X}{2:X}{3:X}{4:X}{5:X}{6:X}{7:X}",
        //                                         rxArray[55].ToString("X2"), rxArray[54].ToString("X2"), rxArray[53].ToString("X2"), rxArray[52].ToString("X2"),
        //                                         rxArray[51].ToString("X2"), rxArray[50].ToString("X2"), rxArray[49].ToString("X2"), rxArray[48].ToString("X2"));

        //        this.RxLQI = rxArray[56];

        //        //Gas Sensors
        //        this.CH4gas = (float)((rxArray[58] << 8) + (rxArray[57])) / 100;  // %
        //        this.COgas = (rxArray[60] << 8) + rxArray[59];                    //ppm
        //        this.O2gas = (float)((rxArray[62] << 8) + rxArray[61]) / 10;      // %
        //        this.CO2gas = (float)((rxArray[64] << 8) + rxArray[63]) / 10;      // %

        //    }

        //}

        public class TestBind
        {public string Name;
            public TestBind(string stringIN)
            {
            Name = stringIN;
               }
        }

        public class TagBind : INotifyPropertyChanged
        {
            //public TagBind():this("")
            //{
            //}
            public event PropertyChangedEventHandler PropertyChanged;
           
            
            
            
            public TagBind(string TagAddIn, int TtlIn, string tagData1) 
            {
               
                
                _name = TagAddIn;
                _TTL = TtlIn;
                TestBind aa = new TestBind(tagData1);
                tagData.Add(aa);
                
                
                
               
            }

            string _name = "";
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
            private int _TTL;
            public int TTL
            {
                                 get { return _TTL; }
                                set
                                {
                                    _TTL = value;
                                    this.NotifyPropertyChanged("TTL");}
                                }          

            private ObservableCollection<TestBind> _tagData = null;
            public ObservableCollection<TestBind> tagData    //test for tree view
            {

                get
                {

                    if (_tagData == null) _tagData = new ObservableCollection<TestBind>();
                    return _tagData;
                }
                set { _tagData = value; }
            }

                    private void NotifyPropertyChanged(string name)
        {


            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));


        }

        }

    }
}
