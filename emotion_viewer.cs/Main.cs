using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionViewer
{
    public class Main
    {
        MainForm mainForm;
        Sender sender;

        public Main()
        {
            // TODO: Make it possible to adjust the name of the person
            this.sender = new Sender("PersonA");

            // Start up main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PXCMSession session;
            pxcmStatus sts = PXCMSession.CreateInstance(out session);
            if (sts >= pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                this.mainForm = new MainForm(this, session);
                Application.Run(this.mainForm);
                session.Dispose();
            }
        }

        public Sender getSender()
        {
            return sender;
        }

        private MainForm getMainForm()
        {
            return mainForm;
        }
    }
}
