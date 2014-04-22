using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model
{
    public class Model
    {
        Person personA;
        Person personB;
        Receiver receiver;
        Interpreter interpreter;
        COM com;
        MainForm mainForm;

        public Model()
        {
            // Initialize main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            this.mainForm = new MainForm(this);

            // Initialize other components
            personA = new Person("A");
            personB = new Person("B");
            receiver = new Receiver(this);
            interpreter = new Interpreter(this);
            com = new COM(this);

            // Run main form
            Application.Run(this.mainForm);
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

        public void print(String text)
        {
            mainForm.print(text);
        }

    }
}
