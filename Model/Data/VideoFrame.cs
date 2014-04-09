using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable()]
    public class VideoFrame : ISerializable
    {
        long time;
        string emotion;
        float emotionIntensity;
        string valence;
        float valenceIntensity;

        public VideoFrame(long time, string emotion, float emotionIntensity, string valence, float valenceIntensity)
        {
            this.time = time;
            this.emotion = emotion;
            this.emotionIntensity = emotionIntensity;
            this.valence = valence;
            this.valenceIntensity = valenceIntensity;
        }

        //Deserialization constructor.
        public VideoFrame(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            time = (long)info.GetValue("time", typeof(long));
            emotion = (string)info.GetValue("emotion", typeof(string));
            emotionIntensity = (float)info.GetValue("emotionIntensity", typeof(float));
            valence = (string)info.GetValue("valence", typeof(string));
            valenceIntensity = (float)info.GetValue("valenceIntensity", typeof(float));

        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("time", time);
            info.AddValue("emotion", emotion);
            info.AddValue("emotionIntensity", emotionIntensity);
            info.AddValue("valence", valence);
            info.AddValue("valenceIntensity", valenceIntensity);
        }

        public string ToString()
        {
            return "VideoFrame<" + time + ", " + emotion + ", " + emotionIntensity + ", " + valence + ", " + valenceIntensity + ">";
        }
    }
}
