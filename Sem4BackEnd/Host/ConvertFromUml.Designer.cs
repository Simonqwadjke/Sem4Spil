namespace Host {
    partial class ConvertFromUml {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.rtbInputProperties = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpProperties = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbOutputProperties = new System.Windows.Forms.RichTextBox();
            this.btnConvertProperties = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbInputProperties
            // 
            this.rtbInputProperties.Location = new System.Drawing.Point(6, 6);
            this.rtbInputProperties.Name = "rtbInputProperties";
            this.rtbInputProperties.Size = new System.Drawing.Size(304, 147);
            this.rtbInputProperties.TabIndex = 0;
            this.rtbInputProperties.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpProperties);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(324, 391);
            this.tabControl1.TabIndex = 2;
            // 
            // tpProperties
            // 
            this.tpProperties.BackColor = System.Drawing.SystemColors.Control;
            this.tpProperties.Controls.Add(this.btnConvertProperties);
            this.tpProperties.Controls.Add(this.rtbOutputProperties);
            this.tpProperties.Controls.Add(this.rtbInputProperties);
            this.tpProperties.Location = new System.Drawing.Point(4, 22);
            this.tpProperties.Name = "tpProperties";
            this.tpProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tpProperties.Size = new System.Drawing.Size(316, 365);
            this.tpProperties.TabIndex = 0;
            this.tpProperties.Text = "UML to properties";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbOutputProperties
            // 
            this.rtbOutputProperties.Location = new System.Drawing.Point(6, 159);
            this.rtbOutputProperties.Name = "rtbOutputProperties";
            this.rtbOutputProperties.Size = new System.Drawing.Size(304, 147);
            this.rtbOutputProperties.TabIndex = 1;
            this.rtbOutputProperties.Text = "";
            // 
            // btnConvertProperties
            // 
            this.btnConvertProperties.Location = new System.Drawing.Point(235, 336);
            this.btnConvertProperties.Name = "btnConvertProperties";
            this.btnConvertProperties.Size = new System.Drawing.Size(75, 23);
            this.btnConvertProperties.TabIndex = 2;
            this.btnConvertProperties.Text = "Convert";
            this.btnConvertProperties.UseVisualStyleBackColor = true;
            this.btnConvertProperties.Click += new System.EventHandler(this.btnConvertProperties_Click);
            // 
            // ConvertFromUml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 415);
            this.Controls.Add(this.tabControl1);
            this.Name = "ConvertFromUml";
            this.Text = "ConvertFromUml";
            this.tabControl1.ResumeLayout(false);
            this.tpProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInputProperties;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpProperties;
        private System.Windows.Forms.Button btnConvertProperties;
        private System.Windows.Forms.RichTextBox rtbOutputProperties;
        private System.Windows.Forms.TabPage tabPage2;
    }
}