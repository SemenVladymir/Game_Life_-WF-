namespace Game_Life__WF_
{
    partial class Form1
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
            BtnStart = new Button();
            Field = new Panel();
            label1 = new Label();
            Delay = new TextBox();
            BtnStop = new Button();
            label2 = new Label();
            label3 = new Label();
            Generation = new Label();
            AutoFill = new CheckBox();
            label4 = new Label();
            Fill = new TextBox();
            label5 = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnStart
            // 
            BtnStart.BackColor = Color.Cyan;
            BtnStart.Location = new Point(936, 404);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(167, 41);
            BtnStart.TabIndex = 0;
            BtnStart.Text = "START";
            BtnStart.UseVisualStyleBackColor = false;
            BtnStart.Click += BtnStart_Click;
            // 
            // Field
            // 
            Field.Location = new Point(12, 12);
            Field.Name = "Field";
            Field.Size = new Size(900, 600);
            Field.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 45);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 2;
            label1.Text = "Delay";
            // 
            // Delay
            // 
            Delay.Location = new Point(59, 45);
            Delay.Name = "Delay";
            Delay.Size = new Size(64, 27);
            Delay.TabIndex = 3;
            Delay.KeyPress += Delay_KeyPress;
            // 
            // BtnStop
            // 
            BtnStop.BackColor = Color.FromArgb(255, 224, 192);
            BtnStop.Location = new Point(936, 512);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(167, 38);
            BtnStop.TabIndex = 4;
            BtnStop.Text = "PAUSE";
            BtnStop.UseVisualStyleBackColor = false;
            BtnStop.Click += BtnStop_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 48);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 5;
            label2.Text = "mS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(930, 40);
            label3.Name = "label3";
            label3.Size = new Size(109, 28);
            label3.TabIndex = 6;
            label3.Text = "Generation";
            // 
            // Generation
            // 
            Generation.AutoSize = true;
            Generation.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Generation.ForeColor = Color.Red;
            Generation.Location = new Point(1045, 40);
            Generation.Name = "Generation";
            Generation.Size = new Size(24, 28);
            Generation.TabIndex = 7;
            Generation.Text = "0";
            // 
            // AutoFill
            // 
            AutoFill.AutoSize = true;
            AutoFill.Location = new Point(13, 129);
            AutoFill.Name = "AutoFill";
            AutoFill.Size = new Size(88, 24);
            AutoFill.TabIndex = 9;
            AutoFill.Text = "Auto fill";
            AutoFill.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(103, 175);
            label4.Name = "label4";
            label4.Size = new Size(22, 20);
            label4.TabIndex = 12;
            label4.Text = "%";
            // 
            // Fill
            // 
            Fill.Location = new Point(47, 172);
            Fill.Name = "Fill";
            Fill.Size = new Size(50, 27);
            Fill.TabIndex = 11;
            Fill.KeyPress += Fill_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 175);
            label5.Name = "label5";
            label5.Size = new Size(29, 20);
            label5.TabIndex = 10;
            label5.Text = "Fill";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Khaki;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Delay);
            groupBox1.Controls.Add(Fill);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(AutoFill);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(930, 108);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(176, 240);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Setup";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(1122, 623);
            Controls.Add(groupBox1);
            Controls.Add(Generation);
            Controls.Add(label3);
            Controls.Add(BtnStop);
            Controls.Add(Field);
            Controls.Add(BtnStart);
            Name = "Form1";
            Text = "Game \"LIFE\"";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnStart;
        private Panel Field;
        private Label label1;
        private TextBox Delay;
        private Button BtnStop;
        private Label label2;
        private Label label3;
        private Label Generation;
        private CheckBox AutoFill;
        private Label label4;
        private TextBox Fill;
        private Label label5;
        private GroupBox groupBox1;
    }
}