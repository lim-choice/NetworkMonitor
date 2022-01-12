using NetworkMonitor.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //네트워크 로드 
            NetDevice netDevice = NetDevice.Instance;
            netDevice.Load();

            string[] devInfo = netDevice.GetSelectedDeviceInfo();
            label1.Text += devInfo[0];
            label2.Text += devInfo[1];
            label3.Text += devInfo[2];
            label4.Text += devInfo[3];
        }
    }
}
