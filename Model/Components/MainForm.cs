using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public void print(String text)
        {
            text += "\r\n";
            this.thread = new Thread(new ThreadStart(this.ThreadProcSafe));

            this.thread.Start();
            if (outputTextbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(print);
                outputTextbox.Invoke(d, new object[] { text });
            }
            else
            {
                outputTextbox.AppendText(text);
            }
        }

        // This method is executed on the worker thread and makes 
        // a thread-safe call on the TextBox control. 
        private void ThreadProcSafe()
        {
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            model.loadData();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            model.saveData();
        }


    }
}
