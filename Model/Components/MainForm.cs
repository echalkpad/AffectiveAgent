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
    }
}
