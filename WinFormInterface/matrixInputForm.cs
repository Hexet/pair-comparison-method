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
    public interface ImatrixInputForm
    {
        string FilePath { get; }
        string Content { get; set; }
        event EventHandler FileOpenClick;
        void ShowForm();

    }
    public partial class matrixInputForm : Form, ImatrixInputForm
    {
        public matrixInputForm()
        {
            InitializeComponent();
            butOpenFile.Click += ButOpenFile_Click;
            butSelectFile.Click += ButSelectFile_Click;
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
        public void ShowForm()
        {
            this.ShowDialog();
        }
    }
}
