namespace WinFormInterface
{
    partial class SelfAssesForm
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
            this.butChoice1 = new System.Windows.Forms.Button();
            this.butChoice2 = new System.Windows.Forms.Button();
            this.butChoice3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butChoice1
            // 
            this.butChoice1.Location = new System.Drawing.Point(114, 78);
            this.butChoice1.Name = "butChoice1";
            this.butChoice1.Size = new System.Drawing.Size(578, 56);
            this.butChoice1.TabIndex = 0;
            this.butChoice1.Text = "button1";
            this.butChoice1.UseVisualStyleBackColor = true;
            // 
            // butChoice2
            // 
            this.butChoice2.Location = new System.Drawing.Point(114, 188);
            this.butChoice2.Name = "butChoice2";
            this.butChoice2.Size = new System.Drawing.Size(578, 56);
            this.butChoice2.TabIndex = 1;
            this.butChoice2.Text = "button2";
            this.butChoice2.UseVisualStyleBackColor = true;
            // 
            // butChoice3
            // 
            this.butChoice3.Location = new System.Drawing.Point(114, 297);
            this.butChoice3.Name = "butChoice3";
            this.butChoice3.Size = new System.Drawing.Size(578, 56);
            this.butChoice3.TabIndex = 2;
            this.butChoice3.Text = "Одинаково предпочтительно";
            this.butChoice3.UseVisualStyleBackColor = true;
            // 
            // SelfAssesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butChoice3);
            this.Controls.Add(this.butChoice2);
            this.Controls.Add(this.butChoice1);
            this.Name = "SelfAssesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelfAssesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butChoice1;
        private System.Windows.Forms.Button butChoice2;
        private System.Windows.Forms.Button butChoice3;
    }
}