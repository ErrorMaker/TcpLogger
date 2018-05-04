namespace JewLogger
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtLocalAddress = new System.Windows.Forms.TextBox();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIncomingData = new System.Windows.Forms.TextBox();
            this.btnStartListen = new System.Windows.Forms.Button();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.txtRemoteAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutgoingData = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkOutgoingAutoscroll = new System.Windows.Forms.CheckBox();
            this.chkIncomingAutoscroll = new System.Windows.Forms.CheckBox();
            this.chkDecodeEncryption = new System.Windows.Forms.CheckBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.btnStopListen = new System.Windows.Forms.Button();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b64VL64HelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txtLocalAddress
            // 
            this.txtLocalAddress.Location = new System.Drawing.Point(135, 35);
            this.txtLocalAddress.Name = "txtLocalAddress";
            this.txtLocalAddress.Size = new System.Drawing.Size(142, 20);
            this.txtLocalAddress.TabIndex = 1;
            this.txtLocalAddress.Text = "localhost";
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(316, 35);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(56, 20);
            this.txtLocalPort.TabIndex = 2;
            this.txtLocalPort.Text = "12321";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Incoming data:";
            // 
            // txtIncomingData
            // 
            this.txtIncomingData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIncomingData.Location = new System.Drawing.Point(12, 142);
            this.txtIncomingData.Multiline = true;
            this.txtIncomingData.Name = "txtIncomingData";
            this.txtIncomingData.Size = new System.Drawing.Size(383, 410);
            this.txtIncomingData.TabIndex = 10;
            // 
            // btnStartListen
            // 
            this.btnStartListen.Location = new System.Drawing.Point(404, 35);
            this.btnStartListen.Name = "btnStartListen";
            this.btnStartListen.Size = new System.Drawing.Size(138, 34);
            this.btnStartListen.TabIndex = 5;
            this.btnStartListen.Text = "Start Listening";
            this.btnStartListen.UseVisualStyleBackColor = true;
            this.btnStartListen.Click += new System.EventHandler(this.btnStartListen_Click);
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Location = new System.Drawing.Point(316, 64);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(56, 20);
            this.txtRemotePort.TabIndex = 4;
            this.txtRemotePort.Text = "1232";
            // 
            // txtRemoteAddress
            // 
            this.txtRemoteAddress.Location = new System.Drawing.Point(135, 64);
            this.txtRemoteAddress.Name = "txtRemoteAddress";
            this.txtRemoteAddress.Size = new System.Drawing.Size(142, 20);
            this.txtRemoteAddress.TabIndex = 3;
            this.txtRemoteAddress.Text = "localhost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Remote IP Address";
            // 
            // txtOutgoingData
            // 
            this.txtOutgoingData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutgoingData.Location = new System.Drawing.Point(405, 142);
            this.txtOutgoingData.Multiline = true;
            this.txtOutgoingData.Name = "txtOutgoingData";
            this.txtOutgoingData.Size = new System.Drawing.Size(383, 410);
            this.txtOutgoingData.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(401, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Outgoing data:";
            // 
            // chkOutgoingAutoscroll
            // 
            this.chkOutgoingAutoscroll.AutoSize = true;
            this.chkOutgoingAutoscroll.Checked = true;
            this.chkOutgoingAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutgoingAutoscroll.Location = new System.Drawing.Point(404, 558);
            this.chkOutgoingAutoscroll.Name = "chkOutgoingAutoscroll";
            this.chkOutgoingAutoscroll.Size = new System.Drawing.Size(75, 17);
            this.chkOutgoingAutoscroll.TabIndex = 9;
            this.chkOutgoingAutoscroll.Text = "Auto scroll";
            this.chkOutgoingAutoscroll.UseVisualStyleBackColor = true;
            // 
            // chkIncomingAutoscroll
            // 
            this.chkIncomingAutoscroll.AutoSize = true;
            this.chkIncomingAutoscroll.Checked = true;
            this.chkIncomingAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncomingAutoscroll.Location = new System.Drawing.Point(15, 558);
            this.chkIncomingAutoscroll.Name = "chkIncomingAutoscroll";
            this.chkIncomingAutoscroll.Size = new System.Drawing.Size(75, 17);
            this.chkIncomingAutoscroll.TabIndex = 7;
            this.chkIncomingAutoscroll.Text = "Auto scroll";
            this.chkIncomingAutoscroll.UseVisualStyleBackColor = true;
            // 
            // chkDecodeEncryption
            // 
            this.chkDecodeEncryption.AutoSize = true;
            this.chkDecodeEncryption.Checked = true;
            this.chkDecodeEncryption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDecodeEncryption.Location = new System.Drawing.Point(559, 75);
            this.chkDecodeEncryption.Name = "chkDecodeEncryption";
            this.chkDecodeEncryption.Size = new System.Drawing.Size(114, 17);
            this.chkDecodeEncryption.TabIndex = 8;
            this.chkDecodeEncryption.Text = "Decode encrypton";
            this.chkDecodeEncryption.UseVisualStyleBackColor = true;
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Checked = true;
            this.chkLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLog.Location = new System.Drawing.Point(559, 45);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(113, 17);
            this.chkLog.TabIndex = 15;
            this.chkLog.Text = "Log packets to file";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // btnStopListen
            // 
            this.btnStopListen.Location = new System.Drawing.Point(404, 75);
            this.btnStopListen.Name = "btnStopListen";
            this.btnStopListen.Size = new System.Drawing.Size(138, 30);
            this.btnStopListen.TabIndex = 16;
            this.btnStopListen.Text = "Stop Listening";
            this.btnStopListen.UseVisualStyleBackColor = true;
            this.btnStopListen.Click += new System.EventHandler(this.btnStopListen_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendDataToolStripMenuItem,
            this.b64VL64HelperToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // sendDataToolStripMenuItem
            // 
            this.sendDataToolStripMenuItem.Name = "sendDataToolStripMenuItem";
            this.sendDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendDataToolStripMenuItem.Text = "Send data";
            this.sendDataToolStripMenuItem.Click += new System.EventHandler(this.sendDataToolStripMenuItem_Click);
            // 
            // b64VL64HelperToolStripMenuItem
            // 
            this.b64VL64HelperToolStripMenuItem.Name = "b64VL64HelperToolStripMenuItem";
            this.b64VL64HelperToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.b64VL64HelperToolStripMenuItem.Text = "B64/VL64 Helper";
            this.b64VL64HelperToolStripMenuItem.Click += new System.EventHandler(this.b64VL64HelperToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.btnStopListen);
            this.Controls.Add(this.chkLog);
            this.Controls.Add(this.chkDecodeEncryption);
            this.Controls.Add(this.chkIncomingAutoscroll);
            this.Controls.Add(this.chkOutgoingAutoscroll);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOutgoingData);
            this.Controls.Add(this.txtRemotePort);
            this.Controls.Add(this.txtRemoteAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnStartListen);
            this.Controls.Add(this.txtIncomingData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.txtLocalAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "JewLogger - A MITM Packetlogger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox txtLocalAddress;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtIncomingData;
        public System.Windows.Forms.TextBox txtOutgoingData;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.TextBox txtRemoteAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox chkOutgoingAutoscroll;
        public System.Windows.Forms.CheckBox chkIncomingAutoscroll;
        public System.Windows.Forms.CheckBox chkDecodeEncryption;
        public System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.Button btnStopListen;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b64VL64HelperToolStripMenuItem;
    }
}

