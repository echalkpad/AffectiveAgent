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
        int time;
        string emotion;
        double emotionIntensity;
        string valence;
        double valenceIntensity;

        public VideoFrame(int time, string emotion, double emotionIntensity, string valence, double valenceIntensity)
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
            time = (int)info.GetValue("time", typeof(int));
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("time", time);
        }
    }
}
