using SharpOSC;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    class COM
    {
        // SerialPort for comunicating with the  Arduino Board
        bool ledState = false;
        static SerialPort serialPort1 = new SerialPort();

        Main model;

        public COM(Main model)
        {
            this.model = model;
        }

        public void setLight() {                        
            // Com port can be changed here 
            try
            {
                serialPort1.PortName = "COM6";
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
            }
            catch (System.Exception)
            {
                Console.Write("Exception caught while trying to open a COM connection");
            }

            if (serialPort1.IsOpen) serialPort1.Close();
        }
    }
}
