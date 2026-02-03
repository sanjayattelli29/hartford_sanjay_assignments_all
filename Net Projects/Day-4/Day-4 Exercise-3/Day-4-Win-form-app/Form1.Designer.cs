namespace Day_4_Win_form_app
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.CheckBox chkPostal;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.ListView listViewCountry;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemoveCountry;
        private System.Windows.Forms.Button btnRemoveState;
        private System.Windows.Forms.Button btnShowDetails;

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
            lblCountry = new Label();
            lblState = new Label();
            txtCountry = new TextBox();
            txtState = new TextBox();
            chkPostal = new CheckBox();
            chkEmail = new CheckBox();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();
            listViewCountry = new ListView();
            comboBox1 = new ComboBox();
            btnAdd = new Button();
            btnRemoveCountry = new Button();
            btnRemoveState = new Button();
            btnShowDetails = new Button();

            SuspendLayout();

            lblCountry.Location = new Point(40, 40);
            lblCountry.Size = new Size(60, 20);
            lblCountry.Text = "Country";

            txtCountry.Location = new Point(120, 37);
            txtCountry.Size = new Size(220, 27);

            lblState.Location = new Point(40, 85);
            lblState.Size = new Size(60, 20);
            lblState.Text = "State";

            txtState.Location = new Point(120, 82);
            txtState.Size = new Size(220, 27);

            chkPostal.Location = new Point(40, 130);
            chkPostal.Text = "Postal Mail";

            chkEmail.Location = new Point(40, 160);
            chkEmail.Text = "E-Mail";

            rdoMale.Location = new Point(200, 130);
            rdoMale.Text = "Male";

            rdoFemale.Location = new Point(200, 160);
            rdoFemale.Text = "Female";

            listViewCountry.Location = new Point(380, 37);
            listViewCountry.Size = new Size(200, 150);
            listViewCountry.CheckBoxes = true;
            listViewCountry.View = View.Details;
            listViewCountry.Columns.Add("Country", 150);

            comboBox1.Location = new Point(380, 200);
            comboBox1.Size = new Size(200, 28);

            btnAdd.Location = new Point(40, 220);
            btnAdd.Size = new Size(90, 30);
            btnAdd.Text = "Add";

            btnRemoveCountry.Location = new Point(140, 220);
            btnRemoveCountry.Size = new Size(130, 30);
            btnRemoveCountry.Text = "Remove Country";

            btnRemoveState.Location = new Point(280, 220);
            btnRemoveState.Size = new Size(120, 30);
            btnRemoveState.Text = "Remove State";

            btnShowDetails.Location = new Point(410, 220);
            btnShowDetails.Size = new Size(120, 30);
            btnShowDetails.Text = "Show Details";

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 280);
            Controls.Add(lblCountry);
            Controls.Add(txtCountry);
            Controls.Add(lblState);
            Controls.Add(txtState);
            Controls.Add(chkPostal);
            Controls.Add(chkEmail);
            Controls.Add(rdoMale);
            Controls.Add(rdoFemale);
            Controls.Add(listViewCountry);
            Controls.Add(comboBox1);
            Controls.Add(btnAdd);
            Controls.Add(btnRemoveCountry);
            Controls.Add(btnRemoveState);
            Controls.Add(btnShowDetails);
            Text = "Country Info";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
