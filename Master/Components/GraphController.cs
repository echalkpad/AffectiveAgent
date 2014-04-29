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
        public Model model;
        public ZedGraphControl graphControl;
        public GraphPane graphPane;
        public LineItem lineItem1, lineItem2;
        public Boolean autoScale = true;
        public List<LineObj> threshHoldLines = new List<LineObj>();

        public GraphController(Model model, ZedGraphControl graphControl)
        {
            this.model = model;
            this.graphControl = graphControl;
            this.graphPane = graphControl.GraphPane;
            this.lineItem1 = this.graphPane.AddCurve("Person A", new PointPairList(), Color.Red, SymbolType.Diamond);
            this.lineItem2 = this.graphPane.AddCurve("Person B", new PointPairList(), Color.Blue, SymbolType.Circle);

            // Set the Titles
            this.graphPane.XAxis.Title.Text = "Time";
            this.graphPane.XAxis.Type = AxisType.Date;

            // Initialize threshold lines
            for (int i = -3; i <= 3; i++)
            {
                LineObj threshHoldLine = new LineObj(Color.FromArgb(255, 175 - (Math.Abs(i) * 25), 175 - (Math.Abs(i) * 25)), graphPane.XAxis.Scale.Min, i, graphPane.XAxis.Scale.Max, i);
                threshHoldLine.Location.CoordinateFrame = CoordType.AxisXYScale;
                threshHoldLine.ZOrder = ZOrder.D_BehindAxis;
                threshHoldLine.IsVisible = false;
                graphPane.GraphObjList.Add(threshHoldLine);
                threshHoldLines.Add(threshHoldLine);
            }
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
            EnableThresholdLines(false);

            // Set the titles
            graphPane.Title.Text = "Audio packets";
            graphPane.YAxis.Title.Text = "";

            // Make up some data arrays based on video features
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            DateTime minTime = model.getMinTime();
            for (int i = 0; i < Math.Max(packets1.Count, packets2.Count); i++)
            {
                // Packets of person A
                if (i < packets1.Count)
                {
                    double x1 = ComputeX(minTime, packets1[i].time);
                    double y1 = 0;
                    switch (featureIndex)
                    {
                        case 0:
                            graphPane.YAxis.Title.Text = "Individual's time";
                            y1 = packets1[i].individualsTime;
                            break;
                        case 1:
                            graphPane.YAxis.Title.Text = "Number of interruptions";
                            y1 = packets1[i].numberOfInterruptions;
                            break;
                        case 2:
                            graphPane.YAxis.Title.Text = "Maximal value";
                            y1 = packets1[i].maxValue;
                            break;
                    }
                    list1.Add(x1, y1);
                }

                // Packets of person B
                if (i < packets2.Count)
                {
                    double x2 = ComputeX(minTime, packets2[i].time);
                    double y2 = 0;
                    switch (featureIndex)
                    {
                        case 0:
                            graphPane.YAxis.Title.Text = "Individual's time";
                            y2 = packets2[i].individualsTime;
                            break;
                        case 1:
                            graphPane.YAxis.Title.Text = "Number of interruptions";
                            y2 = packets2[i].numberOfInterruptions;
                            break;
                        case 2:
                            graphPane.YAxis.Title.Text = "Maximal value";
                            y2 = packets2[i].maxValue;
                            break;
                    }
                    list2.Add(x2, y2);
                }
            }

            // Add points
            lineItem1.Points = list1;
            lineItem2.Points = list2;

            // Tell ZedGraph to refigure the axis since the data have changed
            graphControl.AxisChange();
            if (autoScale)
                graphControl.RestoreScale(graphControl.GraphPane);
        }

        public void CreateGraph(List<VideoFrame> packets1, List<VideoFrame> packets2, int featureIndex)
        {
            // Clear the graph
            Clear();
            EnableThresholdLines(false);

            // Set the titles
            graphPane.Title.Text = "Video packets";
            graphPane.YAxis.Title.Text = "";

            // Make up some data arrays based on video features
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            DateTime minTime = model.getMinTime();
            for (int i = 0; i < Math.Max(packets1.Count, packets2.Count); i++)
            {
                // Packets of person A
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

                // Packets of person B
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
                            graphPane.YAxis.Title.Text = "Emotion intensity";
                            y2 = packets2[i].emotionIntensity;
                            break;
                        case 8:
                            graphPane.YAxis.Title.Text = "Valence";
                            y2 = ComputeValenceIntensity(packets2[i]);
                            break;
                        case 9:
                            graphPane.YAxis.Title.Text = "Valence intensity";
                            y2 = packets2[i].valenceIntensity;
                            break;
                    }
                    list2.Add(x2, y2);
                }
            }

            // Add points
            lineItem1.Points = list1;
            lineItem2.Points = list2;

            // Tell ZedGraph to refigure the axis since the data have changed
            graphControl.AxisChange();
            if (autoScale)
                graphControl.RestoreScale(graphControl.GraphPane);
        }

        public void CreateGraph(Interpreter interPreter)
        {
            // Clear the graph
            Clear();

            // Set the titles
            graphPane.Title.Text = "Video packets";
            graphPane.YAxis.Title.Text = "Agent's state";
            graphPane.YAxis.Scale.Min = -4;
            graphPane.YAxis.Scale.Max = 4;

            // Enable threshold lines
            EnableThresholdLines(true);

            // Make up some data arrays based on video features
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();


            
            
            /*DateTime minTime = MinTime(packets1, packets2);
            for (int i = 0; i < Math.Max(packets1.Count, packets2.Count); i++)
            {
                // Packets of person A
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

                // Packets of person B
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
                            graphPane.YAxis.Title.Text = "Emotion intensity";
                            y2 = packets2[i].emotionIntensity;
                            break;
                        case 8:
                            graphPane.YAxis.Title.Text = "Valence";
                            y2 = ComputeValenceIntensity(packets2[i]);
                            break;
                        case 9:
                            graphPane.YAxis.Title.Text = "Valence intensity";
                            y2 = packets2[i].valenceIntensity;
                            break;
                    }
                    list2.Add(x2, y2);
                }
            }*/

            // Add points
            lineItem1.Points = list1;
            lineItem2.Points = list2;

            // Tell ZedGraph to refigure the axis since the data have changed
            graphControl.Refresh();
            //if (autoScale)
            //    graphControl.RestoreScale(graphControl.GraphPane);
        }

        public void EnableThresholdLines(Boolean enable)
        {
            for (int i = 0; i < threshHoldLines.Count; i++)
            {
                threshHoldLines[i].IsVisible = enable;
            }
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

        public double ComputeX(DateTime minTime, DateTime time)
        {
            return time.Subtract(minTime).TotalDays;
        }
    }
}
