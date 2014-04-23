using Model.Data;
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
        List<Person> persons = new List<Person>();
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
            persons.Add(new Person("A"));
            persons.Add(new Person("B"));
            receiver = new Receiver(this);
            receiver.start();
            interpreter = new Interpreter(this);
            com = new COM(this);

            // Run main form
            Application.Run(this.mainForm);
        }

        public Person getPersonA()
        {
            return persons[0];
        }

        public Person getPersonB()
        {
            return persons[1];
        }

        public Person getPerson(int index)
        {
            return persons[index];
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

        public void addVideoPacket(VideoPacket videoPacket)
        {
            Person person = getPersonA();
            person.addVideoPacket(videoPacket);
            updateDataOutput();
        }

        public void addAudioPacket(AudioPacket audioPacket)
        {
            Person person = getPersonA();
            person.addAudioPacket(audioPacket);
            updateDataOutput();
        }

        public void updateDataOutput()
        {
            mainForm.updateDataOutput();
        }

        public void loadData(String text)
        {
            persons = (List<Person>) Serializer.StringToObject(text);
            updateDataOutput();
        }

        public String saveData()
        {
            return Serializer.ObjectToString(persons);
        }
    }
}
