namespace WinFormInterface
{
    partial class modeSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butFinishedMatrix = new System.Windows.Forms.Button();
            this.butSelfAssessment = new System.Windows.Forms.Button();
            this.butAlterChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butFinishedMatrix
            // 
            this.butFinishedMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butFinishedMatrix.Location = new System.Drawing.Point(186, 276);
            this.butFinishedMatrix.Name = "butFinishedMatrix";
            this.butFinishedMatrix.Size = new System.Drawing.Size(422, 67);
            this.butFinishedMatrix.TabIndex = 1;
            this.butFinishedMatrix.Text = "Готовая матрица предпотчений";
            this.butFinishedMatrix.UseVisualStyleBackColor = true;
            // 
            // butSelfAssessment
            // 
            this.butSelfAssessment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butSelfAssessment.Location = new System.Drawing.Point(186, 159);
            this.butSelfAssessment.Name = "butSelfAssessment";
            this.butSelfAssessment.Size = new System.Drawing.Size(422, 67);
            this.butSelfAssessment.TabIndex = 2;
            this.butSelfAssessment.Text = "Самостоятельная оценка альтернатив";
            this.butSelfAssessment.UseVisualStyleBackColor = true;
            // 
            // butAlterChange
            // 
            this.butAlterChange.Location = new System.Drawing.Point(186, 73);
            this.butAlterChange.Name = "butAlterChange";
            this.butAlterChange.Size = new System.Drawing.Size(422, 23);
            this.butAlterChange.TabIndex = 3;
            this.butAlterChange.Text = "Изменить альтернативы";
            this.butAlterChange.UseVisualStyleBackColor = true;
            // 
            // modeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butAlterChange);
            this.Controls.Add(this.butSelfAssessment);
            this.Controls.Add(this.butFinishedMatrix);
            this.Name = "modeSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "modeSelectionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butFinishedMatrix;
        private System.Windows.Forms.Button butSelfAssessment;
        private System.Windows.Forms.Button butAlterChange;
    }
}