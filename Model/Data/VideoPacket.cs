using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable()]
    public class VideoPacket : ISerializable
    {
        string person;
        List<VideoFrame> videoFrames;

        public VideoPacket(string person)
        {
            this.person = person;
            this.videoFrames = new List<VideoFrame>();
        }

        //Deserialization constructor.
        public VideoPacket(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            person = (String)info.GetValue("person", typeof(String));
            videoFrames = (List<VideoFrame>)info.GetValue("videoFrames", typeof(List<VideoFrame>));
        }
        
        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("person", person);
            info.AddValue("videoFrames", videoFrames);
        }

        public void addVideoFrame(VideoFrame videoFrame)
        {
            videoFrames.Add(videoFrame);
        }

        public string getPerson()
        {
            return person;
        }

        public string ToString()
        {
            string str = "VideoPacket<" + person + ", List<";
            foreach (VideoFrame frame in videoFrames)
            {
                str += "(" + frame.ToString() + ")";
            }
            str += ">>";
            return str;
        }
    }
}
