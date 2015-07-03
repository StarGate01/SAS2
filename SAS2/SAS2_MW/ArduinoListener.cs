using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace SAS2_MW
{
    public class ArduinoListener : IDisposable
    {

        public struct ValueBuffer
        {
            public bool[] DigitalPins;
            public decimal[] AnalogPins;
        }
        public struct ArduinoCommand
        {
            public string RawCommand;
            public int BusyId;
            public string Command;
            public byte PinNumber;
            public byte Parameter;
        }

        public ValueBuffer LastState;
        public Queue<ArduinoCommand> CommandQueue;

        private SerialPort SPort;
        private CancellationTokenSource ListeningThreadCancelToken;
        private object WriteMonitor = new object();

        private bool WaitsForACK;
        private EventWaitHandle waitACKHandle = new AutoResetEvent(false);
        private bool WaitsForPollData;
        private EventWaitHandle waitOKHandle = new AutoResetEvent(false);
        private byte[] LastPollData;
        private int LastPollDataPosition;

        public event ReadEventHandler Read;
        public delegate void ReadEventHandler(object sender);
        protected virtual void OnRead() { if (Read != null) Read(this); }

        public ArduinoListener(string portName, int baud)
        {
            LastState = new ValueBuffer()
            {
                DigitalPins = new bool[14],
                AnalogPins = new decimal[6]
            };
            CommandQueue = new Queue<ArduinoCommand>();
            ListeningThreadCancelToken = new CancellationTokenSource();
            SPort = new SerialPort(portName);
            SPort.BaudRate = baud;
            SPort.DataReceived += SPort_DataReceived;
            SPort.Open();
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object cToken)
            {
                CancellationToken token = (CancellationToken)cToken;
                while (!token.IsCancellationRequested)
                {
                    lock (WriteMonitor)
                    {
                        WaitsForACK = true;
                        SPort.Write(new byte[] { 0x42 }, 0, 1);
                        waitACKHandle.WaitOne();
                        if (!token.IsCancellationRequested)
                        {
                            WaitsForACK = false;
                            byte[] binaryCommand;
                            if (CommandQueue.Count > 0)
                            {
                                binaryCommand = new byte[3];
                                WaitsForPollData = false;
                                ArduinoCommand command = CommandQueue.Dequeue();
                                switch (command.Command)
                                {
                                    case "setup":
                                        binaryCommand[0] = 0x01;
                                        break;
                                    case "change_d":
                                        binaryCommand[0] = 0x02;
                                        break;
                                    case "change_a":
                                        binaryCommand[0] = 0x03;
                                        break;
                                    case "reset_all":
                                        binaryCommand[0] = 0x04;
                                        break;
                                }
                                binaryCommand[1] = command.PinNumber;
                                binaryCommand[2] = command.Parameter;
                            }
                            else
                            {
                                binaryCommand = new byte[] { 0x00, 0x00, 0x00 };
                                WaitsForPollData = true;
                                LastPollData = new byte[14];
                                LastPollDataPosition = 0;
                            }
                            SPort.Write(binaryCommand, 0, binaryCommand.Length);
                            waitOKHandle.WaitOne();
                            if (!token.IsCancellationRequested)
                            {
                                if (WaitsForPollData)
                                {
                                    for (var i = 0; i < 8; i++) LastState.DigitalPins[i] = (LastPollData[0] & (1 << i - 1)) != 0;
                                    for (var i = 0; i < 6; i++) LastState.DigitalPins[i + 8] = (LastPollData[1] & (1 << i - 1)) != 0;
                                    for (var i = 0; i < 6; i++)
                                    {
                                        int value = 256 * LastPollData[2 + (i * 2)] + LastPollData[3 + (i * 2)];
                                        LastState.AnalogPins[i] = value * 100m / 1023m;
                                    }
                                }
                            }
                        }
                    }
                }
            }), ListeningThreadCancelToken.Token);
        }

        void SPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (SPort.IsOpen && SPort.BytesToRead > 0)
            {
                OnRead();
                byte data = Convert.ToByte(SPort.ReadByte());
                if (WaitsForACK)
                {
                    if (data == 0x13)
                    {
                        waitACKHandle.Set();
                    }
                }
                else
                {
                    if (WaitsForPollData && LastPollDataPosition < 14)
                    {
                        LastPollData[LastPollDataPosition] = data;
                        LastPollDataPosition++;
                    }
                    if ((!WaitsForPollData && data == 0x66) || (WaitsForPollData && LastPollDataPosition == 14 && data == 0x66))
                    {
                        waitOKHandle.Set();
                    }
                }
            }
        }

        public void Dispose()
        {
            ListeningThreadCancelToken.Cancel();
            waitACKHandle.Set();
            waitOKHandle.Set();
            SPort.DataReceived -= SPort_DataReceived;
            SPort.Close();
        }

    }
}
