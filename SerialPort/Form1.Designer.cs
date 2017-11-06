using System.IO.Ports;

namespace SerialPortDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboRate = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(3, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 380);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "";
            // 
            // comboPort
            // 
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Items.AddRange(new object[] {
            "COM3"});
            this.comboPort.Location = new System.Drawing.Point(70, 25);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(101, 23);
            this.comboPort.TabIndex = 3;
            this.comboPort.Text = "COM3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "端口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "频率：";
            // 
            // comboRate
            // 
            this.comboRate.FormattingEnabled = true;
            this.comboRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboRate.Location = new System.Drawing.Point(262, 25);
            this.comboRate.Name = "comboRate";
            this.comboRate.Size = new System.Drawing.Size(101, 23);
            this.comboRate.TabIndex = 6;
            this.comboRate.Text = "9600";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(168, 86);
            this.chart1.Name = "chart1";
            series19.ChartArea = "ChartArea1";
            series19.Legend = "Legend1";
            series19.Name = "u1";
            series20.ChartArea = "ChartArea1";
            series20.Legend = "Legend1";
            series20.Name = "u2";
            series21.ChartArea = "ChartArea1";
            series21.Legend = "Legend1";
            series21.Name = "k";
            this.chart1.Series.Add(series19);
            this.chart1.Series.Add(series20);
            this.chart1.Series.Add(series21);
            this.chart1.Size = new System.Drawing.Size(559, 380);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 478);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.comboRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPort);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboRate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

