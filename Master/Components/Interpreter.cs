using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    public class Interpreter
    {
        Model model;
        Person personA;
        Person personB;
        public List<TimeValuePair> values = new List<TimeValuePair>();

        public Interpreter(Model model, Person personA, Person personB)
        {
            this.model = model;
            this.personA = personA;
            this.personB = personB;
        }

        public void Clear()
        {
            values = new List<TimeValuePair>();
        }

        public Person getPersonA()
        {
            return model.getPersonA();
        }

        public Person getPersonB()
        {
            return model.getPersonB();
        }

        public void Interpret()
        {
            DateTime minTime = model.getMinTime();
        }

        public int Update()
        {
            Interpret(DateTime.Now);
            if (values.Count == 0)
                return -100;
            else
            {
                int value = (int)Math.Round(values[values.Count - 1].value);
                if (value > 3)
                    value = 3;
                else if (value < -3)
                    value = -3;
                return value;
            }
        }

        public void Interpret(DateTime dateTime)
        {
            if (model.getAgentBehaviour() == Model.AgentBehaviour.ON)
            {
                InterpretOn(dateTime);
            }
            else if (model.getAgentBehaviour() == Model.AgentBehaviour.RANDOM)
            {
                InterpretRandom(dateTime);
            }   
        }

        public void InterpretOn(DateTime dateTime)
        {
            double value = 0;

            // 4.0 point of the 8.0 points are the valence of people
            // 3.0 of the 4.0 points is the valence
            // 0.5 of the 4.0 points is the number of interruptions 
            // 0.5 of the 4.0 points is max value

            // 4.0 point of the 8.0 points is the equal distribution
            // 2.5 of the 4.0 points is the valence
            // 0.5 of the 4.0 points is the speakers time
            // 0.5 of the 4.0 points is the number of interruptions 
            // 0.5 of the 4.0 points is max value
            



            values.Add(new TimeValuePair(dateTime, value));
        }

        public void InterpretRandom(DateTime dateTime)
        {
            double value = (new Random().NextDouble() - 0.5) * 6.0;
            values.Add(new TimeValuePair(dateTime, value));
        }

        public DateTime minTime()
        {
            DateTime winner = DateTime.MaxValue;
            foreach (TimeValuePair value in values)
            {
                if (value.time < winner)
                    winner = value.time;
            }
            return winner;
        }
    }

    public class TimeValuePair
    {
        public DateTime time;
        public double value;

        public TimeValuePair(DateTime time, double value)
        {
            this.time = time;
            this.value = value;
        }
    }
}
