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

namespace GSM_test
{
    public partial class Form1 : Form
    {
        SerialPort _sp;

        public Form1()
        {
            InitializeComponent();
            _sp = new SerialPort();
        }

        private void OpenPort()
        {
            _sp.BaudRate = 2400; // еще варианты 4800, 9600, 28800 или 56000
            _sp.DataBits = 7; // еще варианты 8, 9

            _sp.StopBits = StopBits.One; // еще варианты StopBits.Two StopBits.None или StopBits.OnePointFive         
            _sp.Parity = Parity.Odd; // еще варианты Parity.Even Parity.Mark Parity.None или Parity.Space

            _sp.ReadTimeout = 500; // самый оптимальный промежуток времени
            _sp.WriteTimeout = 500; // самый оптимальный промежуток времени

            _sp.Encoding = Encoding.GetEncoding("windows-1251");
            _sp.PortName = "COM5";

            if (_sp.IsOpen)
                _sp.Close();
            try
            {
                _sp.Open();
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenPort();
        }
    }
}
