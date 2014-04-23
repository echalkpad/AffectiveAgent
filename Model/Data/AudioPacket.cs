using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable()]
    public class AudioPacket : ISerializable
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

        //Deserialization constructor.
        public AudioPacket(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            personAudioPackets = (List<PersonAudioPacket>)info.GetValue("personAudioPackets", typeof(List<PersonAudioPacket>));
        }
        
        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("personAudioPackets", personAudioPackets);
        }
    }
}
