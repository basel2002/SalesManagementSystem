namespace ProjectForm
{
    partial class OfficeForm
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
            dgvOffices = new DataGridView();
            lblCity = new Label();
            txtCity = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblPostalCode = new Label();
            txtPostalCode = new TextBox();
            lblState = new Label();
            txtState = new TextBox();
            lblCountry = new Label();
            txtCountry = new TextBox();
            lblTerritory = new Label();
            txtTerritory = new TextBox();
            btnCreate = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOffices).BeginInit();
            SuspendLayout();

            dgvOffices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOffices.Location = new Point(12, 12);
            dgvOffices.Name = "dgvOffices";
            dgvOffices.RowTemplate.Height = 25;
            dgvOffices.Size = new Size(776, 250);
            dgvOffices.TabIndex = 0;
            dgvOffices.CellClick += dgvOffices_CellClick;

            lblCity.AutoSize = true;
            lblCity.Location = new Point(12, 280);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(34, 15);
            lblCity.TabIndex = 1;
            lblCity.Text = "City:";

            txtCity.Location = new Point(93, 277);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(200, 23);
            txtCity.TabIndex = 2;

            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(12, 310);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(52, 15);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Phone:";

            txtPhone.Location = new Point(93, 307);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 23);
            txtPhone.TabIndex = 4;

            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(12, 340);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(61, 15);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Address:";

            txtAddress.Location = new Point(93, 337);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 23);
            txtAddress.TabIndex = 6;

            lblPostalCode.AutoSize = true;
            lblPostalCode.Location = new Point(12, 370);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(80, 15);
            lblPostalCode.TabIndex = 7;
            lblPostalCode.Text = "Postal Code:";

            txtPostalCode.Location = new Point(93, 367);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(200, 23);
            txtPostalCode.TabIndex = 8;

            lblState.AutoSize = true;
            lblState.Location = new Point(400, 280);
            lblState.Name = "lblState";
            lblState.Size = new Size(41, 15);
            lblState.TabIndex = 9;
            lblState.Text = "State:";

            txtState.Location = new Point(481, 277);
            txtState.Name = "txtState";
            txtState.Size = new Size(200, 23);
            txtState.TabIndex = 10;

            lblCountry.AutoSize = true;
            lblCountry.Location = new Point(400, 310);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(58, 15);
            lblCountry.TabIndex = 11;
            lblCountry.Text = "Country:";

            txtCountry.Location = new Point(481, 307);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(200, 23);
            txtCountry.TabIndex = 12;

            lblTerritory.AutoSize = true;
            lblTerritory.Location = new Point(400, 340);
            lblTerritory.Name = "lblTerritory";
            lblTerritory.Size = new Size(59, 15);
            lblTerritory.TabIndex = 13;
            lblTerritory.Text = "Territory:";

            txtTerritory.Location = new Point(481, 337);
            txtTerritory.Name = "txtTerritory";
            txtTerritory.Size = new Size(200, 23);
            txtTerritory.TabIndex = 14;

            btnCreate.Location = new Point(12, 410);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 15;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;

            btnAdd.Location = new Point(93, 410);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            btnUpdate.Location = new Point(174, 410);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Location = new Point(255, 410);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            btnClear.Location = new Point(336, 410);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 19;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 460);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnCreate);
            Controls.Add(txtTerritory);
            Controls.Add(lblTerritory);
            Controls.Add(txtCountry);
            Controls.Add(lblCountry);
            Controls.Add(txtState);
            Controls.Add(lblState);
            Controls.Add(txtPostalCode);
            Controls.Add(lblPostalCode);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtCity);
            Controls.Add(lblCity);
            Controls.Add(dgvOffices);
            Name = "OfficeForm";
            Text = "Office Management";
            ((System.ComponentModel.ISupportInitialize)dgvOffices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvOffices;
        private Label lblCity;
        private TextBox txtCity;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblPostalCode;
        private TextBox txtPostalCode;
        private Label lblState;
        private TextBox txtState;
        private Label lblCountry;
        private TextBox txtCountry;
        private Label lblTerritory;
        private TextBox txtTerritory;
        private Button btnCreate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
    }
}
