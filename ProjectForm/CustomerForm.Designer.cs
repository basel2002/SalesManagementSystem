namespace ProjectForm
{
    partial class CustomerForm
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
            dgvCustomers = new DataGridView();
            lblName = new Label();
            txtName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblCity = new Label();
            txtCity = new TextBox();
            lblState = new Label();
            txtState = new TextBox();
            lblPostalCode = new Label();
            txtPostalCode = new TextBox();
            lblCountry = new Label();
            txtCountry = new TextBox();
            lblCreditLimit = new Label();
            txtCreditLimit = new TextBox();
            lblSalesEmployee = new Label();
            cmbSalesEmployee = new ComboBox();
            btnCreate = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();

            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(12, 12);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowTemplate.Height = 25;
            dgvCustomers.Size = new Size(776, 250);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellClick += dgvCustomers_CellClick;

            lblName.AutoSize = true;
            lblName.Location = new Point(12, 280);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";

            txtName.Location = new Point(93, 277);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 2;

            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(12, 310);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(73, 15);
            lblFirstName.TabIndex = 3;
            lblFirstName.Text = "First Name:";

            txtFirstName.Location = new Point(93, 307);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(200, 23);
            txtFirstName.TabIndex = 4;

            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(12, 340);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(72, 15);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "Last Name:";

            txtLastName.Location = new Point(93, 337);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 23);
            txtLastName.TabIndex = 6;

            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(400, 280);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(52, 15);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Phone:";

            txtPhone.Location = new Point(481, 277);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 23);
            txtPhone.TabIndex = 8;

            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(400, 310);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(61, 15);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Address:";

            txtAddress.Location = new Point(481, 307);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 23);
            txtAddress.TabIndex = 10;

            lblCity.AutoSize = true;
            lblCity.Location = new Point(400, 340);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(34, 15);
            lblCity.TabIndex = 11;
            lblCity.Text = "City:";

            txtCity.Location = new Point(481, 337);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(200, 23);
            txtCity.TabIndex = 12;

            lblState.AutoSize = true;
            lblState.Location = new Point(12, 370);
            lblState.Name = "lblState";
            lblState.Size = new Size(41, 15);
            lblState.TabIndex = 13;
            lblState.Text = "State:";

            txtState.Location = new Point(93, 367);
            txtState.Name = "txtState";
            txtState.Size = new Size(200, 23);
            txtState.TabIndex = 14;

            lblPostalCode.AutoSize = true;
            lblPostalCode.Location = new Point(400, 370);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(80, 15);
            lblPostalCode.TabIndex = 15;
            lblPostalCode.Text = "Postal Code:";

            txtPostalCode.Location = new Point(481, 367);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(200, 23);
            txtPostalCode.TabIndex = 16;

            lblCountry.AutoSize = true;
            lblCountry.Location = new Point(12, 400);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(58, 15);
            lblCountry.TabIndex = 17;
            lblCountry.Text = "Country:";

            txtCountry.Location = new Point(93, 397);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(200, 23);
            txtCountry.TabIndex = 18;

            lblCreditLimit.AutoSize = true;
            lblCreditLimit.Location = new Point(400, 400);
            lblCreditLimit.Name = "lblCreditLimit";
            lblCreditLimit.Size = new Size(79, 15);
            lblCreditLimit.TabIndex = 19;
            lblCreditLimit.Text = "Credit Limit:";

            txtCreditLimit.Location = new Point(481, 397);
            txtCreditLimit.Name = "txtCreditLimit";
            txtCreditLimit.Size = new Size(200, 23);
            txtCreditLimit.TabIndex = 20;

            lblSalesEmployee.AutoSize = true;
            lblSalesEmployee.Location = new Point(12, 430);
            lblSalesEmployee.Name = "lblSalesEmployee";
            lblSalesEmployee.Size = new Size(88, 15);
            lblSalesEmployee.TabIndex = 21;
            lblSalesEmployee.Text = "Sales Employee:";

            cmbSalesEmployee.FormattingEnabled = true;
            cmbSalesEmployee.Location = new Point(93, 427);
            cmbSalesEmployee.Name = "cmbSalesEmployee";
            cmbSalesEmployee.Size = new Size(200, 23);
            cmbSalesEmployee.TabIndex = 22;

            btnCreate.Location = new Point(12, 470);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 23;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;

            btnAdd.Location = new Point(93, 470);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            btnUpdate.Location = new Point(174, 470);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 25;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Location = new Point(255, 470);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            btnClear.Location = new Point(336, 470);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 27;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnCreate);
            Controls.Add(cmbSalesEmployee);
            Controls.Add(lblSalesEmployee);
            Controls.Add(txtCreditLimit);
            Controls.Add(lblCreditLimit);
            Controls.Add(txtCountry);
            Controls.Add(lblCountry);
            Controls.Add(txtPostalCode);
            Controls.Add(lblPostalCode);
            Controls.Add(txtState);
            Controls.Add(lblState);
            Controls.Add(txtCity);
            Controls.Add(lblCity);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(dgvCustomers);
            Name = "CustomerForm";
            Text = "Customer Management";
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvCustomers;
        private Label lblName;
        private TextBox txtName;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblCity;
        private TextBox txtCity;
        private Label lblState;
        private TextBox txtState;
        private Label lblPostalCode;
        private TextBox txtPostalCode;
        private Label lblCountry;
        private TextBox txtCountry;
        private Label lblCreditLimit;
        private TextBox txtCreditLimit;
        private Label lblSalesEmployee;
        private ComboBox cmbSalesEmployee;
        private Button btnCreate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
    }
}
