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

            // Title
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Location = new Point(110, 20);
            lblTitle.Text = "Get Age of a Person";

            // DOB Label
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(60, 80);
            lblDOB.Text = "Enter DOB";

            // DateTimePicker
            dtpDOB.Location = new Point(160, 77);
            dtpDOB.Size = new Size(200, 27);

            // Age Label
            lblAge.AutoSize = true;
            lblAge.Location = new Point(60, 130);
            lblAge.Text = "Your Age";

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 200);
            Controls.Add(lblTitle);
            Controls.Add(lblDOB);
            Controls.Add(dtpDOB);
            Controls.Add(lblAge);
            Text = "Get Age of a Person";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
