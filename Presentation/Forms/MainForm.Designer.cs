﻿namespace OnlyMyKeyClient.Presentation.Forms
{
    partial class MainForm
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btcEditPass = new Button();
            btnDeletePass = new Button();
            btnAddPass = new Button();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("TRY Clother", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(56, 5);
            label1.Name = "label1";
            label1.Size = new Size(162, 22);
            label1.TabIndex = 1;
            label1.Text = "RafaelChasmanj1223";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(6, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 62);
            panel2.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(713, 31);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Keys";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(57, 30);
            button1.Name = "button1";
            button1.Size = new Size(73, 24);
            button1.TabIndex = 2;
            button1.Text = "Logout";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btcEditPass);
            panel1.Controls.Add(btnDeletePass);
            panel1.Controls.Add(btnAddPass);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 400);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 50);
            panel1.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(218, 15);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 6;
            textBox3.Text = "Note";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(112, 15);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "Login";
            // 
            // btcEditPass
            // 
            btcEditPass.Location = new Point(405, 15);
            btcEditPass.Name = "btcEditPass";
            btcEditPass.Size = new Size(75, 23);
            btcEditPass.TabIndex = 2;
            btcEditPass.Text = "Edit";
            btcEditPass.UseVisualStyleBackColor = true;
            // 
            // btnDeletePass
            // 
            btnDeletePass.Location = new Point(486, 15);
            btnDeletePass.Name = "btnDeletePass";
            btnDeletePass.Size = new Size(75, 23);
            btnDeletePass.TabIndex = 1;
            btnDeletePass.Text = "Delete";
            btnDeletePass.UseVisualStyleBackColor = true;
            btnDeletePass.Visible = false;
            btnDeletePass.Click += btnDeletePass_Click;
            // 
            // btnAddPass
            // 
            btnAddPass.Location = new Point(324, 15);
            btnAddPass.Name = "btnAddPass";
            btnAddPass.Size = new Size(75, 23);
            btnAddPass.TabIndex = 0;
            btnAddPass.Text = "Add";
            btnAddPass.UseVisualStyleBackColor = true;
            btnAddPass.Click += btnAddPass_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 62);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 338);
            panel3.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MaximumSize = new Size(800, 338);
            dataGridView1.MinimumSize = new Size(800, 338);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(800, 338);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OMK - Password Manager";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        private Button btnDeletePass;
        private Button btnAddPass;
        private Panel panel3;
        private Button btcEditPass;
        private DataGridView dataGridView1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Button button2;
    }
}