using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;

namespace C_S7PLCFinal
{
    public partial class Form1 : Form
    {
        private Plc plc = null; 
        public Form1()
        {
            InitializeComponent();
        }

        
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetNames(typeof(CpuType));
        }

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
            CpuType cpu=(CpuType)Enum.Parse(typeof(CpuType), comboBox1.SelectedItem.ToString());
            plc = new Plc(cpu, textBox1.Text, Convert.ToInt16(textBox2.Text), Convert.ToInt16(textBox3.Text));
            if (plc.IsConnected)
            {
                textBox6.Text = "Connected";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            plc.Close();
            textBox6.Text = "Disconnected";
        }

        private void ReadBTN_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void DC_BTN_Click(object sender, EventArgs e)
        {
            plc.Close();
            textBox6.Text = "Disconnected";
        }

        private void R_BTN_Click(object sender, EventArgs e)
        {
            string address = textBox7.Text;
            object result = plc.Read(address);
            textBox4.Text = string.Format("{0}", result.ToString());
        }

        private void W_BTN_Click(object sender, EventArgs e)
        {
            string address =textBox7.Text;
            object setpoint = textBox5.Text;
            plc.Write(address, setpoint);
        }
    }
}
