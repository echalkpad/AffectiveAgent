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
        AudioPacket audioPacket;

        UDPListener videolistener, audiolistener;

        public Receiver(Model model)
        {
            this.model = model;
        }

        public void updateAudiopacket(string person, double individualsTime, double totalTime, int numberOfInterruptions, double maxValue)
        {
            PersonAudioPacket personAudioPacket = new PersonAudioPacket(person, individualsTime, totalTime, numberOfInterruptions, maxValue);
            audioPacket.add(personAudioPacket);
            print(audioPacket.ToString());
            audioPacket = new AudioPacket();  
        }

        public void start()
        {
            audioPacket = new AudioPacket();

            // The video cabllback function
            HandleOscPacket callback = delegate(OscPacket packet)
            {
                var messageReceived = (OscMessage)packet;
                String message = messageReceived.Arguments[0].ToString();
                VideoPacket videoPacket = (VideoPacket)Serializer.StringToObject(message);
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
                    updateAudiopacket("PersonA", 0.0, Convert.ToDouble(messageReceived.Arguments[0]), 0, 0.0);
                    updateAudiopacket("PersonB", 0.0, Convert.ToDouble(messageReceived.Arguments[0]), 0, 0.0);
                }
                else
                {
                    if (messageReceived.Address == "/speaker1/volume")
                    {
                        updateAudiopacket("PersonA", 0.0, 0.0, 0, Convert.ToDouble(messageReceived.Arguments[0]));
                    }
                    if (messageReceived.Address == "/speaker2/volume")
                    {
                        updateAudiopacket("PersonB", 0.0, 0.0, 0, Convert.ToDouble(messageReceived.Arguments[0]));
                    }
                    if (messageReceived.Address == "/speaker1/interrupts")
                    {
                        updateAudiopacket("PersonA", 0.0, 0.0, Convert.ToInt32(messageReceived.Arguments[0]), 0.0);
                    }
                    if (messageReceived.Address == "/speaker2/interrupts")
                    {
                        updateAudiopacket("PersonB", 0.0, 0.0, Convert.ToInt32(messageReceived.Arguments[0]), 0.0);
                    }
                    if (messageReceived.Address == "/speaker1/talktime")
                    {
                        updateAudiopacket("PersonA", Convert.ToDouble(messageReceived.Arguments[0]), 0.0, 0, 0.0);
                    }
                    if (messageReceived.Address == "/speaker2/talktime")
                    {
                        updateAudiopacket("PersonB", Convert.ToDouble(messageReceived.Arguments[0]), 0.0, 0, 0.0);
                    }
                }

                print("Audio Affect Recieved!");
            };

            audiolistener = new UDPListener(55556, Audiocallback);

            print("Press any key to stop receiving");
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
