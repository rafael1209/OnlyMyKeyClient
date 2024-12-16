namespace OnlyMyKeyClient.Presentation.Forms
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
            panel1 = new Panel();
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
            label1.Location = new Point(57, 30);
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
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 62);
            panel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btcEditPass);
            panel1.Controls.Add(btnDeletePass);
            panel1.Controls.Add(btnAddPass);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 400);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 50);
            panel1.TabIndex = 3;
            // 
            // btcEditPass
            // 
            btcEditPass.Location = new Point(551, 15);
            btcEditPass.Name = "btcEditPass";
            btcEditPass.Size = new Size(75, 23);
            btcEditPass.TabIndex = 2;
            btcEditPass.Text = "Edit";
            btcEditPass.UseVisualStyleBackColor = true;
            // 
            // btnDeletePass
            // 
            btnDeletePass.Location = new Point(632, 15);
            btnDeletePass.Name = "btnDeletePass";
            btnDeletePass.Size = new Size(75, 23);
            btnDeletePass.TabIndex = 1;
            btnDeletePass.Text = "Delete";
            btnDeletePass.UseVisualStyleBackColor = true;
            // 
            // btnAddPass
            // 
            btnAddPass.Location = new Point(713, 15);
            btnAddPass.Name = "btnAddPass";
            btnAddPass.Size = new Size(75, 23);
            btnAddPass.TabIndex = 0;
            btnAddPass.Text = "Add";
            btnAddPass.UseVisualStyleBackColor = true;
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
            dataGridView1.AllowUserToOrderColumns = true;
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
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridView1.Size = new Size(800, 338);
            dataGridView1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "MainForm";
            Text = "OMK - Password Manager";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
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
    }
}