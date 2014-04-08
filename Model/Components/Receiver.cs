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
    class Receiver
    {
        Model model;

        public Receiver(Model model)
        {
            this.model = model;

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
        }

    }
}
