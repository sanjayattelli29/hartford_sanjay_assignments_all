namespace Day_4_Win_form_app
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.DateTimePicker dtpDOB;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblDOB = new Label();
            lblAge = new Label();
            dtpDOB = new DateTimePicker();

            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Location = new Point(120, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 25);
            lblTitle.Text = "Get Age of a Person";

            // lblDOB
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(60, 80);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(76, 20);
            lblDOB.Text = "Enter DOB";

            // dtpDOB
            dtpDOB.Location = new Point(160, 77);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(200, 27);

            // lblAge
            lblAge.AutoSize = true;
            lblAge.Location = new Point(60, 130);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(66, 20);
            lblAge.Text = "Your Age";

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 200);
            Controls.Add(lblTitle);
            Controls.Add(lblDOB);
            Controls.Add(dtpDOB);
            Controls.Add(lblAge);
            Name = "Form1";
            Text = "Get Age of a Person";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
