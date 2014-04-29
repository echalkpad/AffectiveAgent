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

        List<TimeValuePair> values;

        public Interpreter(Model model, Person personA, Person personB)
        {
            this.model = model;
            this.personA = personA;
            this.personB = personB;
        }

        public Person getPersonA()
        {
            return model.getPersonA();
        }

        public Person getPersonB()
        {
            return model.getPersonB();
        }

        public void interpret()
        {
            DateTime minTime = model.getMinTime();
        }

        public void interpret(DateTime dateTime)
        {
            double value = (new Random().NextDouble() - 0.5) * 6.0;
            values.Add(new TimeValuePair(dateTime, value));
        }
    }

    class TimeValuePair
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
