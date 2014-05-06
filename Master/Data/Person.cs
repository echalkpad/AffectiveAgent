using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    [Serializable()]
    public class Person : ISerializable
    {
        public string label;
        public List<VideoPacket> videoPackets;
        public List<AudioPacket> audioPackets;
        public List<VideoFrame> videoFrames { get { return videoPackets.SelectMany(videoPacket => videoPacket.videoFrames).ToList(); } }

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

        public List<VideoFrame> getVideoFrames()
        {
            List<VideoFrame> frames = new List<VideoFrame>();
            foreach (VideoPacket packet in videoPackets)
            {
                foreach (VideoFrame frame in packet.videoFrames)
                    frames.Add(frame);
            }
            return frames;
        }

        // Clear data
        public void Clear()
        {
            videoPackets = new List<VideoPacket>();
            audioPackets = new List<AudioPacket>();
        }

        // Return all audio packets within a time range
        public List<AudioPacket> AudioPacketsWithinRange(DateTime start, DateTime end)
        {
            return audioPackets.Where(audioPacket => audioPacket.time > start && audioPacket.time < end).ToList();
        }

        // Return all audio packets within a time range
        public List<VideoFrame> VideoFramesWithinRange(DateTime start, DateTime end)
        {
            return videoFrames.Where(frame => frame.time > start && frame.time < end).ToList();
        }

        //Deserialization constructor.
        public Person(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            label = (String)info.GetValue("label", typeof(String));
            videoPackets = (List<VideoPacket>)info.GetValue("videoPackets", typeof(List<VideoPacket>));
            audioPackets = (List<AudioPacket>)info.GetValue("audioPackets", typeof(List<AudioPacket>));
        }
        
        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("label", label);
            info.AddValue("videoPackets", videoPackets);
            info.AddValue("audioPackets", audioPackets);
        }

        public String ToString()
        {
            String output = "Person: " + label + "\r\n";
            output += "Audiopackets: \r\n";
            foreach (AudioPacket audioPacket in audioPackets)
            {
                output += "\tAudiopacket: " + audioPacket.ToString() + "\r\n";
            }
            output += "Videopackets: \r\n";
            foreach (VideoPacket videoPacket in videoPackets)
            {
                output += "\tVideopacket: " + videoPacket.ToString() + "\r\n";
            }
            return output;
        }

    }
}
