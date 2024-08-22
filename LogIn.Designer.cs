namespace StartSmartDelivery
{
    partial class LogIn
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
            this.lable1 = new System.Windows.Forms.Label();
            this.UsernameIn = new System.Windows.Forms.TextBox();
            this.PasswordIn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.Location = new System.Drawing.Point(95, 67);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(124, 29);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "Username";
            this.lable1.Click += new System.EventHandler(this.Lable1_Click);
            // 
            // UsernameIn
            // 
            this.UsernameIn.Location = new System.Drawing.Point(276, 71);
            this.UsernameIn.Name = "UsernameIn";
            this.UsernameIn.Size = new System.Drawing.Size(233, 26);
            this.UsernameIn.TabIndex = 1;
            this.UsernameIn.TextChanged += new System.EventHandler(this.UsernameIn_TextChanged);
            // 
            // PasswordIn
            // 
            this.PasswordIn.Location = new System.Drawing.Point(276, 155);
            this.PasswordIn.Name = "PasswordIn";
            this.PasswordIn.Size = new System.Drawing.Size(233, 26);
            this.PasswordIn.TabIndex = 3;
            this.PasswordIn.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(95, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(164, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 60);
            this.button1.TabIndex = 4;
            this.button1.Text = "Log In";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 327);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PasswordIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsernameIn);
            this.Controls.Add(this.lable1);
            this.MinimumSize = new System.Drawing.Size(670, 383);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.TextBox UsernameIn;
        private System.Windows.Forms.TextBox PasswordIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}