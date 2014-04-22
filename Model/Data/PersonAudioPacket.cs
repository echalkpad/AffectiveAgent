using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonAudioPacket
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

    }
}
