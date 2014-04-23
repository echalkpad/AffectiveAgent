using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable()]
    public class PersonAudioPacket : ISerializable
    {
        string person;
        double individualsTime;
        double totalTime;
        int numberOfInterruptions;
        double maxValue;

        public PersonAudioPacket(string person, double individualsTime, double totalTime, int numberOfInterruptions, double maxValue)
        {
            this.person = person;
            this.individualsTime = individualsTime;
            this.totalTime = totalTime;
            this.numberOfInterruptions = numberOfInterruptions;
            this.maxValue = maxValue;
        }
      
        public string getPerson()
        {
            return person;
        }

        public override string ToString()
        {
            return "PersonAudioPacket<" + person + ", " + individualsTime + ", " + totalTime + ", " + numberOfInterruptions + ", " + maxValue + ">";
        }

        //Deserialization constructor.
        public PersonAudioPacket(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            person = (string)info.GetValue("person", typeof(string));
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
            info.AddValue("individualsTime", individualsTime);
            info.AddValue("totalTime", totalTime);
            info.AddValue("numberOfInterruptions", numberOfInterruptions);
            info.AddValue("maxValue", maxValue);
        }
    }
}
