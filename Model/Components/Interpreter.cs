using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    class Interpreter
    {
        Main model; 

        public Interpreter(Main model)
        {
            this.model = model;
        }

        public Person getPersonA()
        {
            return model.getPersonA();
        }

        public Person getPersonB()
        {
            return model.getPersonB();
        }
    }
}
