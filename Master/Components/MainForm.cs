using Master.Components;
using Master.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Master
{
    public partial class MainForm : Form
    {
        Model model;
        GraphController graphController;
        delegate void SetTextCallback(string text);
        private Thread thread;
        private int selectedPacketIndex = -1;
        private int selectedFeatureIndex = -1;
        private Boolean updateGraphAxisNow = false;

        public MainForm(Model model)
        {
            InitializeComponent();

            this.model = model;
            this.graphController = new GraphController(model, graphControl);
            this.updateGraphTimer.Start();
            this.updateCOMTimer.Start();
        }

        public Boolean isLiveGraph()
        {
            return liveCheckBox.Checked;
        }

        public void CreateGraph()
        {
            if (selectedPacketIndex == 0)
            {
                List<AudioPacket> packets1 = model.getPersonA().audioPackets;
                List<AudioPacket> packets2 = model.getPersonB().audioPackets;
                graphController.CreateGraph(packets1, packets2, selectedFeatureIndex);
            }
            else if (selectedPacketIndex == 1)
            {
                List<VideoFrame> packets1 = model.getPersonA().getVideoFrames();
                List<VideoFrame> packets2 = model.getPersonB().getVideoFrames();
                graphController.CreateGraph(packets1, packets2, selectedFeatureIndex);
            }
            else if (selectedPacketIndex == 2)
            {
                graphController.CreateGraph(selectedFeatureIndex);
            }
            else
            {
                graphController.CreateGraph();
            }
        }

        public void UpdateGraphAxis(Boolean boolean)
        {
            if (boolean)
                updateGraphAxisNow = true;
            else
                graphControl.RestoreScale(graphControl.GraphPane);
        }

        public void updateDataOutput()
        {
            if (showDataRadioButton.Checked)
            {
                print("");
            }
        }

        public void UpdateAgentBehaviour()
        {
            if (agentOffRadioButton.Checked)
            {
                model.setAgentBehaviour(Model.AgentBehaviour.OFF);
            }
            else if (agentRandomRadioButton.Checked)
            {
                model.setAgentBehaviour(Model.AgentBehaviour.RANDOM);
            }
            else if (agentOnRadioButton.Checked)
            {
                model.setAgentBehaviour(Model.AgentBehaviour.ON);
            }

        }

        public void print(String text)
        {
            if (showConsoleRadioButton.Checked)
            {
                text = outputTextbox.Text + text + "\r\n";
            }
            else if (showDataRadioButton.Checked)
            {
                text = model.getPerson(0).ToString() + "\r\n\r\n" + model.getPerson(1).ToString();
            }
            else if (showNothingRadioButton.Checked)
            {
                text = "";
            }

            this.thread = new Thread(new ThreadStart(this.ThreadProcSafe));
            this.thread.Start();
            if (outputTextbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(print);
                outputTextbox.Invoke(d, new object[] { text });
            }
            else
            {
                outputTextbox.Text = text;
            }
        }

        public void printError(String text)
        {
            showConsoleRadioButton.Checked = true;

            print(text);
        }

        // This method is executed on the worker thread and makes 
        // a thread-safe call on the TextBox control. 
        private void ThreadProcSafe()
        {
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void showDataRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            outputTextbox.Clear();
            updateDataOutput();
        }

        private void showConsoleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            outputTextbox.Clear();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            model.openData(openFileDialog.FileName);
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            model.saveData(saveFileDialog.FileName);
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            CreateGraph();
        }

        private void PacketListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            featureListBox.Items.Clear();
            if (PacketListBox.SelectedIndex == 0)
            {
                featureListBox.Items.Add("Individual's time");
                featureListBox.Items.Add("Number of interruptions");
                featureListBox.Items.Add("Maximal value");
            }
            else if (PacketListBox.SelectedIndex == 1)
            {
                foreach (Emotion emotion in Constants.GetEmotions())
                {
                    featureListBox.Items.Add(Constants.PrintEmotion(emotion));
                }
                featureListBox.Items.Add("Emotion intensity");
                featureListBox.Items.Add("Valence");
                featureListBox.Items.Add("Valence intensity");
            }
            else if (PacketListBox.SelectedIndex == 2)
            {
                featureListBox.Items.Add("Valence");
                featureListBox.Items.Add("Interruptions");
                featureListBox.Items.Add("Max value");
                featureListBox.Items.Add("Total valence");
                featureListBox.Items.Add("Valence distribution");
                featureListBox.Items.Add("Speaker's time distribution");
                featureListBox.Items.Add("Interruptions distribution");
                featureListBox.Items.Add("Max value distribution");
                featureListBox.Items.Add("Total distribution");
                featureListBox.Items.Add("All");
            }

            selectedPacketIndex = PacketListBox.SelectedIndex;
            selectedFeatureIndex = -1;
        }

        private void showNothingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (showNothingRadioButton.Checked)
            {
                outputTextbox.Clear();
            }
        }

        private void liveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (liveCheckBox.Checked)
            {
                updateGraphTimer.Start();
            }
            else
            {
                updateGraphTimer.Stop();
            }
        }

        private void featureListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFeatureIndex = featureListBox.SelectedIndex;
        }

        private void updateGraphTimer_Tick(object sender, EventArgs e)
        {
            if (isLiveGraph())
            {
                CreateGraph();
            }
        }

        private void AutoResizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            graphController.autoScale = AutoResizeCheckBox.Checked;
        }

        private void newDataButton_Click(object sender, EventArgs e)
        {
            foreach (Person p in model.getPersons())
            {
                p.Clear();
            }
            print("");
            graphController.Clear();
        }

        private void clearGraphButton_Click(object sender, EventArgs e)
        {
            PacketListBox.ClearSelected();
            graphController.Clear();
        }

        private void agentOffRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAgentBehaviour();
        }

        private void agentRandomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAgentBehaviour();
        }

        private void agentOnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAgentBehaviour();
        }

        private void updateCOMTimer_Tick(object sender, EventArgs e)
        {
            if (!agentOffRadioButton.Checked)
            {
                int state = model.getInterpreter().Update();
                model.getCOM().switchState(state);
            }
        }
    }
}
