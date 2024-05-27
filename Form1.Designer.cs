namespace WinFormsCinema
{
    partial class Cinema
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
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            label5 = new Label();
            pictureBox4 = new PictureBox();
            label6 = new Label();
            button1 = new Button();
            listBox1 = new ListBox();
            label7 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightBlue;
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(54, 150);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(900, 600);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "План посадки";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(54, 81);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(276, 36);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 50);
            label1.Name = "label1";
            label1.Size = new Size(77, 28);
            label1.TabIndex = 2;
            label1.Text = "Фильм";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(390, 81);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(276, 36);
            comboBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(390, 50);
            label2.Name = "label2";
            label2.Size = new Size(66, 28);
            label2.TabIndex = 4;
            label2.Text = "Сеанс";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Lime;
            pictureBox1.Location = new Point(54, 766);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 29);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 766);
            label3.Name = "label3";
            label3.Size = new Size(234, 28);
            label3.TabIndex = 6;
            label3.Text = "Свободно (300 Рублей)";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Thistle;
            pictureBox2.Location = new Point(377, 770);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 29);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(413, 770);
            label4.Name = "label4";
            label4.Size = new Size(170, 28);
            label4.TabIndex = 8;
            label4.Text = "VIP (500 Рублей)";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Yellow;
            pictureBox3.Location = new Point(646, 770);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 29);
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(682, 771);
            label5.Name = "label5";
            label5.Size = new Size(97, 28);
            label5.TabIndex = 10;
            label5.Text = "Выбрано";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Red;
            pictureBox4.Location = new Point(841, 768);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 29);
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(877, 768);
            label6.Name = "label6";
            label6.Size = new Size(77, 28);
            label6.TabIndex = 12;
            label6.Text = "Занято";
            // 
            // button1
            // 
            button1.Location = new Point(749, 81);
            button1.Name = "button1";
            button1.Size = new Size(205, 36);
            button1.TabIndex = 13;
            button1.Text = "Применить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonSitting;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 28;
            listBox1.Items.AddRange(new object[] { "Выбранные места" });
            listBox1.Location = new Point(960, 150);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(277, 480);
            listBox1.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(960, 643);
            label7.Name = "label7";
            label7.Size = new Size(106, 28);
            label7.TabIndex = 15;
            label7.Text = "Ваше имя";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(960, 674);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 34);
            textBox1.TabIndex = 16;
            // 
            // button2
            // 
            button2.Location = new Point(960, 714);
            button2.Name = "button2";
            button2.Size = new Size(277, 36);
            button2.TabIndex = 17;
            button2.Text = "Забронировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonResult;
            // 
            // Cinema
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1278, 844);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(pictureBox4);
            Controls.Add(label5);
            Controls.Add(pictureBox3);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Name = "Cinema";
            Text = "Cinema";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public GroupBox groupBox1;
        private ComboBox comboBox1;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
        private PictureBox pictureBox2;
        private Label label4;
        private PictureBox pictureBox3;
        private Label label5;
        private PictureBox pictureBox4;
        private Label label6;
        private Button button1;
        private ListBox listBox1;
        private Label label7;
        private TextBox textBox1;
        private Button button2;
    }
}
