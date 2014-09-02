namespace STM32scope
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.StartButton = new System.Windows.Forms.Button();
            this.rebootButton = new System.Windows.Forms.Button();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gatewayTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.netMaskTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.macTextBoxTemp = new System.Windows.Forms.TextBox();
            this.saveEnvButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.uImageButton = new System.Windows.Forms.Button();
            this.cramfsButton = new System.Windows.Forms.Button();
            this.NANDeraseButton = new System.Windows.Forms.Button();
            this.nandWriteButton = new System.Windows.Forms.Button();
            this.nandWriteButton2 = new System.Windows.Forms.Button();
            this.saveBootEnv = new System.Windows.Forms.Button();
            this.programMacButton = new System.Windows.Forms.Button();
            this.getMacButton = new System.Windows.Forms.Button();
            this.textBox_MAC = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_product = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_SN = new System.Windows.Forms.TextBox();
            this.comboBox_use = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape10 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape9 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape8 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape7 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.DiscinnectButton = new System.Windows.Forms.Button();
            this.cyclePortButton = new System.Windows.Forms.Button();
            this.readDB = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 39);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(617, 337);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            this.richTextBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.richTextBox1_PreviewKeyDown);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(127, 10);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Connect";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // rebootButton
            // 
            this.rebootButton.Location = new System.Drawing.Point(1075, 634);
            this.rebootButton.Name = "rebootButton";
            this.rebootButton.Size = new System.Drawing.Size(75, 23);
            this.rebootButton.TabIndex = 3;
            this.rebootButton.Text = "ReBoot";
            this.rebootButton.UseVisualStyleBackColor = true;
            this.rebootButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(903, 90);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(100, 20);
            this.serverTextBox.TabIndex = 4;
            this.serverTextBox.Text = "10.1.0.137";
            this.serverTextBox.TextChanged += new System.EventHandler(this.serverTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1005, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TFTP Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1005, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Camera IP (Temporary)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // IPtextBox
            // 
            this.IPtextBox.Location = new System.Drawing.Point(903, 116);
            this.IPtextBox.Name = "IPtextBox";
            this.IPtextBox.Size = new System.Drawing.Size(100, 20);
            this.IPtextBox.TabIndex = 6;
            this.IPtextBox.Text = "10.1.0.38";
            this.IPtextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1005, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Camera gateway (Temporary)";
            // 
            // gatewayTextBox
            // 
            this.gatewayTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.gatewayTextBox.Location = new System.Drawing.Point(903, 139);
            this.gatewayTextBox.Name = "gatewayTextBox";
            this.gatewayTextBox.Size = new System.Drawing.Size(100, 20);
            this.gatewayTextBox.TabIndex = 8;
            this.gatewayTextBox.Text = "10.0.0.2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1005, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Camera netmask (Temporary)";
            // 
            // netMaskTextBox
            // 
            this.netMaskTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.netMaskTextBox.Location = new System.Drawing.Point(903, 164);
            this.netMaskTextBox.Name = "netMaskTextBox";
            this.netMaskTextBox.Size = new System.Drawing.Size(100, 20);
            this.netMaskTextBox.TabIndex = 10;
            this.netMaskTextBox.Text = "255.0.0.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1005, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Camera MAC (Temporary)";
            // 
            // macTextBoxTemp
            // 
            this.macTextBoxTemp.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.macTextBoxTemp.Location = new System.Drawing.Point(903, 193);
            this.macTextBoxTemp.Name = "macTextBoxTemp";
            this.macTextBoxTemp.Size = new System.Drawing.Size(100, 20);
            this.macTextBoxTemp.TabIndex = 12;
            this.macTextBoxTemp.Text = "00:01:02:03:04:05";
            // 
            // saveEnvButton
            // 
            this.saveEnvButton.Location = new System.Drawing.Point(734, 190);
            this.saveEnvButton.Name = "saveEnvButton";
            this.saveEnvButton.Size = new System.Drawing.Size(116, 23);
            this.saveEnvButton.TabIndex = 14;
            this.saveEnvButton.Text = "SaveEnv";
            this.saveEnvButton.UseVisualStyleBackColor = true;
            this.saveEnvButton.Click += new System.EventHandler(this.saveEnvButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(734, 221);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(116, 23);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click_1);
            // 
            // uImageButton
            // 
            this.uImageButton.Location = new System.Drawing.Point(734, 255);
            this.uImageButton.Name = "uImageButton";
            this.uImageButton.Size = new System.Drawing.Size(116, 23);
            this.uImageButton.TabIndex = 16;
            this.uImageButton.Text = "TFTP uImage";
            this.uImageButton.UseVisualStyleBackColor = true;
            this.uImageButton.Click += new System.EventHandler(this.uImageButton_Click);
            // 
            // cramfsButton
            // 
            this.cramfsButton.Location = new System.Drawing.Point(734, 284);
            this.cramfsButton.Name = "cramfsButton";
            this.cramfsButton.Size = new System.Drawing.Size(116, 23);
            this.cramfsButton.TabIndex = 17;
            this.cramfsButton.Text = "TFTP cramfsImage";
            this.cramfsButton.UseVisualStyleBackColor = true;
            this.cramfsButton.Click += new System.EventHandler(this.cramfsButton_Click);
            // 
            // NANDeraseButton
            // 
            this.NANDeraseButton.Location = new System.Drawing.Point(734, 317);
            this.NANDeraseButton.Name = "NANDeraseButton";
            this.NANDeraseButton.Size = new System.Drawing.Size(116, 23);
            this.NANDeraseButton.TabIndex = 18;
            this.NANDeraseButton.Text = "NAND erase";
            this.NANDeraseButton.UseVisualStyleBackColor = true;
            this.NANDeraseButton.Click += new System.EventHandler(this.NANDeraseButton_Click);
            // 
            // nandWriteButton
            // 
            this.nandWriteButton.Location = new System.Drawing.Point(734, 350);
            this.nandWriteButton.Name = "nandWriteButton";
            this.nandWriteButton.Size = new System.Drawing.Size(116, 23);
            this.nandWriteButton.TabIndex = 19;
            this.nandWriteButton.Text = "nand Write 1";
            this.nandWriteButton.UseVisualStyleBackColor = true;
            this.nandWriteButton.Click += new System.EventHandler(this.nandWriteButton_Click);
            // 
            // nandWriteButton2
            // 
            this.nandWriteButton2.Location = new System.Drawing.Point(734, 379);
            this.nandWriteButton2.Name = "nandWriteButton2";
            this.nandWriteButton2.Size = new System.Drawing.Size(116, 23);
            this.nandWriteButton2.TabIndex = 20;
            this.nandWriteButton2.Text = "nand Write 2";
            this.nandWriteButton2.UseVisualStyleBackColor = true;
            this.nandWriteButton2.Click += new System.EventHandler(this.nandWriteButton2_Click);
            // 
            // saveBootEnv
            // 
            this.saveBootEnv.Location = new System.Drawing.Point(734, 408);
            this.saveBootEnv.Name = "saveBootEnv";
            this.saveBootEnv.Size = new System.Drawing.Size(116, 23);
            this.saveBootEnv.TabIndex = 21;
            this.saveBootEnv.Text = "save Boot Env";
            this.saveBootEnv.UseVisualStyleBackColor = true;
            this.saveBootEnv.Click += new System.EventHandler(this.saveBootEnv_Click);
            // 
            // programMacButton
            // 
            this.programMacButton.Location = new System.Drawing.Point(731, 568);
            this.programMacButton.Name = "programMacButton";
            this.programMacButton.Size = new System.Drawing.Size(156, 23);
            this.programMacButton.TabIndex = 22;
            this.programMacButton.Text = "Program New Mac";
            this.programMacButton.UseVisualStyleBackColor = true;
            this.programMacButton.Click += new System.EventHandler(this.programMacButton_Click);
            // 
            // getMacButton
            // 
            this.getMacButton.Location = new System.Drawing.Point(734, 442);
            this.getMacButton.Name = "getMacButton";
            this.getMacButton.Size = new System.Drawing.Size(116, 23);
            this.getMacButton.TabIndex = 23;
            this.getMacButton.Text = "Get New Mac";
            this.getMacButton.UseVisualStyleBackColor = true;
            this.getMacButton.Click += new System.EventHandler(this.getMacButton_Click);
            // 
            // textBox_MAC
            // 
            this.textBox_MAC.Location = new System.Drawing.Point(734, 471);
            this.textBox_MAC.Name = "textBox_MAC";
            this.textBox_MAC.Size = new System.Drawing.Size(116, 20);
            this.textBox_MAC.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(868, 514);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Product";
            // 
            // comboBox_product
            // 
            this.comboBox_product.FormattingEnabled = true;
            this.comboBox_product.Items.AddRange(new object[] {
            "WiPAN Coord",
            "Flex Display",
            "NC5"});
            this.comboBox_product.Location = new System.Drawing.Point(840, 530);
            this.comboBox_product.Name = "comboBox_product";
            this.comboBox_product.Size = new System.Drawing.Size(121, 21);
            this.comboBox_product.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(979, 514);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Serial Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(765, 514);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Use";
            // 
            // textBox_SN
            // 
            this.textBox_SN.Location = new System.Drawing.Point(967, 531);
            this.textBox_SN.Name = "textBox_SN";
            this.textBox_SN.Size = new System.Drawing.Size(100, 20);
            this.textBox_SN.TabIndex = 38;
            // 
            // comboBox_use
            // 
            this.comboBox_use.FormattingEnabled = true;
            this.comboBox_use.Items.AddRange(new object[] {
            "Production",
            "Development"});
            this.comboBox_use.Location = new System.Drawing.Point(734, 530);
            this.comboBox_use.Name = "comboBox_use";
            this.comboBox_use.Size = new System.Drawing.Size(100, 21);
            this.comboBox_use.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(637, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(337, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "1. Camera Should be have UBOOT loaded via Code Composer Studio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(637, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "2. Load TFTPd application";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(637, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(281, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "3. Power up board with COM cable fitted and interupt boot";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape10,
            this.lineShape9,
            this.lineShape8,
            this.lineShape7,
            this.lineShape6,
            this.lineShape5,
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1162, 669);
            this.shapeContainer1.TabIndex = 45;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape10
            // 
            this.lineShape10.Name = "lineShape10";
            this.lineShape10.X1 = 650;
            this.lineShape10.X2 = 1136;
            this.lineShape10.Y1 = 495;
            this.lineShape10.Y2 = 494;
            // 
            // lineShape9
            // 
            this.lineShape9.Name = "lineShape9";
            this.lineShape9.X1 = 648;
            this.lineShape9.X2 = 1134;
            this.lineShape9.Y1 = 436;
            this.lineShape9.Y2 = 435;
            // 
            // lineShape8
            // 
            this.lineShape8.Name = "lineShape8";
            this.lineShape8.X1 = 649;
            this.lineShape8.X2 = 1135;
            this.lineShape8.Y1 = 406;
            this.lineShape8.Y2 = 405;
            // 
            // lineShape7
            // 
            this.lineShape7.Name = "lineShape7";
            this.lineShape7.X1 = 648;
            this.lineShape7.X2 = 1134;
            this.lineShape7.Y1 = 375;
            this.lineShape7.Y2 = 374;
            // 
            // lineShape6
            // 
            this.lineShape6.Name = "lineShape6";
            this.lineShape6.X1 = 646;
            this.lineShape6.X2 = 1132;
            this.lineShape6.Y1 = 344;
            this.lineShape6.Y2 = 343;
            // 
            // lineShape5
            // 
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 645;
            this.lineShape5.X2 = 1131;
            this.lineShape5.Y1 = 311;
            this.lineShape5.Y2 = 310;
            // 
            // lineShape4
            // 
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 643;
            this.lineShape4.X2 = 1129;
            this.lineShape4.Y1 = 280;
            this.lineShape4.Y2 = 279;
            // 
            // lineShape3
            // 
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 643;
            this.lineShape3.X2 = 1129;
            this.lineShape3.Y1 = 251;
            this.lineShape3.Y2 = 250;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 642;
            this.lineShape2.X2 = 1128;
            this.lineShape2.Y1 = 218;
            this.lineShape2.Y2 = 217;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 633;
            this.lineShape1.X2 = 1119;
            this.lineShape1.Y1 = 61;
            this.lineShape1.Y2 = 60;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(637, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(366, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "4. Enter TFTP server address & Camera IP in same range then click SaveEnv";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(646, 226);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "5. ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(646, 260);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "6.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(646, 289);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 13);
            this.label15.TabIndex = 49;
            this.label15.Text = "7.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(646, 322);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "8.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(646, 355);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 13);
            this.label17.TabIndex = 51;
            this.label17.Text = "9.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(645, 384);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 13);
            this.label18.TabIndex = 52;
            this.label18.Text = "10.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(646, 413);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 13);
            this.label19.TabIndex = 53;
            this.label19.Text = "11.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(646, 442);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 13);
            this.label20.TabIndex = 54;
            this.label20.Text = "12.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(646, 501);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(148, 13);
            this.label21.TabIndex = 55;
            this.label21.Text = "13. Enter details for DataBase";
            // 
            // DiscinnectButton
            // 
            this.DiscinnectButton.Location = new System.Drawing.Point(208, 11);
            this.DiscinnectButton.Name = "DiscinnectButton";
            this.DiscinnectButton.Size = new System.Drawing.Size(75, 23);
            this.DiscinnectButton.TabIndex = 56;
            this.DiscinnectButton.Text = "Disconnect";
            this.DiscinnectButton.UseVisualStyleBackColor = true;
            this.DiscinnectButton.Click += new System.EventHandler(this.DiscinnectButton_Click);
            // 
            // cyclePortButton
            // 
            this.cyclePortButton.Location = new System.Drawing.Point(289, 10);
            this.cyclePortButton.Name = "cyclePortButton";
            this.cyclePortButton.Size = new System.Drawing.Size(75, 23);
            this.cyclePortButton.TabIndex = 58;
            this.cyclePortButton.Text = "CyclePort";
            this.cyclePortButton.UseVisualStyleBackColor = true;
            this.cyclePortButton.Click += new System.EventHandler(this.cyclePortButton_Click);
            // 
            // readDB
            // 
            this.readDB.Location = new System.Drawing.Point(371, 11);
            this.readDB.Name = "readDB";
            this.readDB.Size = new System.Drawing.Size(112, 23);
            this.readDB.TabIndex = 59;
            this.readDB.Text = "Read Data Base";
            this.readDB.UseVisualStyleBackColor = true;
            this.readDB.Click += new System.EventHandler(this.readDB_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(3, 382);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(36, 20);
            this.richTextBox2.TabIndex = 57;
            this.richTextBox2.Text = "";
            // 
            // chart1
            // 
            chartArea1.AxisX.Maximum = 30D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(45, 139);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(867, 518);
            this.chart1.TabIndex = 60;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 669);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.readDB);
            this.Controls.Add(this.cyclePortButton);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.DiscinnectButton);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox_product);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_SN);
            this.Controls.Add(this.comboBox_use);
            this.Controls.Add(this.textBox_MAC);
            this.Controls.Add(this.getMacButton);
            this.Controls.Add(this.programMacButton);
            this.Controls.Add(this.saveBootEnv);
            this.Controls.Add(this.nandWriteButton2);
            this.Controls.Add(this.nandWriteButton);
            this.Controls.Add(this.NANDeraseButton);
            this.Controls.Add(this.cramfsButton);
            this.Controls.Add(this.uImageButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveEnvButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.macTextBoxTemp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.netMaskTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gatewayTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IPtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.rebootButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button rebootButton;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPtextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox gatewayTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox netMaskTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox macTextBoxTemp;
        private System.Windows.Forms.Button saveEnvButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button uImageButton;
        private System.Windows.Forms.Button cramfsButton;
        private System.Windows.Forms.Button NANDeraseButton;
        private System.Windows.Forms.Button nandWriteButton;
        private System.Windows.Forms.Button nandWriteButton2;
        private System.Windows.Forms.Button saveBootEnv;
        private System.Windows.Forms.Button programMacButton;
        private System.Windows.Forms.Button getMacButton;
        private System.Windows.Forms.TextBox textBox_MAC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_product;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_SN;
        private System.Windows.Forms.ComboBox comboBox_use;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label12;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape10;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape9;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape8;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape7;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button DiscinnectButton;
        private System.Windows.Forms.Button cyclePortButton;
        private System.Windows.Forms.Button readDB;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

