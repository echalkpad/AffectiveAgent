using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class AudioPacket
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
    }
}
