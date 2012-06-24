namespace GoldParser
{
    partial class ProtectorForm
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
            this.HashKeyTextBox = new System.Windows.Forms.RichTextBox();
            this.CheckHashTextBox = new System.Windows.Forms.RichTextBox();
            this.CheckKeyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // HashKeyTextBox
            // 
            this.HashKeyTextBox.Location = new System.Drawing.Point(3, 3);
            this.HashKeyTextBox.Name = "HashKeyTextBox";
            this.HashKeyTextBox.ReadOnly = true;
            this.HashKeyTextBox.Size = new System.Drawing.Size(269, 24);
            this.HashKeyTextBox.TabIndex = 0;
            this.HashKeyTextBox.Text = "";
            // 
            // CheckHashTextBox
            // 
            this.CheckHashTextBox.Location = new System.Drawing.Point(3, 85);
            this.CheckHashTextBox.Name = "CheckHashTextBox";
            this.CheckHashTextBox.Size = new System.Drawing.Size(269, 24);
            this.CheckHashTextBox.TabIndex = 2;
            this.CheckHashTextBox.Text = "";
            // 
            // CheckKeyButton
            // 
            this.CheckKeyButton.Location = new System.Drawing.Point(3, 115);
            this.CheckKeyButton.Name = "CheckKeyButton";
            this.CheckKeyButton.Size = new System.Drawing.Size(75, 23);
            this.CheckKeyButton.TabIndex = 3;
            this.CheckKeyButton.Text = "Check";
            this.CheckKeyButton.UseVisualStyleBackColor = true;
            this.CheckKeyButton.Click += new System.EventHandler(this.CheckKeyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "skype: ololasek64";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "English",
            "Русский"});
            this.comboBox1.Location = new System.Drawing.Point(13, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ProtectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 142);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckKeyButton);
            this.Controls.Add(this.CheckHashTextBox);
            this.Controls.Add(this.HashKeyTextBox);
            this.Name = "ProtectorForm";
            this.Text = "ProtectorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProtectorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox HashKeyTextBox;
        private System.Windows.Forms.RichTextBox CheckHashTextBox;
        private System.Windows.Forms.Button CheckKeyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}