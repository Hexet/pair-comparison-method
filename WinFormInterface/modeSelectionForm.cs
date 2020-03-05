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
    public interface ImodeSelectionForm
    {
        event EventHandler SelfAssesClick;
        event EventHandler FinishMatrixClick;
    }
    public partial class modeSelectionForm : Form, ImodeSelectionForm
    {
        public modeSelectionForm()
        {
            InitializeComponent();
            butFinishedMatrix.Click += ButFinishedMatrix_Click;
            butSelfAssessment.Click += ButSelfAssessment_Click;
        }

        private void ButSelfAssessment_Click(object sender, EventArgs e)
        {
            SelfAssesClick(this, null);
        }

        private void ButFinishedMatrix_Click(object sender, EventArgs e)
        {
            FinishMatrixClick(this, null);
        }

        public event EventHandler SelfAssesClick;
        public event EventHandler FinishMatrixClick;

    }
}
