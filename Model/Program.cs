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
    class Program
    {
        // SerialPort for comunicating with the  Arduino Board
        bool ledState = false;
        static SerialPort serialPort1 = new SerialPort();

        static void Main(string[] args)
        {
            // Com port can be changed here 
            serialPort1.PortName = "COM6";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
            
            
            // The cabllback function
                HandleOscPacket callback = delegate(OscPacket packet)
                {
                    var messageReceived = (OscMessage)packet;
                    Console.WriteLine(messageReceived.Arguments[0].ToString());
                    Console.WriteLine("Affect Recieved!");
                };

                var listener = new UDPListener(55555, callback);

                Console.WriteLine("Press any key to stop receiving");
                Console.ReadLine();
                listener.Close();
                if (serialPort1.IsOpen) serialPort1.Close();
            }
            
            
          
        }
        
        
    
    
}
