using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormInterface
{
    public interface IInputForm
    {
        string FilePath { get; }
        string Content { get; set; }
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ButProcessingClick;
        event EventHandler ButAlterChangeClick;
        void ShowForm();
        void ShowButProcessing();
        void ShowButAlterChange();

    }
    public partial class InputForm : Form, IInputForm
    {
        public InputForm()
        {
            InitializeComponent();
            butOpenFile.Click += ButOpenFile_Click;
            butSelectFile.Click += ButSelectFile_Click;
            butSaveFile.Click += ButSaveFile_Click;
            butProcessingMatrix.Click += ButProcessingMatrix_Click;
            butAlterChange.Click += ButAlterChange_Click;
        }

        private void ButAlterChange_Click(object sender, EventArgs e)
        {
            ButAlterChangeClick(this, null);
        }

        private void ButProcessingMatrix_Click(object sender, EventArgs e)
        {
            ButProcessingClick(this, null);
        }

        private void ButSaveFile_Click(object sender, EventArgs e)
        {
            FileSaveClick(this, EventArgs.Empty);
        }

        private void ButSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePathSelection.Text = dlg.FileName;

                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        private void ButOpenFile_Click(object sender, EventArgs e)
        {
            FileOpenClick(this, EventArgs.Empty);
        }
        public string FilePath
        {
            get { return filePathSelection.Text; }
        }

        public string Content
        {
            get { return fldContent.Text; }
            set { fldContent.Text = value; }
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ButProcessingClick;
        public event EventHandler ButAlterChangeClick;
        public void ShowForm()
        {
            this.ShowDialog();
        }
        public void ShowButProcessing()
        {
            butAlterChange.Enabled = false;
            butAlterChange.Visible = false;
            butProcessingMatrix.Enabled = true;
            butProcessingMatrix.Visible = true;
        }
        public void ShowButAlterChange()
        {
            butAlterChange.Enabled = true;
            butAlterChange.Visible = true;
            butProcessingMatrix.Enabled = false;
            butProcessingMatrix.Visible = false;
        }
    }
}
