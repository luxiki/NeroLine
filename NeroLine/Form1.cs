using System;
using System.Windows.Forms;

namespace Nero_Wiev
{

    public interface IForm {
        string FilePath { get; }
        int GetNeroLine();
        void SetMsg(string msg);
        void SetButSaveFile(bool state);
        event EventHandler FileSave;
        event EventHandler FileOpen;
        event EventHandler<EventArgString> AddSmd;
    }

    public partial class Form1 : Form,IForm
    {
        private string filePath;
        public Form1()
        {
            InitializeComponent();
            butOpen.Click += ButOpen_Click;
            butSave.Click += ButSave_Click;
            butAdd.Click += ButAdd_Click;
        }




        #region Event

        private void ButOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Теккстовые фаилы|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK) {
                filePath = dialog.FileName;
                if (FileOpen != null) { FileOpen(this, EventArgs.Empty); }
            }

        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (FileSave != null) { FileSave(this, EventArgs.Empty); }
        }

        private void ButAdd_Click(object sender, EventArgs e)
        {
            AddSmdForm form = new AddSmdForm();
            form.ShowDialog();
            EventArgString arg = new EventArgString(Convert.ToString(numericLine.Value),form.SmdName,form.SmdRotate);
            if(arg.strArg2 != null && arg.strArg3 != null)
            {
                AddSmd(this, arg);
            }
        }


        #endregion

        #region Interface

        public string FilePath
        {
            get
            {
                return filePath;
            }

        }

        public int GetNeroLine()
        {
            return (int)numericLine.Value;
        }

        public void SetMsg(string msg)
        {
            toolStripStatusLabel1.Text = msg;
        }

        public void SetButSaveFile(bool state)
        {
            butSave.Enabled = state;
        }

        public event EventHandler FileSave;
        public event EventHandler FileOpen;
        public event EventHandler<EventArgString> AddSmd;

        #endregion


    }

    public class EventArgString : EventArgs
    {
        public EventArgString(string stringArg1 , string stringArg2 , string stringArg3)
        {
            strArg1 = stringArg1;
            strArg2 = stringArg2;
            strArg3 = stringArg3;
        }

        public string strArg1 { get; private set; }
        public string strArg2 { get; private set; }
        public string strArg3 { get; private set; }
    }

}
