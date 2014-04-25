using Master.Components;
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

        public MainForm(Model model)
        {
            InitializeComponent();

            this.model = model;
            this.graphController = new GraphController(graphControl);
        }

        public void updateDataOutput()
        {
            if (showDataRadioButton.Checked)
            {
                print("");
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
                text = text;
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
            if (PacketListBox.SelectedIndex == 0)
            {
                List<AudioPacket> packets1 = model.getPersonA().audioPackets;
                List<AudioPacket> packets2 = model.getPersonB().audioPackets;
                graphController.CreateGraph(packets1, packets2, featureListBox.SelectedIndex);
            }
            else if (PacketListBox.SelectedIndex == 1)
            {
                List<VideoFrame> packets1 = new List<VideoFrame>();
                foreach (VideoPacket packet in model.getPersonA().videoPackets)
                {
                    foreach (VideoFrame frame in packet.videoFrames)
                        packets1.Add(frame);
                }

                List<VideoFrame> packets2 = new List<VideoFrame>();
                foreach (VideoPacket packet in model.getPersonB().videoPackets)
                {
                    foreach (VideoFrame frame in packet.videoFrames)
                        packets2.Add(frame);
                }
                graphController.CreateGraph(packets1, packets2, featureListBox.SelectedIndex);
            }
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
                featureListBox.Items.Add("Emotion");
                featureListBox.Items.Add("Emotion intensity");
                featureListBox.Items.Add("Valence");
                featureListBox.Items.Add("Valence intensity");
            }
        }

        private void showNothingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            outputTextbox.Clear();
        }
    }
}
