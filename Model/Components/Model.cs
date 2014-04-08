using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Model
    {
        Person personA;
        Person personB;
        Receiver receiver;
        Interpreter interpreter;
        COM com;

        public Model()
        {
            personA = new Person("A");
            personB = new Person("B");
            receiver = new Receiver(this);
            interpreter = new Interpreter(this);
            com = new COM(this);
        }

        public Person getPersonA()
        {
            return personA;
        }

        public Person getPersonB()
        {
            return personB;
        }

        public Interpreter getInterpreter()
        {
            return interpreter;
        }

        public COM getCOM()
        {
            return com;
        }

    }
}
