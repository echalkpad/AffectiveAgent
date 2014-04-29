using Master.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master
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
            interpreter = new Interpreter(this, getPersonA(), getPersonB());
            com = new COM(this);

            // Run main form
            Application.Run(this.mainForm);
        }

        public List<Person> getPersons()
        {
            return persons;
        }

        public Interpreter getInterpreter()
        {
            return interpreter;
        }

        public COM getCOM()
        {
            return com;
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
            if (index >= persons.Count)
            {
                printError("The person with index " + index + " does not exist");
                return null;
            }
            return persons[index];
        }

        public Person getPerson(AudioPacket audioPacket)
        {
            return getPerson(audioPacket.person);
        }

        public Person getPerson(VideoPacket videoPacket)
        {
            return getPerson(videoPacket.person);
        }

        #region Max and min time

        public DateTime getMaxTime(List<VideoFrame> frames)
        {
            DateTime winner = DateTime.MinValue;
            foreach (VideoFrame frame in frames)
                if (frame.time > winner)
                    winner = frame.time;
            return winner;
        }

        public DateTime getMaxTime(List<AudioPacket> packets)
        {
            DateTime winner = DateTime.MinValue;
            foreach (AudioPacket packet in packets)
                if (packet.time > winner)
                    winner = packet.time;
            return winner;
        }

        public DateTime getMinTime(List<VideoFrame> frames)
        {
            DateTime winner = DateTime.MaxValue;
            foreach (VideoFrame frame in frames)
                if (frame.time < winner)
                    winner = frame.time;
            return winner;
        }

        public DateTime getMinTime(List<AudioPacket> packets)
        {
            DateTime winner = DateTime.MaxValue;
            foreach (AudioPacket packet in packets)
                if (packet.time < winner)
                    winner = packet.time;
            return winner;
        }

        public DateTime getMinTime()
        {
            DateTime video, audio;
            DateTime video1 = getMinTime(getPersonA().getVideoFrames());
            DateTime video2 = getMinTime(getPersonB().getVideoFrames());
            video = video1.CompareTo(video2) > 0 ? video1 : video2;

            DateTime audio1 = getMinTime(getPersonA().audioPackets);
            DateTime audio2 = getMinTime(getPersonB().audioPackets);
            audio = audio1.CompareTo(audio2) > 0 ? audio1 : audio2;

            return video.CompareTo(audio) > 0 ? video : audio;
        }

        public DateTime getMaxTime()
        {
            DateTime video, audio;
            DateTime video1 = getMaxTime(getPersonA().getVideoFrames());
            DateTime video2 = getMaxTime(getPersonB().getVideoFrames());
            video = video1.CompareTo(video2) < 0 ? video1 : video2;

            DateTime audio1 = getMaxTime(getPersonA().audioPackets);
            DateTime audio2 = getMaxTime(getPersonB().audioPackets);
            audio = audio1.CompareTo(audio2) < 0 ? audio1 : audio2;

            return video.CompareTo(audio) < 0 ? video : audio;
        }

        #endregion

        public void print(String text)
        {
            mainForm.print(text);
        }

        public void printError(String text)
        {
            mainForm.printError(text);
        }

        public void addVideoPacket(VideoPacket videoPacket)
        {
            getPerson(videoPacket).addVideoPacket(videoPacket);
            updateDataOutput();
        }

        public void addAudioPacket(AudioPacket audioPacket)
        {
            getPerson(audioPacket).addAudioPacket(audioPacket);
            updateDataOutput();
        }

        public void updateDataOutput()
        {
            mainForm.updateDataOutput();
        }

        public void openData(String filename)
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                String text = reader.ReadToEnd();
                persons = (List<Person>)Serializer.StringToObject(text);
                reader.Close();
            }
            catch (Exception ex)
            {
                printError("Loading failed. Exception: \r\n" + ex.Message);
            }
            updateDataOutput();
        }

        public void saveData(String filename)
        {
            String text = Serializer.ObjectToString(persons);
            try
            {
                StreamWriter writer = new StreamWriter(filename);
                writer.Write(text);
                writer.Close();
            }
            catch (Exception ex)
            {
                printError("Saving failed. Exception: \r\n" + ex.Message);
            }
        }
    }
}
