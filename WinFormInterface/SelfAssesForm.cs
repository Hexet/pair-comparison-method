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
    public interface ISelfAssesForm
    {
        string Alternative1 { set; }
        string Alternative2 { set; }
        void ShowForm();
    }
    public partial class SelfAssesForm : Form, ISelfAssesForm
    {
        public SelfAssesForm()
        {
            InitializeComponent();
            
        }

        public string Alternative1 
        { 
            set { butChoice1.Text = value; }
        }
        public string Alternative2
        {
            set { butChoice2.Text = value; }
        }

        public void ShowForm()
        {
            this.ShowDialog();
        }
    }
}
