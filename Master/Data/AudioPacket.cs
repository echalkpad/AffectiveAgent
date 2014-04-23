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
    public class AudioPacket : ISerializable
    {
        public int person;
        public DateTime time = DateTime.Now;
        public double individualsTime;
        public double totalTime;
        public int numberOfInterruptions;
        public double maxValue;


        public AudioPacket(int person)
        {
            this.person = person;
            this.individualsTime = -1;
            this.totalTime = -1;
            this.numberOfInterruptions = 0;
            this.maxValue = -1;
        }

        public AudioPacket(int person, double individualsTime, double totalTime, int numberOfInterruptions, double maxValue)
        {
            this.person = person;
            this.individualsTime = individualsTime;
            this.totalTime = totalTime;
            this.numberOfInterruptions = numberOfInterruptions;
            this.maxValue = maxValue;
        }

        public Boolean isFinished()
        {
            return individualsTime != -1 && totalTime != -1 && numberOfInterruptions != -1 && maxValue != -1;
        }
       
        public override string ToString()
        {
            return "AudioPacket<" + person + ", " + time.ToString() + ", " + individualsTime + ", " + totalTime + ", " + numberOfInterruptions + ", " + maxValue + ">";
        }

        //Deserialization constructor.
        public AudioPacket(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            person = (int)info.GetValue("person", typeof(int));
            time = (DateTime)info.GetValue("time", typeof(DateTime));
            individualsTime = (double)info.GetValue("individualsTime", typeof(double));
            totalTime = (double)info.GetValue("totalTime", typeof(double));
            numberOfInterruptions = (int)info.GetValue("numberOfInterruptions", typeof(int));
            maxValue = (double)info.GetValue("maxValue", typeof(double));
        }
        
        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("person", person);
            info.AddValue("time", time);
            info.AddValue("individualsTime", individualsTime);
            info.AddValue("totalTime", totalTime);
            info.AddValue("numberOfInterruptions", numberOfInterruptions);
            info.AddValue("maxValue", maxValue);
        }
    }
}
