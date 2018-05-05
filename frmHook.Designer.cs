﻿namespace JewLogger
{
    partial class frmHook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHook));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.incomingGridView = new System.Windows.Forms.DataGridView();
            this.outgoingGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.incomingGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outgoingGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Incoming";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(360, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Outgoing";
            // 
            // incomingGridView
            // 
            this.incomingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incomingGridView.Location = new System.Drawing.Point(15, 76);
            this.incomingGridView.Name = "incomingGridView";
            this.incomingGridView.Size = new System.Drawing.Size(342, 362);
            this.incomingGridView.TabIndex = 3;
            // 
            // outgoingGridView
            // 
            this.outgoingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outgoingGridView.Location = new System.Drawing.Point(363, 76);
            this.outgoingGridView.Name = "outgoingGridView";
            this.outgoingGridView.Size = new System.Drawing.Size(350, 362);
            this.outgoingGridView.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(575, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "Validate Registered Headers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmHook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.outgoingGridView);
            this.Controls.Add(this.incomingGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHook";
            this.Text = "JewLogger - Hooking";
            this.Load += new System.EventHandler(this.frmHook_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHook_Close);
            ((System.ComponentModel.ISupportInitialize)(this.incomingGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outgoingGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView incomingGridView;
        private System.Windows.Forms.DataGridView outgoingGridView;
        private System.Windows.Forms.Button button1;
    }
}