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

namespace Model
{
    public partial class MainForm : Form
    {
        Model model;
        delegate void SetTextCallback(string text);
        private Thread thread;

        public MainForm(Model model)
        {
            InitializeComponent();

            this.model = model;

            print("test1");
            print("test2");
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
            else
            {
                text = model.getPerson(0).ToString() + "\r\n\r\n" + model.getPerson(1).ToString();
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

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader("sample.txt");
                String text = reader.ReadToEnd();
                model.loadData(text);
                reader.Close();
            }
            catch (Exception ex)
            {
                printError("Loading failed. Exception: \r\n" + ex.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String text = model.saveData();
            try
            {
                StreamWriter writer = new StreamWriter("sample.txt");
                writer.Write(text);
                writer.Close();
            }
            catch (Exception ex)
            {
                printError("Saving failed. Exception: \r\n" + ex.Message);
            }
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
    }
}
