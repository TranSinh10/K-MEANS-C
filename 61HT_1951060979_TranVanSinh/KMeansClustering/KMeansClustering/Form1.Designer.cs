namespace KMeansClustering
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
            clusterButton = new Button();
            dataGridView1 = new DataGridView();
            numClustersTextBox = new TextBox();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            label1 = new Label();
            label2 = new Label();
            btnExit = new Button();
            checkedListBox1 = new CheckedListBox();
            btnOpen = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            comboBox2 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            plotView2 = new OxyPlot.WindowsForms.PlotView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // clusterButton
            // 
            clusterButton.BackColor = Color.FromArgb(255, 128, 128);
            clusterButton.Location = new Point(18, 212);
            clusterButton.Margin = new Padding(5, 4, 5, 4);
            clusterButton.Name = "clusterButton";
            clusterButton.Size = new Size(117, 38);
            clusterButton.TabIndex = 1;
            clusterButton.Text = "Phân cụm";
            clusterButton.UseVisualStyleBackColor = false;
            clusterButton.Click += clusterButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(150, 85);
            dataGridView1.Margin = new Padding(5, 4, 5, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1088, 298);
            dataGridView1.TabIndex = 3;
            // 
            // numClustersTextBox
            // 
            numClustersTextBox.Location = new Point(18, 296);
            numClustersTextBox.Margin = new Padding(5, 4, 5, 4);
            numClustersTextBox.Name = "numClustersTextBox";
            numClustersTextBox.Size = new Size(120, 33);
            numClustersTextBox.TabIndex = 4;
            numClustersTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // plotView1
            // 
            plotView1.BackColor = Color.White;
            plotView1.Location = new Point(565, 435);
            plotView1.Margin = new Padding(5, 4, 5, 4);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(675, 307);
            plotView1.TabIndex = 5;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(18, 257);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(20, 21);
            label1.TabIndex = 6;
            label1.Text = "K";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(754, 388);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(173, 25);
            label2.TabIndex = 7;
            label2.Text = "Kết quả phân cụm";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(255, 128, 128);
            btnExit.Location = new Point(18, 346);
            btnExit.Margin = new Padding(5, 4, 5, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 38);
            btnExit.TabIndex = 8;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(150, 435);
            checkedListBox1.Margin = new Padding(5, 4, 5, 4);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(350, 256);
            checkedListBox1.TabIndex = 9;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // btnOpen
            // 
            btnOpen.BackColor = Color.FromArgb(255, 128, 128);
            btnOpen.Location = new Point(150, 21);
            btnOpen.Margin = new Padding(5, 4, 5, 4);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(117, 38);
            btnOpen.TabIndex = 10;
            btnOpen.Text = "Mở file";
            btnOpen.UseVisualStyleBackColor = false;
            btnOpen.Click += btnOpen_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(314, 21);
            textBox1.Margin = new Padding(5, 4, 5, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(432, 33);
            textBox1.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(462, 747);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(428, 30);
            label3.TabIndex = 12;
            label3.Text = "Mô tả dữ liệu theo từng cụm từng trường";
            label3.Click += label3_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(156, 786);
            comboBox1.Margin = new Padding(2, 3, 2, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(344, 33);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(625, 786);
            textBox2.Margin = new Padding(2, 3, 2, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(121, 33);
            textBox2.TabIndex = 14;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(156, 843);
            comboBox2.Margin = new Padding(2, 3, 2, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(344, 33);
            comboBox2.TabIndex = 15;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 788);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(119, 25);
            label4.TabIndex = 16;
            label4.Text = "Chọn trường";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 846);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(98, 25);
            label5.TabIndex = 17;
            label5.Text = "Chọn cụm";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 128);
            button1.Location = new Point(408, 903);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(92, 33);
            button1.TabIndex = 18;
            button1.Text = "Tính";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(625, 845);
            textBox3.Margin = new Padding(4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(121, 33);
            textBox3.TabIndex = 19;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(863, 846);
            textBox4.Margin = new Padding(4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(121, 33);
            textBox4.TabIndex = 20;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1116, 846);
            textBox5.Margin = new Padding(4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(121, 33);
            textBox5.TabIndex = 21;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(1117, 785);
            textBox6.Margin = new Padding(4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(121, 33);
            textBox6.TabIndex = 22;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(863, 785);
            textBox7.Margin = new Padding(4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(121, 33);
            textBox7.TabIndex = 23;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(625, 904);
            textBox8.Margin = new Padding(4);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(230, 33);
            textBox8.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(544, 792);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(60, 25);
            label6.TabIndex = 25;
            label6.Text = "Mean";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(544, 846);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(76, 25);
            label7.TabIndex = 26;
            label7.Text = "Median";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(528, 907);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(88, 25);
            label8.TabIndex = 27;
            label8.Text = "Quartiles";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(794, 792);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(61, 25);
            label9.TabIndex = 28;
            label9.Text = "Mode";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(761, 848);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(94, 25);
            label10.TabIndex = 29;
            label10.Text = "Midrange";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1049, 789);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(42, 25);
            label11.TabIndex = 30;
            label11.Text = "IQR";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1010, 853);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(83, 25);
            label12.TabIndex = 31;
            label12.Text = "variance";
            // 
            // plotView2
            // 
            plotView2.BackColor = Color.White;
            plotView2.Location = new Point(1276, 435);
            plotView2.Name = "plotView2";
            plotView2.PanCursor = Cursors.Hand;
            plotView2.Size = new Size(548, 307);
            plotView2.TabIndex = 32;
            plotView2.Text = "plotView2";
            plotView2.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView2.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView2.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(1826, 1003);
            Controls.Add(plotView2);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(textBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(btnOpen);
            Controls.Add(checkedListBox1);
            Controls.Add(btnExit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(plotView1);
            Controls.Add(numClustersTextBox);
            Controls.Add(dataGridView1);
            Controls.Add(clusterButton);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            Text = "K-MEANS CLUSTERING CUSTOMER";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button clusterButton;
        private DataGridView dataGridView1;
        private TextBox numClustersTextBox;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private Label label1;
        private Label label2;
        private Button btnExit;
        private CheckedListBox checkedListBox1;
        private Button btnOpen;
        private TextBox textBox1;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private ComboBox comboBox2;
        private Label label4;
        private Label label5;
        private Button button1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private OxyPlot.WindowsForms.PlotView plotView2;
    }
}