namespace ProjectForm
{
    partial class EmployeeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvEmployees = new DataGridView();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblJobTitle = new Label();
            txtJobTitle = new TextBox();
            lblExtension = new Label();
            txtExtension = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblOfficeCode = new Label();
            cmbOfficeCode = new ComboBox();
            lblReportsTo = new Label();
            cmbReportsTo = new ComboBox();
            btnCreate = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();

            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(12, 12);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowTemplate.Height = 25;
            dgvEmployees.Size = new Size(776, 250);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellClick += dgvEmployees_CellClick;

            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(12, 280);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(73, 15);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name:";

            txtFirstName.Location = new Point(93, 277);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(200, 23);
            txtFirstName.TabIndex = 2;

            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(12, 310);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(72, 15);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Last Name:";

            txtLastName.Location = new Point(93, 307);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 23);
            txtLastName.TabIndex = 4;

            lblJobTitle.AutoSize = true;
            lblJobTitle.Location = new Point(12, 340);
            lblJobTitle.Name = "lblJobTitle";
            lblJobTitle.Size = new Size(64, 15);
            lblJobTitle.TabIndex = 5;
            lblJobTitle.Text = "Job Title:";

            txtJobTitle.Location = new Point(93, 337);
            txtJobTitle.Name = "txtJobTitle";
            txtJobTitle.Size = new Size(200, 23);
            txtJobTitle.TabIndex = 6;

            lblExtension.AutoSize = true;
            lblExtension.Location = new Point(12, 370);
            lblExtension.Name = "lblExtension";
            lblExtension.Size = new Size(70, 15);
            lblExtension.TabIndex = 7;
            lblExtension.Text = "Extension:";

            txtExtension.Location = new Point(93, 367);
            txtExtension.Name = "txtExtension";
            txtExtension.Size = new Size(200, 23);
            txtExtension.TabIndex = 8;

            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 400);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 15);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email:";

            txtEmail.Location = new Point(93, 397);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 10;

            lblOfficeCode.AutoSize = true;
            lblOfficeCode.Location = new Point(400, 280);
            lblOfficeCode.Name = "lblOfficeCode";
            lblOfficeCode.Size = new Size(80, 15);
            lblOfficeCode.TabIndex = 11;
            lblOfficeCode.Text = "Office Code:";

            cmbOfficeCode.FormattingEnabled = true;
            cmbOfficeCode.Location = new Point(481, 277);
            cmbOfficeCode.Name = "cmbOfficeCode";
            cmbOfficeCode.Size = new Size(200, 23);
            cmbOfficeCode.TabIndex = 12;

            lblReportsTo.AutoSize = true;
            lblReportsTo.Location = new Point(400, 310);
            lblReportsTo.Name = "lblReportsTo";
            lblReportsTo.Size = new Size(73, 15);
            lblReportsTo.TabIndex = 13;
            lblReportsTo.Text = "Reports To:";

            cmbReportsTo.FormattingEnabled = true;
            cmbReportsTo.Location = new Point(481, 307);
            cmbReportsTo.Name = "cmbReportsTo";
            cmbReportsTo.Size = new Size(200, 23);
            cmbReportsTo.TabIndex = 14;

            btnCreate.Location = new Point(12, 440);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 15;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;

            btnAdd.Location = new Point(93, 440);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            btnUpdate.Location = new Point(174, 440);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Location = new Point(255, 440);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            btnClear.Location = new Point(336, 440);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 19;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 490);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnCreate);
            Controls.Add(cmbReportsTo);
            Controls.Add(lblReportsTo);
            Controls.Add(cmbOfficeCode);
            Controls.Add(lblOfficeCode);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtExtension);
            Controls.Add(lblExtension);
            Controls.Add(txtJobTitle);
            Controls.Add(lblJobTitle);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(dgvEmployees);
            Name = "EmployeeForm";
            Text = "Employee Management";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvEmployees;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblJobTitle;
        private TextBox txtJobTitle;
        private Label lblExtension;
        private TextBox txtExtension;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblOfficeCode;
        private ComboBox cmbOfficeCode;
        private Label lblReportsTo;
        private ComboBox cmbReportsTo;
        private Button btnCreate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
    }
}
