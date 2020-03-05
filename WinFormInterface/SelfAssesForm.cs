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
        void ShowForm();
    }
    public partial class SelfAssesForm : Form, ISelfAssesForm
    {
        public SelfAssesForm()
        {
            InitializeComponent();
            
        }



        public void ShowForm()
        {
            this.ShowDialog();
        }
    }
}
