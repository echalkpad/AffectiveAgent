using Master.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    [Serializable()]
    public class VideoFrame : ISerializable
    {        
        public DateTime time;
        public Emotion emotion;
        public float emotionIntensity;
        public Valence valence;

        public float valenceIntensity;

        public VideoFrame(DateTime time, string emotion, float emotionIntensity, string valence, float valenceIntensity)
        {
            this.time = time;
            this.emotion = Constants.ParseEmotion(emotion);
            this.emotionIntensity = emotionIntensity;
            this.valence = Constants.ParseValence(valence);
            this.valenceIntensity = valenceIntensity;
        }

        //Deserialization constructor.
        public VideoFrame(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            time = (DateTime)info.GetValue("time", typeof(DateTime));
            emotion = (Emotion)info.GetValue("emotion", typeof(Emotion));
            emotionIntensity = (float)info.GetValue("emotionIntensity", typeof(float));
            valence = (Valence)info.GetValue("valence", typeof(Valence));
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

        public override string ToString()
        {
            return "VideoFrame<" + time + ", " + emotion + ", " + emotionIntensity + ", " + valence + ", " + valenceIntensity + ">";
        }
    }
}
