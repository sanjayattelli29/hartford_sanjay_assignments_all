namespace Day_4_Win_form_app
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblFatherName;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblPreference;

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ComboBox cmbPreference;
        private System.Windows.Forms.Button btnSubmit;

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
            lblFirstName = new Label();
            lblFatherName = new Label();
            lblDOB = new Label();
            lblPreference = new Label();

            txtFirstName = new TextBox();
            txtFatherName = new TextBox();
            dtpDOB = new DateTimePicker();
            cmbPreference = new ComboBox();
            btnSubmit = new Button();

            SuspendLayout();

            // Title
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(140, 20);
            lblTitle.Text = "Person Details";

            // First Name Label
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(50, 70);
            lblFirstName.Text = "Person Name";

            // First Name TextBox
            txtFirstName.Location = new Point(180, 67);
            txtFirstName.Size = new Size(200, 27);

            // Father Name Label
            lblFatherName.AutoSize = true;
            lblFatherName.Location = new Point(50, 110);
            lblFatherName.Text = "Father's Name";

            // Father Name TextBox
            txtFatherName.Location = new Point(180, 107);
            txtFatherName.Size = new Size(200, 27);

            // DOB Label
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(50, 150);
            lblDOB.Text = "Date Of Birth";

            // DateTimePicker
            dtpDOB.Location = new Point(180, 147);
            dtpDOB.Size = new Size(200, 27);

            // Preference Label
            lblPreference.AutoSize = true;
            lblPreference.Location = new Point(50, 190);
            lblPreference.Text = "Preferences";

            // ComboBox
            cmbPreference.Location = new Point(180, 187);
            cmbPreference.Size = new Size(200, 28);
            cmbPreference.Items.AddRange(new object[]
            {
                "Investments",
                "Technology",
                "Sports",
                "Music",
                "Travel"
            });

            // Submit Button
            btnSubmit.Location = new Point(220, 235);
            btnSubmit.Size = new Size(94, 30);
            btnSubmit.Text = "Submit";

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 300);
            Controls.Add(lblTitle);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFatherName);
            Controls.Add(txtFatherName);
            Controls.Add(lblDOB);
            Controls.Add(dtpDOB);
            Controls.Add(lblPreference);
            Controls.Add(cmbPreference);
            Controls.Add(btnSubmit);
            Text = "Person Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
