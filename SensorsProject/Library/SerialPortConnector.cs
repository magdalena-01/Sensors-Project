﻿using System.IO.Ports;

namespace SensorsProject.Library
{
    public class SerialPortConnector
    {
        private readonly int _baudRate = 9600;
        private readonly string _portName = "COM8";
        
        public void Send(string command)
        {
            using (var serialPort = new SerialPort(_portName, _baudRate))
            {
                serialPort.Open();
                serialPort.Write(command);
            }
        }
    }
}
