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
    public interface IResultForm
    {
        void ShowForm();
        void PrintResult(int[] orderedIndexAlternatives, string[] alternatives);
    }
    public partial class ResultForm : Form, IResultForm
    {
        public ResultForm()
        {
            InitializeComponent();

        }

        public void PrintResult(int[] orderedIndexAlternatives, string[] alternatives)
        {
            ResultBox.Text = String.Empty;
            ResultBox.Text += "Полученный список альтернатив:" + Environment.NewLine;
            for (int i = 0; i < alternatives.Length; i++)
            {
                ResultBox.Text += alternatives[orderedIndexAlternatives[i]] + Environment.NewLine;
            }
        }

        public void ShowForm()
        {
            this.ShowDialog();
        }
    }
}
