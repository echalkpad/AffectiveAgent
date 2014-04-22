using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        string label;
        List<VideoPacket> videoPackets;
        List<AudioPacket> audioPackets;

        public Person(string label)
        {
            this.label = label;
            videoPackets = new List<VideoPacket>();
            audioPackets = new List<AudioPacket>();
        }

        public void addVideoPacket(VideoPacket packet)
        {
            videoPackets.Add(packet);
        }

        public void addAudioPacket(AudioPacket packet)
        {
            audioPackets.Add(packet);
        }

    }
}
