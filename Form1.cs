using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Text;
using System;
using OpenAI_API;
using OpenAI_API.Completions;

namespace WinFormsApp1
{
    public partial class Main_Window : Form
    {
        public Main_Window()
        {
            InitializeComponent();
        }

        UdpClient server;
        IPEndPoint remoteIP;
        int remotPort = 5555;
        int port = 44444;

        private void button12_Click(object sender, EventArgs e)
        {
            IpConnect.BackColor = Color.Red;
            server = new UdpClient(port);
            remoteIP = new IPEndPoint(IPAddress.Parse(txtRemteIp.Text), remotPort);
            server.BeginReceive(new AsyncCallback(onReceive), server);

        }
        private void onReceive(IAsyncResult AR)
        {

            byte[] buff = server.EndReceive(AR, ref remoteIP);
            server.BeginReceive(new AsyncCallback(onReceive), server);
            ControlInvoke(txtInMsg, () => txtInMsg.AppendText(":>>" + Encoding.ASCII.GetString(buff) + Environment.NewLine));

        }


        private void button9_Click_1(object sender, EventArgs e)
        {
            server.Connect(remoteIP);
            server.Send(Encoding.ASCII.GetBytes(txtmsg.Text), txtmsg.Text.Length);
            txtmsg.Clear();
        }



        delegate void UniversalVoidDelegate();

        public static void ControlInvoke(Control control, Action function)

        {

            if (control.IsDisposed || control.Disposing)
            {
                return;
            }


            if (control.InvokeRequired)
            {
                control.Invoke(new UniversalVoidDelegate(() => ControlInvoke(control, function)));
                return;
            }

            function();
        }



        private void button8_Click(object sender, EventArgs e)
        {

        }











        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Main_Pannel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Contact_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChatShow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Chatbot_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Document_Click(object sender, EventArgs e)
        {

        }


        private void ProfilePhoto_Click(object sender, EventArgs e)
        {

        }

        private void Ajay_Click(object sender, EventArgs e)
        {

        }


    }
}