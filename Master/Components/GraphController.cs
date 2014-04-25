using Master.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace Master.Components
{
    public class GraphController
    {
        public ZedGraphControl graphControl;
        public GraphPane graphPane;
        public LineItem lineItem1, lineItem2;
        public Boolean autoScale = true;

        public GraphController(ZedGraphControl graphControl)
        {
            this.graphControl = graphControl;
            this.graphPane = graphControl.GraphPane;
            this.lineItem1 = this.graphPane.AddCurve("Person A", new PointPairList(), Color.Red, SymbolType.Diamond);
            this.lineItem2 = this.graphPane.AddCurve("Person B", new PointPairList(), Color.Blue, SymbolType.Circle);

            // Set the Titles
            this.graphPane.XAxis.Title.Text = "Time";
            this.graphPane.XAxis.Type = AxisType.Date;
        }

        public void Clear()
        {
            lineItem1.Clear();
            lineItem2.Clear();
        }

        public void CreateGraph(List<AudioPacket> packets1, List<AudioPacket> packets2, int featureIndex)
        {
            // Clear the graph
            Clear();

            // Set the titles
            graphPane.Title.Text = "Audio packets";

            // Make up some data arrays based on audio features
            double x, y1, y2;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < 36; i++)
            {
                //x = (((double)i) / 2d) * (((double)i) / 2d);
                x = i;
                if (i >= packets1.Count)
                    y1 = 0;
                else
                    y1 = packets1[i].individualsTime;

                if (i >= packets1.Count)
                    y2 = 0;
                else
                    y2 = packets2[i].individualsTime;

                list1.Add(x, y1);
                list2.Add(x, y2);
            }

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            lineItem1.Points = list1;

            // Generate a blue curve with circle symbols, and "Piper" in the legend
            lineItem2.Points = list2;

            // Tell ZedGraph to refigure the axes since the data have changed
            graphControl.AxisChange();
            if (autoScale)
                graphControl.RestoreScale(graphControl.GraphPane);
        }

        public void CreateGraph(List<VideoFrame> packets1, List<VideoFrame> packets2, int featureIndex)
        {
            // Clear the graph
            Clear();

            // Set the titles
            graphPane.Title.Text = "Video packets";

            // Make up some data arrays based on video features
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            DateTime minTime = MinTime(packets1, packets2);
            for (int i = 0; i < Math.Max(packets1.Count, packets2.Count); i++)
            {
                if (i < packets1.Count)
                {
                    double x1 = ComputeX(minTime, packets1[i].time);
                    double y1 = 0;
                    switch (featureIndex)
                    {
                        case 0:
                            graphPane.YAxis.Title.Text = "Anger";
                            y1 = ComputeEmotionIntensity(packets1[i], Emotion.ANGER);
                            break;
                        case 1:
                            graphPane.YAxis.Title.Text = "Contempt";
                            y1 = ComputeEmotionIntensity(packets1[i], Emotion.CONTEMPT);
                            break;
                        case 2:
                            graphPane.YAxis.Title.Text = "Disgust";
                            y1 = ComputeEmotionIntensity(packets1[i], Emotion.DISGUST);
                            break;
                        case 3:
                            graphPane.YAxis.Title.Text = "Fear";
                            y1 = ComputeEmotionIntensity(packets1[i], Emotion.FEAR);
                            break;
                        case 4:
                            graphPane.YAxis.Title.Text = "Joy";
                            y1 = ComputeEmotionIntensity(packets1[i], Emotion.JOY);
                            break;
                        case 5:
                            graphPane.YAxis.Title.Text = "Sadness";
                            y1 = ComputeEmotionIntensity(packets1[i], Emotion.SADNESS);
                            break;
                        case 6:
                            graphPane.YAxis.Title.Text = "Surprise";
                            y1 = ComputeEmotionIntensity(packets1[i], Emotion.SURPRISE);
                            break;
                        case 7:
                            graphPane.YAxis.Title.Text = "Emotion intensity";
                            y1 = packets1[i].emotionIntensity;
                            break;
                        case 8:
                            graphPane.YAxis.Title.Text = "Valence";
                            y1 = ComputeValenceIntensity(packets1[i]);
                            break;
                        case 9:
                            graphPane.YAxis.Title.Text = "Valence intensity";
                            y1 = packets1[i].valenceIntensity;
                            break;
                    }
                    list1.Add(x1, y1);
                }

                if (i < packets2.Count)
                {
                    double x2 = ComputeX(minTime, packets2[i].time);
                    double y2 = 0;
                    switch (featureIndex)
                    {
                        case 0:
                            graphPane.YAxis.Title.Text = "Anger";
                            y2 = ComputeEmotionIntensity(packets2[i], Emotion.ANGER);
                            break;
                        case 1:
                            graphPane.YAxis.Title.Text = "Contempt";
                            y2 = ComputeEmotionIntensity(packets2[i], Emotion.CONTEMPT);
                            break;
                        case 2:
                            graphPane.YAxis.Title.Text = "Disgust";
                            y2 = ComputeEmotionIntensity(packets2[i], Emotion.DISGUST);
                            break;
                        case 3:
                            graphPane.YAxis.Title.Text = "Fear";
                            y2 = ComputeEmotionIntensity(packets2[i], Emotion.FEAR);
                            break;
                        case 4:
                            graphPane.YAxis.Title.Text = "Joy";
                            y2 = ComputeEmotionIntensity(packets2[i], Emotion.JOY);
                            break;
                        case 5:
                            graphPane.YAxis.Title.Text = "Sadness";
                            y2 = ComputeEmotionIntensity(packets2[i], Emotion.SADNESS);
                            break;
                        case 6:
                            graphPane.YAxis.Title.Text = "Surprise";
                            y2 = ComputeEmotionIntensity(packets2[i], Emotion.SURPRISE);
                            break;
                        case 7:
                            y2 = packets2[i].emotionIntensity;
                            break;
                        case 8:
                            y2 = ComputeValenceIntensity(packets2[i]);
                            break;
                        case 9:
                            y2 = packets2[i].valenceIntensity;
                            break;
                    }
                    list2.Add(x2, y2);
                }
            }

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            lineItem1.Points = list1;

            // Generate a blue curve with circle
            // symbols, and "Piper" in the legend
            lineItem2.Points = list2;

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            graphControl.AxisChange();
            if (autoScale)
                graphControl.RestoreScale(graphControl.GraphPane);
        }

        public double ComputeEmotionIntensity(VideoFrame frame, Emotion emotion)
        {
            if (frame.emotion == emotion)
                return frame.emotionIntensity;
            else
                return 0;
        }

        public double ComputeValenceIntensity(VideoFrame frame)
        {
            int weight = 0;
            if (frame.valence == Valence.NEGATIVE)
                weight = -1;
            else if (frame.valence == Valence.POSITIVE)
                weight = 1;
            else if (frame.valence == Valence.NEUTRAL)
                weight = 0;
            return frame.valenceIntensity * (double)weight;
        }

        public DateTime MaxTime(List<VideoFrame> frames)
        {
            DateTime winner = DateTime.MinValue;
            foreach (VideoFrame frame in frames)
                if (frame.time > winner)
                    winner = frame.time;
            return winner;
        }

        public DateTime MaxTime(List<AudioPacket> packets)
        {
            DateTime winner = DateTime.MinValue;
            foreach (AudioPacket packet in packets)
                    if (packet.time > winner)
                        winner = packet.time;
            return winner;
        }

        public DateTime MinTime(List<VideoFrame> frames)
        {
            DateTime winner = DateTime.MaxValue;
            foreach (VideoFrame frame in frames)
                if (frame.time < winner)
                    winner = frame.time;
            return winner;
        }

        public DateTime MinTime(List<AudioPacket> packets)
        {
            DateTime winner = DateTime.MaxValue;
            foreach (AudioPacket packet in packets)
                if (packet.time < winner)
                    winner = packet.time;
            return winner;
        }

        public DateTime MinTime(List<VideoFrame> frames1, List<VideoFrame> frames2)
        {
            DateTime minTime1 = MinTime(frames1);
            DateTime minTime2 = MinTime(frames2);
            if (minTime1.CompareTo(minTime2) > 0)
                return minTime1;
            else
                return minTime2;
        }

        public DateTime MinTime(List<AudioPacket> packets1, List<AudioPacket> packets2)
        {
            DateTime minTime1 = MinTime(packets1);
            DateTime minTime2 = MinTime(packets2);
            if (minTime1.CompareTo(minTime2) > 0)
                return minTime1;
            else
                return minTime2;
        }

        public double ComputeX(DateTime minTime, DateTime time)
        {
            return time.Subtract(minTime).TotalDays;
        }
    }
}
