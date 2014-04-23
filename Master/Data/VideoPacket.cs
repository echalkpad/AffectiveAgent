using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    [Serializable()]
    public class VideoPacket : ISerializable
    {
        public int person;
        public DateTime time = DateTime.Now;
        public List<VideoFrame> videoFrames;

        public VideoPacket(int person)
        {
            this.person = person;
            this.videoFrames = new List<VideoFrame>();
        }

        public void addVideoFrame(VideoFrame videoFrame)
        {
            videoFrames.Add(videoFrame);
        }

        //Deserialization constructor.
        public VideoPacket(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            person = (int)info.GetValue("person", typeof(int));
            time = (DateTime)info.GetValue("time", typeof(DateTime));
            videoFrames = (List<VideoFrame>)info.GetValue("videoFrames", typeof(List<VideoFrame>));
        }
        
        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("person", person);
            info.AddValue("time", time);
            info.AddValue("videoFrames", videoFrames);
        }

        public override string ToString()
        {
            string str = "VideoPacket<" + person + ", " + time.ToString() + ", List<";
            foreach (VideoFrame frame in videoFrames)
            {
                str += "(" + frame.ToString() + ")";
            }
            str += ">>";
            return str;
        }
    }
}
