using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

namespace SerialPortDemo
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort = new SerialPort();
        private int received_count = 0;
        private StringBuilder builder = new StringBuilder();
        private String lastData = "";
        public Form1()
        {
            InitializeComponent();
            initSerialPort();
            
            initChart();
        }
        private void initSerialPort()
        {
            this.serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            //this.serialPort.PortName = "COM3"; //端口号 
            this.serialPort.Parity = 0; //奇偶校验 
            //this.serialPort.BaudRate = 9600;//串口通信波特率 
            this.serialPort.DataBits = 8; //数据位 
            this.serialPort.StopBits = (StopBits)1;//停止位 
            this.serialPort.ReadTimeout = 1000; //读超时 
        }
        private void initChart()
        {
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].ChartType = SeriesChartType.Spline;
            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[2].ChartType = SeriesChartType.Spline;

            chart1.Series[1].Color = Color.Green;
            chart1.Series[2].Color = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lastData = "";
            if (serialPort.IsOpen)
            {
                //串口状态是open时，text是关闭 点击，则关闭串口
                serialPort.Close();
                button1.Text = "打开";
                //textBox1.Text = "";
            }
            else
            {
                if (comboPort.Text == "")
                {
                    MessageBox.Show("选择串口！");
                    return;
                }
                if (comboRate.Text == "")
                {
                    MessageBox.Show("设置波特率！");
                    return;
                }
                serialPort.PortName = comboPort.Text;
                serialPort.BaudRate = int.Parse(comboRate.Text);
                try
                {
                    serialPort.Open();
                    button1.Text = "关闭";
                }
                catch (Exception e1)
                {
                    //捕获到异常信息，创建一个新的comm对象，之前的不能用了。
                    serialPort = new SerialPort();
                    //显示异常信息给客户。
                    MessageBox.Show(e1.Message);
                }

            }

        }
        //接收串口数据函数
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            int n = serialPort.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致

            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据
            received_count += n;//增加接收计数
            serialPort.Read(buf, 0, n); ;//读取缓冲数据

            builder.Clear();//清除字符串构造器的内容
            //因为要访问ui资源，所以需要使用invoke方式同步ui。
            this.Invoke((EventHandler)(delegate
            {
                //直接按ASCII规则转换成字符串
                String data = Encoding.ASCII.GetString(buf);
                //
                String[] d = data.Split('#');
                //lastData = d[d.Length - 1];
                if (data.Equals("#")|| d.Length == 1 || (!d[0].Equals("")&&d[1].Equals("")))
                {
                    if ((data[data.Length - 1]!='#'))
                    {
                        lastData += data;
                        return;
                    }
                    else//遇到‘#’
                    {
                        lastData += data.Trim('#');
                        String[] dataNum = lastData.Split(',');
                        if (dataNum.Length != 3)
                            return;
                        for (int j = 0; j < 3; j++)
                        {
                            try
                            {
                            drawChart(j, double.Parse(dataNum[j]));

                            }
                            catch
                            {
                                lastData = "";
                                return;
                            }
                        }

                        builder.Append(lastData + "\n");
                        textBox1.AppendText(builder.ToString());
                        lastData = "";

                    }
                }
                else//缓存数据筛去
                {
                    String[] t=data.Split('#');
                    lastData = t[t.Length - 1];
                    return;
                }


            }));


            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
        }

        //绘图
        private void drawChart(int index, double y)
        {
            chart1.Series[index].Points.AddY(y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort.Close();
        }
    }
}
