namespace JewLogger
{
    partial class frmEncoder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEncoder));
            this.label1 = new System.Windows.Forms.Label();
            this.txtToB64 = new System.Windows.Forms.TextBox();
            this.txtFromB64 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromVL64 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToVL64 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFromB64 = new System.Windows.Forms.Button();
            this.btnToB64 = new System.Windows.Forms.Button();
            this.btnToVL64 = new System.Windows.Forms.Button();
            this.btnFromVL64 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To B64:";
            // 
            // txtToB64
            // 
            this.txtToB64.Location = new System.Drawing.Point(63, 17);
            this.txtToB64.Name = "txtToB64";
            this.txtToB64.Size = new System.Drawing.Size(100, 20);
            this.txtToB64.TabIndex = 1;
            this.txtToB64.Text = "1";
            // 
            // txtFromB64
            // 
            this.txtFromB64.Location = new System.Drawing.Point(247, 17);
            this.txtFromB64.Name = "txtFromB64";
            this.txtFromB64.Size = new System.Drawing.Size(100, 20);
            this.txtFromB64.TabIndex = 3;
            this.txtFromB64.Text = "@A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From B64:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtFromVL64
            // 
            this.txtFromVL64.Location = new System.Drawing.Point(247, 94);
            this.txtFromVL64.Name = "txtFromVL64";
            this.txtFromVL64.Size = new System.Drawing.Size(100, 20);
            this.txtFromVL64.TabIndex = 7;
            this.txtFromVL64.Text = "YNE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "From VL64:";
            // 
            // txtToVL64
            // 
            this.txtToVL64.Location = new System.Drawing.Point(63, 94);
            this.txtToVL64.Name = "txtToVL64";
            this.txtToVL64.Size = new System.Drawing.Size(100, 20);
            this.txtToVL64.TabIndex = 5;
            this.txtToVL64.Text = "1337";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "To VL64:";
            // 
            // btnFromB64
            // 
            this.btnFromB64.Location = new System.Drawing.Point(189, 55);
            this.btnFromB64.Name = "btnFromB64";
            this.btnFromB64.Size = new System.Drawing.Size(158, 23);
            this.btnFromB64.TabIndex = 8;
            this.btnFromB64.Text = "Convert from B64";
            this.btnFromB64.UseVisualStyleBackColor = true;
            this.btnFromB64.Click += new System.EventHandler(this.btnFromB64_Click);
            // 
            // btnToB64
            // 
            this.btnToB64.Location = new System.Drawing.Point(15, 55);
            this.btnToB64.Name = "btnToB64";
            this.btnToB64.Size = new System.Drawing.Size(148, 23);
            this.btnToB64.TabIndex = 9;
            this.btnToB64.Text = "Convert to B64";
            this.btnToB64.UseVisualStyleBackColor = true;
            this.btnToB64.Click += new System.EventHandler(this.btnToB64_Click);
            // 
            // btnToVL64
            // 
            this.btnToVL64.Location = new System.Drawing.Point(15, 131);
            this.btnToVL64.Name = "btnToVL64";
            this.btnToVL64.Size = new System.Drawing.Size(148, 23);
            this.btnToVL64.TabIndex = 11;
            this.btnToVL64.Text = "Convert to VL64";
            this.btnToVL64.UseVisualStyleBackColor = true;
            this.btnToVL64.Click += new System.EventHandler(this.btnToVL64_Click);
            // 
            // btnFromVL64
            // 
            this.btnFromVL64.Location = new System.Drawing.Point(189, 131);
            this.btnFromVL64.Name = "btnFromVL64";
            this.btnFromVL64.Size = new System.Drawing.Size(158, 23);
            this.btnFromVL64.TabIndex = 10;
            this.btnFromVL64.Text = "Convert from VL64";
            this.btnFromVL64.UseVisualStyleBackColor = true;
            this.btnFromVL64.Click += new System.EventHandler(this.btnFromVL64_Click);
            // 
            // frmEncoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 175);
            this.Controls.Add(this.btnToVL64);
            this.Controls.Add(this.btnFromVL64);
            this.Controls.Add(this.btnToB64);
            this.Controls.Add(this.btnFromB64);
            this.Controls.Add(this.txtFromVL64);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtToVL64);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFromB64);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToB64);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEncoder";
            this.Text = "JewLogger - B64/VL64 Encoder";
            this.Load += new System.EventHandler(this.frmEncoder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToB64;
        private System.Windows.Forms.TextBox txtFromB64;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFromVL64;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtToVL64;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFromB64;
        private System.Windows.Forms.Button btnToB64;
        private System.Windows.Forms.Button btnToVL64;
        private System.Windows.Forms.Button btnFromVL64;
    }
}