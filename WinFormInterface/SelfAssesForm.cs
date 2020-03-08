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
        void HideForm();
        event EventHandler ChoiceClick;
        float ButValue { get; }
    }
    public partial class SelfAssesForm : Form, ISelfAssesForm
    {
        float button = -1;
        public SelfAssesForm()
        {
            InitializeComponent();
            butChoice1.Click += ButChoice_Click;
            butChoice2.Click += ButChoice_Click;
            butChoice3.Click += ButChoice_Click;
        }

        private void ButChoice_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name[9])
            {
                case '1': 
                    button = 1;
                    break;
                case '2':
                    button = 0;
                    break;
                case '3':
                    button = 0.5f;
                    break;
                default:
                    button = -1;
                    break;
            }
            //button = (int)(sender as Button).Name[9] - 48;
            ChoiceClick(this, null);
        }

        public string Alternative1 
        { 
            set { butChoice1.Text = value; }
        }
        public string Alternative2
        {
            set { butChoice2.Text = value; }
        }
        public float ButValue
        {
            get { return button; }
        }
        public void ShowForm()
        {
            this.ShowDialog();
        }
        public void HideForm()
        {
            this.Hide();
        }
        public event EventHandler ChoiceClick;
    }
}
