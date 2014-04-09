using SharpOSC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Model
{
    class Receiver
    {
        Main model;

        public Receiver(Main model)
        {
            this.model = model;

            // The cabllback function
            HandleOscPacket callback = delegate(OscPacket packet)
            {
                var messageReceived = (OscMessage) packet;
                String message = messageReceived.Arguments[0].ToString();
                VideoPacket videoPacket = (VideoPacket)StringToObject(message);
                Console.WriteLine(videoPacket.ToString());
                Console.WriteLine("Affect Recieved!");
            };

            var listener = new UDPListener(55555, callback);

            Console.WriteLine("Press any key to stop receiving");
            Console.ReadLine();
            listener.Close();
        }

        public object StringToObject(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return new BinaryFormatter().Deserialize(ms);
            }
        }
    }
}
