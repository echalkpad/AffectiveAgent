using SharpOSC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace Master
{
    public class COM
    {
        // SerialPort for comunicating with the  Arduino Board
        bool ledState = false;
         SerialPort serialPort1 = new SerialPort();

        Model model;

        public COM(Model model)
        {
            this.model = model;
            serialPort1.PortName = "COM6";
            serialPort1.BaudRate = 9600;
            //serialPort1.Open();
        }

        public void switchState(int state)
        {
            //serialPort1.Write(state.ToString());
        }

        public void switchLightOn()
        {
            serialPort1.Write("1");           
            ledState = true; 
          
        }
        public void switchLightOff()
        { 
            this.serialPort1.Write("0");          
            ledState = false; 
        
        
        }

        public void OpenCom() {                        
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

        public void CloseCOM()
        {
            try
            {
                if (serialPort1.IsOpen) serialPort1.Close();
            }
            catch (Exception)
            {

                Console.Write("Error Closing Connection");
            }
           
        }
    }
}
