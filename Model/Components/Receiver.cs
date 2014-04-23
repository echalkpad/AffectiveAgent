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
using Model.Data;

namespace Model
{
    public class Receiver
    {
        Model model;
        List<AudioPacket> audioPackets = new List<AudioPacket>();

        UDPListener videolistener, audiolistener;

        public Receiver(Model model)
        {
            this.model = model;
            this.audioPackets.Add(new AudioPacket(0));
            this.audioPackets.Add(new AudioPacket(1));
        }

        public void start()
        {
            // The video cabllback function
            HandleOscPacket callback = delegate(OscPacket packet)
            {
                var messageReceived = (OscMessage)packet;
                String message = messageReceived.Arguments[0].ToString();
                VideoPacket videoPacket = (VideoPacket)Serializer.StringToObject(message);
                model.addVideoPacket(videoPacket);
                print(videoPacket.ToString());
                print("Video Affect Recieved!");
            };

            videolistener = new UDPListener(55555, callback);

            // Audio Reciever
            HandleOscPacket Audiocallback = delegate(OscPacket packet)
            {
                var messageReceived = (OscMessage)packet;

                if (messageReceived.Address == "/general/totaltime")
                {
                    //updateAudiopacket("PersonA", 0.0, Convert.ToDouble(messageReceived.Arguments[0]), 0, 0.0);
                    //updateAudiopacket("PersonB", 0.0, Convert.ToDouble(messageReceived.Arguments[0]), 0, 0.0);
                    audioPackets[0].totalTime = Convert.ToDouble(messageReceived.Arguments[0]);
                    audioPackets[1].totalTime = Convert.ToDouble(messageReceived.Arguments[0]);
                }
                else
                {
                    if (messageReceived.Address == "/speaker1/volume")
                    {
                        //updateAudiopacket(0, 0.0, 0.0, 0, Convert.ToDouble(messageReceived.Arguments[0]));
                        audioPackets[0].maxValue = Convert.ToDouble(messageReceived.Arguments[0]);
                    }
                    if (messageReceived.Address == "/speaker2/volume")
                    {
                        //updateAudiopacket(1, 0.0, 0.0, 0, Convert.ToDouble(messageReceived.Arguments[0]));
                        audioPackets[1].maxValue = Convert.ToDouble(messageReceived.Arguments[0]);
                    }
                    if (messageReceived.Address == "/speaker1/interrupts")
                    {
                        //updateAudiopacket(0, 0.0, 0.0, Convert.ToInt32(messageReceived.Arguments[0]), 0.0);
                        audioPackets[0].numberOfInterruptions = Convert.ToInt32(messageReceived.Arguments[0]);
                    }
                    if (messageReceived.Address == "/speaker2/interrupts")
                    {
                        //updateAudiopacket(1, 0.0, 0.0, Convert.ToInt32(messageReceived.Arguments[0]), 0.0);
                        audioPackets[1].numberOfInterruptions = Convert.ToInt32(messageReceived.Arguments[0]);
                    }
                    if (messageReceived.Address == "/speaker1/talktime")
                    {
                        //updateAudiopacket(0, Convert.ToDouble(messageReceived.Arguments[0]), 0.0, 0, 0.0);
                        audioPackets[0].individualsTime = Convert.ToDouble(messageReceived.Arguments[0]);
                    }
                    if (messageReceived.Address == "/speaker2/talktime")
                    {
                        //updateAudiopacket(1, Convert.ToDouble(messageReceived.Arguments[0]), 0.0, 0, 0.0);
                        audioPackets[1].individualsTime = Convert.ToDouble(messageReceived.Arguments[0]);
                    }
                    for (int i = 0; i < audioPackets.Count; i++)
                    {
                        if (audioPackets[i].isFinished())
                        {
                            model.addAudioPacket(audioPackets[i]);
                            int person = audioPackets[i].person;
                            print(audioPackets[i].ToString());
                            audioPackets[i] = new AudioPacket(person);
                        }
                    }
                }

                
                
            };

            audiolistener = new UDPListener(55556, Audiocallback);
        }

        public void stop()
        {
            videolistener.Close();
            audiolistener.Close();

        }

        public void print(String text)
        {
            model.print(text);
        }
    }
}
