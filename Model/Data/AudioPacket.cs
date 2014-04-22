using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AudioPacket
    {
       
        List<PersonAudioPacket> personAudioPackets;

        public AudioPacket()
        {
            
            personAudioPackets = new List<PersonAudioPacket>();
        }

        public void add(PersonAudioPacket packet)
        {
            personAudioPackets.Add(packet);
        }
       
        public override string ToString()
        {
            string str = "AudioPacket<" + "" + ", List<";
            foreach (PersonAudioPacket packet in personAudioPackets)
            {
                str += "(" + packet.ToString() + ")";
            }
            str += ">>";
            return str;
        }
    }
}
