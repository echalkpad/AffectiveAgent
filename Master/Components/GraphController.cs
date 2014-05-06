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
        public LineItem lineItemA, lineItemB, lineItemAgent;
        public Boolean autoScale = true;
        public Interpreter interpreter
        {
            get { return model.getInterpreter(); }
        }
        double min;
        double max;

        public GraphController(Model model, ZedGraphControl graphControl)
        {
            this.model = model;
            this.graphControl = graphControl;
            this.graphPane = graphControl.GraphPane;

            // Initialize lines
            this.lineItemA = this.graphPane.AddCurve("Person A", new PointPairList(), Color.Red, SymbolType.Diamond);
            this.lineItemB = this.graphPane.AddCurve("Person B", new PointPairList(), Color.Blue, SymbolType.Circle);
            this.lineItemAgent = this.graphPane.AddCurve("Agent", new PointPairList(), Color.Green, SymbolType.Star);
            this.lineItemAgent.IsY2Axis = true;

            // Set the Titles
            this.graphPane.Title.Text = "Graph of persons' data and the agent's state";
            this.graphPane.XAxis.Title.Text = "Time";
            this.graphPane.XAxis.Type = AxisType.Date;
            this.graphPane.Y2Axis.Title.Text = "Agent's state";
            this.graphPane.YAxis.Scale.Min = -4;
            this.graphPane.YAxis.Scale.Max = 4;
            this.graphPane.Y2Axis.Scale.Min = -4;
            this.graphPane.Y2Axis.Scale.Max = 4;
            this.graphPane.Y2Axis.IsVisible = true;

            // Update threshold lines
            UpdateThresholdLines();
        }

        public void Clear()
        {
            // Reset min and max
            min = 0.0;
            max = 0.0;

            // Clear data
            lineItemA.Clear();
            lineItemB.Clear();
            lineItemAgent.Clear();

            // Refresh threshold lines
            UpdateThresholdLines();

            // Update titles
            graphPane.YAxis.Title.Text = "";
        }

        // Create empty graph
        public void CreateGraph()
        {
            // Clear the graph
            Clear();

            // Set the titles
            graphPane.YAxis.Title.Text = "";

            // Make up some data arrays based on video features
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            // Add points
            lineItemA.Points = list1;
            lineItemB.Points = list2;

            // Add agent's graph
            CreateAgentGraph();

            // Tell ZedGraph to refigure the axis since the data have changed
            Rescale();
        }

        // Create audio data graph
        public void CreateGraph(List<AudioPacket> packets1, List<AudioPacket> packets2, int featureIndex)
        {
            // Clear the graph
            Clear();

            // Set the titles
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
                    if (y1 < min)
                        min = y1;
                    if (y1 > max)
                        max = y1;
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
                    if (y2 < min)
                        min = y2;
                    if (y2 > max)
                        max = y2;
                    list2.Add(x2, y2);
                }
            }

            // Add points
            lineItemA.Points = list1;
            lineItemB.Points = list2;

            // Add agent's graph
            CreateAgentGraph();

            // Tell ZedGraph to refigure the axis since the data have changed
            Rescale();
        }

        // Create video data graph
        public void CreateGraph(List<VideoFrame> packets1, List<VideoFrame> packets2, int featureIndex)
        {
            // Clear the graph
            Clear();

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
                    if (y1 < min)
                        min = y1;
                    if (y1 > max)
                        max = y1;
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
                    if (y2 < min)
                        min = y2;
                    if (y2 > max)
                        max = y2;
                    list2.Add(x2, y2);
                }
            }

            // Add points
            lineItemA.Points = list1;
            lineItemB.Points = list2;

            // Add agent's graph
            CreateAgentGraph();

            // Tell ZedGraph to refigure the axis since the data have changed
            Rescale();
        }

        // Create agent's state graph
        public void CreateGraph(int featureIndex)
        {
            // Clear the graph
            Clear();

            // Set the titles
            graphPane.Title.Text = "Agent's state";
            graphPane.YAxis.Title.Text = "";

            // Get points
            PointPairList list = new PointPairList();
            DateTime minTime = interpreter.minTime();
            foreach (ValenceData value in interpreter.values)
            {
                double x = ComputeX(minTime, value.time);
                double y = 0;
                switch (featureIndex)
                {
                    case 0:
                        y = value.valenceVa;
                        graphPane.YAxis.Title.Text = "Valence";
                        break;
                    case 1:
                        y = value.interruptionsVa;
                        graphPane.YAxis.Title.Text = "Interruptions";
                        break;
                    case 2:
                        y = value.maxVa;
                        graphPane.YAxis.Title.Text = "Max value";
                        break;
                    case 3:
                        y = value.valence;
                        graphPane.YAxis.Title.Text = "Total valence";
                        break;
                    case 4:
                        y = value.valenceDi;
                        graphPane.YAxis.Title.Text = "Valence distribution";
                        break;
                    case 5:
                        y = value.timeDi;
                        graphPane.YAxis.Title.Text = "Speaker's time distribution";
                        break;
                    case 6:
                        y = value.interruptionsDi;
                        graphPane.YAxis.Title.Text = "Interruptions distribution";
                        break;
                    case 7:
                        y = value.maxDi;
                        graphPane.YAxis.Title.Text = "Max value distribution";
                        break;
                    case 8:
                        y = value.distribution;
                        graphPane.YAxis.Title.Text = "Total distribution";
                        break;
                    case 9:
                        y = value.value;
                        graphPane.YAxis.Title.Text = "All";
                        break;
                }
                list.Add(new PointPair(x, y));
            }
            lineItemAgent.Points = list;

            // Refresh graph
            UpdateThresholdLines();

            // Tell ZedGraph to refigure the axis since the data have changed
            Rescale();
        }

        public void CreateAgentGraph()
        {
            // Get points
            PointPairList list = new PointPairList();
            DateTime minTime = interpreter.minTime();
            foreach (ValenceData value in interpreter.values)
            {
                double x = ComputeX(minTime, value.time);
                double y = value.value;
                list.Add(new PointPair(x, y));
            }
            lineItemAgent.Points = list;

            // Refresh graph
            UpdateThresholdLines();          
        }

        public void Rescale()
        {
            if (min == max)
            {
                min = min - 1;
                max = max + 1;
            }
            graphPane.YAxis.Scale.Min = min;
            graphPane.YAxis.Scale.Max = max;
            graphPane.Y2Axis.Scale.Min = -4;
            graphPane.Y2Axis.Scale.Max = 4;
            graphControl.AxisChange();
            graphControl.Refresh();
        }

        public void UpdateThresholdLines()
        {
            for (int i = -3; i <= 4; i++)
            {
                double j = (double)i - 0.5;
                LineObj threshHoldLine = new LineObj(Color.FromArgb(255, 175 - ((int)(Math.Abs(j) * 25)), 175 - ((int)(Math.Abs(j) * 25))), graphPane.XAxis.Scale.Min, j, graphPane.XAxis.Scale.Max, j);
                threshHoldLine.ZOrder = ZOrder.D_BehindAxis;
                threshHoldLine.Location.CoordinateFrame = CoordType.AxisXY2Scale;
                graphPane.GraphObjList.Add(threshHoldLine);
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
