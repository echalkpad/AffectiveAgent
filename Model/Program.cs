using SharpOSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            // The cabllback function
            HandleOscPacket callback = delegate(OscPacket packet)
            {
                var messageReceived = (OscMessage)packet;
                Console.WriteLine(messageReceived.Arguments[0].ToString());
                Console.WriteLine("Received a message!");
            };

            var listener = new UDPListener(55555, callback);

            Console.WriteLine("Press enter to stop");
            Console.ReadLine();
            listener.Close();
        }
        
        
    }
    
}
