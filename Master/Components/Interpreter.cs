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
        public List<ValenceData> values = new List<ValenceData>();

        public Interpreter(Model model, Person personA, Person personB)
        {
            this.model = model;
            this.personA = personA;
            this.personB = personB;
        }

        public void Clear()
        {
            values = new List<ValenceData>();
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
                return -3;
            else
            {
                int value = (int)Math.Round(values[values.Count - 1].value);

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

        public void InterpretOn(DateTime end)
        {
            DateTime start = end.Subtract(new TimeSpan(0, 1, 0));
            List<VideoFrame> framesA = getPersonA().VideoFramesWithinRange(start, end);
            List<VideoFrame> framesB = getPersonB().VideoFramesWithinRange(start, end);
            List<AudioPacket> audioA = getPersonA().AudioPacketsWithinRange(start, end);
            List<AudioPacket> audioB = getPersonB().AudioPacketsWithinRange(start, end);

            // 4.0 point of the 8.0 points are the valence of people
            // 3.0 of the 4.0 points is the valence
            // 0.5 of the 4.0 points is the number of interruptions 
            // 0.5 of the 4.0 points is max value
            double valenceVa = (getValenceValence(framesA) + getValenceValence(framesB)) / 2.0;
            double interruptionsVa = (getInterruptionsValence(audioA) + getInterruptionsValence(audioB)) / 2.0;
            double maxVa = (getMaxValence(audioA, getPersonA().audioPackets) + getMaxValence(audioB, getPersonB().audioPackets)) / 2.0;
            double valence = 3.0 * valenceVa + 0.5 * interruptionsVa + 0.5 * maxVa;

            // 4.0 point of the 8.0 points is the equal distribution
            // 2.5 of the 4.0 points is the valence
            // 0.5 of the 4.0 points is the speakers time
            // 0.5 of the 4.0 points is the number of interruptions 
            // 0.5 of the 4.0 points is max value
            double valenceDi = getValenceDistribution(framesA, framesB);
            double timeDi = getTimeDistribution(audioA, audioB);
            double interruptionsDi = getInterruptionsDistribution(audioA, audioB);
            double maxDi = getMaxDistribution(audioA, audioB);
            double distribution = 2.5 * valenceDi + 0.5 * timeDi + 0.5 * interruptionsDi + 0.5 * maxDi;

            double value = (valence + distribution) - 4;
            ValenceData valenceData = new ValenceData(end, value);
            valenceData.valenceVa = valenceVa;
            valenceData.interruptionsVa = interruptionsVa;
            valenceData.maxVa = maxVa;
            valenceData.valence = valence;
            valenceData.valenceDi = valenceDi;
            valenceData.timeDi = timeDi;
            valenceData.interruptionsDi = interruptionsDi;
            valenceData.maxDi = maxDi;
            valenceData.distribution = distribution;
            values.Add(valenceData);
        }

        public void InterpretRandom(DateTime dateTime)
        {
            Random random = new Random();
            double value = (random.NextDouble() - 0.5) * 6.0;
            values.Add(new ValenceData(dateTime, value));
        }

        private double getValenceValence(List<VideoFrame> frames)
        {
            int pos = frames.Count(frame => frame.valence == Data.Valence.POSITIVE);
            int neg = frames.Count(frame => frame.valence == Data.Valence.NEGATIVE);
            int neutral = frames.Count(frame => frame.valence == Data.Valence.NEUTRAL);

            double valence;
            if (pos + neg >= 10)
            {
                if (pos > 0)
                {
                    valence = neg / pos;
                }
                else
                {
                    valence = 1.0;
                }
            }
            else
            {
                valence = 0.5;
            }
            return valence;
        }

        private double getInterruptionsValence(List<AudioPacket> audioPackets)
        {
            // TODO: Max 15 interruptions?
            int count = audioPackets.Sum(packet => packet.numberOfInterruptions);
            if (count > 15)
            {
                return 0.0;
            }
            else
            {
                return 1.0 - (count / 15.0);
            }
        }

        private double getMaxValence(List<AudioPacket> lastAudioPackets, List<AudioPacket> allAudioPackets)
        {
            if (allAudioPackets.Count() <= 1)
                return 0.5;
            double average = allAudioPackets.Average(packet => packet.maxValue);
            int count = lastAudioPackets.Count(packet => packet.maxValue <= average);
            int length = lastAudioPackets.Count();
            if (length > 0)
            {
                return count / length;
            }
            else
            {
                return 0.5;
            }
        }

        private double getValenceDistribution(List<VideoFrame> framesA, List<VideoFrame> framesB)
        {
            int posA = framesA.Count(frame => frame.valence == Data.Valence.POSITIVE);
            int negA = framesA.Count(frame => frame.valence == Data.Valence.NEGATIVE);
            int neutralA = framesA.Count(frame => frame.valence == Data.Valence.NEUTRAL);
            double valenceA;
            if (posA + negA + neutralA >= 10)
                valenceA = ((double)(posA - negA)) / ((double)(posA + negA + neutralA)) + 1;
            else
                valenceA = 1;

            int posB = framesB.Count(frame => frame.valence == Data.Valence.POSITIVE);
            int negB = framesB.Count(frame => frame.valence == Data.Valence.NEGATIVE);
            int neutralB = framesB.Count(frame => frame.valence == Data.Valence.NEUTRAL);
            double valenceB;
            if (posB + negB + neutralB >= 10)
                valenceB = ((double)(posB - negB)) / ((double)(posB + negB + neutralB)) + 1;
            else
                valenceB = 1;

            return 1 - (Math.Abs(valenceA - valenceB) / 4);
        }

        private double getTimeDistribution(List<AudioPacket> audioPacketsA, List<AudioPacket> audioPacketsB)
        {
            if (audioPacketsA.Count() <= 1 || audioPacketsB.Count() <= 1)
                return 0.5;

            double timeA = audioPacketsA.Sum(packet => packet.individualsTime);
            double timeB = audioPacketsB.Sum(packet => packet.individualsTime);
            return 1 - Math.Abs(timeA - timeB) / (timeA + timeB);
        }

        private double getInterruptionsDistribution(List<AudioPacket> audioPacketsA, List<AudioPacket> audioPacketsB)
        {
            if (audioPacketsA.Count() <= 1 || audioPacketsB.Count() <= 1)
                return 0.5;

            int interruptionsA = audioPacketsA.Sum(packet => packet.numberOfInterruptions);
            int interruptionsB = audioPacketsB.Sum(packet => packet.numberOfInterruptions);
            return 1 - ((double)Math.Abs(interruptionsA - interruptionsB)) / ((double)(interruptionsA + interruptionsB));
        }

        private double getMaxDistribution(List<AudioPacket> audioPacketsA, List<AudioPacket> audioPacketsB)
        {
            if (personA.audioPackets.Count <= 1 || personB.audioPackets.Count <= 1 || audioPacketsA.Count() <= 1 || audioPacketsB.Count() <= 1)
                return 0.5;

            double averageA = personA.audioPackets.Average(packet => packet.maxValue);
            double diffA = (audioPacketsA.Sum(packet => packet.maxValue) - (averageA * audioPacketsA.Count())) / averageA;

            double averageB = personA.audioPackets.Average(packet => packet.maxValue);
            double diffB = (audioPacketsB.Sum(packet => packet.maxValue) - (averageB * audioPacketsB.Count())) / averageB;

            return 1 - Math.Abs(diffA - diffB) / (diffA + diffB);
        }

        public DateTime minTime()
        {
            DateTime winner = DateTime.MaxValue;
            foreach (ValenceData value in values)
            {
                if (value.time < winner)
                    winner = value.time;
            }
            return winner;
        }
    }

    public class ValenceData
    {
        public DateTime time;
        public double value;

        // 4.0 point of the 8.0 points are the valence of people
        // 3.0 of the 4.0 points is the valence
        // 0.5 of the 4.0 points is the number of interruptions 
        // 0.5 of the 4.0 points is max value
        public double valenceVa;
        public double interruptionsVa;
        public double maxVa;
        public double valence;

        // 4.0 point of the 8.0 points is the equal distribution
        // 2.5 of the 4.0 points is the valence
        // 0.5 of the 4.0 points is the speakers time
        // 0.5 of the 4.0 points is the number of interruptions 
        // 0.5 of the 4.0 points is max value
        public double valenceDi;
        public double timeDi;
        public double interruptionsDi;
        public double maxDi;
        public double distribution;

        public ValenceData(DateTime time, double value)
        {
            this.time = time;
            this.value = value;
        }
    }
}
