using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;
using ComPort;
using FTD2XX_NET;
using System.Windows.Forms.DataVisualization.Charting;


namespace STM32scope
{
    public partial class Form1 : Form
    {
        // The main control for communicating through the RS-232 port
        private SerialPort comport = new SerialPort();
        //Queue<char> rxQueue = new Queue<char>();
        Queue<double> rxQueue = new Queue<double>();
        DBConnect dbConnect;
        bool Do_Work = false;
        bool bgWorkerRun = true;
        string macUnFormatted=null;
        bool cyclePort = true;

        private double x = 0;
        private double y = 0;
        double[] serise = new double[1000];
       // DataPointCollection pCol = new DataPointCollection();
        DataPoint[] p = new DataPoint[1000];
        Series seriesA;
        Series seriesB;
        int pointer;
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.Maximum = 1000;
            seriesA = new System.Windows.Forms.DataVisualization.Charting.Series();
            seriesA.ChartType = SeriesChartType.FastPoint;

            seriesB = new System.Windows.Forms.DataVisualization.Charting.Series();
            seriesB.ChartType = SeriesChartType.FastPoint;
            // Set the port's settings
            

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            cyclePort = false;
            //ftdi_connect();
            Thread.Sleep(100);
            if (comport.IsOpen)
            {

                bgWorkerRun = false;
               // Thread.Sleep(500);
                backgroundWorker1.CancelAsync();
               // Thread.Sleep(1000);
                comport.Close();

            }

            comport.BaudRate = 115200; // 921600;
            comport.DataBits = 8;
            comport.StopBits = StopBits.One;
            comport.Parity = Parity.None;
            comport.PortName = comboBox1.Text;

            try
            {
                // Open the port
                comport.Open();
            }
            catch (Exception ex) 
            { MessageBox.Show("connection error"+ex.ToString());
            }


            richTextBox1.Clear();
            richTextBox1.Focus();
            //while (backgroundWorker1.IsBusy)
            //{
            //    Thread.Sleep(10);
            //    richTextBox1.AppendText(".");
                
            //}
            if (backgroundWorker1.IsBusy)
            {
                bgWorkerRun = true;
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
           private void DiscinnectButton_Click(object sender, EventArgs e)
        {
            if (comport.IsOpen)
            {

                bgWorkerRun = false;
                // Thread.Sleep(500);
                backgroundWorker1.CancelAsync();
                // Thread.Sleep(1000);
                comport.Close();
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
                comboBox1.Items.Add(s);
        }

         private int get_comms()
        {
            // If the com port has been closed, message box, return -1;
            if (!comport.IsOpen)
            {
                MessageBox.Show("comport not open");
                return -2;
            }
            else
            {
                try
                {
                    int read = comport.ReadByte();
                    return read;      //returns -1 if end of stream has been read
                }
                catch
                {
                    return -1;
                }
            }
            
       }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Do_Work = true;
            bgWorkerRun = true;
            while (Do_Work)
            {
                if (bgWorkerRun)
                {
                    // int com_byte = get_comms();
                    if (!comport.IsOpen)
                    {
                        MessageBox.Show("comport not open");
                    }
                    else
                    {
                        //string line = comport.ReadLine();
                        if (comport.BytesToRead > 0)
                        {
                           // char ch = (char)comport.ReadChar();
                            string st = comport.ReadLine();
                            if (st.Length > 1)
                            {
                                try
                                {
                                    double dbl = Convert.ToDouble(st);

                                    rxQueue.Enqueue(dbl);

                                    backgroundWorker1.ReportProgress(1);
                                }
                                catch
                                {
                                    backgroundWorker1.ReportProgress(0);
                                }
                                //  }
                                //   else
                                //   {
                                // backgroundWorker1.ReportProgress(0);
                                //    }
                            }
                        }




                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            
           

            if (e.ProgressPercentage == 1)
            {

                while (rxQueue.Count != 0)
                {

                    if (x < 999)
                    {
                        y = rxQueue.Dequeue();
                        serise[(int)x++] = y;
                        //p[(int)x++] = new System.Windows.Forms.DataVisualization.Charting.DataPoint(x, y);
                       // pCol.Add(x++, y);
                    }
                    else
                    {
                        //x = 1000;
                        //y = rxQueue.Dequeue();
                        //serise[(int)x] = y;


                        chart1.Series["Series1"].Points.Clear();
                        for (int i = 0; i < 1000; i++)
                        {
                            chart1.Series["Series1"].Points.AddXY(i,serise[i]);
     
                        }
                        x = 0;
              
                    }



                   
       
                }
            }
            else
            {
                Application.DoEvents();
            }


            //    while (rxQueue.Count != 0)
            //    {
            //        y = rxQueue.Dequeue();
            //        string strout = y.ToString();
            //        //if (strout != "\n")
            //        //{
            //           // richTextBox1.AppendText(strout);
                        
            //            chart1.Series["Series1"].Points.AddXY(x++, y);
                       
            //            if (x >= chart1.ChartAreas[0].AxisX.Maximum) 
            //            { 
            //                x = 0;
            //                chart1.Series["Series1"].Points.Clear();
            //            }
            //        //}
            //        //if (richTextBox1.Lines.Count() >= 1000)
            //        //{
            //        //    richTextBox1.Clear();
            //        //}
            //    }
            //}
            //else
            //{

            //}
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            char[] key = new char[1]{e.KeyChar};
            comport.Write(key, 0, 1);
            
        }

        private void richTextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            comport.WriteLine("reboot");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void serverTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveEnvButton_Click(object sender, EventArgs e)
        {
            //string temp = string.Format("setenv serverip {0};setenv ipaddr {1};setenv gatewayip {2};setenv netmask {3};setenv ethaddr {4};saveenv;reset",
            //                            serverTextBox.Text,
            //                            IPtextBox.Text,
            //                            gatewayTextBox.Text,
            //                            netMaskTextBox.Text,
            //                            macTextBoxTemp.Text);

            string temp = string.Format("setenv serverip {0};setenv ipaddr {1};setenv gatewayip {2};setenv netmask {3};setenv ethaddr {4};saveenv",
                                        serverTextBox.Text,
                                        IPtextBox.Text,
                                        gatewayTextBox.Text,
                                        netMaskTextBox.Text,
                                        macTextBoxTemp.Text);
            
            comport.WriteLine(temp);
        }

        private void resetButton_Click_1(object sender, EventArgs e)
        {
            comport.WriteLine("reset");
            richTextBox1.Clear();
            Thread.Sleep(1000);
            comport.Write("\n");

        }

        private void uImageButton_Click(object sender, EventArgs e)
        {
            comport.WriteLine("tftpboot 0x80700000 uImage_ipnc_dm365_2.6.0");
        }

        private void cramfsButton_Click(object sender, EventArgs e)
        {
            comport.WriteLine("tftpboot 0x82000000 cramfsImage_ipnc_dm365_2.6.0");
        }

        private void NANDeraseButton_Click(object sender, EventArgs e)
        {
            comport.WriteLine("nand erase 0x200000 0x1000000");
        }

        private void nandWriteButton_Click(object sender, EventArgs e)
        {
            comport.WriteLine("nand write 0x80700000 0x200000 0x200000");
        }

        private void nandWriteButton2_Click(object sender, EventArgs e)
        {
            comport.WriteLine("nand write 0x82000000 0x400000 0xe00000");
        }

        private void saveBootEnv_Click(object sender, EventArgs e)
        {
            comport.WriteLine("setenv bootcmd 'nboot 0x80700000 0 0x200000;bootm 0x80700000';setenv bootargs 'mem=48M console=ttyS1,115200n8 root=/dev/mtdblock3 rootfstype=cramfs ip=dhcp eth=$(ethaddr)';");
            comport.WriteLine("saveenv");
           // comport.WriteLine("reset");
        }

        private void getMacButton_Click(object sender, EventArgs e)
        {
            getNewMac();

        }

        private void programMacButton_Click(object sender, EventArgs e)
        {
            updateDB();
           
            string progMacString = string.Format("setenv bootargs 'mem=48M console=ttyS1,115200n8 root=/dev/mtdblock3 rootfstype=cramfs ip=dhcp eth={0}'", 
                                                textBox_MAC.Text);
            comport.WriteLine(progMacString);
            comport.WriteLine("saveenv");

        }

        private void updateDB()
        {
            DataTable table = new DataTable();
            Int64 intMac = Convert.ToInt64(macUnFormatted, 16);

            if (dbConnect.OpenConnection() == true)
            {
                string sql = string.Format("UPDATE mac_table SET Allocated=true, STM32_UID = '{0}', use_devOrProduction = '{1}', Product_type = '{2}', Product_SN = '{3}', Date = (@value) WHERE MAC = {4}",
                                                                                    "DM368", comboBox_use.Text, comboBox_product.Text, textBox_SN.Text, intMac); // TagAdd);
                MySqlCommand command = new MySqlCommand(sql, dbConnect.connection);
                command.Parameters.AddWithValue("@value", DateTime.Now);
                command.ExecuteNonQuery();
                dbConnect.CloseConnection();

            }
            else // datbase connection not open
            {
                MessageBox.Show("Error , no database connection!");

            }

        }

        private void getNewMac()
        {

            //initialises new db connection
            string password = null;
            if (Properties.Settings.Default.Password == "")
            {
                password = null;

            }
            else
            {
                password = Properties.Settings.Default.Password;
            }
            dbConnect = new DBConnect(Properties.Settings.Default.Server, Properties.Settings.Default.Port, Properties.Settings.Default.Database, Properties.Settings.Default.UID, password); //initialises new db connection



            DataTable table = new DataTable();

            if (dbConnect.OpenConnection() == true)
            {
                string sql = string.Format("select * from mac_table where Allocated = '0' limit 1"); // TagAdd);
                MySqlCommand command = new MySqlCommand(sql, dbConnect.connection);

                MySqlDataReader dataReader = command.ExecuteReader();
                // table.Load(command.ExecuteReader(), LoadOption.OverwriteChanges);
                table.Load(dataReader, LoadOption.OverwriteChanges);
                dbConnect.CloseConnection();

                foreach (DataRow i in table.Rows)
                {
                    //string macAddr = (string)i.ItemArray[0];

                    var macAddr = i.ItemArray[0];
                    macUnFormatted = string.Format("{0:x}", macAddr).ToUpper();

                    string macFormatted = macUnFormatted;

                    for (int j = macUnFormatted.Length - 2; j > 0; j = j - 2)
                    {
                        macFormatted = macFormatted.Insert(j, ":");
                    }

                    textBox_MAC.Text = macFormatted;

                }

            }
            else // datbase connection not open
            {
                MessageBox.Show("Error , no database connection!");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


        private void ftdi_connect()
        {

            uint ftdiDeviceCount = 0;
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            // Create new instance of the FTDI device class
            FTDI myFtdiDevice = new FTDI();

            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                richTextBox2.Text = "start";
                richTextBox2.AppendText("Number of FTDI devices: " + ftdiDeviceCount.ToString());
                richTextBox2.AppendText("");
            }
            else
            {
                // Wait for a key press
                richTextBox2.AppendText("Failed to get number of devices (error " + ftStatus.ToString() + ")");
                //Console.ReadKey();
                return;
            }

            // If no devices available, return
            if (ftdiDeviceCount == 0)
            {
                // Wait for a key press
                richTextBox2.AppendText("Failed to get number of devices (error " + ftStatus.ToString() + ")");
               // Console.ReadKey();
                return;
            }

            // Allocate storage for device info list
            FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

            // Populate our device list
            ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                {
                    richTextBox2.AppendText("Device Index: " + i.ToString());
                    richTextBox2.AppendText("Flags: " + String.Format("{0:x}", ftdiDeviceList[i].Flags));
                    richTextBox2.AppendText("Type: " + ftdiDeviceList[i].Type.ToString());
                    richTextBox2.AppendText("ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID));
                    richTextBox2.AppendText("Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId));
                    richTextBox2.AppendText("Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString());
                    richTextBox2.AppendText("Description: " + ftdiDeviceList[i].Description.ToString());
                    richTextBox2.AppendText("");
                }
            }


            // Open first device in our list by serial number
            ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[0].SerialNumber);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                richTextBox2.AppendText("Failed to open device (error " + ftStatus.ToString() + ")");
               // Console.ReadKey();
                return;
            }

            // Set up device data parameters
            // Set Baud rate to 9600
            ftStatus = myFtdiDevice.SetBaudRate(115200);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                richTextBox2.AppendText("Failed to set Baud rate (error " + ftStatus.ToString() + ")");
               // Console.ReadKey();
                return;
            }

            // Set data characteristics - Data bits, Stop bits, Parity
            ftStatus = myFtdiDevice.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_1, FTDI.FT_PARITY.FT_PARITY_NONE);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                richTextBox2.AppendText("Failed to set data characteristics (error " + ftStatus.ToString() + ")");
               // Console.ReadKey();
                return;
            }

            // Set flow control - set RTS/CTS flow control
            ftStatus = myFtdiDevice.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0x11, 0x13);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                richTextBox2.AppendText("Failed to set flow control (error " + ftStatus.ToString() + ")");
               // Console.ReadKey();
                return;
            }

            // Set read timeout to 5 seconds, write timeout to infinite
            ftStatus = myFtdiDevice.SetTimeouts(5000, 0);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                richTextBox2.AppendText("Failed to set timeouts (error " + ftStatus.ToString() + ")");
                //Console.ReadKey();
                return;
            }

            while (cyclePort)
            {
                byte mode = 0;
                ftStatus = myFtdiDevice.GetPinStates(ref mode);
                Thread.Sleep(100);
            }


            //// Perform loop back - make sure loop back connector is fitted to the device
            //// Write string data to the device
            //string dataToWrite = "Hello world!";
            //UInt32 numBytesWritten = 0;
            //// Note that the Write method is overloaded, so can write string or byte array data
            //ftStatus = myFtdiDevice.Write(dataToWrite, dataToWrite.Length, ref numBytesWritten);
            //if (ftStatus != FTDI.FT_STATUS.FT_OK)
            //{
            //    // Wait for a key press
            //    richTextBox2.AppendText("Failed to write to device (error " + ftStatus.ToString() + ")");
            //    //Console.ReadKey();
            //    return;
            //}


            //// Check the amount of data available to read
            //// In this case we know how much data we are expecting, 
            //// so wait until we have all of the bytes we have sent.
            //UInt32 numBytesAvailable = 0;
            //do
            //{
            //    ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
            //    if (ftStatus != FTDI.FT_STATUS.FT_OK)
            //    {
            //        // Wait for a key press
            //        richTextBox2.AppendText("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")");
            //        //Console.ReadKey();
            //        return;
            //    }
            //    Thread.Sleep(10);
            //} while (numBytesAvailable < dataToWrite.Length);

            //// Now that we have the amount of data we want available, read it
            //string readData;
            //UInt32 numBytesRead = 0;
            //// Note that the Read method is overloaded, so can read string or byte array data
            //ftStatus = myFtdiDevice.Read(out readData, numBytesAvailable, ref numBytesRead);
            //if (ftStatus != FTDI.FT_STATUS.FT_OK)
            //{
            //    // Wait for a key press
            //    richTextBox2.AppendText("Failed to read data (error " + ftStatus.ToString() + ")");
            //    //Console.ReadKey();
            //    return;
            //}
            //richTextBox2.AppendText(readData);

            // Close our device
            ftStatus = myFtdiDevice.Close();

            // Wait for a key press
            richTextBox2.AppendText("Press any key to continue.");
            //Console.ReadKey();
            return;
        }

        private void cyclePortButton_Click(object sender, EventArgs e)
        {
            ftdi_connect();
        }

        private void readDB_Click(object sender, EventArgs e)
        {
            DBView dbView = new DBView();
            dbView.Show();
        }


 


    }
    public class record
    {
        double x;
        double y;
    }
}
