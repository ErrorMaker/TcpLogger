namespace JewLogger
{
    partial class frmSending
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSending));
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendToClient = new System.Windows.Forms.Button();
            this.btnSendToServer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(12, 35);
            this.txtSendData.Multiline = true;
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(411, 117);
            this.txtSendData.TabIndex = 5;
            this.txtSendData.Text = "BKTest alert";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data to send:";
            // 
            // btnSendToClient
            // 
            this.btnSendToClient.Location = new System.Drawing.Point(440, 35);
            this.btnSendToClient.Name = "btnSendToClient";
            this.btnSendToClient.Size = new System.Drawing.Size(115, 51);
            this.btnSendToClient.TabIndex = 6;
            this.btnSendToClient.Text = "To Client";
            this.btnSendToClient.UseVisualStyleBackColor = true;
            this.btnSendToClient.Click += new System.EventHandler(this.btnSendToClient_Click);
            // 
            // btnSendToServer
            // 
            this.btnSendToServer.Location = new System.Drawing.Point(440, 101);
            this.btnSendToServer.Name = "btnSendToServer";
            this.btnSendToServer.Size = new System.Drawing.Size(115, 51);
            this.btnSendToServer.TabIndex = 7;
            this.btnSendToServer.Text = "To Server";
            this.btnSendToServer.UseVisualStyleBackColor = true;
            this.btnSendToServer.Click += new System.EventHandler(this.btnSendToServer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(448, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Depending if you send to client or server, the program will automatically add the" +
    " (char)1 suffix, \r\nor if sent to server, the B64 length prefix will be added aut" +
    "omatically.";
            // 
            // frmSending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 207);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSendToServer);
            this.Controls.Add(this.btnSendToClient);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSending";
            this.Text = "JewLogger - Send Data";
            this.Load += new System.EventHandler(this.frmSending_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendToClient;
        private System.Windows.Forms.Button btnSendToServer;
        private System.Windows.Forms.Label label2;
    }
}