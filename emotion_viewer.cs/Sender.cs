using SharpOSC;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EmotionViewer
{
    public class Sender
    {
        Stopwatch timer = new Stopwatch();
        List<int> valenceList = new List<int>();

        private string[] EmotionLabels = { "ANGER", "CONTEMPT", "DISGUST", "FEAR", "JOY", "SADNESS", "SURPRISE" };
        private string[] SentimentLabels = { "NEGATIVE", "POSITIVE", "NEUTRAL" };

        public Sender()
        {
            timer.Start();
        }

        public void update(int valenceID)
        {
            /* 
            initialize OSC object..
            *                          * 
            * Collect 30 seconds of  Valence  in an array .
            * Then find  the most occured 
            * 
            * Send the via OSC
            */
            if (timer.Elapsed.TotalSeconds < TimeSpan.FromSeconds(10).TotalSeconds)
            {
                valenceList.Add(valenceID);
            }
            else
            {
                // Find the valence that has occured the most  
                if (valenceList.Count > 0)
                {
                    var mostOccured = valenceList.GroupBy(i => i).OrderByDescending(grp => grp.Count())
                                .Select(grp => grp.Key).First();
                    // Send the valence to the affective model to be checked
                    TransmitData(SentimentLabels[mostOccured].ToString());
                    valenceList.Clear();

                }
                // reset and start timer
                timer.Reset();
                timer.Start();
            }
        }

        private void TransmitData(string valence)
        {
            VideoPacket packet = new VideoPacket("valence - " + valence);
            var message = new OscMessage("/test/1", ObjectToString(packet));
            var udpSender = new UDPSender("127.0.0.1", 55555);
            udpSender.Send(message);
        }

        public string ObjectToString(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
