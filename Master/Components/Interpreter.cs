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
                return (int) Math.Round(values[values.Count - 1].value);
        }

        public void Interpret(DateTime dateTime)
        {
            if (model.getAgentBehaviour() == Model.AgentBehaviour.ON)
            {
                values.Add(new TimeValuePair(dateTime, 0.0));
            }
            else if (model.getAgentBehaviour() == Model.AgentBehaviour.RANDOM)
            {
                double value = (new Random().NextDouble() - 0.5) * 6.0;
                values.Add(new TimeValuePair(dateTime, value));
            }   
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
