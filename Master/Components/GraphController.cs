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

        public GraphController(ZedGraphControl graphControl)
        {
            this.graphControl = graphControl;
            this.graphPane = graphControl.GraphPane;
            this.lineItem1 = this.graphPane.AddCurve("Person A", new PointPairList(), Color.Red, SymbolType.Diamond);
            this.lineItem2 = this.graphPane.AddCurve("Person B", new PointPairList(), Color.Blue, SymbolType.Circle);
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

            // Set the Titles
            graphPane.Title.Text = "My Test Graph\n";
            graphPane.XAxis.Title.Text = "Time";
            graphPane.YAxis.Title.Text = "Individuals time";

            // Make up some data arrays based on audio features
            double x, y1, y2;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < 36; i++)
            {
                x = (double)i + 5;

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
            graphControl.RestoreScale(graphControl.GraphPane);
        }

        public void CreateGraph(List<VideoFrame> packets1, List<VideoFrame> packets2, int featureIndex)
        {
            // Clear the graph
            Clear();

            // Set the Titles
            graphPane.Title.Text = "My Test Graph\n";
            graphPane.XAxis.Title.Text = "Time";
            graphPane.YAxis.Title.Text = "Emotion";

            // Make up some data arrays based on video features
            double x, y1 = 0, y2 = 0;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < Math.Max(packets1.Count, packets2.Count); i++)
            {
                x = (double)i + 5;

                if (i < packets1.Count)
                {
                    switch (featureIndex)
                    {
                        case 0:
                            break;
                        case 1:
                            y1 = packets1[i].emotionIntensity;
                            break;
                        case 2:
                            y1 = ComputeValenceIntensity(packets1[i]);
                            break;
                        case 3:
                            y1 = packets1[i].valenceIntensity;
                            break;
                    }
                }

                if (i < packets2.Count)
                {
                    switch (featureIndex)
                    {
                        case 0:
                            break;
                        case 1:
                            y2 = packets2[i].emotionIntensity;
                            break;
                        case 2:
                            y2 = ComputeValenceIntensity(packets2[i]);
                            break;
                        case 3:
                            y2 = packets2[i].valenceIntensity;
                            break;
                    }
                }

                list1.Add(x, y1);
                list2.Add(x, y2);
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
            graphControl.RestoreScale(graphControl.GraphPane);
        }

        public void test(List<AudioPacket> packets1, List<AudioPacket> packets2)
        {
            // clear the graph
            Clear();

            // Set the Titles
            graphPane.Title.Text = "My Test Graph\n";
            graphPane.XAxis.Title.Text = "Time";
            graphPane.YAxis.Title.Text = "Individuals time";

            // Make up some data arrays based on the Sine function
            double x, y1, y2;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < 36; i++)
            {
                x = (double)i + 5;

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

            // Generate a blue curve with circle
            // symbols, and "Piper" in the legend
            lineItem2.Points = list2;

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            graphControl.AxisChange();
            graphControl.RestoreScale(graphPane);
            graphControl.Refresh();
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

    }
}
