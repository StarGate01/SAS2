using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SAS2_MW
{
    public partial class FormMain : Form
    {

        private const int HTTPPortNumber = 45133;
        private const int Baud = 9600;
        private ScratchListener SListener;
        private ArduinoListener AListener;
        private string[] TextBoxContents = new string[4];

        public FormMain()
        {
            InitializeComponent();
        }

        #region UI interaction

        private void FormMain_Load(object sender, EventArgs e)
        {
            buttonRefreshPort_Click(null, null);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonDisconnect_Click(null, null);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Did you hardware-reset your Arduino?" + Environment.NewLine + "If not, please do it now.", "SAS2_MW", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            try
            {
                SListener = new ScratchListener(HTTPPortNumber);
                SListener.Request += SListener_Request;
                AListener = new ArduinoListener(comboBoxPort.SelectedItem.ToString(), Baud);
                AListener.Read += AListener_Read;
            }
            catch
            {
                MessageBox.Show("Cannot start servers." + Environment.NewLine + "Did you pick the correct COM-port?", "SAS_MW", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = true;
            buttonRefreshPort.Enabled = false;
            comboBoxPort.Enabled = false;
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (SListener != null) SListener.Dispose();
            labelLastHTTPResponse.Text = "";
            if (AListener != null) AListener.Dispose();
            labelHTTPState.Text = "";
            labelCOMState.Text = "";
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            buttonRefreshPort.Enabled = true;
            comboBoxPort.Enabled = true;
        }

        private void buttonRefreshPort_Click(object sender, EventArgs e)
        {
            comboBoxPort.Items.Clear();
            foreach (String port in System.IO.Ports.SerialPort.GetPortNames()) comboBoxPort.Items.Add(port);
            if (comboBoxPort.Items.Count > 0) comboBoxPort.SelectedIndex = 0;
        }

        #endregion

        #region Core events

        private string SListener_Request(object sender, ScratchListener.RequestEventArgs args)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                labelHTTPState.Text = DateTime.Now.ToString("HH:mm:ss.fff");
            });
            string[] urlParts = args.RawURL.Split('/');
            if (urlParts[1] == "poll")
            {
                char nl = Convert.ToChar(0xA);
                string value = "high true" + nl + "low false" + nl;
                for (var i = 0; i < AListener.LastState.DigitalPins.Length; i++) value += "get_d/D" + i + " " + AListener.LastState.DigitalPins[i].ToString().ToLower() + nl;
                for (var i = 0; i < AListener.LastState.AnalogPins.Length; i++) value += "get_a/A" + i + " " + AListener.LastState.AnalogPins[i].ToString(CultureInfo.InvariantCulture) + nl;
                lock (AListener.CommandQueue)
                {
                    value += "_busy ";
                    List<ArduinoListener.ArduinoCommand> queueList = AListener.CommandQueue.ToList();
                    for (var i = 0; i < queueList.Count; i++) value += queueList[i].BusyId + " ";
                }
                BeginInvoke((MethodInvoker)delegate
                {
                    labelLastHTTPResponse.Text = value.Replace(nl.ToString(), Environment.NewLine);
                });
                return value;
            }
            else if (urlParts[1] == "reset_all")
            {
                lock (AListener.CommandQueue)
                {
                    AListener.CommandQueue.Enqueue(new ArduinoListener.ArduinoCommand()
                    {
                        RawCommand = args.RawURL,
                        BusyId = 0,
                        Command = urlParts[1],
                        PinNumber = 0x00,
                        Parameter = 0x00
                    });
                }
            }
            else if (urlParts[1] == "setup" || urlParts[1] == "change_d" || urlParts[1] == "change_a")
            {
                lock (AListener.CommandQueue)
                {
                    if (urlParts.Length == 5)
                    {
                        byte pinNumber = Convert.ToByte(urlParts[3].Substring(1));
                        byte parameter = 0x00;
                        switch (urlParts[1])
                        {
                            case "setup":
                            case "change_d":
                                if (urlParts[4] == "Output" || urlParts[4] == "Ausgang" || urlParts[4] == "true") parameter = 0x01;
                                break;
                            case "change_a":
                                decimal value = Convert.ToDecimal(urlParts[4], CultureInfo.InvariantCulture);
                                value = (value < 0) ? 0 : (value > 100) ? 100 : value;
                                parameter = Convert.ToByte(value / 100m * 255m);
                                break;
                        }
                        AListener.CommandQueue.Enqueue(new ArduinoListener.ArduinoCommand()
                        {
                            RawCommand = args.RawURL,
                            BusyId = Convert.ToInt32(urlParts[2]),
                            Command = urlParts[1],
                            PinNumber = pinNumber,
                            Parameter = parameter
                        });
                    }
                }
            }
            return "";
        }

        void AListener_Read(object sender)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                labelCOMState.Text = DateTime.Now.ToString("HH:mm:ss.fff");
            });
        }

        #endregion

    }
}
