namespace OnlyMyKeyClient.Presentation.Forms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            btnAuth = new Button();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAuth
            // 
            btnAuth.BackColor = Color.White;
            btnAuth.Image = Properties.Resources.photo_2024_1dwad2_16_11_03_05;
            btnAuth.ImageAlign = ContentAlignment.MiddleRight;
            btnAuth.Location = new Point(32, 204);
            btnAuth.Name = "btnAuth";
            btnAuth.Size = new Size(231, 51);
            btnAuth.TabIndex = 1;
            btnAuth.Text = " Continue with Google";
            btnAuth.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAuth.UseVisualStyleBackColor = false;
            btnAuth.Click += btnAuth_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(294, 116);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("TRY Clother", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(59, 63);
            label2.Name = "label2";
            label2.Size = new Size(176, 27);
            label2.TabIndex = 1;
            label2.Text = "Password Manager";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("TRY Clother", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(60, 23);
            label1.Name = "label1";
            label1.Size = new Size(174, 40);
            label1.TabIndex = 0;
            label1.Text = "OnlyMyKey";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(32, 261);
            button1.Name = "button1";
            button1.Size = new Size(231, 51);
            button1.TabIndex = 3;
            button1.Text = " Continue with Facebook";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.Location = new Point(32, 318);
            button2.Name = "button2";
            button2.Size = new Size(231, 51);
            button2.TabIndex = 4;
            button2.Text = " Continue with Discord";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("TRY Clother", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.White;
            label3.Location = new Point(99, 148);
            label3.Name = "label3";
            label3.Size = new Size(96, 40);
            label3.TabIndex = 2;
            label3.Text = "Log in";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Backdrop;
            ClientSize = new Size(294, 411);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnAuth);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OMK - Passwords Manager";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAuth;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Label label3;
    }
}
